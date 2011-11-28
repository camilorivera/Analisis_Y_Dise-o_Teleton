using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

//Agregados por Eliazar
using System.Data;

public partial class Crear_Paciente : System.Web.UI.Page
{
    Centro center = new Centro();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false; 

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if ( strPermiso.Equals("pCrearPaci") )
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
            cleanPage();

        if (Request.QueryString["sender"] == "new")
        {
            txtExp.Enabled = false;
        }
        else
            txtExp.Enabled = true;

        cargarDropDownList();
    }

    private void cargarDropDownList()
    {
        Paciente objeto = new Paciente();

        //Escolaridad
        DataTable datos = objeto.cargarEscolaridad();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["GRADO"].ToString();
            item.Value = fila["ID"].ToString();

            ddlEscolaridad.Items.Add(item);
        }

        //Profesion
        datos = objeto.cargarOcupaciones();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["OCUPACION"].ToString();
            item.Value = fila["ID"].ToString();

            ddlProfesion.Items.Add(item);
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
        btnPrint.Enabled = false;
        txtExp.Text = "";
        if (Request.QueryString["sender"] == "new")
        {
            txtExp.Text = "0";
        }
    }

    protected void btIngresar_Click(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('"+txtFechaIngreso.Text+"')", true);
            if (this.IsValid)
            {
                try
                {
                    int ca = (int)long.Parse(Session["Centro_idNum"].ToString());

                    int yy = int.Parse(txtFechaNacimiento.Text.Substring(0, 4));
                    int mm = int.Parse(txtFechaNacimiento.Text.Substring(5, 2));
                    int dd = int.Parse(txtFechaNacimiento.Text.Substring(8, 2));
                    DateTime fechaNac = new DateTime(yy, mm, dd);

                    if (fechaNac >= DateTime.Today)
                    {
                        Response.Write("<script>alert('Fecha de nacimiento mayor o igual a la actual')</script>");
                        return;
                    }
                    if (!FileUpload_Foto.HasFile)
                    {
                        Response.Write("<script>alert('Cargue una foto')</script>");
                        return;
                    }
                    else
                    {
                        if (!FileUpload_Foto.FileName.ToString().ToLower().EndsWith(".jpg"))
                        {
                            Response.Write("<script>alert('Imagen no esta en formato jpg')</script>");
                            return;
                        }
                    }

                    yy = int.Parse(txtFechaIngreso.Text.Substring(0, 4));
                    mm = int.Parse(txtFechaIngreso.Text.Substring(5, 2));
                    dd = int.Parse(txtFechaIngreso.Text.Substring(8, 2));
                    
                    DateTime fechaIng = new DateTime(yy, mm, dd);
                    long exped = 0;
                    
                    if (txtExp.Enabled)
                    {
                        exped = Int64.Parse(txtExp.Text);
                    }

                    bool rehabilitacionAnterior = rblRehabilitacion.SelectedValue.Equals("Sí") ? true : false;
                    bool candidatoTrans = rblCandidato.SelectedValue.Equals("Sí") ? true : false;

                    BL.Paciente pac = new BL.Paciente();
                    pac.asignarDatos(ca, exped, txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text,
                        fechaNac, rdMasculino.Selected, fechaIng, txtCedula.Text, txtDireccion.Text,
                        txtLugarNacimiento.Text, ddEstado.SelectedItem.Text,FileUpload_Foto.FileBytes, txtTelefono.Text,
                        txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue),
                        txtLugarTrabajo.Text, txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, txtCondicionHogar.Text,
                        txtExpectativa.Text, Convert.ToDouble(txtIngreso.Text), rehabilitacionAnterior, candidatoTrans,
                        txtReferencia.Text, txtDocumentos.Text, txtObservaciones.Text);

                    if (!pac.exist(Int32.Parse(Session["Centro_idNum"].ToString()), exped))
                    {
                        pac.guardarPaciente();
                        //Session["expediente"] = pac.Expediente;
                        //TODO: revisar esto de los mensajes
                        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('La data del paciente ha sido guardada exitosamente con expediente:"+ _paciente.Expediente+ " ')", true);
                        long temp = Int64.Parse(Session["Centro_idNum"].ToString());
                        string strExp;
                        if (Request.QueryString["sender"] == "new")
                        {
                            long nextP = center.getNext(temp);
                            strExp = (nextP -1).ToString();

                        }
                        else
                            strExp = txtExp.Text;
                        Response.Write("<script>alert('La data del paciente ha sido guardada exitosamente con expediente: " + strExp + "')</script>");
                        btnPrint.Enabled = true;
                        long tmp = Int64.Parse(Session["Centro_idNum"].ToString());
                        Session["expediente"] = strExp;
                        txtExp.Text = strExp;
                    }
                    else
                    {
                        Response.Write("<script>alert('no se ha guardado por que ya existe un registro')</script>");
                    }
                }
                catch (Exception err)
                {
                    Session["Error_Msg"] = err.Message;
                    Response.Redirect("~/Error.aspx", true);
                }
            }
        }
    }

    protected void btnClean_Click(object sender, EventArgs e)
    {
        cleanPage();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        long exp = long.Parse(Session["expediente"].ToString());
        int ca = (int)long.Parse(Session["Centro_idNum"].ToString());
        String pageArgs = String.Format("HojaPaciente.aspx?Expediente={0}&CentroActual={1}", exp, ca);
        LiteralControl lctl = new LiteralControl("<script type=\"text/javascript\"> function init(){" + String.Format("window.open('{0}', 'Información del Paciente', 'width=1000, height=600, scrollbars=yes');", pageArgs) + "} window.onload = init(); </script>");
        Page.Header.Controls.Add(lctl);
    }
}