using Administracija.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Korisnici.Models
{
    public class Tracker
    {
        public static IList<Tracker> ListOfTrackers { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan WorkTimeAutomatic { get; set; }
        public TimeSpan OvertTimeAutomatic { get; set; }
        public TimeSpan Worktime { get; set; }
        public TimeSpan Overtime { get; set; }
        public User Person { get; set; }

        public Tracker(DataRow row)
        {
            Person = new User { IDWorker = (int)row["WorkerID"], First_name = row["FirstName"].ToString(), Last_name = row["LastName"].ToString() };
            Date = Convert.ToDateTime(row["Date"]);
            WorkTimeAutomatic = TimeSpan.Parse(row["WorkTimeAutomatic"].ToString());
            OvertTimeAutomatic = TimeSpan.Parse(row["OvertTimeAutomatic"].ToString());
            Worktime = TimeSpan.Parse(row["Worktime"].ToString());
            Overtime = TimeSpan.Parse(row["Overtime"].ToString());
        }

        public static IList<Tracker> GetAll(int statusID) => Repo.AllHoursByStatusID(statusID);
    }
}