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
    public partial class _Worker_Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();
            listWorkLevel.Items.Clear();
            int i = 0;


            foreach (KeyValuePair<int, string> roles in UserRoles.State)
            {
               if(i++ < 3)
                {
                listWorkLevel.Items.Add(new ListItem(roles.Value, roles.Key.ToString()));
                }
            }

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

        protected void btnNewWorker_Click(object sender, EventArgs e)
        {
            var firstName = txtFirstName.Text.Trim();
            var lastName = txtLastName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = Processes.SHA512(txtPassword.Text.Trim());
            var userLevel = listWorkLevel.SelectedValue;
            var usetTeam = dllTeams.SelectedValue;
            var employeDate = txtDate.Text.Trim();

            var msg = Models.User.New(firstName, lastName, email, employeDate, password, userLevel, usetTeam);
            lblSystemMessage.Text = msg;
        }
    }
}