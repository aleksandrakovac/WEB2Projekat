namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jgsp1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "TipId", "dbo.TipKorisnikas");
            DropIndex("dbo.AspNetUsers", new[] { "TipId" });
            DropTable("dbo.TipKorisnikas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipKorisnikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AspNetUsers", "TipId");
            AddForeignKey("dbo.AspNetUsers", "TipId", "dbo.TipKorisnikas", "Id", cascadeDelete: true);
        }
    }
}
