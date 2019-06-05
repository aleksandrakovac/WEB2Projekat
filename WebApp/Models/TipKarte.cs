using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipKarte
    {
       public int Id { get; set; }
       [Required]
       public string Ime { get; set; }
}