using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RepositoryDanUNedelji : Repository<DanUNedelji, int>, IRepositoryDanUNedelji
    {
        public RepositoryDanUNedelji(DbContext context) : base(context)
        {
        }
    }
}