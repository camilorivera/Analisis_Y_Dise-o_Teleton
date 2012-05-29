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

        this.Form.DefaultButton = this.btIngresar.UniqueID;

        if (!this.IsPostBack)
        {
            cleanPage();
        }

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

        datos = objeto.cargarDepartamentos();
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["NOMBRE"].ToString();
            item.Value = fila["ID"].ToString();

            ddlDepartamento.Items.Add(item);
        }

        datos = objeto.cargarMunicipios(1);
        foreach (DataRow fila in datos.Rows)
        {
            ListItem item = new ListItem();

            item.Text = fila["NOMBRE"].ToString();
            item.Value = fila["ID"].ToString();

            ddlMunicipio.Items.Add(item);
        }
    }
    
    private void cleanPage()
    {
        string fecha = DateTime.Now.ToString("dd-MM-yyyy");
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
        btnPrint.Enabled = false;
        txtExp.Text = "";//
        txtPadre.Text = "";
        txtMadre.Text = "";
        txtConyugue.Text = "";
        txtFamiliar.Text = "";
        txtEstructuraFamiliar.Text = "";
        txtObservaciones.Text = "";
        rblRehabilitacion.SelectedIndex = 0;
        ddlDepartamento.SelectedIndex = 0;
        ddlMunicipio.SelectedIndex = 0;
        if (Request.QueryString["sender"] == "new")
        {
            txtExp.Text = "0";
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

    protected void btIngresar_Click(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            Validate();
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('"+txtFechaIngreso.Text+"')", true);
            if (this.IsValid)
            {
                try
                {
                    int ca = (int)long.Parse(Session["Centro_idNum"].ToString());

                    int dd = int.Parse(txtFechaNacimiento.Text.Substring(0, 2));
                    int mm = int.Parse(txtFechaNacimiento.Text.Substring(3, 2));
                    int yy = int.Parse(txtFechaNacimiento.Text.Substring(6, 4));
                    DateTime fechaNac = new DateTime(yy, mm, dd);

                    if (fechaNac >= DateTime.Today)
                    {
                        Response.Write("<script>alert('Fecha de nacimiento mayor o igual a la actual')</script>");
                        return;
                    }
                    if (FileUpload_Foto.HasFile)
                    {
                        if (!FileUpload_Foto.FileName.ToString().ToLower().EndsWith(".jpg"))
                        {
                            Response.Write("<script>alert('Imagen no esta en formato jpg')</script>");
                            return;
                        }
                    }

                    dd = int.Parse(txtFechaIngreso.Text.Substring(0, 2));
                    mm = int.Parse(txtFechaIngreso.Text.Substring(3, 2));
                    yy = int.Parse(txtFechaIngreso.Text.Substring(6, 4));
                    
                    DateTime fechaIng = new DateTime(yy, mm, dd);
                    long exped = 0;
                    
                    if (txtExp.Enabled)
                    {
                        exped = Int64.Parse(txtExp.Text);
                    }

                    bool rehabilitacionAnterior = rblRehabilitacion.SelectedValue.Equals("Sí") ? true : false;
                    
                    BL.Paciente pac = new BL.Paciente();
                    pac.asignarDatos(ca, exped, transformarCadena(txtNombres.Text), transformarCadena(txtPrimerApellido.Text), transformarCadena(txtSegundoApellido.Text),
                        fechaNac, rdMasculino.Selected, fechaIng, txtCedula.Text, txtDireccion.Text,
                        txtLugarNacimiento.Text, ddEstado.SelectedItem.Text,FileUpload_Foto.FileBytes, txtTelefono.Text,
                        txtCelular.Text, Convert.ToInt64(ddlEscolaridad.SelectedValue), Convert.ToInt64(ddlProfesion.SelectedValue),
                        txtLugarTrabajo.Text, txtMadre.Text, txtPadre.Text, txtEstructuraFamiliar.Text, rehabilitacionAnterior,
                        txtObservaciones.Text, txtConyugue.Text, true, txtFamiliar.Text,int.Parse(ddlDepartamento.SelectedValue),int.Parse(ddlMunicipio.SelectedValue));

                    if (!pac.exist(Int32.Parse(Session["Centro_idNum"].ToString()), exped))
                    {
                        if (pac.guardarPaciente())
                        {
                            //Session["expediente"] = pac.Expediente;
                            //TODO: revisar esto de los mensajes
                            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('La data del paciente ha sido guardada exitosamente con expediente:"+ _paciente.Expediente+ " ')", true);
                            long temp = Int64.Parse(Session["Centro_idNum"].ToString());
                            string strExp;
                            if (Request.QueryString["sender"] == "new")
                            {
                                long nextP = center.getNext(temp);
                                strExp = (nextP - 1).ToString();
                            }
                            else
                                strExp = txtExp.Text;

                            Response.Write("<script>alert('La data del paciente ha sido guardada exitosamente con expediente: " + strExp + "')</script>");
                            btnPrint.Enabled = true;
                            Session["expediente"] = strExp;
                            txtExp.Text = strExp;
                        }
                        else
                        {
                            Response.Write("<script>alert('No se puedo guardar el expediente')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha guardado por que ya existe un registro con ese expediente')</script>");
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