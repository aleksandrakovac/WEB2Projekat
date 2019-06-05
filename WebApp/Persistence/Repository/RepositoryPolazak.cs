using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryPolazak : Repository<Polazak, int>, IRepositoryPolazak
    {
        public RepositoryPolazak(DbContext context) : base(context)
        {
        }
    }
}