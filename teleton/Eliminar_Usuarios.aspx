<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Eliminar_Usuarios.aspx.cs" Inherits="Eliminar_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <div id="titulo">
            <h1>Eliminar Usuarios</h1>
        </div>
        <div id = "navcenter">
            <fieldset>
                <ul class = "list">
                    <li class="field">
                        <asp:Label ID="Label1" cssclass="label" runat="server" Text="Usuario:"></asp:Label>
                        <asp:DropDownList ID="cmb_usuarios" CssClass="cmb_usuarios" runat="server">
                            </asp:DropDownList>
                    </li>
                </ul>
              </fieldset>
        </div>
        <div id="navBotones">
            <asp:Button ID="btn_eliminar" cssclass="boton" runat="server" Text="Eliminar" 
                onclick="btn_eliminar_Click" />
        </div>
    </div>
</asp:Content>
