using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryCjenovnik : Repository<Cjenovnik, int>, IRepositoryCjenovnik
    {
        public RepositoryCjenovnik(DbContext context) : base(context)
        {

        }
    }
}