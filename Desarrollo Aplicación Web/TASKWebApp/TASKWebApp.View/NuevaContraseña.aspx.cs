using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class NuevaContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string sesEmail;
            sesEmail = Session["Email"].ToString();
            Session["Email"] = null;
            int minLength = 8;
            int maxLength = 50;
            //Entre 8 y 50 letras
            if(txtPass.Text == txtConfirmPass.Text && txtPass.Text.Length>= minLength && txtPass.Text.Length <= maxLength)
            {
                User user = new User() { Email = sesEmail, Password = txtPass.Text };
                if (user.UpdatePassword())
                    Response.Redirect("Login.aspx");
                else
                    lblErrorMessage.Text = "Ha ocurrido un error en el sistema, contacte al administrador";
            }
            else
            {
                lblErrorMessage.Text = "Verifique que las contraseñas coincidan y que la cantidad de caractéres es igual o mayor a 8";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}