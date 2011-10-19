using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Editar_Roles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Lista de permisos que el usuario logueado tiene
        List<String> listaPermisos = (List<String>)Session["Permisos_usuario"];

        bool encontroPermiso = false;

        foreach (String strPermiso in listaPermisos)
        {
            //Iteramos los permisos del usuario para comprobar que puede utilizar esta pagina
            if (strPermiso.Equals("pEditarRol"))
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
                BL.Rol rl = new Rol();
                descripciones_DDList.DataSource = rl.getRolesDescripcion();
                descripciones_DDList.DataBind();

                Security sec = new Security();
                centros.DataSource = sec.getCentros();
                centros.DataBind();

                setCheckBoxes();
            }
        } 
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void descripciones_DDList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            setCheckBoxes();
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }

    }

    private void setCheckBoxes()
    {
        try
        {
            BL.Rol rl = new Rol();
            List<string> pers = rl.getRolPermisos(descripciones_DDList.SelectedItem.Text);
            permisos_CBList.DataSource = pers;
            permisos_CBList.DataBind();

            foreach (ListItem it in permisos_CBList.Items)            
                it.Selected = true;

            BL.Permiso per = new Permiso();
            List<string> otherPers = new List<string>();
            List<string> allPers = per.getPermisosID();

            foreach (string pr in allPers)
            {
                bool flag = false;
                foreach (string myper in pers)
                {
                    if (pr == myper)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    otherPers.Add(pr);
            }
            otrosPermisos_CBList.DataSource = otherPers;
            otrosPermisos_CBList.DataBind();

            long c_id = rl.getCentroID(descripciones_DDList.SelectedItem.Text);
            BL.Centro c = new BL.Centro();
            string c_lugar = c.getLugar(c_id);
            centros.SelectedValue = c_lugar;
            
            /*for (int i = 0; i < centros.Items.Count; i++)
            {
                if (centros.Items[i].Text == c_lugar)
                {
                    centros.Items[i].Selected = true;

                    break;
                }
            }*/
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
            List<string> revokes = new List<string>();
            //bool flag = false;

            foreach (ListItem it in permisos_CBList.Items)
            {
                if (it.Selected == false)
                {
                    revokes.Add(it.Text);
                    //flag = true;
                }
            }

            List<string> grants = new List<string>();

            foreach (ListItem it in otrosPermisos_CBList.Items)
            {
                if (it.Selected == true)
                {
                    grants.Add(it.Text);
                    //flag = true;
                }
            }

            /*if (flag)
            {*/
                BL.Rol rl = new Rol();
                long rolId = rl.getRolID(descripciones_DDList.SelectedItem.Text);
                AdministradordeSistema admin = new AdministradordeSistema();


                Security sec = new Security();
                long centro = sec.getCentroId(centros.Text);
                admin.editarRol(rolId, descripciones_DDList.SelectedItem.Text, grants, revokes, centro);

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Rol Editado')", true);
                setCheckBoxes();
            /*}
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert('Rol No Editado')", true);
            }*/
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);            
        }
    }
}