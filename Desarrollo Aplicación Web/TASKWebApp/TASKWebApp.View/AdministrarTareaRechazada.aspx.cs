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
                if (!IsPostBack)
                {
                    LoadResponsibles();
                }
                int RejectedStatus = 5;
                int SuspendedStatus = 9;
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
                tasks = user.SearchProcessedTaskByStatus(RejectedStatus, true, true);
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
                else
                {
                    lblTareasRechazadas.Text = "No tiene tareas rechazadas pendientes";
                }
            }
            else if (status == SuspendedStatus)
            {
                tasks = user.SearchProcessedTaskByStatus(SuspendedStatus, true, true);
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
                else
                {
                    lblTareasSuspendidas.Text = "No tiene tareas suspendidas pendientes";
                }
            }
            else
            {
                lblTareasRechazadas.Text = "Error!";
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

        protected void btnSubEditarRechazados_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            ProcessedTask processedTask = new ProcessedTask() { Id = GetRowTaskId(item, true) };
            processedTask.Read();
            LoadEditBox(processedTask);
        }

        protected void btnSubEditarSuspendidos_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            ProcessedTask processedTask = new ProcessedTask() { Id = GetRowTaskId(item, false) };
            processedTask.Read();
            LoadEditBox(processedTask);
        }


        protected void btnSubEliminarRechazado_Click(object sender, EventArgs e)
        {
            divEditarInfo.Visible = false;
            int closedId = 6;
            int errorCode = -1;
            LinkButton button = (LinkButton)sender;
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
            divEditarInfo.Visible = false;
            int failedId = 7;
            int errorCode = -1;
            LinkButton button = (LinkButton)sender;
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

        private void LoadEditBox(ProcessedTask processedTask)
        {
            divEditarInfo.Visible = true;
            ddlResponsable.SelectedValue = processedTask.TaskAssignment.ReceiverUser.Id.ToString();
            lblInternalId.Text = processedTask.Id.ToString();
            if (processedTask.TaskAssignment.Task.IsPredefined)
            {
                txtNombreTarea.Enabled = false;
                txtDescripcion.Enabled = false;
                lblMessage.Text = "Tarea predeterminada, no puede editar nombre ni descripción";
            }
            txtNombreTarea.Text = processedTask.TaskAssignment.Task.Name;
            txtDescripcion.Text = processedTask.TaskAssignment.Task.Description;
            txtFechaInicio.Text = processedTask.StartDate.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
            txtFechaFin.Text = processedTask.EndDate.ToLocalTime().ToString("yyyy-MM-ddTHH:mm");
        }

        private int GetRowTaskId(RepeaterItem item, bool isRejected)
        {
            try
            {
                int index = item.ItemIndex;
                RepeaterItem IndItem;

                if (isRejected)
                    IndItem = repTablaRechazo.Items[index];
                else
                    IndItem = repTablaSuspension.Items[index];

                Label label = (Label)IndItem.FindControl("lblIdTarea");
                int idAssigned = int.Parse(label.Text);
                return idAssigned;
            }
            catch (Exception e)
            {
                return -1;
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int reassignedStatusId = 4;
            DateTime startDate;
            DateTime endDate;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtNombreTarea.Text) || DateTime.TryParse(txtFechaInicio.Text, out startDate) == false || DateTime.TryParse(txtFechaFin.Text, out endDate) == false)
            {
                lblMessage.Text = "Los datos ingresados son inválidos";
            }
            else
            {
                ProcessedTask processedTask = new ProcessedTask() { Id = int.Parse(lblInternalId.Text) };
                if (processedTask.Read() && processedTask.TaskAssignment.AssignerUser.Id == ((User)Session["ses"]).Id)
                {
                    if(processedTask.TaskAssignment.Task.IsPredefined == false)
                    {
                        processedTask.TaskAssignment.Task.Name = txtNombreTarea.Text;
                        processedTask.TaskAssignment.Task.Description = txtDescripcion.Text;
                        processedTask.TaskAssignment.Task.Update();
                    }
                    processedTask.Commentary = null;
                    processedTask.StartDate = startDate;
                    processedTask.EndDate = endDate;
                    processedTask.AssignationDate = DateTime.Now;
                    processedTask.IdTaskStatus = reassignedStatusId;
                    processedTask.TaskAssignment.ReceiverUser = new User(int.Parse(ddlResponsable.SelectedValue));
                    processedTask.TaskAssignment.Update();
                    processedTask.TaskAssignment.Task.Update();
                    processedTask.Update();
                    Response.Redirect("AdministrarTareaRechazada.aspx");
                }
                else
                {
                    lblMessage.Text = "Error desconocido.";
                }
            }
        }
    }
}