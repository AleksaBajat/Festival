using System.Collections.Generic;
using Common.Enums;
using Context.Models;

namespace Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.FestivalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.FestivalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Set<User>().Any())
            {
                context.Users.Add(new User
                {
                    Name = "Aleksa",
                    LastName = "Bajat",
                    Password = "admin",
                    Role = CommonEnumerations.UserRole.Admin,
                    UserId = Guid.NewGuid(),
                    Username = "admin"
                });
            }

            if (!context.Set<Stage>().Any())
            {
                Guid stageId = Guid.NewGuid();
                Guid timeSlotId = Guid.NewGuid();

                context.Stages.Add(new Stage
                {
                    Name = "ASFM",
                    StageId = stageId,
                    Version = DateTime.Now,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            StageId = stageId,
                            Description = "Very fun",
                            From = DateTime.Now,
                            To = DateTime.Now,
                            TimeSlotId = timeSlotId,
                            Version = DateTime.Now,
                            Artists = new List<Artist>
                            {
                                new Artist
                                {
                                    ArtistId = Guid.NewGuid(),
                                    Genre = "Zanr",
                                    Name = "IksDe",
                                    Surname = "Ekstra",
                                    Version = DateTime.Now
                                }
                            }
                        },
                        new TimeSlot
                        {
                            StageId = stageId,
                            Description = "Ultra fun",
                            From = DateTime.Now,
                            To = DateTime.Now,
                            Version = DateTime.Now,
                            TimeSlotId = timeSlotId
                        }
                    }
                });
            }

            context.SaveChanges();
        }
    }
}
