using GainTracker.Helpers;
using GainTracker.Models;
using GainTracker.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GainTracker.Controllers
{
    public class HomeController : Controller
    {
        IGainTrackerRepository repository;

        public HomeController(IGainTrackerRepository repository)
        {
            this.repository = repository;
        }

        // GET: Index
        public ActionResult Index()
        {
            string address = Request.UserHostAddress;
            //int type = repository.CheckIP(address) ? (int)StatisticsHelper.StatisticTypes.Visitor : (int)StatisticsHelper.StatisticTypes.UniqueVisitor;

            //repository.AddStatistic(new CreateStatisticModel
            //{
            //    Type = type,
            //    Time = DateTime.Now,
            //    IPAddress = address
            //});

            return View();
        }
    }
}