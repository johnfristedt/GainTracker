using GainTracker.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GainTracker.Models.AjaxModels
{
    public class AddExerciseViewModel
    {
        public SelectListItem[] Exercises { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}