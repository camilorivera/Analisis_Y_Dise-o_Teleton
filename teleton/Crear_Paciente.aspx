<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Crear_Paciente.aspx.cs" Inherits="Crear_Paciente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
        <div id = "titulo">
            <h1>Registro de Pacientes</h1> 
            <h2>Información General</h2>
        </div>

        <div id="navcenter">
        <fieldset>
                <ul class = "list">
                    <li class="field">
                        <asp:Label ID="Label11" CssClass="label" runat="server" Text="Nº de Expediente:"></asp:Label>
                        <asp:TextBox ID="txtExp" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtExp" ErrorMessage="*Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label2" CssClass="label" runat="server" Text="Nº de Cédula:"></asp:Label>
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="*Campo Requerido" ForeColor="Red" 
                                ControlToValidate="txtCedula" ></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label3" CssClass="label" runat="server" Text="Nombres:"></asp:Label>
                        <asp:TextBox ID="txtNombres" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="*Nombre Requerido" ForeColor="Red" 
                                ControlToValidate="txtNombres"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label4" CssClass="label" runat="server" Text="Primer Apellido:"></asp:Label>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ErrorMessage="*Apellido Requerido" ForeColor="Red" 
                             ControlToValidate="txtPrimerApellido"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label1" CssClass="label" runat="server" Text="Segundo Apellido:"></asp:Label>
                        <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label5" CssClass="label" runat="server" Text="Dirección:"></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                             ErrorMessage="*Direccion Requerida" ForeColor="Red" 
                             ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label6" CssClass="label" runat="server" Text="Sexo:"></asp:Label>
                        <asp:radiobuttonlist id="rdSexo" runat="server" RepeatDirection="Horizontal">
                          <asp:listitem id="rdMasculino" Selected="true" runat="server" value="Masculino" />
                          <asp:listitem id="rdFemenino" runat="server" value="Femenino" />
                        </asp:radiobuttonlist>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label7" CssClass="label" runat="server" Text="Estado Civil:"></asp:Label>
                        <asp:DropDownList ID="ddEstado" runat="server" CssClass="tb_Permiso">
                            <asp:ListItem Selected="True" Value="0">Soltero</asp:ListItem>
                            <asp:ListItem Value="1">Casado</asp:ListItem>
                            <asp:ListItem Value="2">Divorciado</asp:ListItem>
                            <asp:ListItem Value="3">Viudo</asp:ListItem>
                            <asp:ListItem Value="4">Unión libre</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label8" CssClass="label" runat="server" Text="Lugar de Nacimiento:"></asp:Label>
                        <asp:TextBox ID="txtLugarNacimiento" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ErrorMessage="*Campo Requerido" ForeColor="Red" 
                                ControlToValidate="txtLugarNacimiento"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label9" CssClass="label" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
                        <asp:TextBox ID="txtFechaNacimiento" runat="server" ></asp:TextBox>
                        <img alt="Icon" src="images/calendar_icon.jpg" id="img_fecha_nacimiento"/>
                        <asp:CalendarExtender ID="FechaNacimientoExtender" runat="server" TargetControlID="txtFechaNacimiento" Format="yyyy-MM-dd" PopupButtonID="img_fecha_nacimiento">
                        </asp:CalendarExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ErrorMessage="*Fecha de Nacimiento Requerida" ForeColor="Red" 
                            ControlToValidate="txtFechaNacimiento"></asp:RequiredFieldValidator>
                    </li>
                    <li class="field">
                        <asp:Label ID="Label10" CssClass="label" runat="server" Text="Fecha de Ingreso:"></asp:Label>
                        <asp:TextBox ID="txtFechaIngreso" runat="server" ></asp:TextBox>
                        <img alt="Icon" src="images/calendar_icon.jpg" id="img1" width="24px" />


                        <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" 
                            TargetControlID="txtFechaIngreso" Format="yyyy-MM-dd" PopupButtonID="img1">
                        </asp:CalendarExtender>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ErrorMessage="*Fecha de Ingreso Requerida" ForeColor="Red" 
                            ControlToValidate="txtFechaIngreso"></asp:RequiredFieldValidator>
                    </li>
                </ul>                
            </fieldset>                    
        </div>
        
        <div id="navBotones">
            <asp:Button ID="btIngresar" CssClass="boton" runat="server" Text="Ingresar Paciente" 
                        onclick="btIngresar_Click" />
            <asp:Button ID="btnClean" CssClass="boton" runat="server" Text="Limpiar" 
                CausesValidation="False" onclick="btnClean_Click"/>
            <asp:Button ID="btnPrint" CssClass="boton" runat="server" Text="Imprimir" 
                EnableTheming="True" onclick="btnPrint_Click"/>
        </div>        
    </div>
</asp:Content>

