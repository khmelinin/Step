using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Processors5
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Semaphore s = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!Semaphore.TryOpenExisting(@"SemaphoreApp", System.Security.AccessControl.SemaphoreRights.FullControl, out Semaphore s))
            {
                s = new Semaphore(3, 3, @"SemaphoreApp");
            }

            bool signal = s.WaitOne(0);
            if (!signal)
            {
                MessageBox.Show("Many copies");
                s = null;
                Shutdown();
                return;
            }

            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            var s = Semaphore.OpenExisting(@"SemaphoreApp", System.Security.AccessControl.SemaphoreRights.Modify);
            if (s != null)
            {
                var c = s.Release();
                if (c == 2)
                {
                    s.Close();
                }

                s.Dispose();
            }

            base.OnExit(e);
        }
    }
}
