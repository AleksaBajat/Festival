﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ViewModels;
using DTO;

namespace Client.Services.Abstractions
{
    public interface ITimeSlotService:IEntityService<TimeSlotViewModel>
    {
        Task GetAll(ObservableCollection<TimeSlotViewModel> collection,Guid stageId);
    }
}
