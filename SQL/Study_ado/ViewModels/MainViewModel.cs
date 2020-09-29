using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Study_ado.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private DataService dataService = new DataService();
        private ICommand loadDataCommand;
        private ICommand saveDataCommand;
        private ObservableCollection<StudentViewModel> students;
        private StudentViewModel currentStudent;
        private ICommand deleteStudentCommand;
        private ICommand newStudentCommand;

        public MainViewModel()
        {

        }

        public ICommand LoadDataCommand
        {
            get
            {
                return loadDataCommand ?? (loadDataCommand = new RelayCommand(
                    () => {
                        dataService.LoadData();
                        Students = new ObservableCollection<StudentViewModel>(dataService.GetStudents());
                    }
                    ));
            }
        }

        public ICommand SaveDataCommand
        {
            get
            {
                return saveDataCommand ?? (saveDataCommand = new RelayCommand(
                    () => { dataService.UpdateData(); }
                    ));
            }
        }

        public ObservableCollection<StudentViewModel> Students
        {
            get { return students;}
            private set
            {
                if (students != value)
                {
                    students = value;
                    RaisePropertyChanged();
                }
            }
        }

        public StudentViewModel CurrentStudent
        {
            get { return currentStudent; }
            set
            {
                if (currentStudent != value)
                {
                    currentStudent = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand DeleteStudentCommand
        {
            get
            {
                return deleteStudentCommand ?? (deleteStudentCommand = new RelayCommand(
                    () => {
                        dataService.DeleteStudent(currentStudent);
                        students.Remove(currentStudent);
                    },
                    (o) => { return currentStudent != null; }
                    ));
            }
        }

        public ICommand NewStudentCommand
        {
            get
            {
                return newStudentCommand ?? (newStudentCommand = new RelayCommand(
                    () => {
                        var vm = new StudentEditorViewModel();
                        var dialogFactory = ...
                        if (dialogFactory.ShowStudentEditorDialog(vm))
                        {
                            var st
                        }
                    }
                    ));

            }
        }
    }
}
