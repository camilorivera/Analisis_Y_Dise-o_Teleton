﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;


public partial class HistoPacienteFrame : System.Web.UI.Page
{

    private BL.Paciente PAT = new BL.Paciente();
    private BL.Security Sec = new BL.Security();
    private static string _strUsuario = "";
    private static int _intExpe = 0;
    private static short _shtPrefijo = 0;
    private static DataTable dt_Hist;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["expediente"] != null && (string)Session["expediente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty)
        {
            ddl_centro.Text = Session["centro"].ToString();
            txt_buscar.Text = Session["expediente"].ToString();
           
            Session.Remove("centro");
            Session.Remove("expediente");
            cargar_Historial();
        }
       //txtid.Text = Request.QueryString["id"];
       Session["id"] = Request.QueryString["id"];
       //txtid.Text = Session["id"].ToString();*/
     
            Session["id"] = Request.QueryString["id"];
            cargar_Historial();
        
    }

    private void cargar_Historial()
    {



        if (Session["expediente"] != null && (string)Session["expediente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty && Session["temp"].ToString()!="")
        {
            try
            {
                int centro = Convert.ToInt32(Sec.getCentroId(Session["centro"].ToString()));
                int area = Convert.ToInt32(Session["temp"].ToString());
                string expediente = Session["expediente"].ToString();
                _intExpe = Convert.ToInt32(expediente);
                string str_temp = expediente;
                int int_temp = Convert.ToInt32(expediente);
                string[] str_Inf = new string[2];
                str_Inf = PAT.nombrePaciente(Convert.ToInt32(expediente), centro);
              
                if (str_Inf != null && (str_Inf[0] != null && str_Inf[1] != null))
                {
                    _strUsuario = str_Inf[0];
                    _shtPrefijo = Convert.ToInt16(str_Inf[1].ToString());
                    if (str_Inf[0] != "")
                    {
                        lb_Paciente.Text = str_Inf[0];
                        dt_Hist = PAT.historial(Convert.ToInt32(expediente), centro,area);
                        if (dt_Hist != null)
                        {
                            lb_Expe.Text = "Num. Expe: " + expediente;
                            _intExpe = Convert.ToInt32(expediente);
                            grd_Historial.DataSource = dt_Hist;
                            grd_Historial.DataBind();
                            txt_historial.Enabled = true;
                            btn_guardar.Enabled = true;
                        }
                        else
                        {
                            lb_Paciente.Text = "Error al obtener el Historial ...";
                            txt_historial.Enabled = false;
                            lb_Expe.Text = "";
                            btn_guardar.Enabled = false;
                        }
                    }
                    else
                    {
                        lb_Paciente.Text = "Expediente no encontrado ...";
                        txt_historial.Enabled = false;
                        lb_Expe.Text = "";
                        btn_guardar.Enabled = false;
                        dt_Hist = null;
                        grd_Historial.DataBind();
                    }
                }
                else
                {
                    lb_Paciente.Text = "Error al obtener el paciente ...\nAsegúrese que el paciente este en el centro en el que se registro.";
                    //txt_buscar = "";
                    txt_historial.Text = "";
                    txt_historial.Enabled = false;
                    btn_guardar.Enabled = false;
                    lb_Expe.Text = "";
                    dt_Hist = null;
                    grd_Historial.DataBind();
                }
            }
            catch
            {
                lb_Paciente.Text = "Error, Tarea no Realizada";
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

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        if (btn_guardar.Text == "Nuevo")
        {
            txt_historial.ReadOnly = false;
            txt_historial.Font.Bold = false;
            txt_historial.Text = "";
            btn_guardar.Text = "Guardar";
        }
        else
        {
            try
            {
                if (Session["temp"].ToString() != "")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
                    if (!PAT.guardarHistorial(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss")), _intExpe, Session["nombre_usuario"].ToString()
                        , txt_historial.Text, _shtPrefijo, Convert.ToInt32(Session["id_empleado"].ToString()), Convert.ToInt32(Session["temp"].ToString())))
                    {
                        lb_Paciente.Text = "Error al tratar de guardar ...";
                    }
                    else
                    {
                        txt_historial.Text = "";
                        lb_Expe.Text = "";
                        lb_Paciente.Text = "";
                        cargar_Historial();

                    }
                }
                else
                {
                    lb_Paciente.Text = "Error...";
                }
            }
            catch
            {
                lb_Paciente.Text = "Excepción al tratar de guardar ...";
            }
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

    protected void Ver_Click(object sender, EventArgs e)
    {
       try
        {
            GridViewRow gdv_Hist = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int int_Index = gdv_Hist.RowIndex;
            string str_TMP = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.Text = dt_Hist.Rows[int_Index][3].ToString();
            txt_historial.ReadOnly = true;
            txt_historial.Font.Bold = true;
            btn_guardar.Text = "Nuevo";
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('" + dt_Hist.Rows[int_Index][3].ToString() + "')",true);
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}