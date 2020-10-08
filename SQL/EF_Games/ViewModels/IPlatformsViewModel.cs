using System.Collections.ObjectModel;
using System.Windows.Input;
using EF_Games.Models;

namespace EF_Games.ViewModels
{
    interface IPlatformsViewModel
    {
        ObservableCollection<Platform> Platforms { get; }
    }
}