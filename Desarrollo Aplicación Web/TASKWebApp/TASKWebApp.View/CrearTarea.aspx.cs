using System;
using System.Collections.Generic;
using System.Drawing;
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
            LoadResponsibles();
            LoadDefaultHours();
            LoadWeekDays();
        }

        private void LoadDefaultHours()
        {
            txtFechaInicio.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            txtFechaFin.Text = DateTime.Now.AddDays(1).ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        }

        #region Métodos tarea propia y predeterminada

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
                ShowDivDependencies(false);
            }
            else if (rbtlTipoCargaTarea.SelectedValue == "TareaPropia")
            {
                EnableButtons();
                ddlTareasPredeterminadas.Enabled = false;
                ddlTareasPredeterminadas.CssClass = "disabledStyle";
                ddlTareasPredeterminadas.Visible = false;
                EnableTaskTextbox(true);
                CleanTaskTextbox();

                if(rbtlTipoTarea.SelectedValue == "TareaUnica")
                {
                    ShowDivDependencies(true);
                }
                else
                {
                    ShowDivDependencies(false);
                }
            }
            else
            {
                throw new Exception();
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
            else
            {
                throw new Exception();
            }
        }

        private void EnableButtons()
        {
            btnCrearTarea.Visible = true;
            btnCrearFlujoTarea.Visible = true;
        }


        #endregion

        #region Métodos tarea única y repetitiva
        protected void rbtlTipoTarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtlTipoTarea.SelectedValue == "TareaUnica")
            {
                LoadUniqueTaskTypeDiv(true);
                if (rbtlTipoCargaTarea.SelectedValue == "TareaPropia")
                {
                    ShowDivDependencies(true);
                }
                else
                {
                    ShowDivDependencies(false);
                }
            }
            else if (rbtlTipoTarea.SelectedValue == "TareaRepetitiva")
            {
                LoadUniqueTaskTypeDiv(false);
                ShowDivDependencies(false);
            }
            else
            {
                Response.Redirect("CrearTarea.aspx");
            }
        }

        private void LoadUniqueTaskTypeDiv(bool val)
        {
            divTareaUnica.Visible = val;
            divTareaRepetitiva.Visible = !val;
        }

        private void LoadWeekDays()
        {

            cbxDiaSemana.Items.Clear();
            cbxDiaSemana.DataSource = ComboBoxDataLoader.DayOfWeek;
            cbxDiaSemana.DataTextField = "Value";
            cbxDiaSemana.DataValueField = "Key";
            cbxDiaSemana.DataBind();
        }

        #endregion

        private void LoadResponsibles()
        {
            ddlResponsable.Items.Clear();
            User user = (User)Session["ses"];
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(user.Id, string.Format("{0} {1} (Yo mismo)", user.FirstName, user.LastName));
            user.GetEqualsAndSubordinatedString().ToList().ForEach(x => dictionary.Add(x.Key, x.Value));
            ddlResponsable.DataSource = dictionary;
            ddlResponsable.DataTextField = "Value";
            ddlResponsable.DataValueField = "Key";
            ddlResponsable.DataBind();
        }

        protected void rbtDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void ShowDivDependencies(bool value)
        {
            divDependencia.Visible = value;
        }

        
    }
}