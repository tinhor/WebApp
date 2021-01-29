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
    public partial class _Client_Delete : Page
    {
        public Client EditingUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Processes.Check_status();

            try
            {
                EditingUser = Repo.GetClient(int.Parse(Request.QueryString["Id"]));
                deleteUser.Text = EditingUser.ToString();
            }
            catch (Exception)
            {
                Response.Redirect("Clients.aspx");
                throw;
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

        protected void btnDeleteClient_Click(object sender, EventArgs e)
        {
            var userid = Request.QueryString["Id"];
            var msg = Models.Client.Delete(userid);
            lblSystemMessage.Text = msg;
        }
    }
}