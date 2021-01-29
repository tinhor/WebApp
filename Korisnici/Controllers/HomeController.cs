using Korisnici.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Korisnici.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Administracija.Models.Processes.Check_login();
            return View();
        }

        [HttpPost]
        public ActionResult Index(WorkerCreateSession user)
        {
            if (ModelState.IsValid)
            {
                var msg = Administracija.Models.Processes.Log_in(user.Email, user.Password);
                ViewBag.Message = msg;
            }
            return View();
        }
    }
}