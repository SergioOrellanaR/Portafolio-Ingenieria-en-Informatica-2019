using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TASKWebApp.Business.Classes;

namespace TASKWebApp.View
{
    public partial class EstadoTareas : System.Web.UI.Page
    {
        public static bool? isDefaultLoad;
        public static List<ViewAssociatedTaskToUser> searchedList;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                User user = (User)Session["ses"];
                LoadResponsibles(user);
                
                if (isDefaultLoad == null || isDefaultLoad == true)
                    LoadDefaultDataGridData(user);
                else
                    FilteredSearch();
            }
            catch (Exception exc)
            {
                string val = exc.Message;
                Response.Redirect("Home.aspx");
            }
        }

        private void LoadResponsibles(User user)
        {
            ddlResponsable.Items.Clear();
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(user.Id, string.Format("{0} {1} (Yo mismo)", user.FirstName, user.LastName));
            user.GetEqualsAndSubordinatedString().ToList().ForEach(x => dictionary.Add(x.Key, x.Value));
            ddlResponsable.DataSource = dictionary;
            ddlResponsable.DataTextField = "Value";
            ddlResponsable.DataValueField = "Key";
            ddlResponsable.DataBind();
        }

        private void LoadDefaultDataGridData(User user)
        {
            int idAllMonths = 13;
            int idAllStatus = 0;
            searchedList = user.RealizeFiltering(user.Id, idAllMonths, DateTime.Now.Year, idAllStatus, true);
            BindDataGridData(searchedList);
            isDefaultLoad = true;
        }

        private void BindDataGridData (List<ViewAssociatedTaskToUser> list)
        {
            grdTareas.DataSource = list;
            grdTareas.DataBind();
            btnImprimirReporte.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            FilteredSearch();
        }

        private void FilteredSearch()
        {
            User user = new User();

            int idResponsible = int.Parse(ddlResponsable.SelectedValue);
            int idMonth = int.Parse(ddlMeses.SelectedValue);
            int year = int.Parse(ddlAño.SelectedValue);
            int status = int.Parse(ddlEstados.SelectedValue);
            bool isAssigner = false;

            if (ddlResponsable.SelectedIndex == 0)
                isAssigner = true;

            searchedList = user.RealizeFiltering(idResponsible, idMonth, year, status, isAssigner);
            BindDataGridData(searchedList);
            isDefaultLoad = false;
        }

        protected void grdTareas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTareas.PageIndex = e.NewPageIndex;
            grdTareas.DataSource = searchedList;
            grdTareas.DataBind();
        }
    }
}