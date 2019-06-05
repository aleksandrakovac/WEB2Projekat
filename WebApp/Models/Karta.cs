using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Karta
    {
        public int Id { get; set; }

        [Required]
        public double Cijena { get; set; } 

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}