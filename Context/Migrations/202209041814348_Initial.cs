namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Guid(nullable: false),
                        TimeSlotId = c.Guid(nullable: false),
                        Genre = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Version = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.TimeSlots", t => t.TimeSlotId, cascadeDelete: true)
                .Index(t => t.TimeSlotId);
            
            CreateTable(
                "dbo.Stages",
                c => new
                    {
                        StageId = c.Guid(nullable: false),
                        Name = c.String(),
                        Version = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StageId);
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        TimeSlotId = c.Guid(nullable: false, identity: true),
                        StageId = c.Guid(nullable: false),
                        Description = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Version = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TimeSlotId)
                .ForeignKey("dbo.Stages", t => t.StageId, cascadeDelete: true)
                .Index(t => t.StageId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeSlots", "StageId", "dbo.Stages");
            DropForeignKey("dbo.Artists", "TimeSlotId", "dbo.TimeSlots");
            DropIndex("dbo.TimeSlots", new[] { "StageId" });
            DropIndex("dbo.Artists", new[] { "TimeSlotId" });
            DropTable("dbo.Users");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.Stages");
            DropTable("dbo.Artists");
        }
    }
}
