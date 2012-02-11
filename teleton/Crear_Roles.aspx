<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Crear_Roles.aspx.cs" Inherits="Crear_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">   
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
        <div id = "titulo">
            <h1>Crear Roles</h1>
        </div>
        <div id = "navcenter">            
            <fieldset>
                <ul class = "list">
                    <li class="field">
                        <asp:Label ID="Label1" cssclass="label" runat="server" Text="Nombre del rol:"></asp:Label>
                        <asp:TextBox ID="descripcion_TB" CssClass="tb_crearRol" runat="server" TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Descripción Requerida" ControlToValidate="descripcion_TB"></asp:RequiredFieldValidator> 
                    </li>
                    <li class = "field">
                        <asp:Label ID="Label3" cssclass="label" runat="server" Text="Centro:"></asp:Label>
                        <asp:DropDownList ID="centros" CssClass="tb_crearRol" runat="server"></asp:DropDownList>       
                    </li>
                </ul>
            </fieldset>
        </div>
        <div id="navcontroles">
            <fieldset>
                <ul class = "list">
                    <li class = "field">
                        <asp:Label ID="Label2" cssclass="label" runat="server" Text="Permisos:"></asp:Label>                        
                        <asp:Panel ID="Panel1" CssClass="panelRoles" runat="server" ScrollBars="Auto">
                            <asp:CheckBoxList ID="permisos_CBList" runat="server" TabIndex="3"></asp:CheckBoxList>
                        </asp:Panel>
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

