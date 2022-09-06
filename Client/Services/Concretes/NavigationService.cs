using System;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Authentication;
using Client.Stores;
using Client.ViewModels;

namespace Client.Services.Concretes
{
    internal class NavigationService:INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly IAuthenticator _authenticator;
        private readonly IRegisterService _registerService;
        private readonly IStageService _stageService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly IArtistService _artistService;

        public NavigationService(NavigationStore navigationStore,
            IAuthenticator authenticator,
            IRegisterService registerService,
            IStageService stageService,
            ITimeSlotService timeSlotService,IArtistService artistService)
        {
            _authenticator = authenticator;
            _navigationStore = navigationStore;
            _registerService = registerService;
            _stageService = stageService;
            _timeSlotService = timeSlotService;
            _artistService = artistService;
            NavigateToLogin();
        }

        public NavigationStore NavigationStore => _navigationStore;

        public void NavigateToAdmin()
        {
            _navigationStore.CurrentViewModel = new AdminViewModel(_registerService,_authenticator,this);
        }

        public void NavigateToFestival()
        {
            _navigationStore.CurrentViewModel = new StageListingViewModel(_authenticator,_stageService,this);
        }

        public void NavigateToLogin()
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_authenticator,this);
        }

        public void NavigateToTimeStamps(Guid stageId)
        {
            _navigationStore.CurrentViewModel = new TimeSlotListingViewModel(_timeSlotService,this,_authenticator,stageId);
        }

        public void NavigateToArtists(Guid timeSlotId)
        {
            _navigationStore.CurrentViewModel = new ArtistListingViewModel(_authenticator,this,_artistService,timeSlotId);
        }

        public void NavigateToAddTimeStamps(TimeSlotViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = new AddUpdateTimeSlotViewModel(_authenticator,this,_timeSlotService,viewModel,"add");
        }

        public void NavigateToEditTimeStamps(TimeSlotViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = new AddUpdateTimeSlotViewModel(_authenticator,this,_timeSlotService,viewModel,"edit");
        }

        public void NavigateToAddArtist(ArtistViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = new AddUpdateArtistViewModel(_authenticator,this, _artistService,viewModel,"add");
        }

        public void NavigateToEditArtist(ArtistViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = new AddUpdateArtistViewModel(_authenticator,this, _artistService,viewModel, "edit");
        }

        public void NavigateToEditStage(StageViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = new AddUpdateStageViewModel(_authenticator,this,_stageService,viewModel, "edit");
        }

        public void NavigateToAddStage()
        {
            _navigationStore.CurrentViewModel = new AddUpdateStageViewModel(_authenticator,this,_stageService,new StageViewModel(new Stage()), "add");
        }
    }
}
