using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        IRepositoryDanUNedelji RepositoryDanUNedelji { get; set; }

        IRepositoryLinija RepositoryLinija { get; set; }

        IRepositoryCjenovnik RepositoryCjenovnik { get; set; }

        IRepositoryStanica RepositoryStanica { get; set; }

        IRepositoryCijenaKarte RepositoryCijenaKarte { get; set; }

        IRepositoryTipKarte RepositoryTipKarte { get; set; }

        IRepositoryPolazak RepositoryPolazak { get; set; }

        IRepositoryTipPolaska RepositoryTipPolaska { get; set; }

        IRepositoryTipKorisnika RepositoryTipKorisnika { get; set; }

        IRepositoryVozilo RepositoryVozilo { get; set; }

        int Complete();
    }
}
