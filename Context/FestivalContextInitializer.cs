using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Context.Models;

namespace Context
{
    public class FestivalContextInitializer:CreateDatabaseIfNotExists<FestivalContext>
    {
        protected override void Seed(FestivalContext context)
        {
            User initialAdmin = new User
            {
                Name = "Aleksa",
                LastName = "Bajat",
                Password = "admin",
                Role = CommonEnumerations.UserRole.Admin,
                Username = "Admin"
            };

            context.Users.Add(initialAdmin);

            base.Seed(context);
        }
    }
}
