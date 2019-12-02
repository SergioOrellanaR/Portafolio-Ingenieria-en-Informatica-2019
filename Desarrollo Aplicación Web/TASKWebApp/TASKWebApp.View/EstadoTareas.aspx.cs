using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using TASKWebApp.Business.Classes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.UI;
using System.Globalization;

namespace TASKWebApp.View
{
    public partial class EstadoTareas : System.Web.UI.Page
    {
        public static bool? isDefaultLoad;
        public static List<ViewAssociatedTaskToUser> searchedList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.btnGeneratePDF);
            try
            {
                User user = (User)Session["ses"];

                if (!IsPostBack)
                {
                    LoadResponsibles(user);
                }
                
                
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
            btnGeneratePDF.Visible = true;
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

        private string GenerateReportTitle()
        {
            string responsible;
            string dates;
            string status;
            string message = null;
            
            if (searchedList != null && searchedList.Count>0)
            {
                ViewAssociatedTaskToUser task = searchedList[0];

                if (ddlResponsable.SelectedIndex == 0)
                    responsible = task.AssignerName;
                else
                    responsible = task.ReceiverName;

                int idMonth = int.Parse(ddlMeses.SelectedValue);
                int year = int.Parse(ddlAño.SelectedValue);

                if (idMonth != 13)
                    dates = "de "+year.ToString();
                else
                    dates = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(idMonth) + "de " + year.ToString();

                int stat = int.Parse(ddlEstados.SelectedValue);

                if (stat == 0)
                    status = "Todos los estados";
                else
                    status = task.TaskStatus;

                message = string.Format("Tareas de {0} {1} ({2})", responsible, dates, status);
            }

            return message;
        }

        private string GenerateReportName()
        {
            string responsible;
            string dates;
            string status;
            string message = null;

            if (searchedList != null && searchedList.Count > 0)
            {
                ViewAssociatedTaskToUser task = searchedList[0];

                if (ddlResponsable.SelectedIndex == 0)
                    responsible = task.AssignerName;
                else
                    responsible = task.ReceiverName;

                int idMonth = int.Parse(ddlMeses.SelectedValue);
                int year = int.Parse(ddlAño.SelectedValue);

                if (idMonth == 13)
                    dates = year.ToString();
                else
                    dates = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(idMonth) + "_" + year.ToString();

                int stat = int.Parse(ddlEstados.SelectedValue);

                if (stat == 0)
                    status = "Todos";
                else
                    status = task.TaskStatus;

                message = string.Format("{0}_{1}_({2}).pdf", responsible, dates, status);
            }

            return message;
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                //string projectPath = @"~/Reports/Reporte.pdf";
                string startPath = AppContext.BaseDirectory;
                string reportPath = startPath+"Reports\\Reporte.pdf";

                DataTable dtbl = MakeDatatable();
                ExportDataTableToPdf(dtbl, reportPath, GenerateReportTitle(), startPath);
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.AppendHeader("content-disposition", "attachment; filename="+ GenerateReportName());
                response.ContentType = "application/octet-stream";
                response.WriteFile(reportPath);
                response.Flush(); 
                response.SuppressContent = true; 
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exce)
            {
                string val = exce.Message;
            }
        }

        private void ExportDataTableToPdf(DataTable dtbl, String pdfPath, string header, string startPath)
        {

            try
            {
                FileStream fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                Document document = new Document();
                document.SetPageSize(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                //Report Header
                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntHead = new Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
                Paragraph prgHeading = new Paragraph();
                prgHeading.Alignment = Element.ALIGN_CENTER;
                prgHeading.Add(new Chunk(header.ToUpper(), fntHead));
                document.Add(prgHeading);

                //Author
                Paragraph prgAuthor = new Paragraph();
                BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntAuthor = new Font(btnAuthor, 8, 2, BaseColor.GRAY);
                prgAuthor.Alignment = Element.ALIGN_LEFT;
                prgAuthor.Add(new Chunk("Fecha de reporte: " + DateTime.Now.ToShortDateString(), fntAuthor));
                document.Add(prgAuthor);

                //Img
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(startPath+ "img\\logo.png");
                logo.ScaleAbsoluteWidth(67);
                logo.ScaleAbsoluteHeight(53);
                logo.Alignment = Element.ALIGN_RIGHT;
                document.Add(logo);

                //Separador de Linea.
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 0.0F)));
                document.Add(p);

                document.Add(new Chunk("\n", fntHead));

                //Escribir la tabla:
                PdfPTable table = new PdfPTable(dtbl.Columns.Count);
                table.WidthPercentage = 100;
                //Header de tabla.
                BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntColumnHeader = new Font(btnColumnHeader, 7, 1, BaseColor.WHITE);
                for (int i = 0; i < dtbl.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = BaseColor.GRAY;
                    cell.AddElement(new Chunk(dtbl.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table.AddCell(cell);
                }
                //Datos de table.
                BaseFont btnColumnData = BaseFont.CreateFont();
                Font fntColumnData = new Font(btnColumnData, 6, 0); 
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    for (int j = 0; j < dtbl.Columns.Count; j++)
                    {

                        PdfPCell cell = new PdfPCell();
                        cell.AddElement(new Chunk(dtbl.Rows[i][j].ToString(), fntColumnData));
                        table.AddCell(cell);
                    }
                }
                document.Add(table);
                document.Close();
                writer.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                string val = e.Message;
            }
        }

        DataTable MakeDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha de asignación");
            dt.Columns.Add("Fecha de Inicio");
            dt.Columns.Add("Fecha de Fin");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Nombre de asignador");
            dt.Columns.Add("Nombre de recibidor");
            dt.Columns.Add("Justificación");

            foreach (GridViewRow row in grdTareas.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < grdTareas.Columns.Count; j++)
                {
                    dr[j] = row.Cells[j].Text;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        
    }
}