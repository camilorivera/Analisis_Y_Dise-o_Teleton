<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditarCitasMedico.aspx.cs" Inherits="EditarCitasMedico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div id = "content">
        
            <div id="content3">
                <div id = "titulo">
                    <h1>Calendario Citas Medico</h1>

                     <div id="navcenter">
                            <fieldset>  
                            <ul class = "list">
                               <li class = "field">                 
                                 <asp:Label ID="LblNumExp" CssClass="labelD" runat="server" Text="Nombre Doctor:"></asp:Label>
                                   <asp:DropDownList ID="cmbdoctor" CssClass="cmbpatologias" runat="server"></asp:DropDownList>
                               </li>
                               <li class = "field">
                                <asp:Label ID="lbldateinit" CssClass="labelD" runat="server" Text="Fecha Inicial:"></asp:Label>
                                <asp:TextBox ID="txtdateinit" runat="server" CssClass="txtbx_labelD"></asp:TextBox>
                                    <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" 
                                          TargetControlID="txtdateinit" Format="yyyy-MM-dd" 
                                          PopupButtonID="imgdateinit">
                                    </asp:CalendarExtender>
                        <img alt="Icon" src="images/calendar_icon.jpg" class="calendar" id="imgdateinit" />
                                   <asp:ImageButton ID="Refrescar" CssClass="botonbusquedarapida" 
                                       ImageUrl="~/images/Refresh-32.png" runat="server" CausesValidation="False" 
                                       onclick="Refrescar_Click"/>
                        </li>

                      </ul>
                 </fieldset>

   <fieldset>
   <asp:Panel ID="Panel1" CssClass="panelRolesSeg" runat="server" ScrollBars="Auto">
       <asp:GridView ID="GridViewCitas" emptydatatext="----No Hay Citas Registradas el Dia de Hoy.----" CssClass="Grid" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="True" PageSize="50">
           <Columns>
               <asp:TemplateField HeaderText="Num Expediente">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("expediente") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%# Bind("expediente") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Hora">
                   <EditItemTemplate>
                       <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("fecha_hora") %>'></asp:TextBox>
                   </EditItemTemplate>
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha_hora") %>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
           </Columns>
       </asp:GridView>
   </asp:Panel>

   </fieldset>
                </div>
              </div>
            </div>
         
 </div>



</asp:Content>

