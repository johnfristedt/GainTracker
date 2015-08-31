using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.EntityModels
{
    public class TrackedData
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DataPoint[] DataPoints { get; set; }
        public float[] DataPointValues { get; set; }
    }
}