using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CijenaKarte
    {
        public int Id { get; set; }
        [Required]
        public double Cijena { get; set; }
        public Cjenovnik Cjenovnik { get; set; }
        public int CjenovnikId { get; set; }
        public TipKarte TipKarte { get; set; }
        public int TipKarteId { get; set; }
    }
}