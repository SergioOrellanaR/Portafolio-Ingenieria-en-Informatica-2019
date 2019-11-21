using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class AdministrarTareaRechazada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["ses"];
            try
            {
                int RejectedStatus = 5;
                int SuspendedStatus = 9;
                List<ProcessedTask> activeAndReasignedTasks = user.SearchProcessedTaskByStatus(RejectedStatus);
                LoadTaskInformation(RejectedStatus, user);
                LoadTaskInformation(SuspendedStatus, user);
            }
            catch
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void LoadTaskInformation(int status, User user)
        {
            List<ProcessedTask> tasks;
            int RejectedStatus = 5;
            int SuspendedStatus = 9;


            if (status == RejectedStatus)
            {
                tasks = user.SearchProcessedTaskByStatus(RejectedStatus);
                if (tasks.Count > 0)
                {
                    repTablaRechazo.DataSource = tasks;
                    repTablaRechazo.DataBind();

                    for (int i = 0; i < tasks.Count; i++)
                    {
                        RepeaterItem item = repTablaRechazo.Items[i];
                        SetRowInTableInformation(item, tasks[i], status);
                    }
                }
            }
            else if (status == SuspendedStatus)
            {
                tasks = user.SearchProcessedTaskByStatus(SuspendedStatus);
                if (tasks.Count > 0)
                {
                    repTablaSuspension.DataSource = tasks;
                    repTablaSuspension.DataBind();
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        RepeaterItem item = repTablaSuspension.Items[i];
                        SetRowInTableInformation(item, tasks[i], status);
                    }
                }
            }
            else
            {
                Label7.Text = "Error!";
            }
        }

        private void SetRowInTableInformation(RepeaterItem item, ProcessedTask processedTask, int status)
        {
            SetTableindividualLabelInformation("lblSubNombre", processedTask.TaskAssignment.Task.Name, item);
            SetTableindividualLabelInformation("lblSubDescripcion", processedTask.TaskAssignment.Task.Description, item);
            SetTableindividualLabelInformation("lblSubFechaInicio", processedTask.StartDate.ToString(), item);
            SetTableindividualLabelInformation("lblSubFechaFin", processedTask.EndDate.ToString(), item);

            /*
            if (processedTask.TaskAssignment.Task.DependentTask != null)
            {
                SetTableindividualLabelInformation("lblSubDependencia", processedTask.TaskAssignment.Task.DependentTask.Name, item);
            }
            else
            {
                SetTableindividualLabelInformation("lblSubDependencia", "Ninguna", item);
            
            }*/
            SetTableindividualLabelInformation("lblResponsable", processedTask.TaskAssignment.ReceiverUser.FullName(), item);
            SetTableindividualLabelInformation("lblMotivo", processedTask.Commentary, item);
            SetTableindividualLabelInformation("lblIdTarea", processedTask.Id.ToString(), item);
        }

        private void SetTableindividualLabelInformation(string labelName, string information, RepeaterItem item)
        {
            Label label = (Label)item.FindControl(labelName);
            label.Text = information;
        }

        protected void btnSubEliminarRechazado_Click(object sender, EventArgs e)
        {
            int closedId = 6;
            int errorCode = -1;
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;

            int rowTaskId = GetRowTaskId(item, closedId);

            if (rowTaskId != errorCode)
            {
                ProcessedTask processedTask = new ProcessedTask() { Id = rowTaskId };
                processedTask.Read();
                processedTask.IdTaskStatus = closedId;
                processedTask.Update();
            }

            Response.Redirect("AdministrarTareaRechazada.aspx");
        }

        protected void btnSubEliminarProblema_Click(object sender, EventArgs e)
        {
            int failedId = 7;
            int errorCode = -1;
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            int rowTaskId = GetRowTaskId(item, failedId);

            if (rowTaskId != errorCode)
            {
                ProcessedTask processedTask = new ProcessedTask() { Id = rowTaskId };
                processedTask.Read();
                processedTask.IdTaskStatus = failedId;
                processedTask.Update();
            }

            Response.Redirect("AdministrarTareaRechazada.aspx");
        }

        private int GetRowTaskId(RepeaterItem item, int status)
        {
            try
            {
                int closedId = 6;
                int index = item.ItemIndex;
                RepeaterItem IndItem;

                if(status == closedId)
                {
                    IndItem = repTablaRechazo.Items[index];
                }
                else
                {
                    IndItem = repTablaSuspension.Items[index];
                }

                Label label = (Label)IndItem.FindControl("lblIdTarea");
                int idAssigned = int.Parse(label.Text);
                return idAssigned;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

    }
}