using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ses"] != null)
                {
                    User user = (User)Session["ses"];
                    loadName(user);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void loadName (User user)
        {
            string name = string.Format("{0} {1}", user.FirstName, user.LastName);
            lblName.Text = name;
        }
    }
}