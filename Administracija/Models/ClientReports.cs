using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class ClientReports
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Fulltime { get; set; }
        public static TimeSpan Sum = TimeSpan.Zero;

        public ClientReports(DataRow row)
        {
            Title = row["Title"].ToString();
            Date = DateTime.Parse(row["Date"].ToString());
            Fulltime = row["Worktime"].ToString();
        }

        public static IList<ClientReports> GenerateClientReport(string client, string start, string end) => Repo.AllClientReports(client, start, end);
    }
}