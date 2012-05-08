using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Buscar_Nombres : System.Web.UI.Page
{
    private BL.Paciente p = new BL.Paciente();
    public string[] partes;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            lista.Items.Clear();
            lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text, false);
            lista.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

 
    protected void lista_Load(object sender, EventArgs e)
    {
        if (Request["__EVENTARGUMENT"] != null && Request["__EVENTARGUMENT"] == "click")
        {
            string cadenaorig = lista.SelectedValue.ToString();
            partes = cadenaorig.Split(' ');
            Session["ppaciente"] = partes[0];
            Session["centro"] = partes[2];
            Response.Redirect("Buscar_Expediente.aspx");
        }
        lista.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(lista, "click"));
    }

    protected void lbBusquedaAvanzada_Click(object sender, EventArgs e)
    {
        lblIdentidad.Visible = true;
        lblFechaIngreso.Visible = true;
        txtFechaIngreso.Visible = true;
        imgCalendarIcon.Visible = true;
        txtIdentidad.Visible = true;
        btBuscar.Visible = true;
        btnBuscar.Visible = false;
        lbBusquedaAvanzada.Visible = false;
    }

    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            int cantidadCampos = 0;
            lblElecciones.Text = String.Empty;

            if (!txt_nombre.Text.Equals(String.Empty))
                cantidadCampos++;

            if (!txtIdentidad.Text.Equals(String.Empty))
                cantidadCampos++;

            if (!txtFechaIngreso.Text.Equals(String.Empty))
                cantidadCampos++;

            switch (cantidadCampos)
            {
                case 1:
                    if (!txt_nombre.Text.Equals(String.Empty))
                    {
                        lista.Items.Clear();
                        lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text, false);
                        lista.DataBind();
                        cantidadCampos = 0;
                    }
                    else if (!txtFechaIngreso.Text.Equals(String.Empty))
                    {
                        lista.Items.Clear();
                        lista.DataSource = p.Busqueda_pacientes(DateTime.Parse(txtFechaIngreso.Text));
                        lista.DataBind();
                        cantidadCampos = 0;
                    }
                    else
                    {
                        lista.Items.Clear();
                        lista.DataSource = p.Busqueda_pacientes(txtIdentidad.Text, true);
                        lista.DataBind();
                        cantidadCampos = 0;
                    }
                    break;
                case 2:

                    if (!txt_nombre.Text.Equals(String.Empty))
                    {
                        if (!txtIdentidad.Text.Equals(String.Empty))
                        {
                            lista.Items.Clear();
                            lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text, txtIdentidad.Text);
                            lista.DataBind();
                            cantidadCampos = 0;
                        }
                        else
                        {
                            lista.Items.Clear();
                            lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text, DateTime.Parse(txtFechaIngreso.Text), false);
                            lista.DataBind();
                            cantidadCampos = 0;
                        }
                    }
                    else
                    {
                        lista.Items.Clear();
                        lista.DataSource = p.Busqueda_pacientes(txtIdentidad.Text, DateTime.Parse(txtFechaIngreso.Text), true);
                        lista.DataBind();
                        cantidadCampos = 0;
                    }

                    break;
                case 3:
                    lista.Items.Clear();
                    lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text, txtIdentidad.Text, DateTime.Parse(txtFechaIngreso.Text));
                    lista.DataBind();
                    cantidadCampos = 0;
                    break;
                default:
                    lblElecciones.Text = "No ha seleccionado ningun campo";
                    break;
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}