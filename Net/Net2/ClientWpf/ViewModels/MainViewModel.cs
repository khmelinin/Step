using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientWpf.ViewModels
{
    class MainViewModel:BindableBase
    {
        private IPAddress serverAddress;
        private int serverPort;
        private IPAddress clientAddress;
        private int clientPort;
        private string userName;
        private string message;
        private ObservableCollection<string> history;
        private ICommand connectCommand;
        private ICommand disconnectCommand;
        private ICommand sendCommand;
        private List<IPAddress> addresses;

        public MainViewModel()
        {

        }

        public IPAddress ServerAddress { get => serverAddress; set => SetProperty(ref serverAddress, value); }
        public int ServerPort { get => serverPort; set => SetProperty(ref serverPort, value); }
        public IPAddress ClientAddress { get => clientAddress; set => SetProperty(ref clientAddress, value); }
        public int ClientPort { get => clientPort; set => SetProperty(ref clientPort, value); }
        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        public string Message { get => message; set => SetProperty(ref message, value); }
        public ObservableCollection<string> History { get => history; }
        public ICommand ConnectCommand { get => connectCommand; }
        public ICommand DisconnectCommand { get => disconnectCommand; }
        public ICommand SendCommand { get => sendCommand; }
        public List<IPAddress> Addresses { get => addresses; }
    }
}
