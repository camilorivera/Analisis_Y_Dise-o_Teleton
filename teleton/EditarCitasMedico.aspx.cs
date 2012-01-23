using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarCitasMedico : System.Web.UI.Page
{
    BL.Citas app = new BL.Citas();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];
        bool encontroPermiso = true;//false;
        foreach (String strPermiso in listaPermisos)
        {
            if (strPermiso.Equals("pEditCitaM"))
            {
                encontroPermiso = true;
                break;
            }
        }
        if (!encontroPermiso)
        {
            Response.Redirect("NoAccess.aspx");
        }
        if (!this.IsPostBack)
        {
            AtarComboDoctores();
        }
    }

    private void AtarComboDoctores()
    {
        BL.Citas citas = new BL.Citas();
        cmbdoctor.DataSource = citas.ObtenerUsuarios();
        cmbdoctor.DataBind();
        /*BL.Empleados emp = new BL.Empleados();
        List<String> lstNombresDoctores = emp.obtenerNombresTerapeutas();
        cmbdoctor.DataSource = lstNombresDoctores;
        cmbdoctor.DataBind();*/
    }

    protected void Refrescar_Click(object sender, ImageClickEventArgs e)
    {
        BL.Usuarios user = new BL.Usuarios();
        string username = user.RetrieveUserName(cmbdoctor.Text.Substring(0,cmbdoctor.Text.IndexOf(' ')));
        DateTime fechai = DateTime.Parse(txtdateinit.Text);
        DateTime fechaf = fechai.AddDays(1);
        GridViewCitas.DataSource = app.getCitasMedicas(username, fechai, fechaf);
        GridViewCitas.DataBind();
    }
}