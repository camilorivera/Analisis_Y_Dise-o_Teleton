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
    private BL.SeguimientoPacientes segPacientes;
    private BL.Paciente paciente;
    int centroid;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Form.DefaultButton = busqueda.UniqueID;
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        segPacientes = new BL.SeguimientoPacientes();
        paciente = new BL.Paciente();

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
                cambiarEnabled(false);
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
            string empleado = Session["nombre_usuario"].ToString();

            if (txtnumexp.Text == "") return;
            if (paciente.isDoctor(empleado))
            {
                /*if (ctrlName == txtnumexp.UniqueID)
                {
                  */
                    if (segPacientes.VerificarPacientes(txtnumexp.Text))
                    {
                        if (segPacientes.VerificarPacienteAlta(txtnumexp.Text))
                        {
                            cambiarEnabled(true);
                            int expid = (int)long.Parse(this.txtnumexp.Text);
                            txtnombrepac.Text = segPacientes.NombrePaciente(txtnumexp.Text);
                            txtnumced.Text = segPacientes.NumIdentidad(txtnumexp.Text);
                            //txtFuncionEstructura.Text = segPacientes.ActividadesPaciente(expid);
                            //txtFuncionEstructura.Text = segPacientes.EstructuraPaciente(expid);       
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('El Paciente está dado de Alta')", true);
                            txtnumced.Text = txtnombrepac.Text = txtnumexp.Text = "";
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Num de Expediente no ha sido Registrado')", true);
                        txtnumced.Text = txtnombrepac.Text = txtnumexp.Text = "";
                    }

                }
                /*else
                {
                    txtnombrepac.Text = "";
                    txtnumced.Text = "";
                }*/
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Lo sentimos, usted no posee privilegios suficientes.. ')", true);
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
            DateTime _dt = Convert.ToDateTime(segPacientes.GetFecha());
            LBLDATE.Text = _dt.ToString("dd-MM-yyyy");
            CargarPatologias();
            CargarClasificacionPaciente();
            CargarOcupaciones();
            CargarGrado();
            CargarCondiciones();
            CargarReferencias();
            CargarTipoDaño();
            CargarAyudasTecnicas();

            //txtdateinit.Text = _dt.ToString("dd/MM/yyyy");
            //txtdatefini.Text = _dt.ToString("dd/MM/yyyy");
            GridViewSegPac.DataSource = segPacientes.RetrievePacientesDiario2(centroid, Session["nombre_usuario"].ToString());
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
            GridViewSegPac.DataSource = segPacientes.RetrievePacientesDiario2(centroid, Session["nombre_usuario"].ToString());
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
            //DateTime inicial = Convert.ToDateTime(txtdateinit.Text);
            //DateTime final = Convert.ToDateTime(txtdatefini.Text);

            //GridViewSegPac.DataSource = segPacientes.BusquedaporRangoFecha(inicial, final, centroid);
            //GridViewSegPac.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    #region CargarCombos
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

    public void CargarClasificacionPaciente() 
    {
        try
        {
            cmb_ClasificacionPaciente.Items.Clear();
            cmb_ClasificacionPaciente.DataSource = segPacientes.RetrieveClasificacionDelPaciente();
            cmb_ClasificacionPaciente.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx",true);
        }
    }

    public void CargarGrado()
    {
        try
        {
            cmb_GradoDeInstruccion.Items.Clear();
            cmb_GradoDeInstruccion.DataSource = segPacientes.RetrieveGrado();
            cmb_GradoDeInstruccion.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarOcupaciones()
    {
        try
        {
            cmb_OcupacionActual.Items.Clear();
            cmb_OcupacionActual.DataSource = segPacientes.RetrieveOcupaciones();
            cmb_OcupacionActual.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarCondiciones()
    {
        try
        {
            cmb_Condicion.Items.Clear();
            cmb_Condicion.DataSource = segPacientes.RetrieveCondiciones();
            cmb_Condicion.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarReferencias()
    {
        try
        {
            cmb_Referencia.Items.Clear();
            cmb_Referencia.DataSource = segPacientes.RetrieveReferencias();
            cmb_Referencia.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarTipoDaño()
    {
        try
        {
            cmb_TipoDaño.Items.Clear();
            cmb_TipoDaño.DataSource = segPacientes.RetrieveTipoDanio();
            cmb_TipoDaño.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    public void CargarAyudasTecnicas()
    {
        try
        {
            cmb_AyudaTecnicaIndicada.Items.Clear();
            cmb_AyudaTecnicaIndicada.DataSource = segPacientes.RetrieveAyudasTecnicas();
            cmb_AyudaTecnicaIndicada.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    #endregion

    private void cambiarEnabled(Boolean b) 
    {
        cmb_GradoDeInstruccion.Enabled = b;
        cmb_OcupacionActual.Enabled = b;
        cmb_ClasificacionPaciente.Enabled = b;
        cmb_Condicion.Enabled = b;
        cmb_patologias.Enabled = b;
        cmb_Referencia.Enabled = b;
        cmb_TipoDaño.Enabled = b;
        
        txt_TDAnios.Enabled = b;
        txt_TDMeses.Enabled = b;
        txt_TDDias.Enabled = b;
        txt_TSAnios.Enabled = b;
        txt_TSMeses.Enabled = b;
        txt_TSDias.Enabled = b;

        cmb_Sexo.Enabled = b;
        txtobser.Enabled = b;

        cmb_AyudaTecnicaIndicada.Enabled = b;
        txtEteologia.Enabled = b;
        cmb_Procedencia.Enabled = b;
        txtFuncionEstructura.Enabled = b;
        txtActividadesParticipacion.Enabled = b;
    }

    protected void Refrescar_Click1(object sender, ImageClickEventArgs e)
    {   /*
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
        }*/

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
                            /*string laFecha = segPacientes.GetFecha();
                            // Arreglar
                            if(laFecha.StartsWith("0"))
                            {
                                laFecha = laFecha.Substring(1,laFecha.Length-1);
                            }

                            /*if (fecha1 != laFecha || fecha2 != laFecha)
                            {

                                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('No Puede Guardar Pacientes en una Fecha Diferente a " + segPacientes.GetFecha() + "')", true);
                            }
                            else
                            {*/

                                if (txt_TDAnios.Text == "" || txt_TDMeses.Text == "" || txt_TDDias.Text == "" ||
                                    txt_TSAnios.Text == "" || txt_TSMeses.Text == "" || txt_TSDias.Text == "")
                                {
                                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Datos de Tiempo de Incapacidad fueron ingresados Incorrectamente, favor revisar')", true);
                                }
                                else
                                {
                                    segPacientes.GuardarSeguimientoPacientes(0, centroid, exped, empleado, cmb_patologias.Text, txtobser.Text, cmb_ClasificacionPaciente.Text,
                                                                             cmb_GradoDeInstruccion.Text, cmb_OcupacionActual.Text, cmb_Condicion.Text, cmb_Referencia.Text,
                                                                             cmb_TipoDaño.Text, cmb_AyudaTecnicaIndicada.Text, txtFuncionEstructura.Text, txtEteologia.Text, cmb_Procedencia.Text,
                                                                             Convert.ToInt32(txt_TDAnios.Text), Convert.ToInt32(txt_TDMeses.Text), Convert.ToInt32(txt_TDMeses.Text), Convert.ToInt32(txt_TSAnios.Text),
                                                                             Convert.ToInt32(txt_TSMeses.Text), Convert.ToInt32(txt_TSDias.Text), txtActividadesParticipacion.Text);
                                   
                                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Paciente Guardado Exitosamente')", true);

                                    txtnombrepac.Text = "";
                                    txtnumced.Text = "";
                                    txtnumexp.Text = "";
                                    txtobser.Text = "";
                                    txtEteologia.Text = 
                                    txtActividadesParticipacion.Text = "";
                                    txtFuncionEstructura.Text = "";
                                    cambiarEnabled(false);
                                    LoadGrid(); //carga grid cargada en session de usuario.*/
                                 }
                            //}
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
    protected void FechaIngresoExtender_Init(object sender, EventArgs e)
    {
        
    }
    protected void txtdateinit_PreRender(object sender, EventArgs e)
    {
        
    }
    protected void GridViewSegPac_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


}