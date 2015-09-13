﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class StatisticListViewModel
    {
        public DateTime Date { get; set; }
        public int Visitors { get; set; }
        [Display(Name="Unique visitors")]
        public int UniqueVisitors { get; set; }
        [Display(Name="Registered users")]
        public int RegisteredUsers { get; set; }
        public string RegPerVisit { get; set; }
        public StatisticViewModel[] Items { get; set; }

        public void Initialize()
        {
            if (UniqueVisitors != 0)
                RegPerVisit = String.Format("{0:0.0%}", (double)RegisteredUsers / (double)UniqueVisitors);
            else
                RegPerVisit = "0%";
        }
    }
}