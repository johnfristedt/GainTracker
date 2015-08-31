using AutoMapper;
using GainTracker.Models.Contexts;
using GainTracker.Models.EntityModels;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GainTracker.Models.Repositories
{
    public class DbGainTrackerRepository : IGainTrackerRepository
    {
        const string LOCALDB = "GainTrackerLocalDB";
        const string LIVEDB = "GainTrackerLiveDB";
        const string ACTIVE_CONNECTION = LIVEDB;

        public ViewModels.ProfileIndexViewModel GetProfileViewModel(string userName)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                var vm = new ProfileIndexViewModel
                {
                    TrackedData = db.TrackedData.Where(u => u.UserName == userName).ToList()
                };

                foreach (var item in vm.TrackedData)
                {
                    item.DataPoints = db.DataPoints.Where(d => d.TrackedDataId == item.Id).ToArray();
                    item.DataPointValues = item.DataPoints.Select(d => d.Value).ToArray();
                }

                return vm;
            }
        }


        public void AddTrackedData(CreateTrackedDataViewModel model)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                db.TrackedData.Add(Mapper.Map<TrackedData>(model));
                db.SaveChanges();
            }
        }


        public void AddDataPoint(CreateDataPointViewModel model)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                db.DataPoints.Add(Mapper.Map<DataPoint>(model));
                db.SaveChanges();
            }
        }
    }
}