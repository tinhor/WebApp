﻿using Administracija.Models;
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
    public partial class _Project_Users : Page
    {
        public IList<User> AvailableUsers { get; set; }
        public IList<User> ProjectUsers { get; set; }
        public Project EditingProject { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();
            EditingProject = Repo.GetProject(int.Parse(Request.QueryString["Id"]));
            AvailableUsers = Repo.AllWorkersNotAssignedToProject(int.Parse(Request.QueryString["Id"]));
            ProjectUsers = Repo.AllUsersOnProject(int.Parse(Request.QueryString["Id"]));

            workerList.Items.Clear();
            workerList.DataSource = AvailableUsers;
            workerList.DataTextField = "Email_address";
            workerList.DataValueField = "IDWorker";
            workerList.DataBind();

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

        protected void btnAddUserToProject_Click(object sender, EventArgs e)
        {
            var projectID = Request.QueryString["Id"];
            var userID = workerList.SelectedValue;

            var msg = Models.Project.AssignUser(int.Parse(projectID), int.Parse(userID));
            lblSystemMessage.Text = msg;
        }
    }
}