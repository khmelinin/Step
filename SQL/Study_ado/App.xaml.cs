using Study_ado.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Study_ado
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var v = new MainWindow();
            var vm = new MainViewModel();
            v.DataContext = vm;
            MainWindow = v;
            v.Show();
        }
    }
}
