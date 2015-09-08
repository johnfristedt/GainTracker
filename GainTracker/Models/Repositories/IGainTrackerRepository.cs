using GainTracker.Models.EntityModels;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GainTracker.Models.Repositories
{
    public interface IGainTrackerRepository
    {
        #region Profile
        ProfileIndexViewModel GetProfileViewModel(string userName);
        void AddTrackedData(CreateTrackedDataViewModel model);
        void AddDataPoint(CreateDataPointViewModel model);
        #endregion

        #region Admin
        void AddExercise(CreateExerciseViewModel model);
        Exercise[] GetExercises();
        #endregion

        #region Site statistics
        void AddStatistic(CreateStatisticModel model);
        StatisticListViewModel[] GetStatistics();
        bool CheckIP(string address);
        bool CheckRegister(string address);
        bool CheckLogin(string address);
        #endregion
    }
}
