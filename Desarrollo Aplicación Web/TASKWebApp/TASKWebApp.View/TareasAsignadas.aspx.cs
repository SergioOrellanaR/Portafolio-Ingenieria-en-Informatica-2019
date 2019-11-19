using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class TareasAsignadas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["ses"];
            try
            {
                List<ProcessedTask> activeAndReasignedTasks = user.GetUnexpiredActiveAndReassignedTasks();
                LoadTaskInformation(activeAndReasignedTasks);
            }
            catch
            {
                Response.Redirect("Home.aspx");
            }
            
        }

        private void LoadTaskInformation(List<ProcessedTask> tasks)
        {
            if(tasks.Count > 0)
            {
                repTabla.DataSource = tasks;
                repTabla.DataBind();

                for (int i = 0; i < tasks.Count; i++)
                {
                    RepeaterItem item = repTabla.Items[i];
                    SetRowInTableInformation(item, tasks[i]);
                }
            }
            else
            {
                Label7.Text = "Usted no tiene tareas pendientes de revisión!";
            }
            
        }

        private void SetRowInTableInformation(RepeaterItem item, ProcessedTask processedTask)
        {
            SetTableindividualLabelInformation("lblSubNombre", processedTask.TaskAssignment.Task.Name, item);
            SetTableindividualLabelInformation("lblAsignadaPor", processedTask.TaskAssignment.AssignerUser.FullName(), item);
            SetTableindividualLabelInformation("lblSubDescripcion", processedTask.TaskAssignment.Task.Description, item);
            SetTableindividualLabelInformation("lblSubFechaInicio", processedTask.StartDate.ToString(), item);
            SetTableindividualLabelInformation("lblSubFechaFin", processedTask.EndDate.ToString(), item);

            if (processedTask.TaskAssignment.Task.DependentTask != null)
            {
                SetTableindividualLabelInformation("lblSubDependencia", processedTask.TaskAssignment.Task.DependentTask.Name, item);
            }
            else
            {
                SetTableindividualLabelInformation("lblSubDependencia", "Ninguna", item);
            }

            SetTableindividualLabelInformation("lblIdTarea", processedTask.Id.ToString(), item);
        }

        private void SetTableindividualLabelInformation(string labelName, string information, RepeaterItem item)
        {
            Label label = (Label)item.FindControl(labelName);
            label.Text = information;
        }

        protected void btnSubAceptar_Click(object sender, EventArgs e)
        {
            int InProcessId = 2;
            int errorCode = -1;
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            int rowTaskId = GetRowTaskId(item); 

            if (rowTaskId != errorCode)
            {
                ProcessedTask processedTask = new ProcessedTask() { Id = rowTaskId };
                processedTask.Read();
                processedTask.IdTaskStatus = InProcessId;
                processedTask.Update();
            }
            
            Response.Redirect("TareasAsignadas.aspx");
        }

        protected void btnSubRechazar_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            ProcessedTask processedTask = new ProcessedTask() { Id = GetRowTaskId(item) };
            processedTask.Read();
            LoadRejectForm(processedTask);
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

        private void LoadRejectForm(ProcessedTask processedTask)
        {
            //ToDo.
        }
    }
}