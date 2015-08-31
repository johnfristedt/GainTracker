using GainTracker.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class ProfileIndexViewModel
    {
        public List<TrackedData> TrackedData { get; set; }
    }
}