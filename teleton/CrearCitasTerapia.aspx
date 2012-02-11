<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CrearCitasTerapia.aspx.cs" Inherits="CrearCitasTerapia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 60px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <div id="titulo">
            <h1>Creación de Citas Terapia</h1>
        </div>
        <div id = "navcenter">
                <fieldset>
                <legend>Ingreso de Citas</legend>
                <ul class = "list">
                    <li class="field">
                            <asp:Label ID="Label1" CssClass="labelD" runat="server" 
                                Text="Nombre de Terapeuta: "></asp:Label>
                            <asp:DropDownList ID="cmbEmpleados" CssClass="cmb_Empleado" runat="server">
                            </asp:DropDownList>
                     </li>
                     <li>
                     <br />
                     </li>
                     
                     <li class="field">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="Label2" CssClass="labelD" runat="server" Text="Nº Expediente: "></asp:Label>
                        <asp:TextBox ID="txtNumExpediente" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
                         &nbsp;
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="txtNumExpediente" ErrorMessage="Campo Requerido" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                     </li>
                     <li>
                        <br />
                     </li>

                      <li class="field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="Label3" CssClass="labelD" runat="server" Text="Fecha de Cita: "></asp:Label>
&nbsp;<asp:TextBox ID="txtfecha" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
                          <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" 
                            TargetControlID="txtfecha" Format="yyyy-MM-dd" 
                             PopupButtonID="imgdateinit">
                          </asp:CalendarExtender>
                          <img alt="Icon" src="images/calendar_icon.jpg" class="calendar" 
                         id="imgdateinit" />
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                              ControlToValidate="txtfecha" ErrorMessage="Campo Requerido" 
                              ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                     <li>
                        <br />
                     </li>
                    <li class="field">
                        <table>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label4" CssClass="labelD" runat="server" Text="Empieza:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                <MKB:TimeSelector ID="timeSelectorHoraEmpieza" CssClass="txtbx_labelH" 
                                         runat="server" MinuteIncrement="30" SelectedTimeFormat="TwentyFour" 
                                        DisplaySeconds="False">
                                    </MKB:TimeSelector>
                                </td>
                                <td class="style1">
                                    &nbsp;<asp:Label ID="Label5" CssClass="labelD" runat="server" Text="Hasta :"></asp:Label> 
                                </td>
                                <td>
                                <MKB:TimeSelector ID="timeSelectorHoraTermina" CssClass="txtbx_labelH" 
                                         runat="server" MinuteIncrement="15" SelectedTimeFormat="TwentyFour" 
                                        DisplaySeconds="False">
                                    </MKB:TimeSelector>
                                </td>
                                
                            </tr>
                        </table>
                    </li>
                    <li>
                        <br />
                    </li>
                    <li class="field">
                        <asp:Label ID="lblHora" runat="server" ForeColor="Red" 
                            Text="*Debe Ingresar una hora inicio menor que la hora final." Visible="False"></asp:Label>
                            <br />
                        <asp:Label ID="lb_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                    </li>

                 </ul>
              </fieldset>
         </div>

    <div id="navBotones">
            <asp:Button ID="btIngresar" CssClass="boton" runat="server" Text="Guardar Cita" 
                        onclick="btIngresar_Click" />
                        <asp:ConfirmButtonExtender ID="GuardarConfirmation" runat="server" TargetControlID="btIngresar"
                                        ConfirmText="Esta Seguro Que Desea Guardar la Informacion?" ></asp:ConfirmButtonExtender>
            <asp:Button ID="btnClean" CssClass="boton" runat="server" Text="Limpiar" 
                CausesValidation="False" onclick="btnClean_Click"/>
        </div>      

         </div>
</asp:Content>

