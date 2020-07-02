using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace _12_vvmm_
{
    public class House : INotifyPropertyChanged
    {
        private string type;
        private string country;
        private int area;

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }
        public int Area
        {
            get { return area; }
            set
            {
                area = value;
                OnPropertyChanged("Area");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private House selectedHouse;

        public ObservableCollection<House> House { get; set; }

        private RCommand addCommand;
        public RCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RCommand(obj =>
                  {
                      House house = new House();
                      House.Insert(0, house);
                      SelectedHouse = house;
                  }));
            }
        }

        private RCommand removeCommand;
        public RCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RCommand(obj =>
                  {
                      House house = obj as House;
                      if (house != null)
                      {
                          House.Remove(house);
                      }
                  },
                 (obj) => House.Count > 0));
            }
        }
        public House SelectedHouse
        {
            get { return selectedHouse; }
            set
            {
                selectedHouse = value;
                OnPropertyChanged("SelectedHouse");
            }
        }



        public ViewModel()
        {
            House = new ObservableCollection<House>
            {
                new House { Type="outside", Country="UK", Area=56000 },
                new House {Type="enter", Country="UA", Area =60000 },
                new House {Type="somewhere", Country="UB", Area=56000 },
                new House {Type="cool", Country="UC", Area=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class HouseViewModel : INotifyPropertyChanged
    {
        private House house;

        public HouseViewModel(House p)
        {
            house = p;
        }

        public string Type
        {
            get { return house.Type; }
            set
            {
                house.Type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Country
        {
            get { return house.Country; }
            set
            {
                house.Country = value;
                OnPropertyChanged("Country");
            }
        }
        public int Area
        {
            get { return house.Area; }
            set
            {
                house.Area = value;
                OnPropertyChanged("Area");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class RCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}