using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace P1.ViewModels
{
    class MainViewModel:BindableBase
    {
        private ObservableCollection<ProcessViewModel> processes;
        private ProcessViewModel currentItem;
        private ICommand refreshCommand;
        private ICommand createCommand;

        public MainViewModel()
        {
            processes = new ObservableCollection<ProcessViewModel>(from p in Process.GetProcesses() select new ProcessViewModel(p));
            refreshCommand = new DelegateCommand(() => { });
            createCommand = new DelegateCommand(() =>
            {
                string filename = string.Empty;
                var dlg = new OpenFileDialog();
                dlg.Filter = "Applications (.exe)|*.exe|";
                if (dlg.ShowDialog() == true)
                {
                    filename = dlg.FileName;
                    Process.Start(filename);
                }
            });
        }

        public ObservableCollection<ProcessViewModel> Processes
        {
            get => this.processes;
        }

        public ICommand RefreshCommand
        {
            get => this.refreshCommand;
        }

    }
}
