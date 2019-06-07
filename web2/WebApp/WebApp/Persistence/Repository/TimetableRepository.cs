﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class TimetableRepository : Repository<Timetable, int>, ITimetableRepository
    {
        public TimetableRepository(DbContext context) : base(context)
        {
        }
    }
}