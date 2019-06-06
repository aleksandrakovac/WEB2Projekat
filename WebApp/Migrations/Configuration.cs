namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //DanUNedelji
            if(!context.DanUNedelji.Any(d => d.Naziv == "Radni dan"))
            {
                DanUNedelji danUNedelji = new DanUNedelji() { Naziv = "Radni dan", Id = 1 };
                context.DanUNedelji.Add(danUNedelji);
                context.SaveChanges();
            }
            if (!context.DanUNedelji.Any(d => d.Naziv == "Subota"))
            {
                DanUNedelji danUNedelji = new DanUNedelji() { Naziv = "Subota", Id = 2 };
                context.DanUNedelji.Add(danUNedelji);
                context.SaveChanges();
            }
            if (!context.DanUNedelji.Any(d => d.Naziv == "Nedelja"))
            {
                DanUNedelji danUNedelji = new DanUNedelji() { Naziv = "Nedelja", Id = 3 };
                context.DanUNedelji.Add(danUNedelji);
                context.SaveChanges();
            }
            //TipPolaska
            if (!context.TipPolaska.Any(d => d.Naziv == "Gradski"))
            {
                TipPolaska tipPolaska = new TipPolaska() { Naziv = "Gradski", Id = 1 };
                context.TipPolaska.Add(tipPolaska);
                context.SaveChanges();
            }
            if (!context.TipPolaska.Any(d => d.Naziv == "Prigradski"))
            {
                TipPolaska tipPolaska = new TipPolaska() { Naziv = "Prigradski", Id = 2 };
                context.TipPolaska.Add(tipPolaska);
                context.SaveChanges();
            }
            //stanice
            if (!context.Stanica.Any(d => d.Ime == "Prva"))
            {
                Stanica stanica = new Stanica() {Id = 1, Ime = "Prva", Adresa = "Adresa Prve", X = 22, Y = 34 };
                context.Stanica.Add(stanica);
                context.SaveChanges();
            }
            if (!context.Stanica.Any(d => d.Ime == "Druga"))
            {
                Stanica stanica = new Stanica() {Id = 2, Ime = "Druga", Adresa = "Adresa Druge", X = 22, Y = 34 };
                context.Stanica.Add(stanica);
                context.SaveChanges();
            }

            //Linija
            if (!context.Linija.Any(t => t.Id == 1))
            {
                Linija linija = new Linija() { Id = 1, SerijskiBroj = 1 };
                context.Linija.Add(linija);
                context.SaveChanges();
            }

            if (!context.Linija.Any(t => t.Id == 2))
            {
                Linija linija = new Linija() { Id = 2, SerijskiBroj = 2 };
                context.Linija.Add(linija);
                context.SaveChanges();
            }
            //Polasci
            if (!context.Polazak.Any(t => t.Id == 1))
            {
                Polazak polazak = new Polazak() { Id = 1, LinijaId = 1, TipPolaskaId = 1, DanUNedeljiId = 1, Vremena = "9:50 10:50 11:50" };
                context.Polazak.Add(polazak);
                context.SaveChanges();
            }
            if (!context.Polazak.Any(t => t.Id == 2))
            {
                Polazak polazak = new Polazak() { Id = 2, LinijaId = 2, TipPolaskaId = 2, DanUNedeljiId = 2, Vremena = "9:50 10:50 11:50 12:50 13:50" };
                context.Polazak.Add(polazak);
                context.SaveChanges();
            }


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
        }
    }
}
