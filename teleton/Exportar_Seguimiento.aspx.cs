using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Agregados
using System.Web.UI.HtmlControls;
using BL;
using System.Data;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;


public partial class Exportar_Seguimiento : System.Web.UI.Page
{

    private HSSFWorkbook Libro;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            List<string> permisos = (List<string>)Session["Permisos_usuario"];
            bool permisoEncontrado = false;
            Paciente pac = new Paciente();
            
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

            if (!IsPostBack)
            {
                if (!pac.isDoctor(Session.Contents["nombre_usuario"].ToString()))
                    cargarDoctores();
                else
                    cargarDoctor();
            }

            ceFechaFinal.SelectedDate = DateTime.Now;
            ceFechaInicio.SelectedDate = DateTime.Now;
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
               
    }

    private void cargarDoctores()
    {
        try
        {
            BL.Empleados doctores = new BL.Empleados();
            Usuarios usuarios = new Usuarios();
            Paciente pac = new Paciente();

            List<string> usuariosTemp = usuarios.RetrieveUserNames();
            List<string> usersDocs = new List<string>();
            List<long> ids = new List<long>();
            List<string> nombres = new List<string>();
            List<string> apellido = new List<string>();
            List<string> segundoApellido = new List<string>();

            foreach (string doc in usuariosTemp)
            {
                if (pac.isDoctor(doc))
                {
                    ids.Add(usuarios.retriveEmpId(doc));
                    usersDocs.Add(doc);
                }
            }

            foreach (long codigo in ids)
            {
                nombres.Add(doctores.obtenerNombresDoctores(codigo));
                apellido.Add(doctores.obtenerApellidoDoctores(codigo));
                segundoApellido.Add(doctores.obtenerSegundoApellidoDoctores(codigo));
            }

            ListItem temporal = new ListItem();
            temporal.Text = "--- Todos ---";
            temporal.Value = "todos";
            temporal.Selected = true;
            ddlDoctor.Items.Add(temporal);

            for (int i = 0; i < nombres.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = nombres[i] + " " + apellido[i] + " " + segundoApellido[i];
                item.Value = usersDocs[i].ToString();
                ddlDoctor.Items.Add(item);
            }
        }
        catch (Exception error)
        {
            Session["Error_Msg"] = error.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void cargarDoctor()
    {
        BL.Empleados doctor = new BL.Empleados();
        int codigo = Convert.ToInt32(Session["id_empleado"].ToString());
        string nombre = doctor.obtenerNombre(codigo);

        ListItem item = new ListItem();
        item.Text = nombre;
        item.Value = Convert.ToString(Session.Contents["nombre_usuario"]);
        item.Selected = true;
        ddlDoctor.Items.Add(item);
        ddlDoctor.Visible = false;
        lblDoctor.Visible = false;
    }

    protected void btEjecutar_Click(object sender, EventArgs e)
    {
        try
        {
            SeguimientoPacientes segPacientes = new SeguimientoPacientes();
            int centroId = (int)long.Parse(Session["Centro_idNum"].ToString());

            gvSeguimientoPaciente.DataSource = segPacientes.BusquedaporRangoFecha2(DateTime.Parse(txtFechaInicio.Text), DateTime.Parse(txtFechaFinal.Text), centroId, ddlDoctor.SelectedValue);
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
        /*string filename = "Export.xls";
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", String.Format("attachment;filename={0}", filename));
        Response.Clear();

        inicializarLibro();
        generarDatos();
        
        Response.BinaryWrite(escribirStream().GetBuffer());
        Response.End();*/
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

    private void inicializarLibro()
    {
        Libro = new HSSFWorkbook();

        //Crea una entrada a DocumentSummaryInformation
        DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        dsi.Company = "Unitec";
        Libro.DocumentSummaryInformation = dsi;

        //Crea una entrada para SummaryInformation
        SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        si.Subject = "Desarrollado por alumnos de Ing. Software II periodo 2012";
        Libro.SummaryInformation = si;
    }

    private void generarDatos()
    {
        ISheet hoja1 = Libro.CreateSheet("Hoja1");
        hoja1.DisplayGridlines = false;

        int alto = gvSeguimientoPaciente.Rows.Count;
        int ancho = gvSeguimientoPaciente.Columns.Count;

        IRow fila = hoja1.CreateRow(0);
        for (int j = 0; j < ancho; j++)
        {
            IFont fuente = Libro.CreateFont();
            fuente.Color = HSSFColor.WHITE.index;

            ICellStyle estilo = Libro.CreateCellStyle();
            estilo.FillForegroundColor = HSSFColor.BLACK.index;
            estilo.FillPattern = FillPatternType.SOLID_FOREGROUND;
            
            estilo.BorderBottom = NPOI.SS.UserModel.BorderStyle.MEDIUM;
            estilo.BottomBorderColor = HSSFColor.BLACK.index;
            
            estilo.BorderLeft = NPOI.SS.UserModel.BorderStyle.MEDIUM;
            estilo.LeftBorderColor = HSSFColor.BLACK.index;

            estilo.BorderRight = NPOI.SS.UserModel.BorderStyle.MEDIUM;
            estilo.RightBorderColor = HSSFColor.BLACK.index;

            estilo.BorderTop = NPOI.SS.UserModel.BorderStyle.MEDIUM;
            estilo.TopBorderColor = HSSFColor.BLACK.index;
            
            estilo.SetFont(fuente);
            
            ICell celda = fila.CreateCell(j);
            celda.CellStyle = estilo;
            celda.SetCellValue(gvSeguimientoPaciente.HeaderRow.Cells[j].Text.ToString());
        }
        
        for (int i = 1; i <= alto; i++)
        {
            IRow row = hoja1.CreateRow(i);
            for (int j = 0; j < ancho; j++)
            {
                ICellStyle estilo = Libro.CreateCellStyle();
                estilo.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
                estilo.BottomBorderColor = HSSFColor.BLACK.index;

                estilo.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
                estilo.LeftBorderColor = HSSFColor.BLACK.index;

                estilo.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
                estilo.TopBorderColor = HSSFColor.BLACK.index;

                estilo.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
                estilo.RightBorderColor = HSSFColor.BLACK.index;
                
                ICell celda = row.CreateCell(j);
                celda.CellStyle = estilo;
                celda.SetCellValue(gvSeguimientoPaciente.Rows[i - 1].Cells[j].Text);
            }
        }
    }

    private MemoryStream escribirStream()
    {
        MemoryStream file = new MemoryStream();
        Libro.Write(file);
        return file;
    }
}