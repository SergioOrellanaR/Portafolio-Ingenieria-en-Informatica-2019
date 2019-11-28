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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                User user = (User)Session["ses"];
                LoadResponsibles(user);
                LoadDefaultDataGridData(user);
            }
            catch
            {
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
            List<ViewAssociatedTaskToUser> list = user.RealizeFiltering(user.Id, idAllMonths, DateTime.Now.Year, idAllStatus, true);
            grdTareas.DataSource = list;
            grdTareas.DataBind();
            btnImprimirReporte.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
    }
}