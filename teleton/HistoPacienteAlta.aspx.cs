using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;

public partial class HistoPaciente : System.Web.UI.Page
{
    private BL.Paciente PAT = new BL.Paciente();
    private BL.Security Sec = new BL.Security();
    private static string _strUsuario = "";
    private static int _intExpe = 0;
    private static short _shtPrefijo = 0;
    private static DataTable dt_Hist;
    private static int centro;
    private static int p_expe;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];
        BL.Security sec = new BL.Security();
        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pBuscarExp"))
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

        if (!this.IsPostBack)
        {

            ddl_centro.DataSource = sec.getCentrosPermitidos(Session["nombre_usuario"].ToString());
            ddl_centro.DataBind();
            ddl_centro.SelectedIndex = 0;
            lb_mensaje.Enabled = false;
            lb_mensaje.Text = "";
        }
    }


    private void cargar_Historial()
    {
        centro = Convert.ToInt32(Sec.getCentroId(ddl_centro.SelectedValue.ToString()));
        lb_mensaje.Enabled = false;
        lb_mensaje.Text = "";
        txt_historial.Enabled = true;
        btn_guardar.Enabled = true;
        txt_historial.Text = "";
        if (txt_buscar.Text != "")
        {
            try
            {
                _intExpe = Convert.ToInt32(txt_buscar.Text);
                string str_temp = txt_buscar.Text;
                int int_temp = Convert.ToInt32(txt_buscar.Text);
                string[] str_Inf = new string[2];
                str_Inf = PAT.nombrePacienteAlta(Convert.ToInt32(txt_buscar.Text), centro);
                if (str_Inf != null && (str_Inf[0] != null && str_Inf[1] != null && str_Inf[1]!="@#$%error"))
                {
                    _strUsuario = str_Inf[0];
                    _shtPrefijo = Convert.ToInt16(str_Inf[1].ToString());
                    if (str_Inf[0] != "")
                    {
                        lb_Paciente.Text = str_Inf[0];
                        dt_Hist = PAT.historialAlta(p_expe, centro,Convert.ToInt32(Session["id_empleado"].ToString()));
                        if (dt_Hist != null)
                        {
                            lb_Expe.Text = "Num. Expe: " + txt_buscar.Text;
                            _intExpe = Convert.ToInt32(txt_buscar.Text);
                            grd_Historial.DataSource = dt_Hist;
                            grd_Historial.DataBind();  
                            txt_historial.Enabled = PAT.pacienteAlta(Convert.ToInt32(txt_buscar.Text), centro);
                            btn_guardar.Enabled = txt_historial.Enabled;
                            if (!txt_historial.Enabled)
                            {
                                lb_mensaje.Text = "El paciente esta dado de alta";
                            }
                        }
                        else
                        {
                            lb_Paciente.Text = "Error al obtener el Historial ...";
                            txt_historial.Enabled = false;
                            btn_guardar.Enabled = false;
                        }
                    }
                    else
                    {
                        lb_Paciente.Text = "Expediente no encontrado ...";
                        lb_Expe.Text = "";
                        txt_historial.Enabled = false;
                        btn_guardar.Enabled = false;
                    }
                }
                else
                {
                    lb_Paciente.Text = str_Inf[0];
                    txt_buscar.Text = "";
                    txt_historial.Text = "";
                    lb_Expe.Text = "";
                    dt_Hist = null;
                    grd_Historial.DataBind();
                    txt_historial.Enabled = false;
                    btn_guardar.Enabled = false;
                }
            }
            catch
            {
                lb_Paciente.Text = "Error, Tarea no Realizada";
                txt_historial.Enabled = false;
                btn_guardar.Enabled = false;
            }
        }
        else
        {
            lb_Paciente.Text = "Introduzca un expediente a buscar ...";
            txt_historial.Enabled = false;
            btn_guardar.Enabled = false;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            p_expe = Convert.ToInt32(txt_buscar.Text);
            if (PAT.isDoctor(Session["nombre_usuario"].ToString()))
            {
                cargar_Historial();
            }
            else
            {
                lb_Paciente.Text = "Su rol no esta autorizado para dar de alta";
                txt_buscar.Text = "";
                txt_historial.Text = "";
                lb_Expe.Text = "";
                dt_Hist = null;
                grd_Historial.DataBind();
                txt_historial.Enabled = false;
                btn_guardar.Enabled = false;
            }
        }
        catch
        {

        }
    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
                if (!PAT.guardarHistorialAlta(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss"))
                    , _intExpe, Session["nombre_usuario"].ToString(), txt_historial.Text, _shtPrefijo,Convert.ToInt32(Session["id_empleado"].ToString())))
                {
                    lb_Paciente.Text = "Error al tratar de guardar ...";
                }
                else
                {
                    PAT.editarPacienteAlta(false, Convert.ToInt32(txt_buscar.Text), centro);
                    txt_historial.Text = "";
                    lb_Expe.Text = "";
                    lb_Paciente.Text = "";
                    cargar_Historial();
                }
               
            }
            catch
            {
                lb_Paciente.Text = "Error al tratar de guardar ...";
                txt_buscar.Text = "";
                txt_historial.Text = "";
                lb_Expe.Text = "";
                dt_Hist = null;
                grd_Historial.DataBind();
                txt_historial.Enabled = false;
                btn_guardar.Enabled = false;
            }
        
    }
    protected void txt_buscar_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void Ver_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gdv_Hist = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int int_Index = gdv_Hist.RowIndex + (grd_Historial.PageIndex * grd_Historial.PageSize);
            string str_TMP = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.Text = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.ReadOnly = true;
            txt_historial.Font.Bold = true;
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + dt_Hist.Rows[int_Index][3].ToString() + "')",true);
        }
        catch(Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void grd_Historial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Historial.PageIndex = e.NewPageIndex;
            grd_Historial.DataSource = dt_Hist;
            grd_Historial.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void EntityDataSource1_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
    {

    }
    protected void ddl_centro_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}