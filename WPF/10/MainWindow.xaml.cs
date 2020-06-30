using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// !
using Microsoft.Win32;
using System.IO;
using System.Windows.Documents;
// !

namespace _10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog file_s = new SaveFileDialog();
            file_s.Filter = "Text Files (*.txt)|*.txt|XAML File (*.xaml)|*.xaml|CS File (*.cs)|*.cs|All Files (*.*)|*.*|";
            if(file_s.ShowDialog() == true)
            {
                TextRange obj_d = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);
                using (FileStream fs=File.Create(file_s.FileName))
                {
                    if (System.IO.Path.GetExtension(file_s.FileName).ToLower() == ".txt")
                        obj_d.Save(fs, DataFormats.Text);
                    else
                        obj_d.Save(fs, DataFormats.Xaml);
                }
            }
        }
        private void Download(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|XAML File (*.xaml)|*.xaml|CS File (*.cs)|*.cs|All Files (*.*)|*.*|";
            if (ofd.ShowDialog() == true)
            {
                TextRange obj_d = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        obj_d.Load(fs, DataFormats.Text);
                    else 
                        obj_d.Load(fs, DataFormats.Xaml);
                }
            }
        }
    }
}
