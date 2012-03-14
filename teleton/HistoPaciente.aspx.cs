using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using System.Data;

public partial class HistoPaciente : System.Web.UI.Page
{
    private BL.Paciente PAT = new BL.Paciente();
    private BL.Security Sec = new BL.Security();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];
        bool encontroPermiso = false;

        Session["expediente"] = txt_buscar.Text;
        Session["centro"] = ddl_centro.Text;
        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pBuscarExp"))
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
            if ((Request.QueryString["sender"] == "alta"))
            {
                Response.Redirect("HistoPacienteAlta.aspx", true);
            }
            else
            {
                BL.Security seg = new BL.Security();
                ddl_centro.DataSource = Sec.getCentrosPermitidos(Session["nombre_usuario"].ToString());
                //ddl_centro.DataSource = seg.getCentros();
                ddl_centro.DataBind();

                GridViewAreas.DataSource = Sec.CargarAreas();
                GridViewAreas.DataBind();
            }
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null && (string)Session["id"] != string.Empty)
        {
            Session["expediente"] = txt_buscar.Text;
            Session["centro"] = ddl_centro.Text;
        
            Session["temp"] = Session["id"].ToString();
        }
        else
        {
            Session.Remove("centro");
            Session.Remove("expediente");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Por favor seleccione un Área')", true);   
        }
  
            

    }
    protected void GridViewAreas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewAreas.PageIndex = e.NewPageIndex;
            GridViewAreas.DataSource = Sec.CargarAreas();
            GridViewAreas.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
}