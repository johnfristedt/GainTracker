using AutoMapper;
using GainTracker.Helpers;
using GainTracker.Models;
using GainTracker.Models.AjaxModels;
using GainTracker.Models.Contexts;
using GainTracker.Models.EntityModels;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GainTracker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.CreateMap<CreateTrackedDataViewModel, TrackedData>();
            Mapper.CreateMap<CreateDataPointViewModel, DataPoint>();
            Mapper.CreateMap<CreateStatisticModel, Statistic>();
            Mapper.CreateMap<CreateExerciseViewModel, Exercise>();
            Mapper.CreateMap<Exercise, AddExerciseViewModel>();

            Mapper.CreateMap<Statistic, StatisticViewModel>()
                .ForMember(vm => vm.Type, opt => opt.MapFrom(src => Enum.GetName(typeof(StatisticsHelper.StatisticTypes), src.Type)));
        }
    }
}
