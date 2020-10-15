using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Processors3_WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Semaphore semaphore;

        bool typeEvent = false;
        //AutoResetEvent @event;
        ManualResetEvent @event;
        ManualResetEvent @exitEvent;
        public MainWindow()
        {
            InitializeComponent();
            //@event = new AutoResetEvent(false);
            //@event = new ManualResetEvent(false);
            exitEvent = new ManualResetEvent(false);
            semaphore = new Semaphore(0, 2);
        }

        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            //if (typeEvent)
            //{
            //    @event = new AutoResetEvent(false);
            //}
            //else
            //{
            //    @event = new ManualResetEvent(false);
            //}

            //@event.Reset();
            exitEvent.Reset();
        }

        private void btnStartThreads_Click(object sender, RoutedEventArgs e)
        {
            var pbs = new ProgressBar[] { First, Second, Third, Fourth, Fifth };
            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread((p) => {
                    semaphore.WaitOne();
                    //@event.WaitOne();
                    Random rnd = new Random();
                    var pb = p as ProgressBar;
                    for (double j = 0; j < 100; j += 1) 
                    {
                        if (exitEvent.WaitOne(0))
                        {
                            break;
                        }

                        App.Current.Dispatcher.Invoke(() => { pb.Value = j; });
                        Thread.Sleep(rnd.Next(7, 90));
                    }

                    //@event.Set();
                    semaphore.Release();
                });
                threads[i].IsBackground = true;
            }
            for (int i = 0; i < 5; i++)
            {
                threads[i].Start(pbs[i]);
            }
            //@event.Set();
            semaphore.Release(2);
            
        }

        private void btnStopThreads_Click(object sender, RoutedEventArgs e)
        {
            exitEvent.Set();
        }
    }
}
