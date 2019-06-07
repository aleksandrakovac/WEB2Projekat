using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class TimetableTypeRepository : Repository<TimetableType, int>, ITimetableTypeRepository
    {
        public TimetableTypeRepository(DbContext context) : base(context)
        {
        }
    }
}