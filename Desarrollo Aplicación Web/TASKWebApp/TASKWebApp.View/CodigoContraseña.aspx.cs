using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    

    public partial class CodigoContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PassRecover"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PassRecover passRecover;
            passRecover = (PassRecover)Session["PassRecover"];
            Session["PassRecover"] = null;
            if (txtCodigo.Text.ToUpper() == passRecover.Code)
            {
                Session["Email"] = passRecover.Email;
                Response.Redirect("NuevaContraseña.aspx");
            }
            else
            {
                lblErrorMessage.Text= "Código incorrecto: Intentos restantes: X";
            }
        }
    }
}