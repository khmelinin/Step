using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Study_ado.ViewModels
{
    class StudentEditorViewModel : BaseViewModel
    {
        private bool closeDialog = false;
        private string name;
        private string surname;
        private bool? sex;
        private DateTime? birthday;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(
                    () =>
                    {
                        DialogResult = true;
                        CloseDialog = true;
                    },
                    (o) => { return true; }
                    ));
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(
                    () =>
                    {
                        DialogResult = false;
                        CloseDialog = true;
                    }));
            }
        }
        public bool DialogResult { get; set; }

        public bool CloseDialog
        {
            get => closeDialog;
            set
            {
                if (closeDialog != value)
                {
                    closeDialog = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool? Sex
        {
            get { return sex; }
            set
            {
                if (sex != value)
                {
                    sex = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                if (birthday != value)
                {
                    birthday = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
