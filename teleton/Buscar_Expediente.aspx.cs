using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Buscar_Expediente : System.Web.UI.Page
{

    string fecha;
    string dia;
    string mes;
    string anio;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false; 

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if ( strPermiso.Equals("pBuscarExp") )
            {
                encontroPermiso = true;
                break;
            }
        }

        if ( !encontroPermiso )
        {
            //Si no tiene permiso redireccionamos
            //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
            Response.Redirect("NoAccess.aspx");
        }
        if (!this.IsPostBack)
        {
            BL.Security sec = new BL.Security();
            cboCentro.DataSource = sec.getCentrosPermitidos(Session["nombre_usuario"].ToString());
            cboCentro.DataBind();
            cleanPage();
        }
    }

    private void cleanPage()
    {
        string fecha = DateTime.Now.Year.ToString();
        fecha = fecha + "-" + (DateTime.Now.Month < 10 ? "0" : "") + DateTime.Now.Month.ToString();
        fecha = fecha + "-" + (DateTime.Now.Day < 10 ? "0" : "") + DateTime.Now.Day.ToString();
        txtFechaIngreso.Text = fecha;
        txtCedula.Text = "";
        txtDireccion.Text = "";
        txtFechaNacimiento.Text = "";
        txtLugarNacimiento.Text = "";
        txtNombres.Text = "";
        txtPrimerApellido.Text = "";
        txtSegundoApellido.Text = "";
        rdFemenino.Selected = false;
        rdMasculino.Selected = true;
        ddEstado.SelectedIndex = 0;
        txtExpediente.Text = "";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            BL.Paciente p = new BL.Paciente();
            BL.Security sec = new BL.Security();
            int CId = (int)sec.getCentroId(cboCentro.SelectedValue);
            long exp = long.Parse(txtExpediente.Text);
            if (p.leerPaciente(CId, exp))
            {
                txtCedula.Text = p.Cedula;
                txtNombres.Text = p.Nombres;
                txtPrimerApellido.Text = p.PrimerApellido;
                txtSegundoApellido.Text = p.SegundoApellido;
                txtDireccion.Text = p.Direccion;
                if (p.Sexo)
                {
                    rdMasculino.Selected = true;
                }
                else
                {
                    rdFemenino.Selected = true;
                }
                txtLugarNacimiento.Text = p.LugarNac;

                dia = p.FechaNac.Day.ToString();
                mes = p.FechaNac.Month.ToString();
                anio = p.FechaNac.Year.ToString();
                fecha = anio + (mes.Length == 1 ? "-0" : "-") + mes + (dia.Length == 1 ? "-0" : "-") + dia;
                txtFechaNacimiento.Text = fecha;


                dia = p.FechaIngreso.Day.ToString();
                mes = p.FechaIngreso.Month.ToString();
                anio = p.FechaIngreso.Year.ToString();
                fecha = anio + (mes.Length == 1 ? "-0" : "-") + mes + (dia.Length == 1 ? "-0" : "-") + dia;
                txtFechaIngreso.Text = fecha;
                Response.Write("<script>alert('El paciente Se ha encontrado exitosamente')</script>");
            }
            else
            {
                Response.Write("<script>alert('El paciente que busca no existe')</script>");
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }


    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        try
        {
            BL.Security sec = new BL.Security();
            int CId = (int)sec.getCentroId(cboCentro.SelectedValue);
            long exp = long.Parse(txtExpediente.Text);
            BL.Paciente pac = new BL.Paciente();
            if (pac.leerPaciente(CId, exp))
            {


                int yy = int.Parse(txtFechaNacimiento.Text.Substring(0, 4));
                int mm = int.Parse(txtFechaNacimiento.Text.Substring(5, 2));
                int dd = int.Parse(txtFechaNacimiento.Text.Substring(8, 2));
                DateTime fechaNac = new DateTime(yy, mm, dd);

                yy = int.Parse(txtFechaIngreso.Text.Substring(0, 4));
                mm = int.Parse(txtFechaIngreso.Text.Substring(5, 2));
                dd = int.Parse(txtFechaIngreso.Text.Substring(8, 2));
                DateTime fechaIng = new DateTime(yy, mm, dd);

                pac.asignarDatos(pac.CentroActual, Int64.Parse(txtExpediente.Text), txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                                          fechaNac, rdMasculino.Selected, fechaIng,
                                          txtCedula.Text, txtDireccion.Text, txtLugarNacimiento.Text,
                                          ddEstado.SelectedItem.Text);

                if (pac.editarPaciente())
                {
                    Response.Write("<script>alert('El paciente se ha editado exitosamente')</script>");
                }
                else
                {
                    Response.Write("<script>alert('No se ha podido editar el registro del paciente')</script>");
                }
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            BL.Security sec = new BL.Security();
            int CId = (int)sec.getCentroId(cboCentro.SelectedValue);
            long exp = long.Parse(txtExpediente.Text);
            BL.Paciente pac = new BL.Paciente();
            if (pac.leerPaciente(CId, exp))
            {
                if (pac.eliminarPaciente())
                {
                    Response.Write("<script>alert('El registro del paciente ha sido eliminado')</script>");
                    cleanPage();
                }
                else
                {
                    Response.Write("<script>alert('No se ha podido eliminar el registro del paciente')</script>");
                }
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btnCleanPage_Click(object sender, EventArgs e)
    {
        cleanPage();
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        try
        {
            BL.Security sec = new BL.Security();
            int CId = (int)sec.getCentroId(cboCentro.SelectedValue);
            long exp = long.Parse(txtExpediente.Text);
            BL.Paciente pac = new BL.Paciente();
            if (pac.leerPaciente(CId, exp))
            {
                String pageArgs = String.Format("HojaPaciente.aspx?Expediente={0}&CentroActual={1}", exp,CId);
                LiteralControl lctl = new LiteralControl("<script type=\"text/javascript\"> function init(){" + String.Format("window.open('{0}', 'Información del Paciente', 'width=1000, height=600, scrollbars=yes');", pageArgs) + "} window.onload = init(); </script>");
                Page.Header.Controls.Add(lctl);
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}