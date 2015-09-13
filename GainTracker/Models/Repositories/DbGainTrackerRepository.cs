using AutoMapper;
using GainTracker.Helpers;
using GainTracker.Models.Contexts;
using GainTracker.Models.EntityModels;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace GainTracker.Models.Repositories
{
    public class DbGainTrackerRepository : IGainTrackerRepository
    {
        const string LOCALDB = "GainTrackerLocalDB";
        const string TIMMILOCALDB = "TimmiLocalDB";
        const string LIVEDB = "GainTrackerLiveDB";
        const string SERVERDB = "GainTrackerDB";
        const string ACTIVE_CONNECTION = SERVERDB;

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

                vm.CreateTrackedViewModel = new CreateTrackedDataViewModel
                {
                    UserName = Membership.GetUser().UserName
                };

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

        #region Admin

        public void AddExercise(CreateExerciseViewModel model)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                db.Exercises.Add(Mapper.Map<Exercise>(model));
                db.SaveChanges();
            }
        }

        public Exercise[] GetExercises()
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                return db.Exercises.ToArray();
            }
        }

        #endregion

        #region Site statistics

        public void AddStatistic(CreateStatisticModel model)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                db.Statistics.Add(Mapper.Map<Statistic>(model));
                db.SaveChanges();
            }
        }

        public StatisticListViewModel[] GetStatistics()
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                var em = db.Statistics.OrderByDescending(s => s.Time).ToArray();
                List<StatisticListViewModel> vm = new List<StatisticListViewModel>();

                foreach (var item in em)
                {
                    if (String.Equals(item.IPAddress, "::1"))
                        continue;

                    if (vm.Count == 0 || vm.Last().Date != item.Time.Date)
                    {
                        var vmItem = new StatisticListViewModel
                        {
                            Date = item.Time.Date,
                            Visitors = em.Where(v => v.Time.Date == item.Time.Date).Where(v => v.Type == (int)StatisticsHelper.StatisticTypes.Visitor || v.Type == (int)StatisticsHelper.StatisticTypes.UniqueVisitor).Count(),
                            UniqueVisitors = em.Where(v => v.Time.Date == item.Time.Date).Where(v => v.Type == (int)StatisticsHelper.StatisticTypes.UniqueVisitor).Count(),
                            RegisteredUsers = em.Where(v => v.Time.Date == item.Time.Date).Where(v => v.Type == (int)StatisticsHelper.StatisticTypes.Register).Count(),
                            Items = Mapper.Map<StatisticViewModel[]>(em.Where(v => v.Time.Date == item.Time.Date).OrderByDescending(v => v.Time).ToArray())
                        };

                        vmItem.Initialize();

                        vm.Add(vmItem);
                    }
                }

                return vm.ToArray();
            }
        }

        public bool CheckIP(string address)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                if (db.Statistics.FirstOrDefault(s => s.IPAddress == address) != null)
                    return true;

                return false;
            }
        }


        public bool CheckRegister(string address)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                if (db.Statistics.FirstOrDefault(
                        s => s.Type == (int)StatisticsHelper.StatisticTypes.Register && s.IPAddress == address) != null)
                    return true;

                return false;
            }
        }

        public bool CheckLogin(string address)
        {
            using (var db = new GainTrackerContext(ACTIVE_CONNECTION))
            {
                if (db.Statistics.FirstOrDefault(
                        s => s.Type == (int)StatisticsHelper.StatisticTypes.Login && s.IPAddress != address) == null)
                    return true;

                return false;
            }
        }

        #endregion
    }
}