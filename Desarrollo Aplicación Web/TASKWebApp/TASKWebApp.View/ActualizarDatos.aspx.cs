using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class ActualizarDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["ses"];

            if (LoadUserInformation(user))
            {
                divCambiarPass.Visible = false;
            }
        }

        private bool LoadUserInformation(User user)
        {
            try
            {
                txtNombre.Text = user.FirstName;
                txtApellido.Text = user.LastName;
                txtCargo.Text = user.GetInternalUnitName();
                txtCelular.Text = user.Phone;
                txtEmail.Text = user.Email;
                txtEmpresa.Text = user.Company;
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private bool EnteredPasswordIsValid(User user)
        {
            bool val = false;
            int minLengthPass = 6;
            int maxLengthPass = 50;
            user.Password = txtActualPass.Text;
            if(user.Authenticate() && txtNuevaPass.Text.Equals(txtRepeticionNuevaPass.Text) && txtNuevaPass.Text.Length > minLengthPass && txtNuevaPass.Text.Length < maxLengthPass)
            {
                val = true;
            }
            return val;
        }


        protected void btnEnablePassChange_Click(object sender, EventArgs e)
        {
            divCambiarPass.Visible = true;
            btnEnablePassChange.Visible = false;
        }

        private string ValidatePasswordChange(User user)
        {
            string value = null;

            if(!EnteredPasswordIsValid(user))
            {
                value = "Datos de nueva contraseña inválidos.";
            }

            return value;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            string validUpdate = null;
            User user = (User)Session["ses"];
            int phone;
            if (btnEnablePassChange.Visible == false)
            {
                string invalidPassMessage = ValidatePasswordChange(user);

                if (invalidPassMessage != null)
                {
                    validUpdate = invalidPassMessage;
                }
                else
                {
                    user.Password = txtNuevaPass.Text;
                    user.UpdatePassword();
                    validUpdate = "La contraseña ha sido actualizada";
                    if (int.TryParse(txtCelular.Text, out phone))
                    {
                        user.Phone = "+569" + phone.ToString();
                        user.Update();
                        validUpdate = "Se ha actualizado el teléfono y la contraseña";
                    }
                }
            }
            else if (int.TryParse(txtCelular.Text, out phone))
            {
                user.Phone = "+569"+phone.ToString();
                user.Update();
                validUpdate = "Se ha actualizado el teléfono";
            }
            else
            {
                validUpdate = "Datos ingresados inválidos";
            }

            lblMessage.Text = validUpdate;
        }
    }
}