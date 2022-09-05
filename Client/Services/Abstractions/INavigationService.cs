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

        void NavigateToTimeStamps(Guid stageId);

        void NavigateToEditStage(StageViewModel viewModel);

        void NavigateToAddStage();

        void NavigateToArtists(Guid timeSlotId);

        void NavigateToAddTimeStamps(TimeSlotViewModel viewModel);

        void NavigateToEditTimeStamps(TimeSlotViewModel viewModel);
    }
}
