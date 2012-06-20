using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;

public partial class HistoPacienteFrameAltaAreas : System.Web.UI.Page
{
    private BL.Paciente PAT = new BL.Paciente();
    private BL.Security Sec = new BL.Security();
    private BL.Permiso Per = new BL.Permiso();
    private static string _strUsuario = "";
    private static int _intExpe = 0;
    private static short _shtPrefijo = 0;
    private static DataTable dt_Hist;
    public static string txt_buscar;
    public static int centro;
    public static int areaid;
    private static string usuario_logeado;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        List<String> listaPermisos = Per.getPermisosID();
        bool encontroPermiso = false;
        
        if (PAT.isDoctor(Session["nombre_usuario"].ToString()))
        {


            Session["id"] = Request.QueryString["id"];
            if (Session["id"] != null)
            {
                 string tmp = Sec.getNameArea(Convert.ToInt32(Request.QueryString["id"]));
            foreach (String strPermiso in listaPermisos)
            {
                //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
                if (strPermiso.Contains(tmp.ToLower()))
                {
                    encontroPermiso = true;
                    break;
                }
            }

            if (!encontroPermiso)
            {
                btn_guardar.Visible = false;
            }
            else
            {
                btn_guardar.Visible = true;
            }

                lb_area.Visible = true;
                lb_area0.Visible = true;
                lb_area.Text = tmp;
                lb_area0.Text = "Area: ";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            cargar_Historial();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Usted no posee suficientes privilegios')", true);
        }
    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (btn_guardar.Text == "Nuevo")
        {
            txt_historial.Enabled = true;
            CheckBox1.Enabled = true;
            txt_historial.Text = "";
            CheckBox1.Checked = false;
            btn_guardar.Text = "Guardar";
        }
        else
        {
            try
            {
               
                if (!PAT.guardarHistoPacienteAltaAreas(_intExpe, _shtPrefijo, DateTime.Now, Convert.ToInt32(Session["id_empleado"].ToString()), txt_historial.Text, Convert.ToInt32(Session["id"].ToString()), CheckBox1.Checked))
                {
                    lb_Paciente.Text = "Error al tratar de guardar ...";
                }
                else
                {
                    //PAT.editarPacienteAlta(false, Convert.ToInt32(txt_buscar), centro);
                    lb_Expe.Text = "";
                    lb_Paciente.Text = "";
                    txt_historial.Text = "";
                    CheckBox1.Checked = false;
                    cargar_Historial();
                }

            }
            catch
            {
                lb_Paciente.Text = "Excepción al tratar de guardar ...";
                txt_buscar = "";
                txt_historial.Text = "";
                lb_Expe.Text = "";
                dt_Hist = null;
                grd_Historial.DataBind();
                txt_historial.Enabled = false;
                btn_guardar.Enabled = false;
            }
        }
    }


    private void cargar_Historial()
    {

        if (Session["expediente"] != null && (string)Session["expediente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty)
        {
            if (Session["id"] != null) //Session["id"] -> Area
            {
                try
                {
                    txt_buscar = Session["expediente"].ToString();
                    int p_expe =Convert.ToInt32( Session["expediente"].ToString());
                    centro = Convert.ToInt32(Sec.getCentroId(Session["centro"].ToString()));
                    areaid = Convert.ToInt32(Session["id"].ToString());
                    usuario_logeado = Session["nombre_usuario"].ToString();
                    lb_mensaje.Enabled = false;
                    lb_mensaje.Text = "";
                    CheckBox1.Enabled = true;

                    _intExpe = Convert.ToInt32(txt_buscar);
                    string str_temp = txt_buscar;
                    int int_temp = Convert.ToInt32(txt_buscar);
                    string[] str_Inf = new string[2];
                    str_Inf = PAT.nombrePacienteAlta(Convert.ToInt32(txt_buscar), centro);
                    if (str_Inf != null && (str_Inf[0] != null && str_Inf[1] != null && str_Inf[1] != "@#$%error"))
                    {
                        _strUsuario = str_Inf[0];
                        _shtPrefijo = Convert.ToInt16(str_Inf[1].ToString());
                        if (str_Inf[0] != "")
                        {
                            lb_Paciente.Text = str_Inf[0];
                            dt_Hist = PAT.HistoPacienteAltaAreas(p_expe, centro, Convert.ToInt32(Session["id_empleado"].ToString()),areaid);
                            if (dt_Hist != null)
                            {
                                lb_Expe.Text = "Num. Expe: " + txt_buscar;
                                _intExpe = Convert.ToInt32(txt_buscar);
                                grd_Historial.DataSource = dt_Hist;
                                grd_Historial.DataBind();
                                txt_historial.Enabled = PAT.pacienteAlta(_intExpe, centro);
                                btn_guardar.Enabled = txt_historial.Enabled;
                                CheckBox1.Enabled = txt_historial.Enabled;                     
                                if (!txt_historial.Enabled)
                                {
                                    lb_mensaje.Text = "El paciente está dado de alta";
                                }
                            }
                            else
                            {
                                lb_Paciente.Text = "Error al obtener el Historial ...";
                                txt_historial.Enabled = false;
                                btn_guardar.Enabled = false;
                                CheckBox1.Enabled = false;
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
                        txt_buscar = "";
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
                    lb_Paciente.Text = "Seleccione un Área...";
                    txt_historial.Enabled = false;
                    lb_Expe.Text = "";
                    btn_guardar.Enabled = false;
                    dt_Hist = null;
                    grd_Historial.DataBind();
            }
        }
        else
        {
                lb_Paciente.Text = "Introduzca un expediente a buscar ...";
                txt_historial.Enabled = false;
                lb_Expe.Text = "";
                btn_guardar.Enabled = false;
                dt_Hist = null;
                grd_Historial.DataBind();
        }
    }

    protected void Ver_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gdv_Hist = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int int_Index = gdv_Hist.RowIndex + (grd_Historial.PageIndex * grd_Historial.PageSize);
            string str_TMP = dt_Hist.Rows[int_Index][3].ToString();
            string histopart = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.Text = PAT.LeerHistoAltaAreas(_intExpe, _shtPrefijo, usuario_logeado, histopart, areaid);

            if (dt_Hist.Rows[int_Index][4].ToString() == "Si")
                CheckBox1.Checked = true;
            else
                CheckBox1.Checked = false;

            txt_historial.Enabled = false;
            CheckBox1.Enabled = false;
            btn_guardar.Text = "Nuevo";
            
        }
        catch (Exception ex)
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
    protected void grd_Historial_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        /*
         * 
         * HTML
         *  <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:Image id="imgalta" imageurl="" runat="server" ImageAlign="Middle"/>
                             </ItemTemplate>
            </asp:TemplateField>
         * 
         * if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgFotografija1 = (Image)e.Row.FindControl("imgalta");
            DataRowView drv = (DataRowView)e.Row.DataItem;
            if (drv["Alta"].ToString() == "True")
            {
                
                imgFotografija1.ImageUrl = "~/imagenes/true.png";
            }
            else
            {
               
                imgFotografija1.ImageUrl = "~/imagenes/false.png";
            }
        } */


    }
}