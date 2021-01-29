using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Hour
    {
        public int IDHour { get; set; }
        public Project Project { get; set; }
        public User Person { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Begin { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Worktime { get; set; }
        public TimeSpan Overtime { get; set; }
        public int Status { get; set; }


        public static IList<Hour> GetAll() => Repo.AllHours();


        public Hour(DataRow row)
        {
            IDHour = (int)row["IDHour"];
            Project = new Project { IDProject = (int)row["IDProject"], Title = row["ProjectTitle"].ToString() };
            Person = new User { IDWorker = (int)row["IDWorker"] };
            Date = Convert.ToDateTime(row["Date"]);
            Begin = TimeSpan.Parse(row["Begin"].ToString());
            End = TimeSpan.Parse(row["End"].ToString());
            Worktime = TimeSpan.Parse(row["Worktime"].ToString());
            Overtime = TimeSpan.Parse(row["Overtime"].ToString());
            Status = (int)row["Status"];
        }

        public Hour()
        {

        }
    }
}