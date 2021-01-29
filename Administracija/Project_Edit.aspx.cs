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
    public partial class _Project_Edit : Page
    {

        public Project EditingProject { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();
            EditingProject = Repo.GetProject(int.Parse(Request.QueryString["Id"]));

            txtProjectTitle_edit.Text = EditingProject.Title.ToString();
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

        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            var projectID = Request.QueryString["Id"];
            var title = txtProjectTitle_edit.Text.Trim();

            var msg = Models.Project.Edit(int.Parse(projectID), title);
            lblSystemMessage.Text = msg;
        }
    }
}