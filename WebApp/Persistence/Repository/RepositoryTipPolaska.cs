using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryTipPolaska : Repository<Polazak, int>, IRepositoryPolazak
    {
        public RepositoryTipPolaska(DbContext context) : base(context)
        {
        }
    }
}