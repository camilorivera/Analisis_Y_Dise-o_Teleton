<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditarUsuarios.aspx.cs" Inherits="EditarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
        <div id = "content">
            <div id="titulo">
                <h1>Editar Usuarios</h1>
            </div>
            <div id = "navcenter">
                <fieldset>
                    <ul class = "list">
                        <li class="field">
                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Nombre Empleado: "></asp:Label>
                            <asp:DropDownList ID="cmb_empleados" runat="server" 
                                    TabIndex="1" CssClass="dropdownlist" AutoPostBack="True" 
                                ontextchanged="cmb_empleados_TextChanged1" 
                              ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmb_empleados" 
                                    ErrorMessage="**Debe Escoger Un Empleado" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                </fieldset>
            </div>            
            <div id = "navcontroles">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <fieldset>
                            <ul class = "list">
                               
                                <li class = "field">
                                    <div id="ctrlCentrado2">
                                        <div id="menuizq">
                                            <asp:Label ID="RolesdlUsuario" runat="server" CssClass="labelUser" 
                                                Text="Roles del Usuario" ></asp:Label>
                                            <asp:ListBox ID="lb_userrols" runat="server" CssClass="listbox"></asp:ListBox>
                                        </div>
                                        <div id="menubotones">
                                            <asp:Button ID="btn_leftuserrol" runat="server" CssClass="boton" onclick="btn_leftuserrol_Click" Text="&lt;" />
                                            
                                            <div id="espaciadorBotones"></div>
                                            <asp:Button ID="btn_rightuserrol" runat="server" CssClass="boton" onclick="btn_rightuserrol_Click" Text="&gt;" />
                                        </div>
                                        <div id="menuder">
                                        <asp:Label ID="rolsist" runat="server" CssClass="labelUser" 
                                                Text="Roles del Sistema" ></asp:Label>
                                            <asp:ListBox ID="lb_sourcerols" runat="server" CssClass="listbox"></asp:ListBox>
                                        </div>
                                        <div id="resetFloats"></div>
                                    </div>
                                </li>
                            </ul>
                        </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>            
            <div id="navBotones">
                    <asp:Button ID="btn_GuardarUsuario" runat="server" CssClass="boton" onclick="btn_GuardarUsuario_Click" 
                        Text="Guardar" />
                    <asp:Button ID="btn_Cancel" runat="server" CssClass="boton" onclick="btn_Cancel_Click" 
                        Text="Cancelar" />
            </div>
        </div>    
</asp:Content>

