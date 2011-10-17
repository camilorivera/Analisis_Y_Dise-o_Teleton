using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        if ((bool)Session["loggedin"] == false)
            Response.Redirect("Login.aspx");

        usr.Text = (string)Session["nombre_usuario"];
        centro.Text = (string)Session["Centro_id"];
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void labelLogout_Click(object sender, EventArgs e)
    {
        Session["loggedin"] = false;
        Session.Abandon();
        //Session["nombre_usuario"] = "";
        Response.Redirect("Login.aspx");        
    }    
}
