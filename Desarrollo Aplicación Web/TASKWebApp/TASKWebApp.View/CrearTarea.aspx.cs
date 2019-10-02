using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business;
using TASKWebApp.Business.Classes;
using TASKWebApp.Business.Helpers;

namespace TASKWebApp.View
{
    public partial class CrearTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDefaultData();
        }

        private void LoadDefaultData()
        {
            LoadDefaultHours();
        }

        private void LoadDefaultHours()
        {
            txtFechaInicio.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            txtFechaFin.Text = DateTime.Now.AddDays(1).ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        }

        #region Métodos tarea única y predeterminada

        private void LoadPredefinedTask()
        {
            CleanPredefinedTasks();
            ddlTareasPredeterminadas.DataSource = ComboBoxDataLoader.GetPredefinedTasks();
            ddlTareasPredeterminadas.DataTextField = "Value";
            ddlTareasPredeterminadas.DataValueField = "Key";
            ddlTareasPredeterminadas.DataBind();
        }

        protected void ddlTareasPredeterminadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPredefinedTaskInformation();
        }

        private void EnableTaskTextbox(bool value)
        {
            txtNombreTarea.Enabled = value;
            txtDescripcion.Enabled = value;
        }

        private void CleanTaskTextbox()
        {
            txtNombreTarea.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        protected void rbtlTipoCargaTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(rbtlTipoCargaTarea.SelectedValue == "TareaPredeterminada")
            {
                ddlTareasPredeterminadas.Enabled = true;
                ddlTareasPredeterminadas.CssClass = "enabledStyle";
                ddlTareasPredeterminadas.Visible = true;
                LoadPredefinedTask();
                LoadPredefinedTaskInformation();
            }
            else
            {
                EnableButtons();
                ddlTareasPredeterminadas.Enabled = false;
                ddlTareasPredeterminadas.CssClass = "disabledStyle";
                ddlTareasPredeterminadas.Visible = false;
                EnableTaskTextbox(true);
                CleanTaskTextbox();
            }
        }

        private void CleanPredefinedTasks()
        {
            ddlTareasPredeterminadas.Items.Clear();
        }

        private void LoadPredefinedTaskInformation()
        {
            int ParsedInt;
            if (int.TryParse(ddlTareasPredeterminadas.SelectedValue, out ParsedInt))
            {
                Task task = new Task(ParsedInt);
                string description = task.Description;
                txtNombreTarea.Text = task.Name;
                EnableTaskTextbox(false);

                if (task.HaveChilds())
                {
                    description += "\n \nEsta tarea pertenece a un flujo de tareas.";
                    btnCrearFlujoTarea.Visible = true;
                    btnCrearTarea.Visible = false;
                }
                else
                {
                    btnCrearFlujoTarea.Visible = false;
                    btnCrearTarea.Visible = true;
                }
                txtDescripcion.Text = description;
            }
        }

        private void EnableButtons()
        {
            btnCrearTarea.Visible = true;
            btnCrearFlujoTarea.Visible = true;
        }

        #endregion
    }
}