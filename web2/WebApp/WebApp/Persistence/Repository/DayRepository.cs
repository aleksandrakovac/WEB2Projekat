using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class DayRepository : Repository<Day, int>, IDayRepository
    {
        public DayRepository(DbContext context) : base(context)
        {
        }
    
    }
}