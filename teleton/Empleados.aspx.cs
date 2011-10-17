using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Empleados : System.Web.UI.Page
{
    private BL.Empleados EMPLOYEES = new BL.Empleados();
   
    protected void LimpiarPage()
    {
        txb_firstname.Text = "";
        txb_nombreemp.Text = "";
        txb_secondlastname.Text = "";
        txb_firstname.Text = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEmpleados"))
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

                cmb_position.Items.Clear();
                cmb_position.DataSource = EMPLOYEES.RetrievePositionName();
                cmb_position.DataBind();

            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.IsPostBack)
            {
                if (this.IsValid)
                {
                    EMPLOYEES.GuardarEmpleado(0, txb_nombreemp.Text, txb_firstname.Text, txb_secondlastname.Text, cmb_position.Text);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Empleado Creado')", true);
                    LimpiarPage();
                }                
            }
        }
        catch (Exception er)
        {
            Session["Error_Msg"] = er.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        LimpiarPage();
    }
}