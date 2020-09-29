using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_ado.ViewModels
{
    internal class StudentViewModel : BaseViewModel
    {
        private int studentId;
        private string name;
        private string surname;
        private bool? sex;
        private DateTime? birthday;

        public int StudentID
        {
            get { return studentId; }
            set { studentId = value; }
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
