using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class TeamReports
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string Worktime { get; set; }
        public string Overtime { get; set; }

        public TeamReports(DataRow row)
        {
            FullName = row["FullName"].ToString();
            Date = DateTime.Parse(row["Date"].ToString());
            Worktime = row["Worktime"].ToString();
            Overtime = row["Overtime"].ToString();
        }

        public static IList<TeamReports> GenerateTeamReport(string team, string start, string end) => Repo.AllTeamReports(team, start, end);
    }
}