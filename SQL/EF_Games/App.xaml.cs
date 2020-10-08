using EF_Games.ViewModels;
using EF_Games.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Games
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainView = new MainView()
            {
                DataContext = new MainViewModel(new PlatformsViewModel())
            };

            MainWindow = mainView;
            MainWindow.Show();
        }
    }
}
