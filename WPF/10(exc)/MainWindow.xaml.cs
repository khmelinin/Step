using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

namespace _10_exc_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class User
    {
        string nick;
        string password;
        string name;
        string sname;

        public User(string nick, string password, string name, string sname)
        {
            this.nick = nick;
            this.password = password;
            this.name = name;
            this.sname = sname;
        }

        public string Nick { get => nick; set => nick = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Sname { get => sname; set => sname = value; }
    }
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<users.Count;i++)
            {
                if (users[i].Nick == nicknameTB.Text && users[i].Password!=passwordTB.Text)
                {
                    MessageBox.Show("incorrect password");
                    nicknameTB.Text = "";
                    passwordTB.Text = "";
                    break;
                }
            }
            if(nicknameTB.Text != "" && passwordTB.Text != "")
            {
                users.Add(new User(nicknameTB.Text, passwordTB.Text, nameTB.Text, snameTB.Text));
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("There is some empty space");
            }
        }
    }
}
