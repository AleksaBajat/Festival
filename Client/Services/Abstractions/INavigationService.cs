using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Abstractions
{
    public interface INavigationService
    {
        void NavigateToAdmin();

        void NavigateToFestival();

        void NavigateToLogin();
    }
}
