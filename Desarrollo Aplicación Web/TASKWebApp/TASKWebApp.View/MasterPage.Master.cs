﻿using System;
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
                    LoadName(user);
                    LoadNumberOfPendentTasks(user);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadName (User user)
        {
            string name = string.Format("{0} {1}", user.FirstName, user.LastName);
            lblName.Text = name;
        }

        private void LoadNumberOfPendentTasks(User user)
        {
            int pendentTasks = user.GetNumberOfPendentTasks();
            if (pendentTasks > 0)
            {
                lblCantidadTareasAsignadas.Text = string.Format("({0})", pendentTasks);
            }
        }
    }
}