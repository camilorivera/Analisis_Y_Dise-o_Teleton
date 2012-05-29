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

        this.Form.DefaultButton = this.btnBuscar.UniqueID;

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

    private string transformarCadena(string str) //Pone mayusculas y despues minusculas
    {
        String[] list = str.Split(' ');
        string newStr = "";

        for (int i = 0; i < list.Length; i++)
        {
            for (int j = 0; j < list[i].Length; j++)
            {
                if (j == 0)
                    newStr += list[i][0].ToString().ToUpper();
                else
                    newStr += list[i][j].ToString().ToLower();
            }

            if (list[i].Length > 0)
            {
                if (i != list.Length - 1)
                    newStr += " ";
            }
        }

        return newStr;
    }

    private void cleanPage()
    {
        string fecha = DateTime.Now.ToString("dd-MM-yyyy");
        
        txtExpediente.Text = "";
        txtFechaIngreso.Text = fecha;//
        txtCedula.Text = "";//
        txtDireccion.Text = "";//
        txtFechaNacimiento.Text = "";//
        txtLugarNacimiento.Text = "";//
        txtNombres.Text = "";//
        txtPrimerApellido.Text = "";//
        txtSegundoApellido.Text = "";//
        txtCelular.Text = "";//
        txtTelefono.Text = "";//
        txtLugarTrabajo.Text = "";//
        //FileUpload_Foto.
        rdFemenino.Selected = false;//
        rdMasculino.Selected = true;//
        ddEstado.SelectedIndex = 0;//
        ddlEscolaridad.SelectedIndex = 0;//
        ddlProfesion.SelectedIndex = 0;//
        txtPadre.Text = "";
        txtMadre.Text = "";
        txtConyugue.Text = "";
        txtFamiliar.Text = "";
        txtEstructuraFamiliar.Text = "";
        txtObservaciones.Text = "";
        rblRehabilitacion.SelectedIndex = 0;
        ddlDepartamento.SelectedIndex = 0;
        ddlMunicipio.SelectedIndex = 0;
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
        txtConyugue.Enabled = estado;
        txtFamiliar.Enabled = estado;
        txtEstructuraFamiliar.Enabled = estado;
        rblRehabilitacion.Enabled = estado;
        txtObservaciones.Enabled = estado;
        txtDiagnostico.Enabled = estado;
        ddlDepartamento.Enabled = estado;
        ddlMunicipio.Enabled = estado;
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
                fecha = (dia.Length == 1 ? "0" : "") + dia + (mes.Length == 1 ? "-0" : "-") + mes + "-" + anio;
                txtFechaNacimiento.Text = fecha;

                dia = p.FechaIngreso.Day.ToString();
                mes = p.FechaIngreso.Month.ToString();
                anio = p.FechaIngreso.Year.ToString();
                fecha = (dia.Length == 1 ? "0" : "") + dia + (mes.Length == 1 ? "-0" : "-") + mes + "-" + anio;
                txtFechaIngreso.Text = fecha;

                Imagen.ImageUrl = "Handler.ashx?Expediente=" + exp + "&CentroActual=" + CId;
                Imagen.Width = (Unit)150;
                Imagen.Height = (Unit)150;

                /*Modificado por Eliazar*/
                txtTelefono.Text = p.telefono;
                txtCelular.Text = p.movil;

                cargarDropDownEscolaridad(p.escolaridad);
                cargarDropDownOcupaciones(p.profesion);
                cargarDropDownDepartamento(p.departamento);
                cargarDropDownMunicipio(p.municipio);

                txtLugarTrabajo.Text = p.lugarTrabajo;
                txtMadre.Text = p.nombreMadre;
                txtPadre.Text = p.nombrePadre;
                txtConyugue.Text = p.nombreConyugue;
                txtFamiliar.Text = p.nombreFamiliar;
                txtEstructuraFamiliar.Text = p.estructuraFamiliar;

                if (p.pacienteActivo)
                {
                    rbActivo.Enabled = false;
                    rbActivo.Items.FindByValue("true").Selected = true;
                }
                else
                {
                    rbActivo.Enabled = true;
                    rbActivo.Items.FindByValue("false").Selected = true;
                }
                
                if (p.rehabilitacion)
                    rblRehabilitacion.Items[0].Selected = true;
                else
                    rblRehabilitacion.Items[1].Selected = true;

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
        Validate();

        if (this.IsValid)
        {
            try
            {
                BL.Security sec = new BL.Security();
                int CId = (int)sec.getCentroId(cboCentro.SelectedValue);
                long exp = long.Parse(txtExpediente.Text);

                BL.Paciente pac = new BL.Paciente();
                if (pac.leerPaciente(CId, exp))
                {
                    int yy = int.Parse(txtFechaNacimiento.Text.Substring(6, 4));
                    int mm = int.Parse(txtFechaNacimiento.Text.Substring(3, 2));
                    int dd = int.Parse(txtFechaNacimiento.Text.Substring(0, 2));
                    DateTime fechaNac = new DateTime(yy, mm, dd);

                    if (fechaNac >= DateTime.Today)
                    {
                        Response.Write("<script>alert('Fecha de nacimiento mayor o igual a la actual')</script>");
                        return;
                    }

                    yy = int.Parse(txtFechaIngreso.Text.Substring(6, 4));
                    mm = int.Parse(txtFechaIngreso.Text.Substring(3, 2));
                    dd = int.Parse(txtFechaIngreso.Text.Substring(0, 2));
                    DateTime fechaIng = new DateTime(yy, mm, dd);

                    bool rehabilitacion = rblRehabilitacion.SelectedValue.Equals("Sí") ? true : false;

                    if (FileUpload_Foto.HasFile)
                    {
                        if (!FileUpload_Foto.FileName.ToString().ToLower().EndsWith(".jpg"))
                        {
                            Response.Write("<script>alert('Imagen no esta en formato jpg')</script>");
                            return;
                        }
                        else
                        {
                            pac.asignarDatos(pac.CentroActual, Int64.Parse(txtExpediente.Text), transformarCadena(txtNombres.Text), transformarCadena(txtPrimerApellido.Text), transformarCadena(txtSegundoApellido.Text),
                            fechaNac, pac.Sexo, fechaIng, txtCedula.Text, txtDireccion.Text, txtLugarNacimiento.Text, ddEstado.SelectedItem.Text, FileUpload_Foto.FileBytes,
                            txtTelefono.Text, txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue), txtLugarTrabajo.Text,
                            txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, rehabilitacion, txtObservaciones.Text, txtConyugue.Text, Convert.ToBoolean(rbActivo.SelectedValue), txtFamiliar.Text, int.Parse(ddlDepartamento.SelectedValue), int.Parse(ddlMunicipio.SelectedValue));
                        }
                    }
                    else
                    {
                        pac.asignarDatos(pac.CentroActual, Int64.Parse(txtExpediente.Text), transformarCadena(txtNombres.Text), transformarCadena(txtPrimerApellido.Text), transformarCadena(txtSegundoApellido.Text),
                        fechaNac, pac.Sexo, fechaIng, txtCedula.Text, txtDireccion.Text, txtLugarNacimiento.Text, ddEstado.SelectedItem.Text, pac.Foto,
                        txtTelefono.Text, txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue), txtLugarTrabajo.Text,
                        txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, rehabilitacion, txtObservaciones.Text, txtConyugue.Text, Convert.ToBoolean(rbActivo.SelectedValue), txtFamiliar.Text, int.Parse(ddlDepartamento.SelectedValue), int.Parse(ddlMunicipio.SelectedValue));

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

    private void cargarDropDownDepartamento(long id)
    {
        ddlDepartamento.Items.Clear();

        Paciente objeto = new Paciente();

        DataTable datos = objeto.cargarDepartamentos();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["NOMBRE"].ToString();
            item.Value = fila["ID"].ToString();

            if (Convert.ToInt64(fila["ID"].ToString()) == id)
                item.Selected = true;

            ddlDepartamento.Items.Add(item);
        }
    }

    private void cargarDropDownMunicipio(long id)
    {
        ddlMunicipio.Items.Clear();

        Paciente objeto = new Paciente();

        DataTable datos = objeto.cargarMunicipios(int.Parse(ddlDepartamento.SelectedValue));
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["NOMBRE"].ToString();
            item.Value = fila["ID"].ToString();

            if (Convert.ToInt64(fila["ID"].ToString()) == id)
                item.Selected = true;

            ddlMunicipio.Items.Add(item);
        }
    }

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        Paciente objeto = new Paciente();

        DataTable datos = objeto.cargarMunicipios(int.Parse(ddlDepartamento.SelectedValue));

        ddlMunicipio.Items.Clear();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["NOMBRE"].ToString();
            item.Value = fila["ID"].ToString();

            ddlMunicipio.Items.Add(item);
        }
    }
}