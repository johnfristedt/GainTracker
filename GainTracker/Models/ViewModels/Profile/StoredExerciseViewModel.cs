using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.ViewModels
{
    public class StoredExerciseViewModel
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}