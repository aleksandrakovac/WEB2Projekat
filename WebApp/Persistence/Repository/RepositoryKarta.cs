using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryKarta : Repository<Karta, int>, IRepositroyKarta
    {
        public RepositoryKarta(DbContext context) : base(context)
        {

        }

    }
}