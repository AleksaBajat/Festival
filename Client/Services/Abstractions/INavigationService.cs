using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels;

namespace Client.Services.Abstractions
{
    public interface INavigationService
    {
        void NavigateToAdmin();

        void NavigateToFestival();

        void NavigateToLogin();

        void NavigateToTimeStamps(int id);

        void NavigateToEditStage(StageViewModel viewModel);

        void NavigateToAddStage();
    }
}
