using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Areas : System.Web.UI.Page
{
    static private bool bl_edicion = false;
    static private int int_id;
    private BL.Areas bl_Areas = new BL.Areas();
    static private int int_row;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void enableControls(bool _bool)
    {
        lb_Nombre.Enabled = _bool;
        lb_Orden.Enabled = _bool;
        txt_Area.Enabled = _bool;
        txt_orden.Enabled = _bool;
    }

    protected void btn_Nuevo_Click(object sender, EventArgs e)
    {
        if (bl_edicion)
        {
            defaultControls();
            bl_edicion = false;
        }
        enableControls(true);
        lb_mensaje.Visible = false;
    }
    protected void btn_Guardar_Click(object sender, EventArgs e)
    {
        if (txt_Area.Text != "" && txt_orden.Text != "")
        {
            enableControls(false);
            try
            {
                if (bl_edicion)
                {
                    bl_Areas.updateAreas(int_id, txt_Area.Text, Convert.ToInt32(txt_orden.Text));
                    defaultControls();
                }
                else
                {
                    bl_Areas.insertAreas(txt_Area.Text, txt_orden.Text);
                }
                lb_mensaje.Visible = true;
                lb_mensaje.Text = " Área Guardado";
                txt_Area.Text = "";
                txt_orden.Text = "";
                enableControls(false);
                bl_edicion = false;
                verArea();
            }
            catch (Exception ex)
            {
                Session["Error_Msg"] = ex.Message;
                Response.Redirect("~/Error.aspx", true);
            }
        }
        else
        {
            lb_mensaje.Text = "Llene todos los campos";
            lb_mensaje.Visible = true;
        }
    }

    protected void Ver_Click(object sender, EventArgs e)
    {
            enableControls(true);
        try
        {
            GridViewRow gdv_Row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int_id = Convert.ToInt32(gdv_Row.Cells[1].Text);
            gdv_Row.ForeColor = System.Drawing.Color.Green;
            gdv_Row.Font.Bold = true;
            txt_Area.Text = Convert.ToString(gdv_Row.Cells[2].Text);
            txt_orden.Text = Convert.ToString(gdv_Row.Cells[3].Text);
            int_row = gdv_Row.RowIndex;
            enableControls(true);
            bl_edicion = true;
        }
        catch(Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void grd_Area_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void verArea()
    {
        try
        {
            grd_Area.DataSource = bl_Areas.listAreas();
            grd_Area.DataBind();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void defaultControls()
    {
        grd_Area.Rows[int_row].Font.Bold = false;
        grd_Area.Rows[int_row].ForeColor = System.Drawing.Color.Black;
        verArea();
        txt_Area.Text = "";
        txt_orden.Text = "";
        enableControls(true);
        lb_mensaje.Visible = false;
    }

    protected void btn_Ver_Click(object sender, EventArgs e)
    {
        if (bl_edicion)
        {
            defaultControls();
            bl_edicion = false;
        }
            verArea();
            enableControls(false);
    }
}