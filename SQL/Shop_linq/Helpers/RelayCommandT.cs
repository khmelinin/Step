using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_linq.Helpers
{
    class RelayCommand<T> : ICommand
    {
        Action<T> execute;
        Predicate<T> canExecute;

        public RelayCommand(Action<T> action, Predicate<T> predicate = null)
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
            try
            {
                T p = (T)parameter;
                return canExecute == null ? true : canExecute(p);
            }
            catch
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            try
            {
                T p = (T)parameter;
                execute(p);
            }
            catch
            {
            }
        }
    }
}
