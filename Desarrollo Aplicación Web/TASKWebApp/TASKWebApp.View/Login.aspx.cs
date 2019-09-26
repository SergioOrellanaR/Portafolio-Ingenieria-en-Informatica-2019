using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            
            /*
            User user = new User()
            {
                Email = txtEmail.text,
                Password = t
            }


            Client client = new Client()
            {
                User = new Business.User()
                {
                    Username = txUser.Text,
                    Password = txPass.Text
                }
            };

            if (client.User.Authenticate() == true)
            {
                client.Read();
                Session["ses"] = client;
                Response.Redirect("indexLogin.aspx");
            }
            else
            {
                lblErrorMessage.Text = "Ingrese credenciales válidas";
                contact.Focus();
            }
            */
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}