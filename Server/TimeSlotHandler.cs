using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Common.Faults;
using Context;
using Context.Models;
using Contracts;
using DTO;
using log4net;

namespace Server
{
    internal class TimeSlotHandler:ITimeSlotHandler
    {
        private readonly object _lock = new object();
        private readonly ILog _log = LogManager.GetLogger(nameof(TimeSlotHandler));

        public Task Add(TimeSlotDto entity)
        {
            using (FestivalContext context = new FestivalContext())
            {
                TimeSlot timeSlot = ConvertToContextModel(entity);

                var existing = context.TimeSlots.FirstOrDefault(s => s.TimeSlotId == entity.TimeSlotId);

                context.TimeSlots.Add(timeSlot);
                
                context.SaveChanges();


                _log.Info("Added Time Slot");
                return Task.CompletedTask;
            }
        }

        public Task Delete(TimeSlotDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var timeSlot = context.TimeSlots.FirstOrDefault(s => s.TimeSlotId == entity.TimeSlotId);

                        if (!confirmed)
                        {
                            if (timeSlot == null)
                            {
                                return Task.FromException(new KeyNotFoundException($"Time slot with id:{entity.TimeSlotId} was not found in database."));
                            }

                            if (DateTime.Compare(entity.Version, timeSlot.Version) < 0 && timeSlot.IsDeleted == false)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Delete on modified time slot conflict."));
                            }

                            if (timeSlot.IsDeleted == true)
                            {
                                return Task.CompletedTask;
                            }
                        }

                        timeSlot.IsDeleted = true;

                        context.SaveChanges();

                        _log.Info("Deleted Time Slot");

                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Delete Time Slot");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public Task Update(TimeSlotDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var timeSlot = context.TimeSlots.FirstOrDefault(s => s.TimeSlotId == entity.TimeSlotId);


                        if (!confirmed)
                        {
                            if (timeSlot == null)
                            {
                                return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                            }

                            if (timeSlot.IsDeleted == true)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Update on deleted stage conflict."));
                            }

                            if (DateTime.Compare(entity.Version, timeSlot.Version) < 0)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Update on modified stage conflict."));
                            }
                        }

                        timeSlot.IsDeleted = false;
                        timeSlot.Description = entity.Description;
                        timeSlot.From = entity.From;
                        timeSlot.To = entity.To;
                        timeSlot.Version = DateTime.Now;

                        context.SaveChanges();


                        _log.Info("Updated Time Slot");
                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Update Time Slot");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public async Task<List<TimeSlotDto>> GetAll(Guid stageId)
        {
            using (FestivalContext context = new FestivalContext())
            {
                List<TimeSlot> timeSlots = context.TimeSlots.Where(ts => ts.IsDeleted == false && ts.StageId == stageId).ToList();

                List<TimeSlotDto> result = new List<TimeSlotDto>();

                foreach (var timeSlot in timeSlots)
                {
                    result.Add(ConvertToTransferModel(timeSlot));
                }

                _log.Info("Retrieved Time Slots");
                return await Task.FromResult(result);
            }
        }

        private TimeSlotDto ConvertToTransferModel(TimeSlot timeSlot)
        {
            return new TimeSlotDto
            {
                Description = timeSlot.Description,
                From = timeSlot.From,
                To = timeSlot.To,
                Version = timeSlot.Version,
                StageId = timeSlot.StageId,
                TimeSlotId = timeSlot.TimeSlotId
            };
        }

        private TimeSlot ConvertToContextModel(TimeSlotDto entity)
        {
            return new TimeSlot
            {
                Description = entity.Description,
                From = entity.From,
                Version = entity.Version,
                To = entity.To,
                StageId = entity.StageId,
                TimeSlotId = entity.TimeSlotId
            };
        }
    }
}
