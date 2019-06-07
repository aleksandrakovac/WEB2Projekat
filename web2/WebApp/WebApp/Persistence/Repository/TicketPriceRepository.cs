using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class TicketPriceRepository : Repository<TicketPrice, int>, ITicketPriceRepository
    {
        public TicketPriceRepository(DbContext context) : base(context)
        {
        }
    }
}