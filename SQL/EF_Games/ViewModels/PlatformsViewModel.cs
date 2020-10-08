using EF_Games.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EF_Games.ViewModels
{
    class PlatformsViewModel : BindableBase, IPlatformsViewModel
    {
        private ICommand editEndingCommand;

        public PlatformsViewModel()
        {
        }

        public ObservableCollection<Platform> Platforms
        {
            get
            {
                using (GamesBaseEntities context = new GamesBaseEntities())
                {
                    var result = new ObservableCollection<Platform>(context.Platforms);
                    result.CollectionChanged += (s, e) => 
                    {
                        if (e.Action == NotifyCollectionChangedAction.Remove)
                        {
                            using (var c = new GamesBaseEntities())
                            {
                                foreach (Platform item in e.OldItems)
                                {
                                    c.Platforms.Attach(item);
                                    c.Entry(item).State = EntityState.Deleted;
                                }

                                c.SaveChanges();
                                RaisePropertyChanged(nameof(Platforms));
                            }
                        }
                    };
                    return result;
                }
            }
        }

        public ICommand EditEndingCommand
        {
            get
            {
                return editEndingCommand ?? (editEndingCommand = new DelegateCommand<DataGridRowEditEndingEventArgs>(
                    (e) => 
                    {
                        if (e.EditAction == DataGridEditAction.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }

                        var platform = e.Row.Item as Platform;
                        using (GamesBaseEntities context = new GamesBaseEntities())
                        {
                            if (e.Row.IsNewItem)
                            {
                                context.Platforms.Add(platform);
                            }
                            else
                            {
                                context.Platforms.Attach(platform);
                                context.Entry(platform).State = EntityState.Modified;
                            }

                            context.SaveChanges();
                            RaisePropertyChanged(nameof(Platforms));
                        }
                    }
                    ));
            }
        }
    }
}
