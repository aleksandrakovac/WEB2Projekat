﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipPolaska
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }

        public List<Polazak> Polasci { get; set; }

    }
}