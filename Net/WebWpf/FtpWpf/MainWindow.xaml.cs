using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FtpWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<FtpFileSystemInfo> fileSystemInfo = new ObservableCollection<FtpFileSystemInfo>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<FtpFileSystemInfo> FileSystemInfo => fileSystemInfo;
        public FtpFileSystemInfo CurrentItem { get; set; }
        private async void btnGetList_Click(object sender, RoutedEventArgs e)
        {
            var request = (FtpWebRequest)WebRequest.Create(txtAddress.Text);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(txtUser.Text, txtPassword.Text);
            var response = (FtpWebResponse)(await request.GetResponseAsync());
            string result = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                result = await reader.ReadToEndAsync();
            }
            response.Close();
            var directory = result.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            fileSystemInfo.Clear();
            foreach (var item in directory)
            {
                fileSystemInfo.Add(new FtpFileSystemInfo(item));
            }

        }
        private async void BtnDownloadFile_Click(object sender, RoutedEventArgs e)
        {
            //ftp://speedtest.tele2.net/filename
            //ftp://speedtest.tele2.net/

            if (CurrentItem == null) {
                return;
            }

            var request = (FtpWebRequest)WebRequest.Create(txtAddress.Text + CurrentItem.Name);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            var response = (FtpWebResponse)(await request.GetResponseAsync());
            Stream reader = response.GetResponseStream();
            FileStream writer = new FileStream(CurrentItem.Name,FileMode.Create, FileAccess.Write );
            byte[] buffer = new byte[1024];
            int readed = 0;
            do
            {
                readed = await reader.ReadAsync(buffer, 0, buffer.Length);
                if (readed != 0)
                {
                    await writer.WriteAsync(buffer, 0, readed);
                }
            }
            while (readed != 0);
            writer.Close();
            response.Close();
        }
    }
}
