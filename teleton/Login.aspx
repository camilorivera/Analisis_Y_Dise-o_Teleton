<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>Login</title>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <!--espacio vertical-->
        <div class="vertical_center">
        </div>
		<div class="wrapper">
			<div class="content">
            <div id="form_wrapper" class="form_wrapper">
                <form id="form1" runat="server" class="login active">                    
                            <span class="failureNotification">
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                            </span>
                            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                                 ValidationGroup="LoginUserValidationGroup" Width="380px"/>
                            
                            <img src="images/teletonLogoSolid.png" alt="teleton_logo"/>
                            <!--Titulo-->
                            <h4>Login</h4>
                            <div class="clear"></div>
                            <div>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="label_img">Username:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;
                                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                    ControlToValidate="Password" ForeColor="Red" 
                                    onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </div>
                            <div>
                                <asp:Label ID="CentroLabel" runat="server" CssClass="l">Centro:</asp:Label>
                                <asp:DropDownList ID="CenterList" runat="server" 
                                 CssClass="dropDownL"></asp:DropDownList>
                            </div>
                            <div class="bottom">
                                
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                    onclick="LoginButton_Click"/>
                                <div class="clear"></div>
                            </div>
                 </form>
		    <div class="clear"></div>
		    </div>
            </div>	
        </div>   
		<!-- The JavaScript -->	
    </body>
</html>
