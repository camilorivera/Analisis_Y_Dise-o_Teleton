using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text.RegularExpressions;
using System.Threading;

public partial class Login : System.Web.UI.Page
{
    private BL.Security sec = new Security();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                CenterList.DataSource = sec.getCentros();
                CenterList.DataBind();
            }
        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.Validate();

            if (this.IsValid)
            {
                if (sec.login(UserName.Text, Password.Text, CenterList.Text))
                {
                    Session["id_empleado"] = sec.getidEmp();


                    Session["Centro_id"] = CenterList.SelectedItem.Text;
                    Session["Centro_idNum"] = sec.getCentroId(Session["Centro_id"].ToString()).ToString();

                    Session["Permisos_usuario"] = sec.getPermisosUsuario(UserName.Text);
                    Session["Roles_Usuario"] = sec.getRolesUsuario(UserName.Text);

                    Session["loggedin"] = true;
                    Session["nombre_usuario"] = UserName.Text;

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    FailureText.Text = "Password o Usuario Incorrecto";
                }
            }
        }
        catch (ThreadAbortException _ex)
        {

        }
        catch (Exception ex)
        {
            Session["Error_Msg"] = ex.Message;
            Response.Redirect("~/Error.aspx", true);
        }
    }
    
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        String patron = @"^[a-z,A-Z,0-9]{6}[a-z,A-Z,0-9]*$";
        Regex regEx = new Regex(patron);
        if (regEx.Match(Password.Text).Success)
        {
            args.IsValid = true;
        }
        else
        {
            if (Password.Text.Length > 5)
            {
                CustomValidator1.ErrorMessage = " Password debe contener solamente ( a-z y 0-9 )";
            }
            else
            {
                CustomValidator1.ErrorMessage = " Password debe ser mayor a 6 digitos y debe contener solamente ( a-z y 0-9 ) ";
            }
            args.IsValid = false;
        }
    }
}