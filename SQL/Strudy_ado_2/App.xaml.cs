﻿using Strudy_ado_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Strudy_ado_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var vm = new MainViewModel();
            var v = new MainWindow() { DataContext = vm };
            MainWindow = v;
            v.Show();
        }
    }
}
