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
    public partial class _Worker_Edit : Page
    {
        public User EditingUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();
            EditingUser = Repo.GetUser(int.Parse(Request.QueryString["Id"]));

            listWorkLevel_edit.Items.Clear();
            int i = 0;

            foreach (KeyValuePair<int, string> roles in UserRoles.State)
            {
                if (i++ < 4)
                {
                    listWorkLevel_edit.Items.Add(new ListItem(roles.Value, roles.Key.ToString()));
                }
            }

            txtFirstName_edit.Text = EditingUser.First_name.ToString();
            txtLastName_edit.Text = EditingUser.Last_name.ToString(); ;
            txtEmail_edit.Text = EditingUser.Email_address.ToString(); ;
            listWorkLevel_edit.SelectedValue = EditingUser.UserLevel.ToString();

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

        protected void btnUpdateWorker_Click(object sender, EventArgs e)
        {
            var userid = Request.QueryString["Id"];
            var firstName = txtFirstName_edit.Text.Trim();
            var lastName = txtLastName_edit.Text.Trim();
            var email = txtEmail_edit.Text.Trim();
            var userLevel = listWorkLevel_edit.SelectedValue;

            System.Diagnostics.Debug.WriteLine(firstName);

            var msg = Models.User.Edit(userid, firstName, lastName, email, userLevel);
            lblSystemMessage.Text = msg;

        }
    }
}