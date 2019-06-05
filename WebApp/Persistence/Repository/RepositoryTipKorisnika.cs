using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryTipKorisnika : Repository<TipKorisnika, int>, IRepositoryTipKorisnika
    {
         public RepositoryTipKorisnika(DbContext context) : base(context)
        {

        }
    }
}