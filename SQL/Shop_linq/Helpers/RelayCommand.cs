using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_linq.Helpers
{
    class RelayCommand : ICommand
    {
        Action execute;
        Func<bool> canExecute;

        public RelayCommand(Action action, Func<bool> predicate = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            execute = action;
            canExecute = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
