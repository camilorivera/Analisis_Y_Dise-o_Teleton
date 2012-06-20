using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Crear_Permisos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pCrearPerm"))
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
    }

    void LimpiarPage()
    {
        nombrePermiso_TB.Text = descripcion_TB.Text = "";
    }

   
    protected void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsValid)
            {
                AdministradordeSistema admin = new AdministradordeSistema();
                admin.crearPermiso(nombrePermiso_TB.Text, descripcion_TB.Text);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Permiso Guardado')",true);
                LimpiarPage();
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);        
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        bool flag = true;
        if (nombrePermiso_TB.Text.Length > 45)
        {
            flag=false;
            
        }
        args.IsValid = flag;

    }
}