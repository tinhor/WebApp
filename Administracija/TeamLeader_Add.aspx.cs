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
    public partial class _TeamLeader_Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();

            dllTeams.DataSource = Team.GetAllTeams();
            dllTeams.DataTextField = "Title";
            dllTeams.DataValueField = "IDTeam";
            dllTeams.DataBind();
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

        protected void btnNewTeamLeader_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = Processes.SHA512(txtPassword.Text.Trim());
            var employeDate = txtDate.Text.Trim();
            var usetTeam = dllTeams.SelectedValue;

            var msg = Models.User.New(firstName, lastName, email, employeDate, password, "4", usetTeam);
            lblSystemMessage.Text = msg;
        }
    }
}