using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class FlujodeTarea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateTaskFlowInfoExists();
            TaskFlowInfo taskFlowInfo = (TaskFlowInfo)Session["TaskFlowInfo"];
            LoadSubTaskInformation(taskFlowInfo);
        }

        private void ValidateTaskFlowInfoExists()
        {
            if (Session["TaskFlowInfo"] == null)
            {
                Response.Redirect("CrearTarea.aspx");
            }
        }

        private void LoadSubTaskInformation(TaskFlowInfo taskFlowInfo)
        {
            LoadSubTaskDiv(taskFlowInfo);
            List<Task> taskList = (List<Task>)repSubTask.DataSource;
            LoadDivInformation(taskFlowInfo, taskList);
            if (taskFlowInfo.IsPredefined)
            {
                SetPredefinidedSubTaskInformation(taskList);
            }
            else
            {
                LoadFirstTaskDiv();
            }
        }

        private void LoadDivInformation(TaskFlowInfo taskFlowInfo, List<Task> taskList)
        {
            if(taskFlowInfo.IsRepetitive)
            {
                EnableUniqueTaskControls(false, taskList);
                LoadRepetitiveSubTaskDetailInformation(taskFlowInfo, taskList);
            }
            else
            {
                EnableUniqueTaskControls(true, taskList);
            }
        }

        private void LoadRepetitiveSubTaskDetailInformation (TaskFlowInfo taskFlowInfo, List<Task> taskList)
        {
            if (taskFlowInfo.IsDayOfWeek == true)
            {
                VisibilizeDayWeek(true);
            }
            else if (taskFlowInfo.IsDayOfWeek == false)
            {
                VisibilizeDayWeek(false);
            }
        }

        private void VisibilizeDayWeek(bool val)
        {
            for (int i = 0; i < repSubTask.Items.Count; i++)
            {
                RepeaterItem item = repSubTask.Items[i];
                EnableVisibleDiv(val, "divDiaSemana", item);
                EnableVisibleDiv(!val, "divDiaMes", item);
                EnableVisibleDiv(val, "divNumeroSemana", item);
                EnableVisibleDiv(true, "divMes", item);
            }
        }

        private void LoadUniqueTaskTypeDiv(bool val)
        {
            //divTareaUnica.Visible = val;
            //divTareaRepetitiva.Visible = !val;
        }

        private void LoadDependenciesDiv(bool val)
        {
            //divDependencia.Visible = val;
        }

        //ToDo: Si arreglo de tareas > 0, LoadDependenciesDiv(true), else LoadDependenciesDiv(false);
        private void LoadFirstTaskDiv()
        {
            int val = 0; //Cambiar por array.length

            if (val > 0)
            {
                LoadDependenciesDiv(true);
            }
            else
            {
                LoadDependenciesDiv(false);
            }
        }

        private void LoadSubTaskDiv(TaskFlowInfo taskFlowInfo)
        {
            List<Task> taskList = new List<Task>();
            if (taskFlowInfo.IsPredefined)
            {
                taskList = taskFlowInfo.OriginalTask.LoadChildTasks().Values.ToList();
            }
            else
            {
                taskList.Add(taskFlowInfo.OriginalTask);
            }
            repSubTask.DataSource = taskList;
            repSubTask.DataBind();
        }

        private void SetPredefinidedSubTaskInformation(List<Task> taskList)
        {
            for (int i = 0; i < repSubTask.Items.Count; i++)
            {
                RepeaterItem item = repSubTask.Items[i];

                TextBox txtName = (TextBox)item.FindControl("txtNombre");
                TextBox txtDescription = (TextBox)item.FindControl("txtDescription");
                Task task = taskList[i];

                txtName.Text = task.Name;
                txtDescription.Text = task.Description;

                txtName.Enabled = false;
                txtDescription.Enabled = false;

                EnableCreateFlowButton(false, taskList, item);
                EnableDependenciesDiv(false, taskList, item);
            }
        }

        private void EnableCreateFlowButton (bool val, List<Task> taskList, RepeaterItem item)
        {
                Button createFlow = (Button)item.FindControl("btnAgregarAFlujo");
                createFlow.Visible = val;
        }

        private void EnableDependenciesDiv(bool val, List<Task> taskList, RepeaterItem item)
        {
                EnableVisibleDiv(val, "divDependencia", item);                
        }

        private void EnableUniqueTaskControls(bool val, List<Task> taskList)
        {
            for (int i = 0; i < repSubTask.Items.Count; i++)
            {
                RepeaterItem item = repSubTask.Items[i];
                EnableVisibleDiv(val, "divTareaUnica", item);
                EnableVisibleDiv(!val, "divTareaRepetitiva", item);
            }
        }


        private void EnableVisibleDiv (bool val, string divName, RepeaterItem item)
        {
            HtmlGenericControl div = (HtmlGenericControl)item.FindControl(divName);
            div.Visible = val;
        }





        /*
         * foreach (RepeaterItem item in Repeater1.Items)
            {
                  TextBox txtName= (TextBox)item.FindControl("txtName");
                  if(txtName!=null)
                  {
                  //do something with txtName.Text
                  }
                  Image img= (Image)item.FindControl("Img");
                  if(img!=null)
                  {
                  //do something with img
                  }
            }
         */
    }
}