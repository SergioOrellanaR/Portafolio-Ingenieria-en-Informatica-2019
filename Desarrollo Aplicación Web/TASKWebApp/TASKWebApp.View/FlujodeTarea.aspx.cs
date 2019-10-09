using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            if(taskFlowInfo.IsPredefined)
            {
                
                //ToDo: Cargar N Divs
            }
            else
            {
                LoadDivInformation(taskFlowInfo);
                LoadFirstTaskDiv();
            }
        }

        private void LoadDivInformation(TaskFlowInfo taskFlowInfo)
        {
            if(taskFlowInfo.IsRepetitive)
            {
                LoadUniqueTaskTypeDiv(false);
            }
            else
            {
                LoadUniqueTaskTypeDiv(true);
            }
        }

        private void LoadUniqueTaskTypeDiv(bool val)
        {
            divTareaUnica.Visible = val;
            divTareaRepetitiva.Visible = !val;
        }

        private void LoadDependenciesDiv(bool val)
        {
            divDependencia.Visible = val;
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

        private void LoadNDiv()
        {
            Div1.InnerHtml = "";
            string htmlDivTarea = divTarea.InnerHtml;
            lblMeme.Text = htmlDivTarea;
        }
    }
}