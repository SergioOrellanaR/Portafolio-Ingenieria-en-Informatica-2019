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
        static int val;
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
            
            if (txtCodigo.Text.ToUpper() == passRecover.Code)
            {
                Session["Email"] = passRecover.Email;
                Response.Redirect("NuevaContraseña.aspx");
            }
            else
            {
                val++;
                int result = 3 - val;
                if (result > 0)
                {
                    lblErrorMessage.Text = "Código incorrecto: Intentos restantes: " + result;
                }
                else
                {
                    val = 0;
                    Session["InternalPassSession"] = new PassRecover { NumberOfTries = 3, LastTry = DateTime.Now };
                    Response.Redirect("RecuperarContraseña.aspx");
                }
            }
        }
    }
}