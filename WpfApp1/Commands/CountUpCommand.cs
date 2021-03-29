using System;
using System.Windows.Input;
using WpfApp1.ViewModels;

namespace WpfApp1.Commands
{
    class CountUpCommand : ICommand
    {
        private MainViewModel ViewModel { get; set; }

        public CountUpCommand(MainViewModel viewModel)
        {
            this.ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.Value++;
        }
    }
}
