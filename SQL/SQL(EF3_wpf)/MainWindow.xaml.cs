using System;
using System.Collections.Generic;
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

namespace SQL_EF3_wpf_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Student> _students;
        private List<Group> _groups;
        public MainWindow()
        {
            
            InitializeComponent();
            using (var db = new schoolEntities())
            {
                _students = db.Students.Local.ToList();
                _groups = db.Groups.Local.ToList();
            }
            gridStudents.ItemsSource = _students;
            gridGroups.ItemsSource = _groups;
        }
    }
}
