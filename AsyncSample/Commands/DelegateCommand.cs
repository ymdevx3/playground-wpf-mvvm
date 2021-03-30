using System;
using System.Windows.Input;

using AsyncSample.ViewModels;

namespace AsyncSample.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;

        private Predicate<object> _canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute; // ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(execute));
            this._canExecute = canExecute; // ?? throw new ArgumentNullException(nameof(DelegateCommand) + ":" + nameof(canExecute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this._execute?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
