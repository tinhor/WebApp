using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Hour
    {
        public int IDWorking { get; set; }
        public Project Project { get; set; }
        public User Person { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan WorkTimeAutomatic { get; set; }
        public TimeSpan OvertTimeAutomatic { get; set; }
        public TimeSpan Worktime { get; set; }
        public TimeSpan Overtime { get; set; }
        public int Status { get; set; }

        public static IList<Hour> GetAll() => Repo.AllHours();
        public static IList<Hour> GetAllByID() => Repo.AllHoursByUserID();
        public static bool CreateUpdate(Hour data) => Repo.UpdateHours(data);

        public Hour(DataRow row)
        {
            IDWorking = (int)row["IDWorking"];
            Project = new Project { IDProject = (int)row["ProjectID"], Title = row["Title"].ToString() };
            Person = new User { IDWorker = (int)row["WorkerID"] };
            Date = Convert.ToDateTime(row["Date"]);
            WorkTimeAutomatic = TimeSpan.Parse(row["WorkTimeAutomatic"].ToString());
            OvertTimeAutomatic = TimeSpan.Parse(row["OvertTimeAutomatic"].ToString());
            Worktime = TimeSpan.Parse(row["Worktime"].ToString());
            Overtime = TimeSpan.Parse(row["Overtime"].ToString());
            Status = (int)row["StatusID"];
        }

        internal static IList<Hour> GetAllByDate(string date, int userID, string v) => Repo.AllHoursByDate(date, userID, v);

        public Hour()
        {

        }
    }
}