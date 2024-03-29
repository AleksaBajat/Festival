﻿using System;
using System.Collections.Generic;
using System.Data;
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
    public class StageHandler:IStageHandler
    {
        private readonly object _lock = new object();
        private readonly ILog _log = LogManager.GetLogger(nameof(StageHandler));

        public Task Add(StageDto entity, bool confirmed = false)
        {
            using (FestivalContext context = new FestivalContext())
            {
                Stage stage = ConvertToContextModel(entity);

                var existing = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                if (existing == null)
                {
                    _log.Info("Added Stage");
                    context.Stages.Add(stage);
                }
                else
                {
                    _log.Info("Deleted stage un-deleted.");
                    existing.IsDeleted = false;
                }

                context.SaveChanges();

                return Task.CompletedTask;
            }
        }

        public Task Duplicate(StageDuplicateDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                        if (!confirmed)
                        {
                            if (stage == null)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Not existing instance."));
                            }

                            if (stage.IsDeleted == true)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Duplicate on deleted stage conflict."));
                            }

                            if (DateTime.Compare(entity.Version, stage.Version) < 0 && stage.IsDeleted == false)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Duplicate on modified stage conflict."));
                            }
                        }

                        stage.IsDeleted = false;

                        var existing = context.Stages.FirstOrDefault(s => s.StageId == entity.NewId);

                        if (existing == null)
                        {
                            var duplicateStage = new Stage
                            {
                                StageId = entity.NewId,
                                Name = stage.Name,
                                Version = DateTime.Now,
                                TimeSlots = stage.TimeSlots.ToList()
                            };

                            context.Stages.Add(duplicateStage);
                        }
                        else
                        {
                            existing.IsDeleted = false;
                        }

                        _log.Info("Duplicated Stage");

                        context.SaveChanges();

                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Error Duplicate");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public Task Delete(StageDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                        if (!confirmed)
                        {
                            if (stage == null)
                            {
                                return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                            }

                            if (DateTime.Compare(entity.Version, stage.Version) < 0 && stage.IsDeleted == false)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Delete on modified stage conflict."));
                            }

                            if (stage.IsDeleted == true)
                            {
                                return Task.CompletedTask;
                            }
                        }

                        stage.IsDeleted = true;

                        context.SaveChanges();

                        _log.Info("Deleted Stage");

                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Error Delete");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public Task Update(StageDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);


                        if (!confirmed)
                        {
                            if (stage == null)
                            {
                                return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                            }

                            if (stage.IsDeleted == true)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Update on deleted stage conflict."));
                            }

                            if (DateTime.Compare(entity.Version, stage.Version) < 0 && stage.IsDeleted == false)
                            {
                                throw new FaultException<ConflictFault>(new ConflictFault("Update on modified stage conflict."));
                            }
                        }

                        stage.IsDeleted = false;
                        stage.Name = entity.Name;
                        stage.Version = DateTime.Now;

                        context.SaveChanges();

                        _log.Info("Updated Stage");
                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Error Update");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public async Task<List<StageDto>> GetAll()
        {
            using (FestivalContext context = new FestivalContext())
            {
                List<Stage> stages = context.Stages.Where(s => s.IsDeleted == false).ToList();

                List<StageDto> result = new List<StageDto>();

                foreach (var stage in stages)
                {
                    result.Add(ConvertToTransferModel(stage));
                }

                _log.Info("Retrieved Stages");
                return await Task.FromResult(result);
            }
        }

        public async Task<List<StageDto>> Search(string parameter)
        {
            using (FestivalContext context = new FestivalContext())
            {
                List<Stage> stages = context.Stages.Where(s => s.IsDeleted == false && s.Name.Contains(parameter)).ToList();

                List<StageDto> result = new List<StageDto>();

                foreach (var stage in stages)
                {
                    result.Add(ConvertToTransferModel(stage));
                }

                _log.Info("Retrieved Stages (Search)");
                return await Task.FromResult(result);
            }
        }

        private Stage ConvertToContextModel(StageDto dto)
        {
            Stage conversionResult = new Stage
            {
                StageId = dto.StageId,
                Name = dto.Name,
                Version = dto.Version
            };

            return conversionResult;
        }

        private StageDto ConvertToTransferModel(Stage cxtModel)
        {
            StageDto conversionResult = new StageDto()
            {
                Name = cxtModel.Name,
                StageId = cxtModel.StageId,
                Version = cxtModel.Version
            };

            return conversionResult;
        }
    }
}
