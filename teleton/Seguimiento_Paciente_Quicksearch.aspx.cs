using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BL;

public partial class Seguimiento_Paciente_Quicksearch : System.Web.UI.Page
{
    SeguimientoPacientes sp = new SeguimientoPacientes();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SetFocus(searchBtn);
            if (!IsPostBack)
            {                
                Security sec = new Security();
                centrosPermitidos.DataSource = sec.getCentrosPermitidos(Session["nombre_usuario"].ToString());
                centrosPermitidos.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void cleanBtn_Click(object sender, EventArgs e)
    {
        nombres_TB.Text = primerApellido_TB.Text = segundoApellido_TB.Text = cedula_TB.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }    

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        try
        {
            this.Validate();


            if (this.IsValid)
            {
                Security sec = new Security();
                long centroSel = sec.getCentroId(centrosPermitidos.Text);

                GridView1.DataSource = sp.BusquedaRapida(nombres_TB.Text, primerApellido_TB.Text, segundoApellido_TB.Text, cedula_TB.Text, centroSel);
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (nombres_TB.Text == "" &&
            primerApellido_TB.Text == "" &&
            segundoApellido_TB.Text == "" &&
            cedula_TB.Text == "")
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void closeBtn_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.close(); }</script>");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'> { window.opener.document.getElementById('MainContent_txtnumexp').value = '" + GridView1.SelectedRow.Cells[1].Text + "'; window.close(); }</script>");    
    }
}