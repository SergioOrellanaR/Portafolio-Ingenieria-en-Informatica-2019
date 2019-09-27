using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;
using TASKWebApp.Business.Helpers;

namespace TASKWebApp.View
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        private static Random random = new Random();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime birthdate;
            if (DateTime.TryParse(txtFecha.Text, out birthdate))
            {
                PassRecover PassRecover = new PassRecover()
                {
                    Email = txtEmail.Text,
                    Birthdate = birthdate
                };

                if (PassRecover.IsEmailAndBirthdayCorrect())
                {
                    if (HasPasswordRecoveryPermission(PassRecover))
                    {
                        string code = RandomString(5);
                        PassRecover.Code = code;
                        string message = string.Format("Usted ha solicitado una recuperación de contraseña, su código de recuperación es:" +
                            "</br>" +
                            "<h1>{0}</h1>" +
                            "</br>" +
                            "O puede dirigirse al siguiente link: XXXX ", code);
                        SMTPHelper SMTPHelper = new SMTPHelper("processsasmtp@gmail.com", PassRecover.Email, message, "Recuperación de contraseña", null);

                        if (SMTPHelper.enviaMail())
                        {
                            Session["PassRecover"] = PassRecover;
                            Response.Redirect("CodigoContraseña.aspx");
                        }
                        else
                            lblErrorMessage.Text = "Error del servidor al enviar el mensaje, contacte al administrador";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Su cuenta no posee el permiso de recuperar contraseña";
                    }
                    
                }
                else
                {
                    lblErrorMessage.Text = "El email o la fecha de nacimiento ingresada no es correcta, número de intentos restantes: X";
                }
            }
            else
            {
                lblErrorMessage.Text = "Error en lectura de fecha";
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private bool HasPasswordRecoveryPermission(PassRecover passRecover)
        {
            int idPasswordRecoverPermission = 34;
            return passRecover.HasPermission(idPasswordRecoverPermission);
        }
    }
}