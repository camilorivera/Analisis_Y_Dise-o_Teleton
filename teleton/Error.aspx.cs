using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HyperLink1.NavigateUrl = this.Page.Request.UrlReferrer.AbsolutePath;
        Label2.Text = Session["Error_Msg"].ToString();
    }
}