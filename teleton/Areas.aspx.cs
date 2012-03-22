using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Areas : System.Web.UI.Page
{
    static private bool bl_edicion = false;
    static private int int_id;
    private BL.Areas bl_Areas = new BL.Areas();
    static private int int_row;
    private static DataTable dt_tabla;
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

    protected void Eliminar_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gdv_Row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int_id = Convert.ToInt32(dt_tabla.Rows[gdv_Row.RowIndex + (grd_Area.PageIndex * grd_Area.PageSize)][0].ToString());
            string t_Area = dt_tabla.Rows[gdv_Row.RowIndex + (grd_Area.PageIndex * grd_Area.PageSize)][2].ToString();
            if (bl_Areas.deleteAreas(int_id))
            {
                lb_mensaje.Text = " Área '"+t_Area+"' Eliminada";
                lb_mensaje.Visible = true;
                int_row = gdv_Row.RowIndex;
                verArea();
            }
            else
            {
                lb_mensaje.Text = "No se puede eliminar, Area asociada a un historial";
                lb_mensaje.Visible = true;
            }
        }
        catch(Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void Ver_Click(object sender, EventArgs e)
    {
        enableControls(true);
        try
        {
            grd_Area.Rows[int_row].Font.Bold = false;
            grd_Area.Rows[int_row].ForeColor = System.Drawing.Color.Black;
            grd_Area.Rows[int_row].BorderColor = System.Drawing.Color.Black;

            GridViewRow gdv_Row = (GridViewRow)((ImageButton)sender).Parent.Parent;
            int_id = Convert.ToInt32(dt_tabla.Rows[gdv_Row.RowIndex+(grd_Area.PageIndex * grd_Area.PageSize)][0].ToString());
            txt_Area.Text = Convert.ToString(gdv_Row.Cells[3].Text);
            txt_orden.Text = Convert.ToString(gdv_Row.Cells[4].Text);
            gdv_Row.Font.Bold = true;
            gdv_Row.ForeColor = System.Drawing.Color.Red;
            gdv_Row.BorderColor = System.Drawing.Color.Black;
            for (int i = 0; i < gdv_Row.Cells.Count; i++)
            {
                gdv_Row.Cells[i].BorderColor = System.Drawing.Color.Black;
            }
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

    protected void grd_Area_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_Area.PageIndex = e.NewPageIndex;
            grd_Area.DataSource = dt_tabla;
            grd_Area.DataBind();
        }
        catch (Exception err)
        {
            Session["Error_Msg"] = err.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void verArea()
    {
        try
        {
            dt_tabla = null;
            dt_tabla = bl_Areas.listAreas();
            grd_Area.DataSource = dt_tabla;
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
        grd_Area.Rows[int_row].BorderColor = System.Drawing.Color.Black;
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