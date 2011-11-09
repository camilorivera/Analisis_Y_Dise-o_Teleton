using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class EditarUsuarios : System.Web.UI.Page
{
    private BL.Usuarios USER = new BL.Usuarios();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Lista de permisos que el usuario logueado tiene
            List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

            bool encontroPermiso = false;

            foreach (String strPermiso in listaPermisos)
            {
                //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
                if (strPermiso.Equals("pEditarUs"))
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
            if (!this.IsPostBack)
            {
                InicializarPantalla();
            }

        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }
    
    protected void btn_leftuserrol_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsPostBack)
            {
                if (lb_sourcerols.SelectedIndex > -1)
                {

                    lb_userrols.Items.Add(lb_sourcerols.SelectedValue.ToString());
                    lb_sourcerols.Items.RemoveAt(lb_sourcerols.SelectedIndex);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('No Tiene Ningun Rol Seleccionado')", true);

                }
            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void InicializarPantalla() {
        CargarRolesdelSistema();
        CargarEmpleados();
        CargarRolesUser();
    }

    protected void CargarRolesdelSistema()
    {
        try
        {
            lb_sourcerols.Items.Clear();
            lb_sourcerols.DataSource = USER.RetrieveRol();
            lb_sourcerols.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void CargarRolesUser()
    {
        try
        {
            lb_userrols.Items.Clear();
            lb_userrols.DataSource = USER.RetrieveRolUser(cmb_empleados.SelectedValue);
            lb_userrols.DataBind();
            CargarRolesSys();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void CargarRolesSys()
    {
        try
        {
            lb_sourcerols.Items.Clear();
            lb_sourcerols.DataSource = USER.RetrieveNewRolList(cmb_empleados.SelectedValue);
            lb_sourcerols.DataBind();
            

        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void CargarEmpleados()
    {
        cmb_empleados.Items.Clear();
        cmb_empleados.DataSource = USER.RetrieveEmployees();
        cmb_empleados.DataBind();
    }

    protected void CargarUsuarios()
    {

    }

    protected void btn_GuardarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> RolUsuario = new List<string>();
            
            if (this.IsValid)
            {
                if (lb_userrols.Items.Count > 0)
                {
                    for (int x = 0; x < lb_userrols.Items.Count; x++)
                    {

                        RolUsuario.Add(lb_userrols.Items[x].ToString());
                    }

                    USER.EditarUsuario(cmb_empleados.SelectedValue, RolUsuario);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Usuario Editado')", true);
                    //InicializarPantalla();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Alerta", "alert('Cada usuario debe tener un rol asociado.')", true);
                }
            }

        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        InicializarPantalla();
    }

    protected void btn_rightuserrol_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsPostBack)
            {
                if (lb_userrols.SelectedIndex > -1)
                {

                    lb_sourcerols.Items.Add(lb_userrols.SelectedValue.ToString());
                    lb_userrols.Items.RemoveAt(lb_userrols.SelectedIndex);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('No Tiene Ningun Rol Seleccionado')", true);
                }
            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    
    protected void cmb_empleados_TextChanged1(object sender, EventArgs e)
    {
        CargarRolesUser();
    }
    protected void cmb_usuarios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


  