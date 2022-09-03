using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryCrud.Commands
{
    public class RelayCommand : ICommand
    {
        Action<object> execute;
        Func<object,bool> canExecute;
        bool canExecuteChanged;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute): this(execute, canExecute, false) { }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute, bool canExecuteChanged)
        {
            this.execute = execute;
            this.canExecute = canExecute;
            this.canExecuteChanged = canExecuteChanged;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null && canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
