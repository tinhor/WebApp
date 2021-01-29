using Administracija.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracija
{
    public partial class _TeamReports : Page
    {
        public IList<TeamReports> ReportList { get; set; }
        public IList<Team> TeamList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamList = Models.Team.GetAllTeams();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();

            try
            {
                ReportList = TeamReports.GenerateTeamReport(Request.QueryString["Team"], Request.QueryString["Start"], Request.QueryString["End"]);
            }
            catch (Exception)
            {

            }


            rpTableClients.DataSource = ReportList;
            rpTableClients.DataBind();

            ddlTeam.DataSource = TeamList;
            ddlTeam.DataTextField = "Title";
            ddlTeam.DataValueField = "IDTeam";
            ddlTeam.DataBind();
        }

        protected override void InitializeCulture()
        {
            if(Session["lang"] != null)
            {
                Culture = Session["lang"].ToString();
                UICulture = Session["lang"].ToString();

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["lang"].ToString());
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(Session["lang"].ToString());

                base.InitializeCulture();
            }
        }

        protected void btnClientReport_Click(object sender, EventArgs e)
        {
            var team = ddlTeam.SelectedValue;
            var firstDate = txtClientDatesStart.Text;
            var lastDate = txtClientDatesEnd.Text;

            new Response("TeamReports?Team=" + team + "&Start=" + firstDate + "&End=" + lastDate).Redirect();
        }
    }
}