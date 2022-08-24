using System.Threading.Tasks;

namespace Client.Commands
{
    public abstract class AsyncBaseCommand:BaseCommand
    {
        private bool _isExecuting;

        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            } 
        }

        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally
            {
                IsExecuting = false;
            }
        }

        public override bool CanExecute(object parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}