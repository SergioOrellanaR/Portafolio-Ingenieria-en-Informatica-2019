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
            if(loopTasks.Count>0)
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
            foreach(LoopTaskSchedule taskSchedule in schedule)
            {
                if(taskSchedule.DayOfWeek != null)
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
            Button button = (Button)sender;
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
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
        }
    }
}