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
    internal class ArtistHandler : IArtistHandler
    {
        private readonly object _lock = new object();
        private readonly ILog _log = LogManager.GetLogger(nameof(StageHandler));

        public Task Add(ArtistDto entity)
        {
            using (FestivalContext context = new FestivalContext())
            {
                Artist artist = ConvertToContextModel(entity);

                var existing = context.Artists.FirstOrDefault(s => s.ArtistId == entity.ArtistId);

                context.Artists.Add(artist);

                context.SaveChanges();

                _log.Info("Added Artist");
                return Task.CompletedTask;
            }
        }

        private Artist ConvertToContextModel(ArtistDto entity)
        {
            return new Artist
            {
                ArtistId = entity.ArtistId,
                Genre = entity.Genre,
                Name = entity.Name,
                Surname = entity.Surname,
                TimeSlotId = entity.TimeSlotId,
                Version = entity.Version
            };
        }

        public Task Delete(ArtistDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var artist = context.Artists.FirstOrDefault(s => s.ArtistId == entity.ArtistId);

                        if (!confirmed)
                        {
                            if (artist == null)
                            {
                                return Task.FromException(
                                    new KeyNotFoundException(
                                        $"Time slot with id:{entity.TimeSlotId} was not found in database."));
                            }

                            if (DateTime.Compare(entity.Version, artist.Version) < 0 && artist.IsDeleted == false)
                            {
                                throw new FaultException<ConflictFault>(
                                    new ConflictFault("Delete on modified time slot conflict."));
                            }

                            if (artist.IsDeleted == true)
                            {
                                return Task.CompletedTask;
                            }
                        }

                        artist.IsDeleted = true;

                        context.SaveChanges();

                        _log.Info("Deleted Artist");
                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Delete Artist");
                        return Task.CompletedTask;
                    }
                }
            }
        }

        public Task Update(ArtistDto entity, bool confirmed = false)
        {
            lock (_lock)
            {
                using (FestivalContext context = new FestivalContext())
                {
                    try
                    {
                        var artist = context.Artists.FirstOrDefault(s => s.ArtistId == entity.ArtistId);


                        if (!confirmed)
                        {
                            if (artist == null)
                            {
                                return Task.FromException(
                                    new KeyNotFoundException(
                                        $"Stage with id:{entity.ArtistId} was not found in database."));
                            }

                            if (artist.IsDeleted == true)
                            {
                                throw new FaultException<ConflictFault>(
                                    new ConflictFault("Update on deleted stage conflict."));
                            }

                            if (DateTime.Compare(entity.Version, artist.Version) < 0)
                            {
                                throw new FaultException<ConflictFault>(
                                    new ConflictFault("Update on modified stage conflict."));
                            }
                        }

                        artist.IsDeleted = false;
                        artist.Name = entity.Name;
                        artist.Genre = entity.Genre;
                        artist.Surname = entity.Surname;
                        artist.TimeSlotId = entity.TimeSlotId;
                        artist.Version = DateTime.Now;

                        context.SaveChanges();

                        _log.Info("Updated Artist");
                        return Task.CompletedTask;
                    }
                    catch
                    {
                        _log.Warn("Conflict Update Artist");
                        return Task.CompletedTask;
                    }
                }
            }
        }
        public async Task<List<ArtistDto>> GetAll(Guid timeSlotId)
        {
            using (FestivalContext context = new FestivalContext())
            {
                List<Artist> artists = context.Artists.Where(ts => ts.IsDeleted == false && ts.TimeSlotId == timeSlotId).ToList();

                List<ArtistDto> result = new List<ArtistDto>();

                foreach (var artist in artists)
                {
                    result.Add(ConvertToTransferModel(artist));
                }

                _log.Info("Retrieved Artists");
                return await Task.FromResult(result);
            }
        }

        private ArtistDto ConvertToTransferModel(Artist artist)
        {
            return new ArtistDto
            {
                ArtistId = artist.ArtistId,
                Genre = artist.Genre,
                Name = artist.Name,
                Surname = artist.Surname,
                TimeSlotId = artist.TimeSlotId,
                Version = artist.Version
            };
        }
    }
}