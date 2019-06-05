using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryCijenaKarte : Repository<CijenaKarte, int>, IRepositoryCijenaKarte
    {
        public RepositoryCijenaKarte(DbContext context) : base(context)
        {
        }
    }
}