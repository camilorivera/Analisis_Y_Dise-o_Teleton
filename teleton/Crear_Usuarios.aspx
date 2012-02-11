<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Crear_Usuarios.aspx.cs" Inherits="Crear_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <div id="titulo">
            <h1>Ingreso de Usuarios</h1>
        </div>
        <div id = "navcenter">
                <fieldset>
                    <ul class = "list">
                        <li class="field">
                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Empleado:"></asp:Label>
                            <asp:DropDownList ID="cmb_empleados" runat="server" 
                                    TabIndex="1" CssClass="dropdownlist"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmb_empleados" 
                                    ErrorMessage="**Debe Escoger Un Empleado" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label1" runat="server" CssClass="label" Text="UserName:"></asp:Label>
                            <asp:TextBox ID="txt_username" runat="server" TabIndex="1" 
                                    CssClass="txtbx_Empleado"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="**Ingrese Username" 
                                  ControlToValidate="txt_username" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label4" runat="server" CssClass="label" Text="Contraseña:"></asp:Label>
                            <asp:TextBox ID="txt_password" runat="server" Enable="false" TabIndex="1" 
                                CssClass="txtbx_Empleado" TextMode="Password" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="**Ingrese Contraseña" 
                                ControlToValidate="txt_password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label5" runat="server" CssClass="label" Text="Contraseña:"></asp:Label>
                            <asp:TextBox ID="txt_password0" runat="server" Enable="false" TabIndex="1" 
                                CssClass="txtbx_Empleado" TextMode="Password" ></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToCompare="txt_password" ControlToValidate="txt_password0" 
                                ErrorMessage="Escriba nuevamente la contraseña" ForeColor="#FF3300"></asp:CompareValidator>
                        </li>
                        <li class="field">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="txt_password" 
                                ErrorMessage="La contraseña debe ser mayor a 6 digitos, contener letras y número (a-z y 0-9)" 
                                ForeColor="#FF3300" ValidationExpression="^[a-z,A-Z,0-9]{6}[a-z,A-Z,0-9]*"></asp:RegularExpressionValidator>
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
                                    <div id="Div1">Roles de Usuario</div>
                                </li>
                                <li class = "field">
                                    <div id="ctrlCentrado2">
                                        <div id="menuizq">
                                            <asp:ListBox ID="lb_userrols" runat="server" CssClass="listbox"></asp:ListBox>
                                        </div>
                                        <div id="menubotones">
                                            <asp:Button ID="btn_leftuserrol" runat="server" CssClass="boton" onclick="btn_leftuserrol_Click" Text="&lt;" />
                                            <div id="espaciadorBotones"></div>
                                            <asp:Button ID="btn_rightuserrol" runat="server" CssClass="boton" onclick="btn_rightuserrol_Click" Text="&gt;" />
                                        </div>
                                        <div id="menuder">
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

