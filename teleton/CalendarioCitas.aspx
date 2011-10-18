<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/CalendarioCitas.aspx.cs" Inherits="EditarCitas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div id = "content">
        <div id="titulo">
            <h1>Calendario de Citas de Terapia</h1>
        </div>
        <div id = "navcenter">
                <fieldset>
                <legend>Calendario de Citas</legend>
                <ul class = "list">
                    <li class="field">
                            <asp:Label ID="Label1" CssClass="labelD" runat="server" 
                                Text="Nombre de Terapeuta "></asp:Label>
                            <asp:DropDownList ID="cmbEmpleados" CssClass="cmb_Empleado" runat="server">
                            </asp:DropDownList>
                     </li>
          

                     <li class="field">
                         <asp:Label ID="Label2" CssClass="labelD" runat="server" Text="N.Expediente: "></asp:Label>
                         <asp:TextBox ID="txtNumExpediente" CssClass="txtbx_labelD" runat="server"></asp:TextBox>
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
                     </li>
                    <li class="field">
                        <asp:GridView ID="grvCitas" runat="server" Width="759px" 
                            AutoGenerateColumns="False" 
                            EmptyDataText="No hay pacientes el día de hoy." 
                            onrowediting="grvCitas_RowEditing" 
                            onrowcancelingedit="grvCitas_RowCancelingEdit" 
                            onrowupdated="grvCitas_RowUpdated">
                            <Columns>
                                   <asp:TemplateField HeaderText="Fecha" SortExpression="fecha">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fecha") %>'>></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha") %>'>></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Terapeuta" SortExpression="user">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("user") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("user") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prefijo" SortExpression="prefijo">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("prefijo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("prefijo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expediente" SortExpression="expediente">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("expediente") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("expediente") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hora Inicial" SortExpression="hora_inicio">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("hora_inicio") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("hora_inicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hora Finaliza" SortExpression="hora_final">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("hora_final") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("hora_final") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Atendido" SortExpression="atendido">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("atendido") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("atendido") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>                       
                     </li>

                     <li class="field">
                     </li>

                 </ul>
              </fieldset>
         </div>

    <div id="navBotones">
            <asp:Button ID="btnBuscar" CssClass="boton" runat="server" Text="Buscar Citas" 
                        onclick="btBuscar_Click" />
                      
            <asp:Button ID="btnClean" CssClass="boton" runat="server" Text="Limpiar" 
                CausesValidation="False" onclick="btnClean_Click"/>
        </div>      

         </div>
</asp:Content>

