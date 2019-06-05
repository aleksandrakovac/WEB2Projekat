using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryVozilo : Repository<Vozilo, int>, IRepositoryVozilo
    {
        public RepositoryVozilo(DbContext context) : base(context)
        {
        }
    }
}