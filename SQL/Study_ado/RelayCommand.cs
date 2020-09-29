using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Study_ado
{
    class RelayCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;

        public RelayCommand(Action action, Predicate<object> predicate = null)
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
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }
    }
}
