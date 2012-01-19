using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearCitasTerapia : System.Web.UI.Page
{
    private int intIdCentro;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;
        intIdCentro = (int)long.Parse(Session["Centro_idNum"].ToString());

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pCreaCitaT"))
            {
                encontroPermiso = true;
                break;
            }
        }

        if (!encontroPermiso)
        {
            //Si no tiene permiso redireccionamos
            //Response.Redirect("NoAccess.aspx");
        }

        try
        {
            if (!this.IsPostBack)
            {
                InitComponentes();

            }

        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void InitComponentes()
    {
        AtarComboTerapeutas();
        LimpiarControles();
    }

    public void AtarComboTerapeutas()
    {
        BL.Empleados emp = new BL.Empleados();
        List<String> lstNombresDoctores = emp.obtenerNombresTerapeutas();
        cmbEmpleados.DataSource = lstNombresDoctores;
        cmbEmpleados.DataBind();
    }

    public void LimpiarControles()
    {
        txtNumExpediente.Text = "";
        txtfecha.Text = "";
        lblHora.Visible = false;
        timeSelectorHoraEmpieza.Hour = DateTime.Now.Hour;
        timeSelectorHoraEmpieza.Minute = DateTime.Now.Minute;

        timeSelectorHoraTermina.Hour = DateTime.Now.Hour;
        timeSelectorHoraTermina.Minute = DateTime.Now.Minute;
        lb_Mensaje.Text = "";
        lb_Mensaje.Visible = false;
    }

    protected void btIngresar_Click(object sender, EventArgs e)
    {
        if (!validarHoras())
        {
            return;
        }
        

        TimeSpan horaCitaInicio = new TimeSpan(timeSelectorHoraEmpieza.Hour, timeSelectorHoraEmpieza.Minute, 0);
        TimeSpan horaCitaFinaliza = new TimeSpan(timeSelectorHoraTermina.Hour, timeSelectorHoraTermina.Minute, 0);
        DateTime fechaCita = DateTime.Parse(txtfecha.Text);
        int prefijo = intIdCentro;

        try
        {
            BL.Paciente _paciente = new BL.Paciente();
            int _int = _paciente.verificarPrefijo(Convert.ToInt32(txtNumExpediente.Text), prefijo);
            if (_int == 0)
            {
                lb_Mensaje.Text = "El expediente pertenece centro distinto... NO se Guardo.";
                lb_Mensaje.Visible = true;
            }
            else
            {
                BL.Citas cita = new BL.Citas();

                if (cita.existeCitaTerapiaProgramada(fechaCita.Date, horaCitaInicio, horaCitaFinaliza, cmbEmpleados.Text))
                {
                    Response.Write("<script>alert('El terapeuta ya tiene una cita en esta hora y fecha')</script>");
                }
                else
                {
                    cita.NuevaCitaTerapia(fechaCita.Date, cmbEmpleados.Text, intIdCentro, long.Parse(txtNumExpediente.Text), horaCitaInicio, horaCitaFinaliza);
                    Response.Write("<script>alert('Se ha agregado la cita!')</script>");
                }
                LimpiarControles();
            }

        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = "Ha ocurrido un error al intentar agregar la cita, compruebe el número de expediente";
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btnClean_Click(object sender, EventArgs e)
    {
        LimpiarControles();
    }

    private Boolean validarHoras()
    {
        if (timeSelectorHoraEmpieza.Hour > timeSelectorHoraTermina.Hour)
        {
            lblHora.Visible = true;
            return false;
        }
        else
        {
            lblHora.Visible = false;
            return true;

        }
    }
}