﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Pricelist
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public List<TicketPrice> TicketPrices { get; set; }

        /*public Pricelist(int i, DateTime f, DateTime t)
        {
            Id = i;
            From = f;
            To = t;
        }
        public Pricelist()
        { }*/
    }
}