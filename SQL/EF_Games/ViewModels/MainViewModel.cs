using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Games.ViewModels
{
    class MainViewModel : BindableBase, IMainViewModel
    {
        private IPlatformsViewModel platforms;

        public MainViewModel(IPlatformsViewModel p)
        {
            platforms = p;
        }

        public IPlatformsViewModel Platforms => platforms;
    }
}
