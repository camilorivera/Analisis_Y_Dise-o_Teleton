<%@ Page Title="" Language="C#" MasterPageFile="~/Reportes.master" AutoEventWireup="true" CodeFile="Seguimiento_Paciente_Quicksearch.aspx.cs" Inherits="Seguimiento_Paciente_Quicksearch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">    
<asp:Panel ID="Panel1" runat="server" DefaultButton="searchBtn" >    
<div id = "content">
    <div id="titulo">Busqueda Rapida: Seguimiento Pacientes</div>
    <div id="navcenter">
        <fieldset class="fsQuickSearch">
            <ul class = "list">
                <li class = "field">
                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Centro"></asp:Label>
                    <asp:DropDownList ID="centrosPermitidos" CssClass="txtbx_QuickSearch" runat="server">
                    </asp:DropDownList>
                </li>
                <li class = "field">
                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Nombres"></asp:Label>
                    <asp:TextBox ID="nombres_TB" CssClass="txtbx_QuickSearch" runat="server"></asp:TextBox>
                </li>
                <li class = "field">
                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Primer Apellido"></asp:Label>
                    <asp:TextBox ID="primerApellido_TB" CssClass="txtbx_QuickSearch" runat="server"></asp:TextBox>
                </li>
                <li class = "field">
                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Segundo Apellido"></asp:Label>
                    <asp:TextBox ID="segundoApellido_TB" CssClass="txtbx_QuickSearch" runat="server"></asp:TextBox>                    
                </li>
                <li class = "field">
                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="Cedula"></asp:Label>
                    <asp:TextBox ID="cedula_TB" CssClass="txtbx_QuickSearch" runat="server"></asp:TextBox>                    
                    <asp:MaskedEditExtender ID="cedula_TB_MaskedEditExtender" runat="server" 
                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                        Mask="9999-9999-99999" MaskType="Number" TargetControlID="cedula_TB">
                    </asp:MaskedEditExtender>
                </li>
                <li class = "customValidator">
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ErrorMessage="Ingrese un valor para buscar." ForeColor="Red" 
                        onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </li>
            </ul>
        </fieldset>
        <div class="resetFloats"></div>        
    </div>
    <div id = "navcontroles">
        <asp:GridView ID="GridView1" CssClass="Grid" runat="server"></asp:GridView>
    </div>
    <div id="navBotones">
        <asp:Button ID="searchBtn" CssClass="boton" runat="server" Text="Buscar" 
            onclick="searchBtn_Click" />
        <asp:Button ID="cleanBtn" CssClass="boton" runat="server" Text="Limpiar" 
            onclick="cleanBtn_Click" />
        <asp:Button ID="closeBtn" CssClass="boton" runat="server" Text="Cerrar" 
            OnClientClick="window.close()" CausesValidation="False" />
    </div>
</div>
</asp:Panel>
</asp:Content>

