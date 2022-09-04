using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DTO;

namespace Server
{
    internal class TimeSlotHandler:ITimeSlotHandler
    {
        public Task Add(TimeSlotDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TimeSlotDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(TimeSlotDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TimeSlotDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
