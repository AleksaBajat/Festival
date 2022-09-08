using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;
using Client.Services.Abstractions;
using Client.State.Authentication;

namespace Client.ViewModels
{
    public class LogsViewModel:BaseViewModel
    {
        public ObservableCollection<string> Logs { get; set; }

        public ICommand NavigateFestivalCommand { get; set; }

        public ICommand LogoutCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        public LogsViewModel(IAuthenticator authenticator,INavigationService navigationService)
        {
            Logs = new ObservableCollection<string>();

            LogoutCommand = new LogoutCommand(authenticator,navigationService);

            NavigateFestivalCommand = new NavigateFestivalCommand(navigationService);

            RefreshCommand = new RefreshLogsCommand(Logs);

            RefreshCommand.Execute(null);
        }
    }
}
