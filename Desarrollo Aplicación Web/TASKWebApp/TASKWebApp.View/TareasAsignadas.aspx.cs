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
            List<ProcessedTask> activeAndReasignedTasks = user.GetUnexpiredActiveAndReassignedTasks();
            LoadTaskInformation(activeAndReasignedTasks);
        }

        private void LoadTaskInformation(List<ProcessedTask> tasks)
        {
            repTabla.DataSource = tasks;
            repTabla.DataBind();

            for (int i = 0; i < tasks.Count; i++)
            {
                RepeaterItem item = repTabla.Items[i];
                //twl.Detail = new TaskLevelDetail();
                SetRowInTableInformation(item, tasks[i]);
            }
        }

        private void SetRowInTableInformation(RepeaterItem item, ProcessedTask processedTask)
        {
            SetTableindividualLabelInformation("lblSubNombre", processedTask.TaskAssignment.Task.Name, item);
            SetTableindividualLabelInformation("lblAsignadaPor", processedTask.TaskAssignment.AssignerUser.FullName(), item);
            SetTableindividualLabelInformation("lblSubDescripcion", processedTask.TaskAssignment.Task.Description, item);
            SetTableindividualLabelInformation("lblSubFechaInicio", processedTask.StartDate.ToString(), item);
            SetTableindividualLabelInformation("lblSubFechaFin", processedTask.EndDate.ToString(), item);

            if(processedTask.TaskAssignment.Task.DependentTask!=null)
            {
                SetTableindividualLabelInformation("lblSubDependencia", processedTask.TaskAssignment.Task.DependentTask.Name, item);
            }
            else
            {
                SetTableindividualLabelInformation("Ninguna", processedTask.TaskAssignment.Task.DependentTask.Name, item);
            }
            
        }

        private void SetTableindividualLabelInformation(string labelName, string information, RepeaterItem item)
        {
            Label label = (Label)item.FindControl(labelName);
            label.Text = information;
        }

    }
}