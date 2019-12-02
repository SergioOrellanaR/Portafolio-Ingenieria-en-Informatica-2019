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
    public partial class AdministrarTareaRepetitiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["ses"];
            try
            {
                LoadResponsibles();
                LoadAssignedLoopTask(user);
            }
            catch
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void LoadAssignedLoopTask(User user)
        {
            List<LoopTask> loopTasks = user.SearchAssignedLoopTask();
            if (loopTasks.Count > 0)
            {
                repTabla.DataSource = loopTasks;
                repTabla.DataBind();
                for (int i = 0; i < loopTasks.Count; i++)
                {
                    RepeaterItem item = repTabla.Items[i];
                    SetRowInTableInformation(item, loopTasks[i]);
                }
            }
            else
            {
                lblInicialMessage.Text = "Usted no ha asignado aún tareas repetitivas";
            }
        }

        private void SetRowInTableInformation(RepeaterItem item, LoopTask loopTask)
        {
            List<LoopTaskSchedule> lts = loopTask.GetSchedule();
            SetTableindividualLabelInformation("lblNombreTarea", loopTask.TaskAssignment.Task.Name, item);
            SetTableindividualLabelInformation("lblSubDescripcion", loopTask.TaskAssignment.Task.Description, item);

            if (loopTask.IsDayOfWeek())
            {
                SetTableindividualLabelInformation("lblSubFechaRepetición", SelectedDaysFormatter(loopTask.GetScheduleDistinct(true), loopTask.GetScheduleDistinct(false), lts), item);
            }
            else if (loopTask.IsDayOfWeek() == false)
            {
                SetTableindividualLabelInformation("lblSubFechaRepetición", SelectedDayOfMonthFormatter(lts), item);
            }

            SetTableindividualLabelInformation("lblSubHora", SelectedHoursFormatter(loopTask), item);
            SetTableindividualLabelInformation("lblResponsable", loopTask.TaskAssignment.ReceiverUser.FullName(), item);
            SetTableindividualLabelInformation("lblIdTarea", loopTask.Id.ToString(), item);
        }

        private void SetTableindividualLabelInformation(string labelName, string information, RepeaterItem item)
        {
            Label label = (Label)item.FindControl(labelName);
            label.Text = information;
        }

        private List<string> getDayOfWeek(List<LoopTaskSchedule> schedule)
        {
            List<string> dayOfWeek = new List<string>();
            foreach (LoopTaskSchedule taskSchedule in schedule)
            {
                if (taskSchedule.DayOfWeek != null)
                {
                    dayOfWeek.Add(taskSchedule.DayOfWeek.ToString());
                }
            }
            return dayOfWeek;
        }

        private List<string> getNumberOfWeeks(List<LoopTaskSchedule> schedule)
        {
            List<string> week = new List<string>();
            foreach (LoopTaskSchedule taskSchedule in schedule)
            {
                if (taskSchedule.NumberOfWeek != null)
                {
                    week.Add(taskSchedule.NumberOfWeek.ToString());
                }
            }
            return week;
        }

        private string SelectedDaysFormatter(List<string> days, List<string> weeks, List<LoopTaskSchedule> taskSchedule)
        {
            string daysOfWeek = "días";
            Dictionary<int, string> dayOfWeek = ComboBoxDataLoader.DayOfWeek;

            if (days.Count > 0 && days.Count < 7)
            {
                daysOfWeek = string.Empty;
                for (int i = 0; i < days.Count; i++)
                {
                    daysOfWeek += dayOfWeek[int.Parse(days[i])];
                    if (i < days.Count - 1)
                    {
                        daysOfWeek += ", ";
                    }
                }
            }

            string numberOfWeeks = string.Empty;
            if (days != null && days.Count > 0)
            {
                numberOfWeeks = "De la/s semana/s ";
                for (int i = 0; i < weeks.Count; i++)
                {
                    numberOfWeeks += weeks[i];
                    if (i < weeks.Count - 1)
                    {
                        numberOfWeeks += ", ";
                    }
                }
            }

            Dictionary<int, string> months = ComboBoxDataLoader.Month;
            int idMonth = taskSchedule[0].IdMonth ?? 13;
            string month = months[idMonth];
            string returnValue = string.Format("Todos los {0} {1} durante {2}", daysOfWeek, numberOfWeeks, month);

            return returnValue;
        }

        private string SelectedDayOfMonthFormatter(List<LoopTaskSchedule> taskSchedule)
        {
            string dayOfMonth = taskSchedule[0].DayOfMonth.ToString();

            Dictionary<int, string> months = ComboBoxDataLoader.Month;
            int idMonth = taskSchedule[0].IdMonth ?? 13;
            string month = months[idMonth];
            string returnValue = string.Format("Todos los {0} de {1}", dayOfMonth, month);
            return returnValue;
        }

        private string SelectedHoursFormatter(LoopTask loopTask)
        {
            DateTime datetime = (DateTime)loopTask.StartTime;
            string startTime = datetime.ToString("HH:mm");
            string endTime = loopTask.EndTime.ToString("HH:mm");
            string returnValue = string.Format("De {0} a {1}", startTime, endTime);
            return returnValue;
        }

        protected void btnSubEliminarRepetitivo_Click(object sender, EventArgs e)
        {
            divEditarInfo.Visible = false;
            int errorCode = -1;
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;

            int rowTaskId = GetRowTaskId(item);

            if (rowTaskId != errorCode)
            {
                LoopTask loopTask = new LoopTask(rowTaskId);
                loopTask.Isactive = false;
                loopTask.Update();
            }

            Response.Redirect("AdministrarTareaRepetitiva.aspx");
        }

        private int GetRowTaskId(RepeaterItem item)
        {
            try
            {
                int index = item.ItemIndex;
                RepeaterItem IndItem = repTabla.Items[index];
                Label label = (Label)IndItem.FindControl("lblIdTarea");
                int idAssigned = int.Parse(label.Text);
                return idAssigned;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        protected void btnSubEditarRepetitivo_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            LoopTask loopTask = new LoopTask(GetRowTaskId(item));
            LoadEditBox(loopTask);
        }

        private void LoadEditBox(LoopTask loopTask)
        {
            DateTime startTime = (DateTime)loopTask.StartTime;
            DateTime endTime = loopTask.EndTime;
            divEditarInfo.Visible = true;
            ddlResponsable.SelectedValue = loopTask.TaskAssignment.ReceiverUser.Id.ToString();
            lblInternalId.Text = loopTask.Id.ToString();
            if(loopTask.TaskAssignment.Task.IsPredefined)
            {
                txtNombreTarea.Enabled = false;
                txtDescripcion.Enabled = false;
                lblMessage.Text = "Tarea predeterminada, no puede editar nombre ni descripción";
            }
            txtNombreTarea.Text = loopTask.TaskAssignment.Task.Name;
            txtDescripcion.Text = loopTask.TaskAssignment.Task.Description;
            txtHoraInicio.Text = startTime.ToString("HH:mm");
            txtHoraFin.Text = endTime.ToString("HH:mm");
            ddlMeses.SelectedValue = loopTask.GetSelectedMonth().ToString();

            if (loopTask.IsDayOfWeek())
            {
                VisibilizeDayWeek(true);
                LoadDayOfWeekInformation(loopTask);
            }
            else
            {
                VisibilizeDayWeek(false);
                LoadMonthlyInformation(loopTask);
            }
        }

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

        private void VisibilizeDayWeek(bool val)
        {
            divDiaSemana.Visible = val;
            divDiaMes.Visible = !val;
            divNumeroSemana.Visible = val;
            divMes.Visible = true;
        }

        private void LoadDayOfWeekInformation(LoopTask loopTask)
        {
            List<string> days = loopTask.GetScheduleDistinct(true);
            List<string> weeks = loopTask.GetScheduleDistinct(false);
            LoadCheckedInformation(days, cbxDiaSemana.Items, true);
            LoadCheckedInformation(weeks, cbxNumeroSemana.Items, false);

        }

        private void LoadCheckedInformation(List<string> items, ListItemCollection listItem, bool dayOfWeek)
        {
            if (dayOfWeek == false && items.Count == 0)
            {
                foreach (ListItem item in listItem)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (ListItem item in listItem)
                {
                    bool value = false;
                    foreach (string stringItem in items)
                    {
                        if (stringItem == item.Value)
                        {
                            value = true;
                            break;
                        }
                    }
                    if (value)
                        item.Selected = true;
                    else
                        item.Selected = false;
                }
            }
        }

        private void LoadMonthlyInformation(LoopTask loopTask)
        {
            ddlDiaDelMes.SelectedValue = loopTask.GetDayOfMonth().ToString();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LoopTask loopTask = new LoopTask(int.Parse(lblInternalId.Text));
            if(UpdateBasicInformation(loopTask))
            {
                List<LoopTaskSchedule> ltsList = ScheduleLoopTask(loopTask);
                if (ltsList.Count > 0)
                {
                    foreach (LoopTaskSchedule loopTaskSchedule in ltsList)
                    {
                        if (!loopTaskSchedule.Create())
                            throw new Exception();
                        else
                            InsertAssignmentForThisWeek(loopTaskSchedule);
                    }
                }
                else
                {
                    throw new Exception();
                }
                Response.Redirect("AdministrarTareaRepetitiva.aspx", false);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        private bool UpdateBasicInformation(LoopTask loopTask)
        {
            bool isValidProcess = false;
            string defaultDate = "1900-01-01";
            DateTime startTime;
            DateTime endTime;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtNombreTarea.Text) || DateTime.TryParse(defaultDate + " " + txtHoraInicio.Text, out startTime) == false || DateTime.TryParse(defaultDate + " " + txtHoraFin.Text, out endTime) == false)
            {
                lblMessage.Text = "Los datos ingresados son inválidos";
            }
            else
            {
                if (loopTask.TaskAssignment.AssignerUser.Id == ((User)Session["ses"]).Id)
                {
                    if (loopTask.TaskAssignment.Task.IsPredefined == false)
                    {
                        loopTask.TaskAssignment.Task.Name = txtNombreTarea.Text;
                        loopTask.TaskAssignment.Task.Description = txtDescripcion.Text;
                        loopTask.TaskAssignment.Task.Update();
                    }

                    loopTask.StartTime = startTime;
                    loopTask.EndTime = endTime;
                    isValidProcess = loopTask.Update();
                }
                else
                {
                    lblMessage.Text = "Error desconocido.";
                }
            }

            return isValidProcess;
        }

        private List<LoopTaskSchedule> ScheduleLoopTask(LoopTask loopTask)
        {
            List<LoopTaskSchedule> ltsList = new List<LoopTaskSchedule>();
            int month = int.Parse(ddlMeses.SelectedValue);
            if (loopTask.IsDayOfWeek())
            {
                List<string> selectedDaysOfWeek = cbxDiaSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
                List<string> selectedWeeks = cbxNumeroSemana.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();

                loopTask.DeleteScheduledTasks();

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
            else
            {
                loopTask.DeleteScheduledTasks();
                string SelectedDay = ddlDiaDelMes.SelectedValue;
                LoopTaskSchedule lts = new LoopTaskSchedule()
                {
                    LoopTask = loopTask,
                    DayOfWeek = null,
                    NumberOfWeek = null,
                    DayOfMonth = int.Parse(SelectedDay),
                    IdMonth = month
                };
                ltsList.Add(lts);
            }
            return ltsList;
        }

        /// <summary>
        /// Inserción de datos de repetitivas
        /// </summary>
        /// <param name="loopTaskSchedule"></param>
        private void InsertAssignmentForThisWeek(LoopTaskSchedule loopTaskSchedule)
        {
            int? selectedDayOfWeek = loopTaskSchedule.DayOfWeek;
            int? dayOfMonth = loopTaskSchedule.DayOfMonth;
            int? idMonth = loopTaskSchedule.IdMonth;
            int? numberOfWeek = loopTaskSchedule.NumberOfWeek;
            DateTime now = DateTime.Now;
            DateTime startTime = (DateTime)loopTaskSchedule.LoopTask.StartTime;
            DateTime endTime = loopTaskSchedule.LoopTask.EndTime;
            int actualDayOfWeek = DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)DateTime.Today.DayOfWeek;

            if (idMonth == 13 || MonthBelongsToActualWeek(idMonth))
            {
                if (dayOfMonth == null)
                {
                    if ((numberOfWeek == null || numberOfWeek == GetWeekNumberOfMonth(now)) && selectedDayOfWeek > actualDayOfWeek || (selectedDayOfWeek == actualDayOfWeek && TimeSpan.Compare(startTime.TimeOfDay, now.TimeOfDay) > 0))
                    {
                        int differenceBetweenDays = ((int)selectedDayOfWeek) - actualDayOfWeek;
                        CreateProcessedTask(loopTaskSchedule, startTime, endTime, differenceBetweenDays);
                    }
                }
                else
                {
                    DateTime firstDayOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
                    int day = (int)dayOfMonth;
                    DateTime wishedDay = new DateTime();
                    if (firstDayOfWeek.Month == lastDayOfWeek.Month)
                    {
                        try
                        {
                            wishedDay = new DateTime(now.Year, now.Month, day);
                        }
                        catch (Exception e) { }
                    }
                    else if ((firstDayOfWeek.Month < lastDayOfWeek.Month) || (firstDayOfWeek.Month > lastDayOfWeek.Month && firstDayOfWeek.Year != lastDayOfWeek.Year))
                    {
                        try
                        {
                            if (day > firstDayOfWeek.Day)
                            {
                                wishedDay = new DateTime(now.Year, firstDayOfWeek.Month, day);
                            }
                            else if (day <= lastDayOfWeek.Day)
                            {
                                wishedDay = new DateTime(now.Year, lastDayOfWeek.Month, day);
                            }
                        }
                        catch (Exception e) { }
                    }

                    if (wishedDay >= firstDayOfWeek && wishedDay <= lastDayOfWeek)
                    {
                        DateTime startDate = wishedDay.Date + startTime.TimeOfDay;
                        DateTime endDate = wishedDay.Date + endTime.TimeOfDay;
                        CreateProcessedTask(loopTaskSchedule, startDate, endDate);
                    }
                }
            }
        }

        private bool CreateProcessedTask(LoopTaskSchedule loopTaskSchedule, DateTime startDate, DateTime endDate)
        {
            int assignedStatusId = 1;
            ProcessedTask processedTask = new ProcessedTask()
            {
                Commentary = null,
                AssignationDate = DateTime.Now,
                IdTaskStatus = assignedStatusId,
                TaskAssignment = loopTaskSchedule.LoopTask.TaskAssignment,
                LoopTaskSchedule = loopTaskSchedule,
                StartDate = startDate,
                EndDate = endDate
            };
            return processedTask.Create();
        }

        private bool CreateProcessedTask(LoopTaskSchedule loopTaskSchedule, DateTime startTime, DateTime endTime, int differenceBetweenDays)
        {
            int assignedStatusId = 1;
            DateTime startDate = DateTime.Now.AddDays(differenceBetweenDays);
            startDate = startDate.Date + startTime.TimeOfDay;
            DateTime endDate = startDate.Date + endTime.TimeOfDay;
            ProcessedTask processedTask = new ProcessedTask()
            {
                Commentary = null,
                AssignationDate = DateTime.Now,
                IdTaskStatus = assignedStatusId,
                TaskAssignment = loopTaskSchedule.LoopTask.TaskAssignment,
                LoopTaskSchedule = loopTaskSchedule,
                StartDate = startDate,
                EndDate = endDate
            };
            return processedTask.Create();
        }

        private bool MonthBelongsToActualWeek(int? idMonth)
        {
            bool val = false;

            if (idMonth != 13)
            {
                DateTime firstDayOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
                if (firstDayOfWeek.Month == idMonth || lastDayOfWeek.Month == idMonth)
                {
                    val = true;
                }
            }

            return val;
        }


        private int GetWeekNumberOfMonth(DateTime date)
        {
            date = date.Date;
            DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
            DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            if (firstMonthMonday > date)
            {
                firstMonthDay = firstMonthDay.AddMonths(-1);
                firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
            }
            int value = ((date - firstMonthMonday).Days / 7 + 1);
            return value;
        }
    }
}