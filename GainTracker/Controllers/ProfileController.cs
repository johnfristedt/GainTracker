using AutoMapper;
using GainTracker.Models.Repositories;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GainTracker.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        IGainTrackerRepository repository;

        public ProfileController(IGainTrackerRepository repository)
        {
            this.repository = repository;
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View(repository.GetProfileViewModel(Membership.GetUser().UserName));
        }

        public ActionResult AddTrackedData()
        {
            var vm = new CreateTrackedDataViewModel
            {
                UserName = Membership.GetUser().UserName
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddTrackedData(CreateTrackedDataViewModel model)
        {
            repository.AddTrackedData(model);

            return RedirectToAction("Index", "Profile");
        }

        public ActionResult AddDataPoint(int trackedDataId)
        {
            var vm = new CreateDataPointViewModel
            {
                TrackedDataId = trackedDataId
            };

            return View();
        }

        [HttpPost]
        public ActionResult AddDataPoint(CreateDataPointViewModel model)
        {
            repository.AddDataPoint(model);

            return RedirectToAction("Index", "Profile");
        }
    }
}