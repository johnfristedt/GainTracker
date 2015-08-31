using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.EntityModels
{
    public class DataPoint
    {
        public int Id { get; set; }
        public int TrackedDataId { get; set; }
        public float Value { get; set; }
    }
}