using Administracija.Models;
using Korisnici.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Korisnici.Controllers
{
    public class DashboardController : Controller
    {
        public static HourViewModel WorkData { get; set; }

        // GET: Dashboard
        public ActionResult Index()
        {
            Administracija.Models.Processes.Check_status();
            return View();
        }

        // GET: Account
        public ActionResult Account()
        {
            Administracija.Models.Processes.Check_status();
            User temp = new User();
            try
            {
                temp = Administracija.Models.User.GetWorkerByID(ActiveSession.Current.ActiveUser.IDWorker);
            }
            catch (Exception)
            {

            }
            return View(temp);
        }


        [HttpPost]
        public ActionResult Account(User p)
        {
            if (ModelState.IsValid)
            {
                var msg = Administracija.Models.User.Edit(ActiveSession.Current.ActiveUser.IDWorker.ToString(), p.First_name, p.Last_name, p.Email_address, ActiveSession.Current.ActiveUser.UserLevel.ToString());
                ViewBag.Message = msg;
            }
            return View();
        }

        // GET: Tracker
        public ActionResult Tracker()
        {
            return View();
        }

        public ActionResult TrackerDetails()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetTrackerTable(string permission, string date)
        {
            WorkData = new HourViewModel(date, Administracija.Models.ActiveSession.Current.ActiveUser.IDWorker, int.Parse(permission));
            return PartialView("_HoursTable", WorkData);
        }

        [HttpPost]
        public PartialViewResult GetAdminTrackerTable(string permission, string date)
        {
            WorkData = new HourViewModel(date, Administracija.Models.ActiveSession.Current.ActiveUser.IDWorker, int.Parse(permission));
            return PartialView("_HoursTableAdmin", WorkData);
        }

        [HttpPost]
        public void StartWorker(string project)
        {
            var data = WorkData.WorkData.ToList().First(w => w.Project.IDProject == int.Parse(project));
            data.Status = 2;
            data.Date = WorkData.Date;
            Hour.CreateUpdate(data);
        }

        [HttpPost]
        public void StopWorker(string project)
        {
            var data = WorkData.WorkData.ToList().First(w => w.Project.IDProject == int.Parse(project));
            data.Status = 1;
            data.Date = WorkData.Date;
            Hour.CreateUpdate(data);
        }

        [HttpPost]
        public void UpdateWorker(string project, string worktime, string overtime)
        {
            var data = WorkData.WorkData.ToList().First(w => w.Project.IDProject == int.Parse(project));
            data.Status = 3;
            data.Worktime = TimeSpan.Parse(worktime);
            data.Overtime = TimeSpan.Parse(overtime);
            data.Date = WorkData.Date;
            Hour.CreateUpdate(data);
        }

        [HttpPost]
        public void ChangeWorker(string project, string worktime, string overtime)
        {
            var data = WorkData.WorkData.ToList().First(w => w.Project.IDProject == int.Parse(project));
            data.Status = 1;
            data.Worktime = TimeSpan.Parse(worktime);
            data.Overtime = TimeSpan.Parse(overtime);
            data.Date = WorkData.Date;
            Hour.CreateUpdate(data);
        }

        [HttpPost]
        public void FinishWorker(string project, string worktime, string overtime)
        {
            var data = WorkData.WorkData.ToList().First(w => w.Project.IDProject == int.Parse(project));
            data.Status = 4;
            data.Worktime = TimeSpan.Parse(worktime);
            data.Overtime = TimeSpan.Parse(overtime);
            data.Date = WorkData.Date;
            Hour.CreateUpdate(data);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            ActiveSession.Current.ActiveUser = null;
            Session.Abandon();
            Session.Clear();
            Response.Redirect("/");
            return View();
        }
    }
}