using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL;

public partial class Eliminar_Usuarios : System.Web.UI.Page
{
    private BL.Usuarios USER = new Usuarios();

    protected void Page_Load(object sender, EventArgs e)
    {        
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEliminarU"))
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
                getUsuarios();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void getUsuarios()
    {
        try
        {
            cmb_usuarios.Items.Clear();
            cmb_usuarios.DataSource = USER.RetrieveUserNames();
            cmb_usuarios.DataBind();            
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void btn_eliminar_Click(object sender, EventArgs e)
    {
        try
        {
            USER.EliminarUsuario(cmb_usuarios.Text);            
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Usuario Eliminado')", true);
            getUsuarios();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}