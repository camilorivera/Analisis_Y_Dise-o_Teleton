using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Editar_Empleados : System.Web.UI.Page
{
    private BL.Empleados EMPLOYEE = new BL.Empleados();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEditarEmp"))
            {
                encontroPermiso = true;
                break;
            }
        }

        if (!encontroPermiso)
        {
            //Si no tiene permiso redireccionamos
            //Response.Write("<script>alert('Usted no posee permisos suficientes para accesar a este recurso')</script>");
            Response.Redirect("NoAccess.aspx");
        }
        try{
            if (!this.IsPostBack)
            {
                CargarEmpleado();
                //carga puestos de empleados
                cmb_puesto.Items.Clear();
                cmb_puesto.DataSource = EMPLOYEE.RetrievePositionName();
                cmb_puesto.DataBind();
            }
            }catch(Exception er){
                Session["Error_Msg"] = er.Message;
                Response.Redirect("~/Error.aspx", true);
            }
        
        }
    protected void CargarEmpleado() {
        //carga empleados
        cmb_usuarios.Items.Clear();
        cmb_usuarios.DataSource = EMPLOYEE.RetrieveEmployeesName();
        cmb_usuarios.DataBind();    
    }
    protected void LimpiarPage() {
        txt_username.Text = "";
        txt_lastname.Text = "";
        txt_secondlastname.Text = "";
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsValid)
            {
                EMPLOYEE.EditarEmpleado(cmb_usuarios.Text,txt_username.Text, txt_lastname.Text, txt_secondlastname.Text, cmb_puesto.Text);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Empleado Editado Correctamente')", true);
                CargarEmpleado();
                LimpiarPage();
            }
       }
        catch (Exception er) {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        LimpiarPage();
    }
}
