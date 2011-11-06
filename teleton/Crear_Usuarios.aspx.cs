using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Crear_Usuarios : System.Web.UI.Page
{
    private BL.Usuarios USER = new BL.Usuarios();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pCrearUsua"))
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

        try
        {
            if (!this.IsPostBack)
            {
                CargarEmpleados();
                CargarRoles();
            }
        }catch(Exception er){
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btn_leftuserrol_Click(object sender, EventArgs e)
    {
        try{
        if (this.IsPostBack)
        {
            if (lb_sourcerols.SelectedIndex > -1)
            {

                lb_userrols.Items.Add(lb_sourcerols.SelectedValue.ToString());
                lb_sourcerols.Items.RemoveAt(lb_sourcerols.SelectedIndex);
            }
            else
            {
                Response.Write("<script>alert('No Tiene Ningun Rol Seleccionado Para el Usuario')</script>");

            }
        }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void CargarEmpleados(){
        try{
            cmb_empleados.Items.Clear();
            cmb_empleados.DataSource = USER.RetrieveEmpleadosid();
            cmb_empleados.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    
    }

    protected void CargarRoles()
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
                    Response.Write("<script>alert('No Tiene Ningun Rol Seleccionado Para el Usuario')</script>");
                }
            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void btn_GuardarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> RolUsuario = new List<string>();
            //if (txt_username.Text.Length > 0 && txt_password.Text.Length > 0)
            //{
            if (this.IsValid)
            {
                if (lb_userrols.Items.Count > 0)
                {
                    for (int x = 0; x < lb_userrols.Items.Count; x++)
                        RolUsuario.Add(lb_userrols.Items[x].ToString());

                    USER.GuardarUsuario(txt_username.Text, txt_password.Text, cmb_empleados.Text, RolUsuario);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Usuario Guardado!')", true);
                    LimpiarPagina();
                }
            }           
        }
        catch (Exception er) {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);    
        }
    }

    protected void LimpiarPagina() {

        lb_userrols.Items.Clear();
        txt_password.Text = "";
        txt_username.Text = "";
        CargarEmpleados();
        CargarRoles();
    
    
    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        LimpiarPagina();
    }
}