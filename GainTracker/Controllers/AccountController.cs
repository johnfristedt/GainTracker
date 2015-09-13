using GainTracker.Helpers;
using GainTracker.Models;
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
    public class AccountController : Controller
    {
        IGainTrackerRepository repository;

        public AccountController(IGainTrackerRepository repository)
        {
            this.repository = repository;
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            else if (Membership.GetUser(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "A user with that name already exists");
                return View(model);
            }
            else if (Membership.FindUsersByEmail(model.Email).Count > 0)
            {
                var user = Membership.FindUsersByEmail(model.Email);
                ModelState.AddModelError("Email", "A user with that e-mail already exists");
                return View(model);
            }

            Membership.CreateUser(model.UserName, model.Password, model.Email);
            Roles.AddUserToRole(model.UserName, "Users");

            FormsAuthentication.SetAuthCookie(model.UserName, true);

            repository.AddStatistic(new CreateStatisticModel
            {
                Type = (int)StatisticsHelper.StatisticTypes.Register,
                Time = DateTime.Now,
                IPAddress = Request.UserHostAddress,
                UserName = model.UserName,
                Email = model.Email
            });

            return RedirectToAction("Index", "Profile");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!Membership.ValidateUser(model.UserName, model.Password))
            {
                ModelState.AddModelError("UserName", "Incorrect user name or password");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(model.UserName, true);

            repository.AddStatistic(new CreateStatisticModel
            {
                Type = (int)StatisticsHelper.StatisticTypes.Login,
                Time = DateTime.Now,
                IPAddress = Request.UserHostAddress
            });

            return RedirectToAction("Index", "Profile");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}