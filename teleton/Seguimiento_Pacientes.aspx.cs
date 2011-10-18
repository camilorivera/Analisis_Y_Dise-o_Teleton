using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using BL;

public partial class Seguimiento_Pacientes : System.Web.UI.Page
{
    private BL.SeguimientoPacientes segPacientes = new BL.SeguimientoPacientes();
    int centroid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;
        centroid = (int)long.Parse(Session["Centro_idNum"].ToString());

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pSegPac"))
            {
                encontroPermiso = true;
                break;
            }
        }

        if (!encontroPermiso)
        {
            //Si no tiene permiso redireccionamos
            //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
            Response.Redirect("NoAccess.aspx");
        }

        this.busqueda.Attributes["onclick"] = "openPopUp()";

        try
        {
            if (!this.IsPostBack)
            {
                InicializarSeguimientoPacientes();

            }
            else
            {
                var ctrlName = Request.Params[Page.postEventSourceID];
                var args = Request.Params[Page.postEventArgumentID];

                HandleCustomPostbackEvent(ctrlName, args);

            }
        }

        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void HandleCustomPostbackEvent(string ctrlName, string args)
    {
        try
        {
            if (ctrlName == txtnumexp.UniqueID && args == "OnBlur")
            {
                if (txtnumexp.Text == "") return;
                if (segPacientes.VerificarPacientes(txtnumexp.Text))
                {
                    txtnombrepac.Text = segPacientes.NombrePaciente(txtnumexp.Text);
                    txtnumced.Text = segPacientes.NumIdentidad(txtnumexp.Text);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Num de Expediente no ha sido Registrado')", true);
                    txtnumced.Text = txtnombrepac.Text = txtnumexp.Text = "";
                }
            }
            else
            {
                txtnombrepac.Text = "";
                txtnumced.Text = "";
            }

        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
            
        }
}

    public void InicializarSeguimientoPacientes()
    {
        try
        {
            LBLDATE.Text = segPacientes.GetFecha();
            CargarPatologias();
            txtdateinit.Text = segPacientes.GetFecha();
            txtdatefini.Text = segPacientes.GetFecha();
            GridViewSegPac.DataSource = segPacientes.RetrievePacientesDiario(centroid);
            GridViewSegPac.DataBind();

            centroid = (int)long.Parse(Session["Centro_idNum"].ToString());
            txtnombrepac.Enabled = false;
            txtnumced.Enabled = false;
        }
        catch (Exception er) {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }

        
    }

    public void LoadGrid()
    {
        try
        {
            GridViewSegPac.DataSource = segPacientes.RetrievePacientesDiario(centroid);
            GridViewSegPac.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void LoadGridFiltrado()
    {
        try
        {
            DateTime inicial = Convert.ToDateTime(txtdateinit.Text);
            DateTime final = Convert.ToDateTime(txtdatefini.Text);

            GridViewSegPac.DataSource = segPacientes.BusquedaporRangoFecha(inicial, final, centroid);
            GridViewSegPac.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarPatologias()
    {
        try
        {
            cmb_patologias.Items.Clear();
            cmb_patologias.DataSource = segPacientes.RetrievePatologias();
            cmb_patologias.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void Refrescar_Click1(object sender, ImageClickEventArgs e)
    {

        try
        {
            DateTime fechainit = DateTime.Parse(txtdateinit.Text);
            DateTime fechafin = DateTime.Parse(txtdatefini.Text);

            if (fechainit.Year > fechafin.Year || fechainit.Month > fechafin.Month || fechainit.Day > fechafin.Day)
            {
                Label1.Visible = true;
            }
            else
            {
                Label1.Visible = false;
                GridViewSegPac.DataSource = segPacientes.BusquedaporRangoFecha(fechainit, fechafin,centroid);
                GridViewSegPac.DataBind();
            }

        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }

    protected void btnguardarseguimiento_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsPostBack)
            {
                if (this.IsValid)
                {
                    string empleado = Session["nombre_usuario"].ToString();
                    int exped = (int)long.Parse(txtnumexp.Text);

                    if (segPacientes.VerificarPacientes(txtnumexp.Text))
                    {
                        if (segPacientes.VerificarExpPorCentro(exped) == centroid)
                        {
                            string fecha1 = txtdateinit.Text;
                            string fecha2 = txtdatefini.Text;

                            if (fecha1 != segPacientes.GetFecha() || fecha2 != segPacientes.GetFecha())
                            {

                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('No Puede Guardar Pacientes en una Fecha Diferente a " + segPacientes.GetFecha() + "')", true);
                            }
                            else
                            {
                                segPacientes.GuardarSeguimientoPacientes(0, centroid, exped, empleado, cmb_patologias.Text, txtobser.Text);
                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Paciente Guardado Exitosamente')", true);
                                txtnumexp.Text = "";
                                txtobser.Text = "";
                                LoadGrid();
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Num de Expediente no Pertenece a su Centro')", true);
                            txtnumexp.Text = "";
                        }
                    }
                    else {
                       Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Num de Expediente no ha sido Registrado')", true);
                        txtnumexp.Text = "";                    
                    }
                }
            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    
    protected void GridViewSegPac_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewSegPac.PageIndex = e.NewPageIndex;
            LoadGridFiltrado();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }


    protected void TextBox8_Init(object sender, EventArgs e)
    {
        try
        {
            var onBlurScript = Page.ClientScript.GetPostBackEventReference(txtnumexp, "OnBlur");
            txtnumexp.Attributes.Add("onblur", onBlurScript);
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }

    
    protected void btnexport_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        GridViewSegPac.EnableViewState = false;

        page.EnableEventValidation = false;
        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(GridViewSegPac);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "text/HTML";
        Response.AddHeader("Content-Disposition", "attachment;filename=DataSeguimientodePacientes.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }
}