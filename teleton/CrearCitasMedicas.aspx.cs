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
        /*BL.Empleados emp = new BL.Empleados();
        List<String> lstNombresDoctores = emp.obtenerNombresDoctores();
        cmbEmpleados.DataSource = lstNombresDoctores;
        cmbEmpleados.DataBind();*/
        BL.Citas citas = new BL.Citas();
        cmbEmpleados.DataSource=citas.ObtenerUsuarios();
        cmbEmpleados.DataBind();

    }

    private void LimpiarControles()
    {
        txtNumExpediente.Text = "";
        txtfecha.Text = "";
        txtTipo.Text = "";
        timeSelectorHoraCita.Hour = DateTime.Now.Hour;
        timeSelectorHoraCita.Minute = DateTime.Now.Minute;
        lb_Mensaje.Text = "";
        lb_Mensaje.Visible = false;
    }

    protected void btIngresar_Click(object sender, EventArgs e)
    {
        TimeSpan horaCita = new TimeSpan(timeSelectorHoraCita.Hour, timeSelectorHoraCita.Minute,0);
        DateTime fechaCita = DateTime.Parse(txtfecha.Text) + horaCita;
        int prefijo = intIdCentro;
        if (txtfecha.Text != "" && txtNumExpediente.Text != "" && txtTipo.Text != "")
        {
            try
            {
                if (Convert.ToDateTime(txtfecha.Text).Year>= DateTime.Now.Year && Convert.ToDateTime(txtfecha.Text).Month>=DateTime.Now.Month 
                    && Convert.ToDateTime(txtfecha.Text).Day>=Convert.ToDateTime(txtfecha.Text).Day)
                {
                    BL.Citas cita = new BL.Citas();
                    if (cita.existeCitaMedicaProgramada(fechaCita, cmbEmpleados.Text.Substring(0, cmbEmpleados.Text.IndexOf(' '))))
                    {
                        Response.Write("<script>alert('El doctor ya tiene una cita programada para esta fecha y hora')</script>");
                    }
                    else
                    {
                        BL.Paciente _paciente = new BL.Paciente();
                        int _int = _paciente.verificarPrefijo(Convert.ToInt32(txtNumExpediente.Text), prefijo);
                        if (_int == 0)
                        {
                            lb_Mensaje.Text = "El expediente pertenece centro distinto... NO se Guardo.";
                            lb_Mensaje.Visible = true;
                        }
                        else if (_int == -1)
                        {
                            lb_Mensaje.Text = "El paciente NO Existe";
                            lb_Mensaje.Visible = true;
                        }
                        else
                        {
                            cita.NuevaCitaMedica(fechaCita, cmbEmpleados.Text.Substring(0, cmbEmpleados.Text.IndexOf(' '))
                                , prefijo, long.Parse(txtNumExpediente.Text), txtTipo.Text);
                            lb_Mensaje.Visible = false;
                            lb_Mensaje.Text = "";
                            lb_Mensaje.Text = "Cita Creada Exitosamente!";
                            lb_Mensaje.Visible = true;
                            LimpiarControles();
                            //Response.Write("<script>alert('Se ha agregado la cita!')</script>");
                        }
                    }
                }
                else
                {
                    lb_Mensaje.Text = "La fecha de la cita debe ser mayor o igual a la fecha actual";
                    lb_Mensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {

                Session["Error_Msg"] = "Ha ocurrido un error al intentar agregar la cita, compruebe el número de expediente";
                Response.Redirect("~/Error.aspx", true);
            }
        }
        else
        {
            lb_Mensaje.Text = "Llene todos los campos";
            lb_Mensaje.Visible = true;
        }
    }
    protected void btnClean_Click(object sender, EventArgs e)
    {
        LimpiarControles();
    }
    protected void cmbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}