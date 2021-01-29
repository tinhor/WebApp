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
    public partial class _Project_Add : Page
    {
        public IList<User> TeamLeaders { get; set; }
        public IList<Client> Clients { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            TeamLeaders = Models.User.GetAllTeamLeaders();
            Clients = Models.Client.GetAll();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();

            listProjectTeamLeader.Items.Clear();
            listProjectClient.Items.Clear();

            foreach (var client in Clients)
            {
               listProjectClient.Items.Add(new ListItem(client.ToString(), client.IDClient.ToString()));
            }            
            
            foreach (var leader in TeamLeaders)
            {
                listProjectTeamLeader.Items.Add(new ListItem(leader.ToString(), leader.IDWorker.ToString()));
            }
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

        protected void btnNewProject_Click(object sender, EventArgs e)
        {
            var title = txtProjectTitle.Text.Trim();
            var client = listProjectClient.SelectedValue;
            var teamleader = listProjectTeamLeader.SelectedValue;

            var msg = Models.Project.New(title, int.Parse(client), int.Parse(teamleader));
            lblSystemMessage.Text = msg;
        }
    }
}