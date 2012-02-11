<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id = "content">
    <div id="titulo">
        <h1>Registro de Empleados</h1>
    </div> 
    <div id = "navcenter">
        <fieldset>
            <ul class = "list">
                <li class="field">
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Nombre:"></asp:Label>
                    <asp:TextBox ID="txb_nombreemp" runat="server" TabIndex="1" CssClass="txtbx_Empleado"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                            ControlToValidate="txb_nombreemp" 
                            ErrorMessage="**Debe Ingresar Nombre"></asp:RequiredFieldValidator>
                </li>
                <li class="field">
                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Primer Apellido:"></asp:Label>
                    <asp:TextBox ID="txb_firstname" runat="server" TabIndex="1" CssClass="txtbx_Empleado"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                ControlToValidate="txb_firstname" 
                                ErrorMessage="**Debe Ingresar Primer Apellido"></asp:RequiredFieldValidator>
                </li>
                <li class="field">
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Segundo Apellido:"></asp:Label>
                    <asp:TextBox ID="txb_secondlastname" runat="server" TabIndex="1" CssClass="txtbx_Empleado"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                            ControlToValidate="txb_secondlastname" 
                            ErrorMessage="**Debe Ingresar Segundo Apellido"></asp:RequiredFieldValidator>
                </li>
                <li class="field">
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="Posición:"></asp:Label>
                    <asp:DropDownList ID="cmb_position" runat="server" CssClass="cmb_Empleado">
                            </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                ControlToValidate="cmb_position" 
                        ErrorMessage="**Debe Ingresar Posición"></asp:RequiredFieldValidator>
                </li>
            </ul>     
        </fieldset>
    </div>            
    <div id="navBotones">
        <asp:Button ID="btn_save1" runat="server" CssClass="boton" onclick="btn_save_Click" 
                Text="Guardar" />
        <asp:Button ID="btn_cancel2" runat="server" CssClass="boton" onclick="btn_cancel_Click" 
                            Text="Cancelar" />
    </div>
</div>
</asp:Content>

