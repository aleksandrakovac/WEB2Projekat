using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Linija
    {
        public int Id { get; set; }
        [Required]
        public int SerijskiBroj { get; set; }
        public List<Vozilo> Vozila { get; set; }
        public List<Stanica> Stanice { get; set; }
        public List<Polazak> VremenskeTable { get; set; }
    }
}