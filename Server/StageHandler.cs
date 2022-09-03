using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Context.Models;
using Contracts;
using DTO;

namespace Server
{
    public class StageHandler:IStageHandler
    {
        private readonly object _lock = new object();

        public Task Add(StageDto entity)
        {
            using (FestivalContext context = new FestivalContext())
            {
                Stage stage = ConvertToContextModel(entity);

                context.Stages.Add(stage);

                context.SaveChanges();

                return Task.CompletedTask;
            }
        }

        public Task Duplicate(StageDto entity)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                    if (stage == null)
                    {
                        return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                    }

                    if (stage.IsDeleted == true)
                    {
                        return Task.FromException(
                            new DeletedRowInaccessibleException($"Stage with id:{entity.StageId} was deleted from database."));
                    }

                    if (DateTime.Compare(entity.Version, stage.Version) < 0)
                    {
                        return Task.FromException(
                            new DeletedRowInaccessibleException($"Stage with id:{entity.StageId} was modified between retrieval and your command."));
                    }

                    var duplicateStage = new Stage
                    {
                        Name = stage.Name,
                        Version = DateTime.Now,
                        TimeSlots = stage.TimeSlots.ToList()
                    };

                    context.Stages.Add(duplicateStage);

                    context.SaveChanges();

                    return Task.CompletedTask;
                }
            }
        }

        public Task Delete(StageDto entity)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                    if (stage == null)
                    {
                        return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                    }

                    if (DateTime.Compare(entity.Version, stage.Version) < 0 && stage.IsDeleted == false)
                    {
                        return Task.FromException(
                            new DeletedRowInaccessibleException($"Stage with id:{entity.StageId} was modified between retrieval and your command."));
                    }

                    if (stage.IsDeleted == true)
                    {
                        return Task.CompletedTask;
                    }

                    stage.IsDeleted = true;

                    context.SaveChanges();

                    return Task.CompletedTask;
                }
            }
        }

        public Task Update(StageDto entity)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    var stage = context.Stages.FirstOrDefault(s => s.StageId == entity.StageId);

                    if (stage == null)
                    {
                        return Task.FromException(new KeyNotFoundException($"Stage with id:{entity.StageId} was not found in database."));
                    }

                    if (stage.IsDeleted == true)
                    {
                        return Task.FromException(
                            new DeletedRowInaccessibleException($"Stage with id:{entity.StageId} was deleted from database."));
                    }

                    if (DateTime.Compare(entity.Version, stage.Version) < 0)
                    {
                        return Task.FromException(
                            new DeletedRowInaccessibleException($"Stage with id:{entity.StageId} was modified between retrieval and your command."));
                    }

                    stage.Name = entity.Name;
                    stage.Version = DateTime.Now;

                    context.SaveChanges();

                    return Task.CompletedTask;
                }
            }
        }

        public async Task<List<StageDto>> GetAll()
        {
            using (FestivalContext context = new FestivalContext())
            {
                List<Stage> stages = context.Stages.ToList();

                List<StageDto> result = new List<StageDto>();

                foreach (var stage in stages)
                {
                    result.Add(ConvertToTransferModel(stage));
                }

                return await Task.FromResult(result);
            }
        }

        private Stage ConvertToContextModel(StageDto dto)
        {
            Stage conversionResult = new Stage
            {
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
