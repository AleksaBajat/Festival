using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.ViewModels
{
    internal class TimeSlotListingViewModel:BaseViewModel
    {
        public ICommand RefreshCommand { get; set; }

        public TimeSlotListingViewModel(int id)
        {

        }
    }
}
