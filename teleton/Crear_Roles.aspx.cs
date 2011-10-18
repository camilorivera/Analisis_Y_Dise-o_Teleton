using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Crear_Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pCrearRole"))
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
                BL.Permiso per = new Permiso();
                permisos_CBList.DataSource = per.getPermisosID();
                permisos_CBList.DataBind();

                Security sec = new Security();
                centros.DataSource = sec.getCentros();
                centros.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void acceptButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsValid)
            {
                List<string> persAdded = new List<string>();
                
                foreach (ListItem it in permisos_CBList.Items)
                {
                    if (it.Selected == true)
                    {
                        persAdded.Add(it.Text);
                        it.Selected = false;
                    }
                }

                AdministradordeSistema admin = new AdministradordeSistema();//tmp-> deberia ser quien este logeado!
                Security sec = new Security();
                long centro = sec.getCentroId(centros.Text);
                admin.crearRol(descripcion_TB.Text, persAdded, centro);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Rol Guardado')", true);
                LimpiarPage();
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);     
        }
    }

    void LimpiarPage()
    {
        descripcion_TB.Text = "";
    }
}