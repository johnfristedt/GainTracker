using AutoMapper;
using GainTracker.Models.Repositories;
using GainTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GainTracker.Controllers
{
    public class AdminController : Controller
    {
        IGainTrackerRepository repository;

        public AdminController(IGainTrackerRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles="Admins")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExercise(CreateExerciseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddExercise(model);

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult ViewExercises()
        {
            return View(Mapper.Map<ExerciseViewModel[]>(repository.GetExercises()));
        }

        public ActionResult ViewStatistics()
        {
            return View(repository.GetStatistics());
        }
    }
}