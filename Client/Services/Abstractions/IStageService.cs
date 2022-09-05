﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.ViewModels;

namespace Client.Services.Abstractions
{
    internal interface IStageService:IEntityInterface<StageViewModel>
    {
        Task GetAll(ObservableCollection<StageViewModel> collection);
        Task Duplicate(StageViewModel stage,Guid newId);
    }
}
