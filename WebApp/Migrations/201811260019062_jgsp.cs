namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jgsp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CijenaKartes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cijena = c.Double(nullable: false),
                        CjenovnikId = c.Int(nullable: false),
                        TipKarteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cjenovniks", t => t.CjenovnikId, cascadeDelete: true)
                .ForeignKey("dbo.TipKartes", t => t.TipKarteId, cascadeDelete: true)
                .Index(t => t.CjenovnikId)
                .Index(t => t.TipKarteId);
            
            CreateTable(
                "dbo.Cjenovniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Polaziste = c.String(),
                        Dolaziste = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipKartes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        LinijaId = c.Int(nullable: false),
                        Vremena = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DanUNedeljis", t => t.DanUNedeljiId, cascadeDelete: true)
                .ForeignKey("dbo.Linijas", t => t.LinijaId, cascadeDelete: true)
                .ForeignKey("dbo.TipPolaskas", t => t.TipPolaskaId, cascadeDelete: true)
                .Index(t => t.TipPolaskaId)
                .Index(t => t.DanUNedeljiId)
                .Index(t => t.LinijaId);
            
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
                "dbo.TipPolaskas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cijena = c.Double(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        Korisnik_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Korisnik_Id)
                .Index(t => t.Korisnik_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TipId = c.Int(nullable: false),
                        Datum = c.String(),
                        Lozinka = c.String(),
                        PotvrdaLozinke = c.String(),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipKorisnikas", t => t.TipId, cascadeDelete: true)
                .Index(t => t.TipId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TipKorisnikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "TipId", "dbo.TipKorisnikas");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Kartas", "Korisnik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Polazaks", "TipPolaskaId", "dbo.TipPolaskas");
            DropForeignKey("dbo.Polazaks", "LinijaId", "dbo.Linijas");
            DropForeignKey("dbo.Voziloes", "LinijaId", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Linija_Id", "dbo.Linijas");
            DropForeignKey("dbo.StanicaLinijas", "Stanica_Id", "dbo.Stanicas");
            DropForeignKey("dbo.Polazaks", "DanUNedeljiId", "dbo.DanUNedeljis");
            DropForeignKey("dbo.CijenaKartes", "TipKarteId", "dbo.TipKartes");
            DropForeignKey("dbo.CijenaKartes", "CjenovnikId", "dbo.Cjenovniks");
            DropIndex("dbo.StanicaLinijas", new[] { "Linija_Id" });
            DropIndex("dbo.StanicaLinijas", new[] { "Stanica_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "TipId" });
            DropIndex("dbo.Kartas", new[] { "Korisnik_Id" });
            DropIndex("dbo.Voziloes", new[] { "LinijaId" });
            DropIndex("dbo.Polazaks", new[] { "LinijaId" });
            DropIndex("dbo.Polazaks", new[] { "DanUNedeljiId" });
            DropIndex("dbo.Polazaks", new[] { "TipPolaskaId" });
            DropIndex("dbo.CijenaKartes", new[] { "TipKarteId" });
            DropIndex("dbo.CijenaKartes", new[] { "CjenovnikId" });
            DropTable("dbo.StanicaLinijas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipKorisnikas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Kartas");
            DropTable("dbo.TipPolaskas");
            DropTable("dbo.Voziloes");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Linijas");
            DropTable("dbo.Polazaks");
            DropTable("dbo.DanUNedeljis");
            DropTable("dbo.TipKartes");
            DropTable("dbo.Cjenovniks");
            DropTable("dbo.CijenaKartes");
        }
    }
}
