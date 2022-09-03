﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Resolver;

namespace Client.Commands
{
    internal class NavigateFestivalCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateFestivalCommand()
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToFestival();
        }
    }
}
