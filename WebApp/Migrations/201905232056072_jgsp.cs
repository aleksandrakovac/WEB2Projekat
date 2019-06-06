namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jgsp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DanUNedeljis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Polazaks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipPolaskaId = c.Int(nullable: false),
                        DanUNedeljiId = c.Int(nullable: false),
                        Vremena = c.String(),
                        Linija_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DanUNedeljis", t => t.DanUNedeljiId, cascadeDelete: true)
                .ForeignKey("dbo.TipPolaskas", t => t.TipPolaskaId, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id)
                .Index(t => t.TipPolaskaId)
                .Index(t => t.DanUNedeljiId)
                .Index(t => t.Linija_Id);
            
            CreateTable(
                "dbo.TipPolaskas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerijskiBroj = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Adresa = c.String(),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voziloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        LinijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linijas", t => t.LinijaId, cascadeDelete: true)
                .Index(t => t.LinijaId);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cijena = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TipKorisnikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StanicaLinijas",
                c => new
                    {
                        Stanica_Id = c.Int(nullable: false),
                        Linija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stanica_Id, t.Linija_Id })
                .ForeignKey("dbo.Stanicas", t => t.Stanica_Id, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.Linija_Id, cascadeDelete: true)
                .Index(t => t.Stanica_Id)
                .Index(t => t.Linija_Id);
            
            AddColumn("dbo.AspNetUsers", "TipId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Datum", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lozinka", c => c.String());
            AddColumn("dbo.AspNetUsers", "PotvrdaLozinke", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ime", c => c.String());
            AddColumn("dbo.AspNetUsers", "Prezime", c => c.String());
            CreateIndex("dbo.AspNetUsers", "TipId");
            AddForeignKey("dbo.AspNetUsers", "TipId", "dbo.TipKorisnikas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {            
            DropForeignKey("dbo.AspNetUsers", "TipId", "dbo.TipKorisnikas");
            DropForeignKey("dbo.Kartas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Polazaks", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.Voziloes", "LinijaId", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.Polazaks", "TipPolaskaId", "dbo.TipPolaskas");
            DropForeignKey("dbo.Polazaks", "DanUNedeljiId", "dbo.DanUNedeljis");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.Kartas", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "TipId" });
            DropIndex("dbo.Voziloes", new[] { "LinijaId" });
            DropIndex("dbo.Polazaks", new[] { "Linija_Id" });
            DropIndex("dbo.Polazaks", new[] { "DanUNedeljiId" });
            DropIndex("dbo.Polazaks", new[] { "TipPolaskaId" });
            DropColumn("dbo.AspNetUsers", "Prezime");
            DropColumn("dbo.AspNetUsers", "Ime");
            DropColumn("dbo.AspNetUsers", "PotvrdaLozinke");
            DropColumn("dbo.AspNetUsers", "Lozinka");
            DropColumn("dbo.AspNetUsers", "Datum");
            DropColumn("dbo.AspNetUsers", "TipId");
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.TipKorisnikas");
            DropTable("dbo.Kartas");
            DropTable("dbo.Voziloes");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.TipPolaskas");
            DropTable("dbo.Polazaks");
            DropTable("dbo.DanUNedeljis");
        }
    }
}
