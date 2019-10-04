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
            if (!IsPostBack)
            {
                LoadDefaultData();
            }
            
        }

        private void LoadDefaultData()
        {
            LoadResponsibles();
            LoadDefaultHours();
            //LoadWeekDays();
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
                //ShowDivDependencies(false);
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
                    //ShowDivDependencies(true);
                }
                else
                {
                    //ShowDivDependencies(false);
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
                    //ShowDivDependencies(true);
                }
                else
                {
                    //ShowDivDependencies(false);
                }
            }
            else if (rbtlTipoTarea.SelectedValue == "TareaRepetitiva")
            {
                LoadUniqueTaskTypeDiv(false);
                //ShowDivDependencies(false);
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

        private TaskAssignment CreateTaskAssignment(User user)
        {
            Task task;
            if (rbtlTipoCargaTarea.SelectedValue == "TareaPredeterminada")
            {
                task = new Task(int.Parse(ddlTareasPredeterminadas.SelectedValue));
            }
            else
            {
                task = new Task()
                {
                    DependentTask = null,
                    Description = txtDescripcion.Text,
                    IsActive = false,
                    Name = txtNombreTarea.Text,
                    SuperiorTask = null,
                    IsPredefined = false
                };
            }

            TaskAssignment taskAssignment = new TaskAssignment()
            {
                AssignerUser = user,
                ReceiverUser = new User(int.Parse(ddlResponsable.SelectedValue)),
                Task = task
            };

            return taskAssignment;

        }

        private bool CreateUniqueTask(User user)
        {
            try
            {
                int AssignedTaskStatusCode = 1;
                TaskAssignment taskAssignment = CreateTaskAssignment(user);
                ProcessedTask processedTask = new ProcessedTask()
                {
                    AssignationDate = DateTime.Now,
                    Commentary = null,
                    StartDate = DateTime.Parse(txtFechaInicio.Text),
                    EndDate = DateTime.Parse(txtFechaFin.Text),
                    LoopTaskSchedule = null,
                    TaskAssignment = taskAssignment,
                    IdTaskStatus = AssignedTaskStatusCode
                };

                return ValidateTaskCreation(processedTask);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool ValidateTaskCreation (ProcessedTask processedTask)
        {
            if (processedTask.TaskAssignment.Task.Id > 0)
            {
                if (processedTask.TaskAssignment.Create() && processedTask.Create())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (processedTask.TaskAssignment.Task.Create() && processedTask.TaskAssignment.Create() && processedTask.Create())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void createRepetitiveTask(User user)
        {
            TaskAssignment taskAssignment = CreateTaskAssignment(user);
            string defaultDate = "1900-01-01";
            DateTime startTime = DateTime.Parse(defaultDate + " " + txtHoraInicio.Text);
            DateTime endTime = DateTime.Parse(defaultDate + " " + txtHoraFin.Text);

            LoopTask loopTask = new LoopTask()
            {
                TaskAssignment = taskAssignment,
                StartTime = startTime,
                EndTime = endTime,
                Isactive = true
            };

            //ToDo
            List<string> SelectedDaysOfWeek = cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
            List<string> SelectedWeeks = cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
            string SelectedDay = ddlDiaDelMes.SelectedValue;
            int? month = int.Parse(ddlMeses.SelectedValue);





        }

        protected void btnCrearTarea_Click(object sender, EventArgs e)
        {
            User user = (User)Session["ses"];
            if(rbtlTipoTarea.SelectedItem.Value == "TareaUnica")
            {
                if (CreateUniqueTask(user))
                {
                    Response.Redirect("CreacionTareaExitosa.aspx");
                }
                else
                {
                    Response.Redirect("CrearTarea.aspx");
                }
            }
            else if (rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
            {

            }
        }
        /*
protected void rbtDependencia_SelectedIndexChanged(object sender, EventArgs e)
{

}



private void ShowDivDependencies(bool value)
{
divDependencia.Visible = value;
}
*/

    }
}