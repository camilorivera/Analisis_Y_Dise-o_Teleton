using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*Agregados por Eliazar*/
using BL;
using System.Data;

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
        BL.Security sec = new BL.Security();
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
           
            cboCentro.DataSource = sec.getCentrosPermitidos(Session["nombre_usuario"].ToString());
            cboCentro.DataBind();
            cleanPage();
        }

        if (Session["ppaciente"] != null && (string)Session["ppaciente"] != string.Empty && Session["centro"] != null && (string)Session["centro"] != string.Empty)
        {
            string x=Session["centro"].ToString();
            txtExpediente.Text = Session["ppaciente"].ToString();
            cboCentro.Text = sec.getCentrolugarNom(x);
            Session.Remove("ppaciente");
            Session.Remove("centro");

            buscar();
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

    private void cambiarEnabled(bool estado)
    {
        //Habilitar Todos Los Campos
        txtCedula.Enabled = estado;
        txtNombres.Enabled = estado;
        txtPrimerApellido.Enabled = estado;
        txtSegundoApellido.Enabled = estado;
        txtDireccion.Enabled = estado;
        rdFemenino.Enabled = estado;
        rdMasculino.Enabled = estado;
        ddEstado.Enabled = estado;
        txtLugarNacimiento.Enabled = estado;
        txtFechaNacimiento.Enabled = estado;
        btnEditar.Enabled = estado;
        btnEliminar.Enabled = estado;
        btnImprimir.Enabled = estado;
        btnCleanPage.Enabled = estado;

        /*Modificado por Eliazar*/
        txtTelefono.Enabled = estado;
        txtCelular.Enabled = estado;
        ddlEscolaridad.Enabled = estado;
        ddlProfesion.Enabled = estado;
        txtLugarTrabajo.Enabled = estado;
        txtMadre.Enabled = estado;
        txtPadre.Enabled = estado;
        txtEstructuraFamiliar.Enabled = estado;
        txtCondicionHogar.Enabled = estado;
        txtExpectativa.Enabled = estado;
        txtIngreso.Enabled = estado;
        rblRehabilitacion.Enabled = estado;
        rblCandidato.Enabled = estado;
        txtReferencia.Enabled = estado;
        txtDocumentos.Enabled = estado;
        txtObservaciones.Enabled = estado;
        txtDiagnostico.Enabled = estado;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        buscar();
    }

    private void buscar()
    {
        try
        {
            if (txtExpediente.Text.Trim() == "")
            {
                lblExpReq.Visible = true;
                cleanPage();
                cambiarEnabled(false);
                return;
            }

            BL.Paciente p = new BL.Paciente();
            BL.Security sec = new BL.Security();
            BL.SeguimientoPacientes segp = new BL.SeguimientoPacientes();
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

                Imagen.ImageUrl = "Handler.ashx?Expediente=" + exp + "&CentroActual=" + CId;
                Imagen.Width = (Unit)150;
                Imagen.Height = (Unit)150;

                /*Modificado por Eliazar*/
                txtTelefono.Text = p.telefono;
                txtCelular.Text = p.movil;

                cargarDropDownEscolaridad(p.escolaridad);
                cargarDropDownOcupaciones(p.profesion);

                txtLugarTrabajo.Text = p.lugarTrabajo;
                txtMadre.Text = p.nombreMadre;
                txtPadre.Text = p.nombrePadre;
                txtEstructuraFamiliar.Text = p.estructuraFamiliar;
                txtCondicionHogar.Text = p.condicionHogar;
                txtExpectativa.Text = p.expectativa;
                txtIngreso.Text = Convert.ToString(p.ingresos);

                if (p.rehabilitacion)
                    rblRehabilitacion.Items[0].Selected = true;
                else
                    rblRehabilitacion.Items[1].Selected = true;

                if (p.candidatoTransporte)
                    rblCandidato.Items[0].Selected = true;
                else
                    rblCandidato.Items[1].Selected = true;

                txtReferencia.Text = p.acercaDe;
                txtDocumentos.Text = p.docsAlternos;
                txtObservaciones.Text = p.observaciones;

                cambiarEnabled(true);

                String temp = segp.getDiagnostico(exp);
                if (temp == null)
                {
                    txtDiagnostico.Enabled = false;
                }
                else
                {
                    txtDiagnostico.Text = temp;
                }

               // Response.Write("<script>alert('El paciente Se ha encontrado exitosamente')</script>");

                // Habilitar los controles para que se pueda editar.
                lblExpReq.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('El paciente que busca no existe')</script>");
                // No lo encontro, no hay nada que editar
                cambiarEnabled(false);
                lblExpReq.Visible = false;
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

                if (fechaNac >= DateTime.Today)
                {
                    Response.Write("<script>alert('Fecha de nacimiento mayor o igual a la actual')</script>");
                    return;
                }
                
                yy = int.Parse(txtFechaIngreso.Text.Substring(0, 4));
                mm = int.Parse(txtFechaIngreso.Text.Substring(5, 2));
                dd = int.Parse(txtFechaIngreso.Text.Substring(8, 2));
                DateTime fechaIng = new DateTime(yy, mm, dd);

                bool rehabilitacion = rblRehabilitacion.SelectedValue.Equals("Sí") ? true : false;
                bool transporte = rblCandidato.SelectedValue.Equals("Sí") ? true : false;

                if (FileUpload_Foto.HasFile)
                {
                    if (!FileUpload_Foto.FileName.ToString().ToLower().EndsWith(".jpg"))
                    {
                        Response.Write("<script>alert('Imagen no esta en formato jpg')</script>");
                        return;
                    }
                    else
                    {
                        pac.asignarDatos(pac.CentroActual, Int64.Parse(txtExpediente.Text), txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                        fechaNac, rdMasculino.Selected, fechaIng, txtCedula.Text, txtDireccion.Text, txtLugarNacimiento.Text, ddEstado.SelectedItem.Text, FileUpload_Foto.FileBytes,
                        txtTelefono.Text, txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue), txtLugarTrabajo.Text,
                        txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, txtCondicionHogar.Text, txtExpectativa.Text, Convert.ToDouble(txtIngreso.Text),
                        rehabilitacion, transporte, txtReferencia.Text, txtDocumentos.Text, txtObservaciones.Text, "");
                    }
                }
                else
                {
                    pac.asignarDatos(pac.CentroActual, Int64.Parse(txtExpediente.Text), txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                    fechaNac, rdMasculino.Selected, fechaIng, txtCedula.Text, txtDireccion.Text, txtLugarNacimiento.Text, ddEstado.SelectedItem.Text, pac.Foto,
                    txtTelefono.Text, txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue), txtLugarTrabajo.Text,
                    txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, txtCondicionHogar.Text, txtExpectativa.Text, Convert.ToDouble(txtIngreso.Text),
                    rehabilitacion, transporte, txtReferencia.Text, txtDocumentos.Text, txtObservaciones.Text, "");

                }

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
                LiteralControl lctl = new LiteralControl("<script type=\"text/javascript\"> function init(){" + String.Format("window.open('{0}', 'Información del Paciente', 'width=1000, height=600, scrollbars=yes, menubar=yes, toolbar=yes');", pageArgs) + "} window.onload = init(); </script>");
                Page.Header.Controls.Add(lctl);
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    /*Modificado por Eliazar Melendez*/
    private void cargarDropDownEscolaridad(long id)
    {
        ddlEscolaridad.Items.Clear();

        Paciente objeto = new Paciente();

        DataTable datos = objeto.cargarEscolaridad();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["GRADO"].ToString();
            item.Value = fila["ID"].ToString();

            if (Convert.ToInt64(fila["ID"].ToString()) == id)
                item.Selected = true;
            
            ddlEscolaridad.Items.Add(item);
        }
    }

    private void cargarDropDownOcupaciones(long id)
    {
        ddlProfesion.Items.Clear();

        Paciente objeto = new Paciente();

        DataTable datos = objeto.cargarOcupaciones();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["OCUPACION"].ToString();
            item.Value = fila["ID"].ToString();

            if (Convert.ToInt64(fila["ID"].ToString()) == id)
                item.Selected = true;

            ddlProfesion.Items.Add(item);
        }
    }
}