using System;
using System.Windows.Input;

namespace Client.Commands
{
    public abstract class BaseCommand:ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this,EventArgs.Empty);
        }

    }
}