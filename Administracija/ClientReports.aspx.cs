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
    public partial class _ClientReports : Page
    {
        public IList<ClientReports> ReportList { get; set; }
        public IList<Client> ClientList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientList = Models.Client.GetAll();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();

            try
            {
                ReportList = ClientReports.GenerateClientReport(Request.QueryString["Client"], Request.QueryString["Start"], Request.QueryString["End"]);
                foreach (var item in ReportList.ToList())
                {
                    ClientReports.Sum += TimeSpan.Parse(item.Fulltime);
                }
            }
            catch (Exception)
            {

            }


            rpTableClients.DataSource = ReportList;
            rpTableClients.DataBind();

            ddlClient.DataSource = ClientList;
            ddlClient.DataTextField = "Title";
            ddlClient.DataValueField = "IDClient";
            ddlClient.DataBind();
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
            var client = ddlClient.SelectedValue;
            var firstDate = txtClientDatesStart.Text;
            var lastDate = txtClientDatesEnd.Text;

            new Response("ClientReports?Client=" + client + "&Start=" + firstDate + "&End=" + lastDate).Redirect();
        }
    }
}