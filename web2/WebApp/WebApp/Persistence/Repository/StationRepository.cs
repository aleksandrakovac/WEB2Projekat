using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class StationRepository : Repository<Station, int>, IStationRepository
    {
        public StationRepository(DbContext context) : base(context)
        {
        }
    }
}