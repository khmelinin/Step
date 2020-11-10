using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerWPF.ViewModels
{
    class MainViewModel : BindableBase
    {
        DelegateCommand startCommand;
        DelegateCommand stopCommand;
        int port;
        IPAddress ipAddress;
        public MainViewModel()
        {
            
        }
        public int Port
        {
            get => port;
            set
            {
                SetProperty(ref port, value);
            }
        }
        public IPAddress IPAddress
        {
            get => ipAddress;
            set
            {
                SetProperty(ref ipAddress, value);
            }
        }
    }
}
