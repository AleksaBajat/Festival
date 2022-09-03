using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.State.Authentication;

namespace Client.ViewModels
{
    internal class StageListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<StageViewModel> _stages;

        private readonly IAuthenticator _authenticator;
     
        private bool _isAdmin;

        public IEnumerable<StageViewModel> Stages => _stages;

        public bool IsAdmin
        {
            get
            {
                return _authenticator.IsAdmin;
            }

            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public StageListingViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            _stages = new ObservableCollection<StageViewModel>();

            _stages.Add(new StageViewModel(new Stage
            {
                Name = "Main",
                StageId = 1,
                TimeSlots = new List<TimeSlot>()
            }));
        }


    }
}
