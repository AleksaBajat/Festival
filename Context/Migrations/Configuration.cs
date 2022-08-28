
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Context.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context.FestivalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}