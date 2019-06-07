using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using WebApp.Models;

namespace WebApp.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Linija> Linija { get; set; }
        public DbSet<DanUNedelji> DanUNedelji { get; set; }
        public DbSet<Polazak> Polazak { get; set; }
        public DbSet<Stanica> Stanica { get; set; }
        public DbSet<TipPolaska> TipPolaska { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<CijenaKarte> CijenaKarte { get; set; }
        public DbSet<Cjenovnik> Cjenovnik { get; set; }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<TipKarte> TipKarte { get; set; }
        //public DbSet<TipKorisnika> TipKorisnika { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}