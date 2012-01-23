using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Agregados
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

public partial class Exportar_Seguimiento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;

            foreach (string rol in permisos)
            {
                if (rol.Equals("pSegPac"))
                {
                    permisoEncontrado = true;
                    break;
                }
            }

            if (!permisoEncontrado)
            {
                //Si no tiene permiso redireccionamos
                //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
                Response.Redirect("NoAccess.aspx");
            }

            ceFechaFinal.SelectedDate = DateTime.Now;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
               
    }

    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {
            BL.SeguimientoPacientes segPacientes = new BL.SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());

            gvSeguimientoPaciente.DataSource = segPacientes.BusquedaporRangoFecha2(DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text), centroId);
            gvSeguimientoPaciente.DataBind();

            btExportar.Visible = true;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }
    
    protected void btExportar_Click(object sender, EventArgs e)
    {
        exportToExcel("Export.xls", gvSeguimientoPaciente);
    }

    private void exportToExcel(string nameReport, GridView fuente)
    {
        HttpResponse response = Response;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page pageToRender = new Page();
        HtmlForm form = new HtmlForm();
        form.Controls.Add(fuente);
        pageToRender.Controls.Add(form);
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
        response.Charset = "UTF-8";
        response.ContentEncoding = Encoding.Default;
        pageToRender.RenderControl(htw);
        response.Write(sw.ToString());
        response.End();
    }
}