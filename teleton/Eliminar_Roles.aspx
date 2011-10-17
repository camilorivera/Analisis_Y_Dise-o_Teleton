<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Eliminar_Roles.aspx.cs" Inherits="Eliminar_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id = "content">
        <div id = "titulo">
            <h1>Eliminar Roles</h1>
        </div>
        <div id="navcontroles">
            <fieldset>
                <ul class = "list">
                    <li class = "field">
                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="Roles:"></asp:Label>
                        <div id="ctrlCentrado">
                            <asp:Panel ID="Panel1" CssClass="panelRoles2" runat="server" ScrollBars="Auto">
                                <asp:CheckBoxList ID="roles_CBList" runat="server" TabIndex="3">
                                        </asp:CheckBoxList>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Seleccione al menos un permiso." 
                                        onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                            </asp:Panel>
                        </div>
                    </li>
                </ul>
            </fieldset>
        </div>
        <div id="navBotones">
            <asp:Button ID="acceptButton" cssclass="boton" runat="server" Text="Aceptar" 
                    onclick="acceptButton_Click" />
        </div>
</div>       
</asp:Content>

