﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TicketPrice
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public int PricelistId { get; set; }

        public Pricelist Pricelist { get; set; }

        public int TypeTicketId { get; set; }

        public TypeTicket TypeTicket { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}