﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Persistence.Repository
{
    public class TypeTicketRepository : Repository<TypeTicket, int>, ITypeTicketRepository
    {
        public TypeTicketRepository(DbContext context) : base(context)
        {
        }
    }
}