﻿using System;
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
                LoadDayWeekOrMonthInfo();
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

        private ProcessedTask CreateUniqueFlowTask(User user)
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

                return processedTask;
            }
            catch (Exception e)
            {
                return null;
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

        private List<LoopTaskSchedule> CreateRepetitiveTaskFlow(User user)
        {
            List<LoopTaskSchedule> ltsList = new List<LoopTaskSchedule>();
            int month = int.Parse(ddlMeses.SelectedValue);
            if (rbtlTipoRepeticion.SelectedValue == "diaSemana")
            {
                List<string> selectedDaysOfWeek = cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
                List<string> selectedWeeks = cbxNumeroSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();


                if (selectedWeeks.Count > 0 && selectedWeeks.Count < 6)
                {
                    foreach (string dayOfWeek in selectedDaysOfWeek)
                    {
                        foreach (string numberOfWeek in selectedWeeks)
                        {
                            LoopTaskSchedule lts = new LoopTaskSchedule()
                            {
                                LoopTask = null,
                                DayOfMonth = null,
                                DayOfWeek = int.Parse(dayOfWeek),
                                NumberOfWeek = int.Parse(numberOfWeek),
                                IdMonth = month
                            };
                            ltsList.Add(lts);
                        }

                    }
                }
                else
                {
                    foreach (string dayOfWeek in selectedDaysOfWeek)
                    {
                        LoopTaskSchedule lts = new LoopTaskSchedule()
                        {
                            LoopTask = null,
                            DayOfMonth = null,
                            DayOfWeek = int.Parse(dayOfWeek),
                            NumberOfWeek = null,
                            IdMonth = month
                        };

                        ltsList.Add(lts);
                    }
                }

                return ltsList;

            }
            else if (rbtlTipoRepeticion.SelectedValue == "diaMes")
            {
                string SelectedDay = ddlDiaDelMes.SelectedValue;
                LoopTaskSchedule lts = new LoopTaskSchedule()
                {
                    LoopTask = null,
                    DayOfWeek = null,
                    NumberOfWeek = null,
                    DayOfMonth = int.Parse(SelectedDay),
                    IdMonth = int.Parse(ddlMeses.SelectedValue)
                };
                ltsList.Add(lts);
            }
        }

        private List<LoopTaskSchedule> CreateRepetitiveTask(User user)
        {
            LoopTask loopTask = createLoopTask(user);
            List<LoopTaskSchedule> ltsList = new List<LoopTaskSchedule>();
            if (loopTask.TaskAssignment.Task.Create() && loopTask.TaskAssignment.Create() && loopTask.Create())
            {
                int month = int.Parse(ddlMeses.SelectedValue);
                if (rbtlTipoRepeticion.SelectedValue == "diaSemana")
                {
                    List<string> selectedDaysOfWeek = cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
                    List<string> selectedWeeks = cbxNumeroSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();


                    if (selectedWeeks.Count > 0 && selectedWeeks.Count < 6)
                    {
                        foreach (string dayOfWeek in selectedDaysOfWeek)
                        {
                            foreach (string numberOfWeek in selectedWeeks)
                            {
                                LoopTaskSchedule lts = new LoopTaskSchedule()
                                {
                                    LoopTask = loopTask,
                                    DayOfMonth = null,
                                    DayOfWeek = int.Parse(dayOfWeek),
                                    NumberOfWeek = int.Parse(numberOfWeek),
                                    IdMonth = month
                                };
                                ltsList.Add(lts);
                            }
                            
                        }
                    }
                    else
                    {
                        foreach (string dayOfWeek in selectedDaysOfWeek)
                        {
                            LoopTaskSchedule lts = new LoopTaskSchedule()
                            {
                                LoopTask = loopTask,
                                DayOfMonth = null,
                                DayOfWeek = int.Parse(dayOfWeek),
                                NumberOfWeek = null, 
                                IdMonth = month
                            };

                            ltsList.Add(lts);
                        }
                    }
                    
                }
                else if (rbtlTipoRepeticion.SelectedValue == "diaMes")
                {
                    string SelectedDay = ddlDiaDelMes.SelectedValue;
                    LoopTaskSchedule lts = new LoopTaskSchedule()
                    {
                        LoopTask = loopTask,
                        DayOfWeek = null,
                        NumberOfWeek = null,
                        DayOfMonth = int.Parse(SelectedDay),
                        IdMonth = int.Parse(ddlMeses.SelectedValue)
                    };
                    ltsList.Add(lts);
                }

                
            }
            return ltsList;
        }

        private LoopTask createLoopTask(User user)
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

            return loopTask;
        }

        

        private string validate()
        {
            string value = null;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtNombreTarea.Text))
            {
                value = "Error: Verifique que el nombre de la tarea y la descripción no esté vacío";
            }

            if (rbtlTipoTarea.SelectedItem.Value == "TareaUnica")
            {
                DateTime datetimeInicio;
                DateTime datetimeFin;
                string fechaInicio = txtFechaInicio.Text;
                string fechaFin = txtFechaFin.Text;

                if (string.IsNullOrWhiteSpace(fechaInicio) || string.IsNullOrWhiteSpace(fechaFin) || !DateTime.TryParse(fechaInicio, out datetimeInicio) || !DateTime.TryParse(fechaFin, out datetimeFin))
                {
                    value = "Las fechas ingresadas son inválidas, o bien, estas vienen vacías";
                }
                else
                {
                    if (datetimeInicio > datetimeFin)
                    {
                        value = "La fecha de inicio no puede ser mayor que la fecha de fin";
                    }
                }
            }
            else if (rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
            {
                DateTime horaInicio;
                DateTime horaFin;
                string horaInicial = txtHoraInicio.Text;
                string horaFinal = txtHoraFin.Text;
                string initialDay = "1900-01-01";
                if (string.IsNullOrWhiteSpace(horaInicial) || string.IsNullOrWhiteSpace(horaFinal) || !DateTime.TryParse(initialDay +" "+ horaInicial, out horaInicio) || !DateTime.TryParse(initialDay + " " + horaFinal, out horaFin))
                {
                    value = "Hora de inicio y fin no pueden ser vacíos, o bien los datos ingresados son inválidos";
                }
                else
                {
                    if (horaInicio > horaFin)
                    {
                        value = "La hora de inicio no puede ser mayor que la hora de fin";
                    }
                }

                if(rbtlTipoRepeticion.SelectedValue == "diaSemana")
                {
                    if(cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList().Count == 0)
                    {
                        value = "Debe marcar al menos 1 día de semana";
                    }
                }
            }

            return value;

        }

        protected void rbtlTipoRepeticion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDayWeekOrMonthInfo();
        }

        private void LoadDayWeekOrMonthInfo()
        {
            if (rbtlTipoRepeticion.SelectedValue == "diaSemana" && rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
            {
                VisibilizeDayWeek(true);
            }
            else if (rbtlTipoRepeticion.SelectedValue == "diaMes" && rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
            {
                VisibilizeDayWeek(false);
            }
            else
            {
                Response.Redirect("CrearTarea.aspx");
            }
        }

        private void VisibilizeDayWeek(bool val)
        {
            divDiaSemana.Visible = val;
            divDiaMes.Visible = !val;
            divNumeroSemana.Visible = val;
            divMes.Visible = true;
        }

        protected void btnCrearTarea_Click(object sender, EventArgs e)
        {
            string validateMessage = validate();
            try
            {
                if (validateMessage == null)
                {
                    User user = (User)Session["ses"];
                    if (rbtlTipoTarea.SelectedItem.Value == "TareaUnica")
                    {
                        if (CreateUniqueTask(user))
                        {
                            Response.Redirect("CreacionTareaExitosa.aspx", false);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
                    {
                        List<LoopTaskSchedule> loopTaskScheduleList = CreateRepetitiveTask(user);

                        if (loopTaskScheduleList.Count > 0)
                        {
                            foreach (LoopTaskSchedule loopTaskSchedule in loopTaskScheduleList)
                            {
                                if (!loopTaskSchedule.Create())
                                    throw new Exception();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                        Response.Redirect("CreacionTareaExitosa.aspx", false);
                    }
                }
                else
                {
                    lblMessage.Text = validateMessage;
                }
            }
            catch (Exception exce)
            {
                string mes = exce.Message;
                Response.Redirect("CrearTarea.aspx");
                lblMessage.Text = "Error inesperado, contacte al administrador";
            }
        }

        protected void btnCrearFlujoTarea_Click(object sender, EventArgs e)
        {
            string validateMessage = validate();
            try
            {
                if (validateMessage == null)
                {
                    TaskFlowInfo taskFlowInfo = SelectedOptions();
                    
                    User user = (User)Session["ses"];


                    if (rbtlTipoTarea.SelectedItem.Value == "TareaUnica")
                    {
                        ProcessedTask processedTask = CreateUniqueFlowTask(user);
                        if (processedTask != null)
                        {
                            taskFlowInfo.ProcessedTask = processedTask;
                            Response.Redirect("FlujodeTarea.aspx", false);
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else if (rbtlTipoTarea.SelectedItem.Value == "TareaRepetitiva")
                    {
                        LoopTask loopTask = createLoopTask(user);
                        List<LoopTaskSchedule> loopTaskScheduleList = CreateRepetitiveTaskFlow(user);

                        if (loopTaskScheduleList.Count > 0)
                        {
                            taskFlowInfo.LoopTask = loopTask;
                            taskFlowInfo.LoopTaskScheduleList = loopTaskScheduleList;
                        }
                        else
                        {
                            throw new Exception();
                        }

                        Session["TaskFlowInfo"] = taskFlowInfo;
                        Response.Redirect("FlujodeTarea.aspx", false);
                    }
                }
                else
                {
                    lblMessage.Text = validateMessage;
                }
            }
            catch (Exception exce)
            {
                string mes = exce.Message;
                Response.Redirect("CrearTarea.aspx", false);
                lblMessage.Text = "Error inesperado, contacte al administrador";
            }
            
        }

        private TaskFlowInfo SelectedOptions()
        {
            TaskFlowInfo tfi = new TaskFlowInfo();

            switch(rbtlTipoTarea.SelectedValue)
            {
                case "TareaRepetitiva":
                    tfi.IsRepetitive = true;
                    if (rbtlTipoRepeticion.SelectedValue == "diaSemana")
                    {
                        tfi.IsDayOfWeek = true;
                    }
                    else if (rbtlTipoRepeticion.SelectedValue == "diaMes")
                    {
                        tfi.IsDayOfWeek = false;
                    }
                    break;
                case "TareaUnica":
                    tfi.IsRepetitive = false;
                    break;
            }

            switch (rbtlTipoCargaTarea.SelectedValue)
            {
                case "TareaPredeterminada":
                    tfi.IsPredefined = true;
                    break;
                case "TareaPropia":
                    tfi.IsPredefined = false;
                    break;
            }

            return tfi;
        }
    }
}