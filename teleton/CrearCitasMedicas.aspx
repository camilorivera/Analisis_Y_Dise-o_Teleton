<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CrearCitasMedicas.aspx.cs" Inherits="CrearCitasMedicas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id = "content">
        <div id="titulo">
            <h1>Creación de Citas Médicas</h1>
        </div>
        <div id = "navcenter">
                <fieldset>
                <legend>Ingreso de Citas</legend>
                <ul class = "list">
                    <li class="field">
                            <asp:Label ID="Label1" CssClass="labelD" runat="server" Text="Nombre de Doctor: "></asp:Label>
                            <asp:DropDownList ID="cmbEmpleados" CssClass="cmb_Empleado" runat="server">
                            </asp:DropDownList>
                     </li>
          

                     <li class="field">
                         <asp:Label ID="Label2" CssClass="labelD" runat="server" Text="N.Expediente: "></asp:Label>
                        <asp:TextBox ID="txtNumExpediente" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="txtNumExpediente" ErrorMessage="Campo Requerido" 
                             ForeColor="Red"></asp:RequiredFieldValidator>
                     </li>

                      <li class="field">
                        <asp:Label ID="Label3" CssClass="labelD" runat="server" Text="Fecha de Cita: "></asp:Label>
                        
                        <asp:TextBox ID="txtfecha" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
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

                     <li class="field">
                         <table>
                             <tr>
                                 <td>
                                    <asp:Label ID="Label4" CssClass="labelD" runat="server" Text="Hora de Cita: "></asp:Label>
                                 </td>
                                 <td>
                                    <MKB:TimeSelector ID="timeSelectorHoraCita" CssClass="txtbx_labelH" 
                                         runat="server" MinuteIncrement="30" DisplaySeconds="False" 
                                         SelectedTimeFormat="TwentyFour">
                                    </MKB:TimeSelector>
                                 </td>
                             </tr>
                         </table>
                     </li>
                    <li class="field">
                        <asp:Label ID="Label5" CssClass="labelD" runat="server" Text="Tipo Cita: "></asp:Label>
                        <asp:TextBox ID="txtTipo" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
                          
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtTipo" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                          
                     </li>

                     <li class="field">
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

