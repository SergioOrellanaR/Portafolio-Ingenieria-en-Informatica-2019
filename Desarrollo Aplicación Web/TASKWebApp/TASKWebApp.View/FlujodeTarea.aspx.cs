using BrightIdeasSoftware;
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

        public static int virtualIdGenerator;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidateTaskFlowInfoExists();
            TaskFlowInfo taskFlowInfo = (TaskFlowInfo)Session["TaskFlowInfo"];
            LoadSubTaskInformation(taskFlowInfo);
            if (!IsPostBack)
                Session["TaskWithLevels"] = null;

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
            ListInformationDataBind(taskFlowInfo.OriginalTask);

            if (taskFlowInfo.IsPredefined)
            {
                SetPredefinidedSubTaskInformation(taskList);
            }
            else
            {
                //LoadFirstTaskDiv();
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

        private void LoadSubTaskDiv(TaskFlowInfo taskFlowInfo)
        {
            List<Task> taskList = new List<Task>();

            if (taskFlowInfo.IsPredefined)
            {
                taskList = taskFlowInfo.OriginalTask.LoadChildTasks().Values.ToList();
            }
            else
            {
                //taskList.Add(taskFlowInfo.OriginalTask);
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
            if(val && divName == "divTareaUnica")
            {
                TextBox txtInicio = (TextBox)item.FindControl("txtFechaInicio");
                TextBox txtFin = (TextBox)item.FindControl("txtFechaFin");
                txtInicio.Text = DateTime.Now.ToLocalTime().ToString("yyyy-MM-ddTHH:mm"); 
                txtFin.Text = DateTime.Now.AddDays(1).ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            }
            HtmlGenericControl div = (HtmlGenericControl)item.FindControl(divName);
            div.Visible = val;
        }
        
        
        private void ListInformationDataBind(Task task)
        {
            ChildTaskContainer ctc = new ChildTaskContainer(task);
            LoadTableDivs(ctc);
        }

        private void LoadTableDivs(ChildTaskContainer ctc)
        {
            int rootLevel = 0;
            ctc.LoadLevel(rootLevel);
            List<TaskWithLevel> tasksWithLevels;

            if (Session["TaskWithLevels"] == null)
            {
                tasksWithLevels = new List<TaskWithLevel>();
                ctc.TransformToListPlainWithLevels(tasksWithLevels);
                foreach(TaskWithLevel twl in tasksWithLevels)
                {
                    twl.virtualId = virtualIdGenerator++;
                }
            }
            else
            {
                tasksWithLevels = (List<TaskWithLevel>)Session["TaskWithLevels"];
            }


            /*
            if (taskFlowInfo.IsPredefined)
            {
                taskList = taskFlowInfo.OriginalTask.LoadChildTasks().Values.ToList();
            }
            else
            {
                taskList.Add(taskFlowInfo.OriginalTask);
            }
            */
            Session["TaskWithLevels"] = UpdateTableInformation(tasksWithLevels, null, 0);
        }

        private List<TaskWithLevel> UpdateTableInformation (List<TaskWithLevel> tasksWithLevels, string operation, int index)
        {
            switch (operation)
            {
                case "Add":
                    TaskWithLevel parentTaskWithLevel = tasksWithLevels[index];
                    int level = parentTaskWithLevel.Level + 1;
                    int operationIdAdd = 1;

                    TaskWithLevel twl = new TaskWithLevel()
                    {
                        virtualId = virtualIdGenerator++,
                        Level = level,
                        virtualParentId = parentTaskWithLevel.virtualId,
                        OperationId = operationIdAdd
                    };

                    List<TaskWithLevel> tempList = new List<TaskWithLevel>();
                    tempList.Add(twl);
                    /*
                    repSubTask.DataSource = tempList;
                    */
                    List<Task> temp = new List<Task>();
                    temp.Add(twl.Task);
                    repSubTask.DataSource = temp;
                    repSubTask.DataBind();
                    break;
                case "Delete":
                    tasksWithLevels.Remove(tasksWithLevels[index]);
                    break;
                case "Update":
                    break;
                default:
                    break;
            }

            repTabla.DataSource = tasksWithLevels;
            repTabla.DataBind();
            LoadTableInfo(tasksWithLevels);
            return tasksWithLevels;
        }

        private List<TaskWithLevel> GetTableDataSource()
        {
            return (List<TaskWithLevel>)Session["TaskWithLevels"];
        }



        private void LoadTableInfo (List<TaskWithLevel> tlwl)
        {
            TaskFlowInfo taskFlowInfo = (TaskFlowInfo)Session["TaskFlowInfo"];
            bool isOwnTask = !taskFlowInfo.IsPredefined;
            bool isUnique = !taskFlowInfo.IsRepetitive;
            EnableHeaderLabelForButtons(isOwnTask);

            for (int i = 0; i < repTabla.Items.Count; i++)
            {
                RepeaterItem item = repTabla.Items[i];
                TaskWithLevel twl = tlwl[i];
                SetRowInTableInformation(item, twl);
                EnableSubButtons(item, isOwnTask, twl.Level);
                LoadUniqueFatherTaskInformation(item, taskFlowInfo, twl.Level);
            }
        }

        private void EnableHeaderLabelForButtons(bool val)
        {
            Label lblAdd = (Label)repTabla.Controls[0].Controls[0].FindControl("hdlblAgregar");
            Label lblDelete = (Label)repTabla.Controls[0].Controls[0].FindControl("hdlblEliminar");
            Label lblEdit = (Label)repTabla.Controls[0].Controls[0].FindControl("hdlblEditar");

            lblAdd.Visible = val;
            lblDelete.Visible = val;
            lblEdit.Visible = val;

        }


        private void EnableSubButtons (RepeaterItem item, bool val, int level)
        {
            SetTableIndividualButtonInformation("btnSubAdd", item, val);
            SetTableIndividualButtonInformation("btnSubEdit", item, val);

            if (level == 0)
            {
                SetTableIndividualButtonInformation("btnSubDelete", item, false);
            }
            else
            {
                SetTableIndividualButtonInformation("btnSubDelete", item, val);
            }
        }

        private void LoadUniqueFatherTaskInformation(RepeaterItem item, TaskFlowInfo taskFlowInfo, int level)
        {
            if (!taskFlowInfo.IsRepetitive && level == 0)
            {
                SetTableindividualLabelInformation("lblSubFechaInicio", taskFlowInfo.ProcessedTask.StartDate.ToString(), item);
                SetTableindividualLabelInformation("lblSubFechaFin", taskFlowInfo.ProcessedTask.EndDate.ToString(), item);
            }
        }

        private void SetRowInTableInformation(RepeaterItem item, TaskWithLevel taskWithLevel)
        {
            Task task = taskWithLevel.Task;
            string separator = String.Concat(Enumerable.Repeat("---", taskWithLevel.Level));
            SetTableindividualLabelInformation("lblSubSeparator", separator, item);
            SetTableindividualLabelInformation("lblSubNombre", task.Name, item);
            SetTableindividualLabelInformation("lblSubDescripcion",task.Description, item);
            SetTableindividualLabelInformation("lblSubFechaInicio","-", item);
            SetTableindividualLabelInformation("lblSubFechaFin","-", item);

            string depTaskName = string.Empty;
            if (task.DependentTask != null)
            {
                depTaskName = task.DependentTask.Name;
            }
            SetTableindividualLabelInformation("lblSubDependencia", depTaskName, item);
        }

        private void SetTableIndividualButtonInformation(string buttonName, RepeaterItem item, bool val)
        {
            Button button = (Button)item.FindControl(buttonName);
            button.Enabled = val;
            button.Visible = val;
        }

        private void SetTableindividualLabelInformation(string labelName, string information, RepeaterItem item)
        {
            Label label = (Label)item.FindControl(labelName);
            label.Text = information;
        }

        protected void btnSubDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            Session["TaskWithLevels"] = UpdateTableInformation(GetTableDataSource(), "Delete", item.ItemIndex);
        }

        protected void btnSubAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            Session["TaskWithLevels"] = UpdateTableInformation(GetTableDataSource(), "Add", item.ItemIndex);
        }

        protected void btnSubEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            Session["TaskWithLevels"] = UpdateTableInformation(GetTableDataSource(), "Edit", item.ItemIndex);
        }

        #region ToDO
        //ToDo.
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

        /*
        private void ConfigureTreeView(ChildTaskContainer ctc)
        {
            
            TreeNode originalTaskNode = new TreeNode();

            originalTaskNode.Text = ctc.Task.Name;
            originalTaskNode.Value = ctc.Task.Id.ToString();
            trvTarea.Nodes.Add(originalTaskNode);
            if (ctc.ChildTasks != null)
            {
                foreach(ChildTaskContainer ctchild in ctc.ChildTasks)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = ctchild.Task.Name;
                    childNode.Value = ctc.Task.Id.ToString();
                    originalTaskNode.ChildNodes.Add(childNode);
                    ConfigureTreeView(ctchild, childNode);
                }
            }
        }

        private void ConfigureTreeView(ChildTaskContainer ctc, TreeNode node)
        {
            if (ctc.ChildTasks != null)
            {
                foreach (ChildTaskContainer ctchild in ctc.ChildTasks)
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = ctchild.Task.Name;
                    childNode.Value = ctc.Task.Id.ToString();
                    node.ChildNodes.Add(childNode);
                    ConfigureTreeView(ctchild, childNode);
                }
            }
        }
        */

        /* private void TreeListViewTest ()
         {
             TreeListView tlv = new TreeListView();
             tlv.add

         }*/
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
        #endregion

    }
}