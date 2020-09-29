using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strudy_ado_2.Models;

namespace Strudy_ado_2.ViewModels
{
    class MainViewModel
    {
        StudyDataClassesDataContext dataContext = new StudyDataClassesDataContext();
        ObservableCollection<Student> students;

        public MainViewModel()
        {
            students = new ObservableCollection<Student>(dataContext.Students);
            students.CollectionChanged += Students_CollectionChanged;
        }

        private void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Student item in e.NewItems)
                {
                    dataContext.Students.InsertOnSubmit(item);
                }
            }
        }

        public ObservableCollection<Student> Students => students;
    }
}
