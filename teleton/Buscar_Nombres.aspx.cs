using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Buscar_Nombres : System.Web.UI.Page
{
    private BL.Paciente p = new BL.Paciente();
    public string[] partes;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
        lista.Items.Clear();
        lista.DataSource = p.Busqueda_pacientes(txt_nombre.Text);
        lista.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {            
            Session["ppaciente"] = partes[0];
            Session["centro"] = partes[2];
            Response.Redirect("Buscar_Expediente.aspx");
        }
        catch (Exception err)
        {
            Response.Write("<script>alert('Por Favor, Seleccione un Nombre de la Lista!')</script>");
        }
    }
    protected void lista_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        string cadenaorig = lista.SelectedValue.ToString();
        partes = cadenaorig.Split(' ');

        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
        
    }
}