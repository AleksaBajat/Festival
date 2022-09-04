using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    internal class TimeSlotListingViewModel:BaseViewModel
    {
        private readonly ObservableCollection<TimeSlotViewModel> _timeSlots;

        public ICommand RefreshCommand { get; set; }

        public TimeSlotListingViewModel(Guid id)
        {

        }
    }
}
