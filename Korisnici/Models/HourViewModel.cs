using Administracija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Korisnici.Models
{
    public class HourViewModel
    {
        private IList<Project> projectRepo;
        private IList<Hour> hourRepo;

        public int Permission { get; set; }
        protected IList<Project> ProjectList { get; set; }
        protected IList<Hour> WorkList { get; set; }
        public DateTime Date { get; set; }
        public IList<Hour> WorkData { get; set; }

        public TimeSpan CalculatedTime { get; set; }
        public TimeSpan CalculatedWorktime { get; set; }
        public TimeSpan CalculatedOvertime { get; set; }

        public HourViewModel(string date, int userID, int permission)
        {
            Permission = permission;
            Date = DateTime.Parse(date);

            projectRepo = Project.GetAll();
            hourRepo = Hour.GetAllByID();

            WorkData = new List<Hour>();
            ProjectList = new List<Project>();
            CalculatedTime = TimeSpan.Zero;
            CalculatedWorktime = TimeSpan.Zero;
            CalculatedOvertime = TimeSpan.Zero;

            ProjectList = Project.GetAllByPersonID(Administracija.Models.ActiveSession.Current.ActiveUser.IDWorker);
            WorkList = Hour.GetAllByDate(date, userID, string.Join(";", ProjectList.Select(c => c.IDProject.ToString()).ToArray<string>()));
            GenerateData();

            WorkData.ToList().ForEach(d => CalculatedTime += d.WorkTimeAutomatic);
            WorkList.ToList().ForEach(d => CalculatedWorktime += d.Worktime);
            WorkList.ToList().ForEach(d => CalculatedOvertime += d.Overtime);

        }

        private void GenerateData()
        {
            foreach (var project in ProjectList)
            {
                Hour hourData = new Hour();
                try
                {
                    hourData = WorkList.First(w => w.Project.IDProject == project.IDProject);
                }
                catch (Exception)
                {
                    hourData.Status = 1;
                    hourData.Person = Administracija.Models.ActiveSession.Current.ActiveUser;
                    hourData.Project = project;
                }


                WorkData.Add(hourData);
            }
        }
    }
}