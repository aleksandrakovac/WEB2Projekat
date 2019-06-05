using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Vozilo
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int LinijaId { get; set; }
        public Linija Linija { get; set; }

    }
}