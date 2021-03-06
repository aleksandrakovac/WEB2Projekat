﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Line
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int StationId { get; set; }
        public string Direction { get; set; }
        public List<Station> Stations { get; set; }
        public List<Timetable> Timetables { get; set; }

    }
}