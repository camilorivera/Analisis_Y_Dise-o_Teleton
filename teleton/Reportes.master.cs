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
    }

    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
}
