using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryKarta : Repository<Karta, int>, IRepositoryKarta
    {
        public RepositoryKarta(DbContext context) : base(context)
        {

        }

    }
}