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
            SetCaptchaKeys();
            CanTryAgain();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            DateTime birthdate;
            if (DateTime.TryParse(txtFecha.Text, out birthdate))
            {
                PassRecover PassRecover = passRecoverSession(birthdate);
                

                if (PassRecover.IsEmailAndBirthdayCorrect() && ValidateCaptcha())
                {
                    if (HasPasswordRecoveryPermission(PassRecover))
                    {
                        string code = RandomString(5);
                        PassRecover.Code = code;
                        string message = string.Format("Usted ha solicitado una recuperación de contraseña en el sistema de ProcessSA, su código de recuperación es:" +
                            "</br>" +
                            "<h1>{0}</h1>" +
                            "</br>" +
                            "En caso que usted no haya solicitado este cambio, ignore este mensaje", code);
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
                    lblErrorMessage.Text = "El email, la fecha de nacimiento o el captcha son inválidos, número de intentos restantes: "+ (3-PassRecover.NumberOfTries);
                    CheckNumberOfTries(PassRecover.NumberOfTries);
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

        private bool ValidateCaptcha()
        {
            return ctrlGoogleReCaptcha.Validate();
        }

        private void SetCaptchaKeys()
        {
            //Keys QA
            string siteKey = "6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI";
            string privateKey = "6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe";
            //Keys ProcessSA.com
            //SiteKey= 6Lesy7oUAAAAAB2QANjL9Zk_fVDExYLydCawlRAc
            //PrivateKey= 6Lesy7oUAAAAAKyFldm-6Pqb8uhUi0OGd8Q89Gs0
            ctrlGoogleReCaptcha.PublicKey = siteKey;
            ctrlGoogleReCaptcha.PrivateKey = privateKey;
        }

        private PassRecover passRecoverSession (DateTime birthdate)
        {
            PassRecover passRecover;
            if(Session["InternalPassSession"] == null)
            {
                passRecover = new PassRecover()
                {
                    Email = txtEmail.Text,
                    Birthdate = birthdate
                };
            }
            else
            {
                passRecover = (PassRecover)Session["InternalPassSession"];
            }
            passRecover.NumberOfTries++;
            passRecover.LastTry = DateTime.Now;
            Session["InternalPassSession"] = passRecover;
            return passRecover;
        }

        private void CheckNumberOfTries(int tries)
        {
            if(tries>=3)
            {
                Session["ExcessError"] = "Ha excedido el número de intentos, intente nuevamente en 5 minutos";
                Response.Redirect("Login.aspx");
            }
        }

        public void CanTryAgain()
        {
            if(Session["InternalPassSession"] != null)
            {
                PassRecover passRecover = (PassRecover)Session["InternalPassSession"];
                TimeSpan span = DateTime.Now.Subtract(passRecover.LastTry);
                if (passRecover.NumberOfTries > 2)
                {
                    if(span.TotalMinutes > 4)
                    {
                        Session["InternalPassSession"] = null;
                    }
                    else
                    {
                        Session["ExcessError"] = "Intente nuevamente en "+ (5-((int)(span.TotalMinutes))).ToString() + " minutos";
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
    }
}