using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        [Dependency]
        public IRepositoryDanUNedelji RepositoryDanUNedelji { get; set; }

        [Dependency]
        public IRepositoryLinija RepositoryLinija { get; set; }

        [Dependency]
        public IRepositoryCjenovnik RepositoryCjenovnik { get; set; }

        [Dependency]
        public IRepositoryStanica RepositoryStanica { get; set; }

        [Dependency]
        public IRepositoryCijenaKarte RepositoryCijenaKarte { get; set; }

        [Dependency]
        public IRepositoryTipKarte RepositoryTipKarte { get; set; }

        [Dependency]
        public IRepositoryPolazak RepositoryPolazak { get; set; }

        [Dependency]
        public IRepositoryTipPolaska RepositoryTipPolaska { get; set; }

        [Dependency]
       // public IRepositoryTipKorisnika RepositoryTipKorisnika { get; set; }

        //[Dependency]
        public IRepositoryVozilo RepositoryVozilo { get; set; }

        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}