using GainTracker.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GainTracker.Models.Contexts
{
    public class GainTrackerContext : DbContext
    {
        public DbSet<TrackedData> TrackedData { get; set; }
        public DbSet<DataPoint> DataPoints { get; set; }

        public GainTrackerContext()
        {

        }

        public GainTrackerContext(string connection)
            : base(connection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackedData>().ToTable("TrackedData");
            modelBuilder.Entity<DataPoint>().ToTable("DataPoints");
        }
    }
}