using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Eliminar_Empleados : System.Web.UI.Page
{
    private BL.Empleados DEMPLOYEES = new BL.Empleados();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEliminarE"))
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

        try { 
            if(!this.IsPostBack){
                CargarEmpleados();
            }
        
        }catch(Exception er){
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void CargarEmpleados() {
        cmb_empleados.Items.Clear();
        cmb_empleados.DataSource = DEMPLOYEES.RetrieveEmployeesName();
        cmb_empleados.DataBind();
    }
    
    protected void btn_eliminar_Click1(object sender, EventArgs e)
    {
        try
        {            
            DEMPLOYEES.EliminarEmpleado(cmb_empleados.Text);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Empleado Eliminado')", true);
            CargarEmpleados();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}