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
        ProfileIndexViewModel GetProfileViewModel(string userName);
        void AddTrackedData(CreateTrackedDataViewModel model);
        void AddDataPoint(CreateDataPointViewModel model);
        void AddStatistic(CreateStatisticModel model);
        bool CheckIP(string address);
        bool CheckRegister(string address);
        bool CheckLogin(string address);
    }
}
