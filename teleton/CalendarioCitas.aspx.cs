using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarCitas : System.Web.UI.Page
{
    private int intIdCentro;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;
        intIdCentro = (int)long.Parse(Session["Centro_idNum"].ToString());

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEditCitaT"))
            {
                encontroPermiso = true;
                break;
            }
        }

        if (!encontroPermiso)
        {
            //Si no tiene permiso redireccionamos
            //Response.Redirect("NoAccess.aspx");
        }

        try
        {
            if (!this.IsPostBack)
            {
                InitComponentes();

            }

        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    private void InitComponentes()
    {
        AtarComboTerapeutas();
        LimpiarControles();
        grvCitas = new GridView();
    }

    private void AtarComboTerapeutas()
    {
        BL.Empleados emp = new BL.Empleados();
        List<String> nombresTerapeutas = emp.obtenerNombresTerapeutas();
        cmbEmpleados.DataSource = nombresTerapeutas;
        cmbEmpleados.DataBind();
    }

    private void LimpiarControles()
    {
        txtfecha.Text = "";
        txtNumExpediente.Text = "";
    }



    protected void btBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            String nombreTerapeuta = cmbEmpleados.Text;
            DateTime fechaCita = DateTime.Parse(txtfecha.Text);
            int prefijo = intIdCentro;
            BL.Citas citas = new BL.Citas();

            if (txtNumExpediente.Text.Length == 0)
            {
                grvCitas.DataSource = citas.ObtenerCitasTerapia(fechaCita, nombreTerapeuta, prefijo);
                grvCitas.DataBind();
            }
            else
            {
                long numExpediente = long.Parse(txtNumExpediente.Text);
                grvCitas.DataSource = citas.ObtenerCitasTerapia(fechaCita, nombreTerapeuta, prefijo, numExpediente);
                grvCitas.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    protected void btnClean_Click(object sender, EventArgs e)
    {
        LimpiarControles();
    }
    protected void grvCitas_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        grvCitas.EditIndex = e.NewEditIndex;
        //Bind data to the GridView control.
        DataBind();
    }
    protected void grvCitas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        grvCitas.EditIndex = -1;
        //Bind data to the GridView control.
        DataBind();
    }

    protected void grvCitas_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       
    }
}