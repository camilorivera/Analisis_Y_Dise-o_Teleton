<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Editar Empleados.aspx.cs" Inherits="Editar_Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">   
    <div id = "content">   
        <div id="titulo">
            <h1>Editar Empleados</h1>
        </div>
        <div id = "navcenter">
            <fieldset>
                <ul class = "list">
                    <li class="field">
                         <asp:Label ID="Label1" CssClass="label" runat="server" Text="Elija Usuario:"></asp:Label>
                         <asp:DropDownList ID="cmb_usuarios" CssClass="cmb_Empleado" runat="server"></asp:DropDownList>
                    </li>
          
                    <li class="field">
                        <asp:Label ID="Label2" runat="server" cssclass="label" Text="Primer Nombre:"></asp:Label>
                        <asp:TextBox ID="txt_username" runat="server" cssclass="txtbx_Empleado"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                ErrorMessage="**Ingrese Primer Nombre" ControlToValidate="txt_username"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label5" cssclass="label" runat="server" Text="Primer Apellido:"></asp:Label>
                        <asp:TextBox ID="txt_lastname" cssclass="txtbx_Empleado" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                ErrorMessage="**Ingrese Primer Apellido" ControlToValidate="txt_lastname"></asp:RequiredFieldValidator>
                    </li>

                    <li class="field">
                        <asp:Label ID="Label3" cssclass="label" runat="server" Text="Segundo Apellido:"></asp:Label>
                        <asp:TextBox ID="txt_secondlastname" CssClass="txtbx_Empleado" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" 
                                ErrorMessage="**Ingrese Segundo  Apellido" 
                                ControlToValidate="txt_secondlastname"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label4" cssclass="label" runat="server" Text="Puesto:"></asp:Label>
                        <asp:DropDownList ID="cmb_puesto" CssClass="cmb_Empleado" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                        ErrorMessage="**Debe elegir un Puesto " 
                            ControlToValidate="cmb_puesto"></asp:RequiredFieldValidator>
                    </li>                          
                </ul>
            </fieldset>
        </div>                   
        <div id="navBotones">
            <asp:Button ID="Button1" CssClass="boton" runat="server" Text="Guardar" onclick="btnGuardar_Click" />     
            <asp:Button ID="Button2" CssClass="boton" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
        </div>
    </div>
</asp:Content>

