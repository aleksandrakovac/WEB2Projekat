namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jgsp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Info = c.String(),
                        LineId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        TimetableTypeId = c.Int(nullable: false),
                        Pricelist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .ForeignKey("dbo.TimetableTypes", t => t.TimetableTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Pricelists", t => t.Pricelist_Id)
                .Index(t => t.LineId)
                .Index(t => t.DayId)
                .Index(t => t.TimetableTypeId)
                .Index(t => t.Pricelist_Id);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        StationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        X = c.Single(nullable: false),
                        Y = c.Single(nullable: false),
                        LineId = c.Int(nullable: false),
                        Pricelist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pricelists", t => t.Pricelist_Id)
                .Index(t => t.Pricelist_Id);
            
            CreateTable(
                "dbo.TimetableTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pricelists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StationId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        PricelistId = c.Int(nullable: false),
                        TypeTicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pricelists", t => t.PricelistId, cascadeDelete: true)
                .ForeignKey("dbo.TypeTickets", t => t.TypeTicketId, cascadeDelete: true)
                .Index(t => t.PricelistId)
                .Index(t => t.TypeTicketId);
            
            CreateTable(
                "dbo.TypeTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StationLines",
                c => new
                    {
                        Station_Id = c.Int(nullable: false),
                        Line_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Station_Id, t.Line_Id })
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lines", t => t.Line_Id, cascadeDelete: true)
                .Index(t => t.Station_Id)
                .Index(t => t.Line_Id);
            
            AddColumn("dbo.AspNetUsers", "Tip", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.AspNetUsers", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketPrices", "TypeTicketId", "dbo.TypeTickets");
            DropForeignKey("dbo.TicketPrices", "PricelistId", "dbo.Pricelists");
            DropForeignKey("dbo.Timetables", "Pricelist_Id", "dbo.Pricelists");
            DropForeignKey("dbo.Stations", "Pricelist_Id", "dbo.Pricelists");
            DropForeignKey("dbo.Timetables", "TimetableTypeId", "dbo.TimetableTypes");
            DropForeignKey("dbo.Timetables", "LineId", "dbo.Lines");
            DropForeignKey("dbo.StationLines", "Line_Id", "dbo.Lines");
            DropForeignKey("dbo.StationLines", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.Timetables", "DayId", "dbo.Days");
            DropIndex("dbo.StationLines", new[] { "Line_Id" });
            DropIndex("dbo.StationLines", new[] { "Station_Id" });
            DropIndex("dbo.TicketPrices", new[] { "TypeTicketId" });
            DropIndex("dbo.TicketPrices", new[] { "PricelistId" });
            DropIndex("dbo.Stations", new[] { "Pricelist_Id" });
            DropIndex("dbo.Timetables", new[] { "Pricelist_Id" });
            DropIndex("dbo.Timetables", new[] { "TimetableTypeId" });
            DropIndex("dbo.Timetables", new[] { "DayId" });
            DropIndex("dbo.Timetables", new[] { "LineId" });
            DropColumn("dbo.AspNetUsers", "Date");
            DropColumn("dbo.AspNetUsers", "ConfirmPassword");
            DropColumn("dbo.AspNetUsers", "Password");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Tip");
            DropTable("dbo.StationLines");
            DropTable("dbo.TypeTickets");
            DropTable("dbo.TicketPrices");
            DropTable("dbo.Pricelists");
            DropTable("dbo.TimetableTypes");
            DropTable("dbo.Stations");
            DropTable("dbo.Lines");
            DropTable("dbo.Timetables");
            DropTable("dbo.Days");
        }
    }
}
