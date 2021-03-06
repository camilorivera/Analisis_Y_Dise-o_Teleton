﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Globalization;

public partial class HistReab_Pediatrica : System.Web.UI.Page
{
    private static DataTable g_Historial = null;
    private static DataTable g_InfoPaciente = null;
    private static int g_Expediente = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void grd_Historial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Historial.PageIndex = e.NewPageIndex;
            grd_Historial.DataSource = g_Historial;
            grd_Historial.DataBind();
        }
        catch(Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void Ver_Click(object sender, EventArgs e)
    {
        try
        {
            lb_Mensaje.Text = "";
            GridViewRow t_grdRow = (GridViewRow)((ImageButton)sender).Parent.Parent;
            txt_Nombre.Text = t_grdRow.Cells[1].Text;
            txt_Edad.Text = t_grdRow.Cells[2].Text;
            txt_Informante.Text = t_grdRow.Cells[3].Text;
            elm1.Value = g_Historial.Rows[t_grdRow.RowIndex + (grd_Historial.PageIndex * grd_Historial.PageSize)][4].ToString();
            txt_Historiador.Text = g_Historial.Rows[t_grdRow.RowIndex + (grd_Historial.PageIndex * grd_Historial.PageSize)][0].ToString();
            controles(false);
            elm1.Visible = true;
            datosPanel(true);
        }
        catch 
        {
            lb_Mensaje.Text = "No se puede mostrar el detalle";
        }
    }

    private void datosPanel(bool p_vs)
    {
        asp_Panel.Visible = p_vs;
        lb_Edad.Visible = p_vs;
        txt_Edad.Visible = p_vs;
    }

    private void buscarCargar()
    {
        BL.Empleados g_BLEmpleado;
        BL.Paciente g_Paciente = new BL.Paciente();
        try
        {
            lb_Mensaje.Text = "";
            g_Historial = g_Paciente.rehabilitacionPediatrica(Convert.ToInt32(txt_Expediente.Text)
                ,Convert.ToInt32(Session["Centro_idNum"].ToString()));

            if (g_Historial!= null && g_Historial.Rows.Count > 0)
            {
                grd_Historial.DataSource = g_Historial;
                grd_Historial.DataBind();
                grd_Historial.Visible = true;
                int t_Anos = DateTime.Now.Year - Convert.ToDateTime(g_Historial.Rows[0][5]).Year;
                DateTime t_Naci = Convert.ToDateTime(g_Historial.Rows[0][5]).AddYears(t_Anos);
                if (DateTime.Now.CompareTo(t_Naci) < 0)
                {
                    txt_Edad.Text = (t_Anos - 1).ToString();
                }
                else
                {
                    txt_Edad.Text = t_Anos.ToString();
                }
                txt_Nombre.Text = g_Historial.Rows[0][0].ToString();
                txt_Sexo.Text = Convert.ToBoolean(g_Historial.Rows[0][6]) == true ? "Masculino" : "Femenino";
                txt_Remitente.Text = g_Historial.Rows[0][7].ToString();
                txt_Informante.Text = g_Historial.Rows[0][2].ToString();
                g_BLEmpleado = new BL.Empleados();
                txt_Historiador.Text = g_BLEmpleado.getNombre(Convert.ToInt32(Session["id_empleado"].ToString()));
                if (Convert.ToInt32(txt_Edad.Text) > 18)
                {
                    mayorEdad(false);
                    lb_Mensaje.Text = "Utilice la pagina de historial de adultos";
                    btn_Nuevo.Visible = false;
                    btn_Nuevo.Enabled = false;

                }
                else
                {
                    mayorEdad(true);
                    btn_Nuevo.Visible = false;
                    btn_Nuevo.Enabled = false;
                    btn_Guardar.Visible = false;
                    btn_Guardar.Enabled = false;

                }
            }
            else
            {
                g_InfoPaciente = g_Paciente.infoHistoPediAdul(Convert.ToInt32(txt_Expediente.Text),
                    Convert.ToInt32(Session["Centro_idNum"].ToString()));
                if (g_InfoPaciente.Rows.Count > 0)
                {
                    int t_Anos = DateTime.Now.Year - Convert.ToDateTime(g_InfoPaciente.Rows[0][2]).Year;
                    DateTime t_Naci = Convert.ToDateTime(g_InfoPaciente.Rows[0][2]).AddYears(t_Anos);
                    if (DateTime.Now.CompareTo(t_Naci) < 0)
                    {
                        txt_Edad.Text = (t_Anos - 1).ToString();
                    }
                    else
                    {
                        txt_Edad.Text = t_Anos.ToString();
                    }
                    txt_Nombre.Text = g_InfoPaciente.Rows[0][0].ToString();
                    txt_Sexo.Text = Convert.ToBoolean(g_InfoPaciente.Rows[0][1]) == true ? "Masculino" : "Femenino";
                    if (Convert.ToInt32(txt_Edad.Text) > 18)
                    {
                        mayorEdad(false);
                        lb_Mensaje.Text = "Utilice la pagina de historial Adultos";
                        btn_Nuevo.Enabled = false;
                        btn_Nuevo.Visible = false;
                    }
                    else
                    {
                        mayorEdad(true);
                        btn_Nuevo.Enabled = true;
                        btn_Nuevo.Visible = true;
                        btn_Guardar.Visible = false;
                        btn_Guardar.Enabled = false;
                    }
                }
                else
                {
                    lb_Mensaje.Text = "El paciente no existe o esta en otro centro";
                    btn_Nuevo.Enabled = false;
                    btn_Nuevo.Visible = false;
                }
                
            }
            controles(false);
            elm1.Value = "";
            elm1.Visible = false;
            datosPanel(false);
        }
        catch
        {
            lb_Mensaje.Text = "Expediente no Encontrado";
        }
    }

    private void mayorEdad(bool p_std)
    {
        controles(p_std);
        elm1.Visible = p_std;
        btn_Nuevo.Enabled = p_std;
        btn_Nuevo.Visible = p_std;
        btn_Guardar.Enabled = p_std;
        btn_Guardar.Visible = p_std;
        grd_Historial.Visible = p_std;
        grd_Historial.Enabled = p_std;
    }

    private void limpiarControles()
    {
        txt_Edad.Text = "";
        txt_Expediente.Text = "";
        txt_Historiador.Text = "";
        txt_Informante.Text = "";
        txt_Nombre.Text = "";
        txt_Remitente.Text = "";
        txt_Sexo.Text = "";
    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        BL.Empleados g_BLEmpleado;
        try
        {
            if(int.TryParse(txt_Expediente.Text,out g_Expediente))
            {
                controles(false);
                buscarCargar();
            }
            else
            {
                limpiarControles();
                grd_Historial.Visible=false;
                g_Historial.Clear();
                lb_Mensaje.Text="El valor de el expediente a buscar debe ser numerico";
            }
            g_BLEmpleado=new BL.Empleados();
            txt_Historiador.Text = g_BLEmpleado.getNombre(Convert.ToInt32(Session["id_empleado"].ToString()));
        }
        catch 
        {
            lb_Mensaje.Text = "Error al Cargar los datos del paciente";
        }

    }

    private void controles(bool p_Valor)
    {
        txt_Informante.Enabled = p_Valor;
        txt_Remitente.Enabled = p_Valor;
        elm1.Visible = p_Valor;
    }

    protected void btn_Nuevo_Click(object sender, EventArgs e)
    {
        datosPanel(true);
        btn_Guardar.Enabled = true;
        btn_Guardar.Visible = true;
        btn_Nuevo.Enabled = false;
        btn_Nuevo.Visible = false;
        controles(true);
        elm1.Value = "";
        grd_Historial.Visible = false;
        txt_Informante.Text = "";
        txt_Remitente.Text = "";
        txt_Remitente.Focus();
        lb_Mensaje.Text = "";
    }

    private string nombreDoctor()
    {
        BL.Empleados g_BLEmpleado = new BL.Empleados();
        return g_BLEmpleado.getNombre(Convert.ToInt32(Session["id_empleado"].ToString())); 
    }

    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        BL.Paciente g_Paciente = new BL.Paciente();
        try
        {
            if (txt_Expediente.Text != "" && txt_Historiador.Text != "" && txt_Edad.Text!=""
                && txt_Sexo.Text != "" && txt_Informante.Text!="" && txt_Remitente.Text!="" && elm1.Value!="")
            {
                if (g_Paciente.isDoctor(Session["nombre_usuario"].ToString()))
                {
                    string t_Doc = nombreDoctor();
                    if (t_Doc != null)
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");
                        if (g_Paciente.guardarHPediatrica(Convert.ToInt32(txt_Expediente.Text), Convert.ToInt32(Session["Centro_idNum"].ToString())
                            , Convert.ToInt32(txt_Edad.Text), txt_Informante.Text, DateTime.Now, Session["nombre_usuario"].ToString()
                            , txt_Remitente.Text, elm1.Value))
                        {
                            buscarCargar();
                            grd_Historial.Visible = true;
                            lb_Mensaje.Text = "Se guardo correctamente";
                            btn_Guardar.Enabled = false;
                            btn_Guardar.Visible = false;
                            btn_Nuevo.Enabled = false;
                            btn_Nuevo.Visible = false;
                            datosPanel(false);
                        }
                        else
                        {
                            lb_Mensaje.Text = "No se pudo guardar";
                        }
                    }
                    else
                    {
                        lb_Mensaje.Text = "Error al obtener el nombre del doctor";
                    }
                }
                else
                {
                    lb_Mensaje.Text = "No tiene permisos para esta opción";
                }
            }
            else
            {
                lb_Mensaje.Text = "Hay datos Vacios";
            }
        }
        catch 
        {
            
        }
    }
}