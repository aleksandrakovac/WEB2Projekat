using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryLinija : Repository<Linija, int>, IRepositoryLinija
    {
        public RepositoryLinija(DbContext context) : base(context)
        {
        }
    }
}