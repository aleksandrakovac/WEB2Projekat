using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Polazak
    {
        public int Id { get; set; }

        public int TipPolaskaId { get; set; }
        public TipPolaska TipPolaska { get; set; }

        public int DanUNedeljiId { get; set; }
        public DanUNedelji DanUNedelji { get; set; }

        public int LinijaId { get; set; }
        public Linija Linija { get; set; }


        public String Vremena { get; set; }
    }
}