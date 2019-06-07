using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class PricelistRepository : Repository<Pricelist, int>, IPricelistRepository
    {
        public PricelistRepository(DbContext context) : base(context)
        {
        }
    }
}