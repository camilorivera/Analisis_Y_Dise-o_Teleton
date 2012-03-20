using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Diagnosticos : System.Web.UI.Page
{
    private BL.Patologia PAT= new BL.Patologia();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pDiagnosti"))
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
        if (!this.IsPostBack) {
            //cargarDiagnostico();
        } 
        }catch(Exception er){
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void cargarDiagnostico()
    {
        try
        {
            GridView1.DataSource = PAT.CargarDiagnostico();
            GridView1.DataBind();
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       try
        {
            if (this.IsValid)
            {
                if (this.IsPostBack)
                {
                    PAT.GuardarPatologia(0, diagnostico_txt.Text,cod.Text);
                    GridView1.DataBind();
                    diagnostico_txt.Text = "";
                    cod.Text = "";
                }
            }
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {     
        try
        {
            if (e.Row is GridViewRow)
            {
                if (e.Row != null)
                {
                    int _temp;
                    if (int.TryParse(e.Row.Cells[2].Text, out _temp))
                    {
                        ImageButton _ib = e.Row.Cells[1].Controls[1] as ImageButton;
                        if (!PAT.EliminarPatologia(Convert.ToInt32(e.Row.Cells[2].Text)))
                        {
                            _ib.Visible = false;
                        }
                    }
                }
            }
        }
        catch
        {

        }
    }
}