using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ses"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            if (user.Authenticate() == true)
            {
                user.ReadByEmail();
                Session["ses"] = user;
                RememberMe();
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Ingrese credenciales válidas";
            }
        }

        public void RememberMe()
        {
            if (cbxrecuerdame != null && cbxrecuerdame.Checked == true)
            {
                int timeout = cbxrecuerdame.Checked ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.
                var ticket = new FormsAuthenticationTicket(txtEmail.Text, cbxrecuerdame.Checked, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
                cookie.HttpOnly = true; // cookie not available in javascript.
                Response.Cookies.Add(cookie);
            }
        }
    }
}