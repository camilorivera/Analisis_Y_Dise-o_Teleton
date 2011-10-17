using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearCitasMedicas : System.Web.UI.Page
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
            if (strPermiso.Equals("pCreaCitaM"))
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
        AtarComboDoctores();
        LimpiarControles();
    }

    private void AtarComboDoctores()
    {
        BL.Empleados emp = new BL.Empleados();
        List<String> lstNombresDoctores = emp.obtenerNombresDoctores();
        cmbEmpleados.DataSource = lstNombresDoctores;
        cmbEmpleados.DataBind();
    }

    private void LimpiarControles()
    {
        txtNumExpediente.Text = "";
        txtfecha.Text = "";
        txtTipo.Text = "";
        timeSelectorHoraCita.Hour = DateTime.Now.Hour;
        timeSelectorHoraCita.Minute = DateTime.Now.Minute;
    }

    protected void btIngresar_Click(object sender, EventArgs e)
    {
        TimeSpan horaCita = new TimeSpan(timeSelectorHoraCita.Hour, timeSelectorHoraCita.Minute,0);
        DateTime fechaCita = DateTime.Parse(txtfecha.Text) + horaCita;
        int prefijo = intIdCentro;

        try
        {
            BL.Citas cita = new BL.Citas();

            if (cita.existeCitaMedicaProgramada(fechaCita, cmbEmpleados.Text))
            {
                Response.Write("<script>alert('El doctor ya tiene una cita programada para esta fecha y hora')</script>");
            }
            else
            {
                cita.NuevaCitaMedica(fechaCita, cmbEmpleados.SelectedItem.ToString(), prefijo, long.Parse(txtNumExpediente.Text),txtTipo.Text);
                Response.Write("<script>alert('Se ha agregado la cita!')</script>");
            }
            LimpiarControles();

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
}