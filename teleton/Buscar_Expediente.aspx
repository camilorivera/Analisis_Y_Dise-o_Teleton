<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buscar_Expediente.aspx.cs" Inherits="Buscar_Expediente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="titulo">
            <h1>Busqueda de pacientes</h1>
        </div>
        <div id="navcenter">
            <fieldset>
                <asp:Label ID="lblCentro" runat="server" Text="Centro:"/>
                <asp:ComboBox ID="cboCentro" runat="server" DropDownStyle="DropDownList"/>
                <asp:Label ID="lblExpediente" runat="server" Text="Expediente:"/>
                <asp:TextBox ID="txtExpediente" runat="server" />
                <asp:RequiredFieldValidator id="reqFieldExp" runat="server"
                    ErrorMessage="Expediente Requerido" ForeColor="Red"
                    ControlToValidate="txtExpediente"></asp:RequiredFieldValidator>
            </fieldset>
        </div>

        <div id="navcontroles">
            <fieldset>
                <ul class = "list">
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
                <asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" 
                    onclick="btnBuscar_Click" CausesValidation="False" />
                <asp:Button ID="btnEditar" runat="server" CssClass="boton" Text="Editar" 
                    onclick="btnEditar_Click"/>
                <asp:Button ID="btnEliminar" runat="server" CssClass="boton" Text="Eliminar" 
                    onclick="btnEliminar_Click"/>
                <asp:ConfirmButtonExtender ID="cfmExtEliminar" runat="server" TargetControlID="btnEliminar"
                    ConfirmText="Desea Eliminar al paciente"></asp:ConfirmButtonExtender>
                <asp:Button ID="btnImprimir" runat="server" CssClass="boton" Text="imprimir" 
                    onclick="btnImprimir_Click" />
                <asp:Button ID="btnCleanPage" runat="server" CssClass="boton" Text="limpiar" 
                    onclick="btnCleanPage_Click" CausesValidation="False" />
        </div>
    </div>
</asp:Content>