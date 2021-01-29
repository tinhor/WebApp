using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Administracija.Models
{
    public class Team
    {
        public int IDTeam { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public Team(DataRow row)
        {
            IDTeam = (int)row["IDTeam"];
            Title = row["Title"].ToString();
            Date = Convert.ToDateTime(row["CreationDate"]);
        }

        public override string ToString() => $"{Title}";

        public static IList<Team> GetAllTeams() => Repo.AllTeams();
    }

}