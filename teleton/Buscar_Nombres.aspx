<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buscar_Nombres.aspx.cs" Inherits="Buscar_Nombres" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
  <div id="content">
    <div id="navcenter">
    <div id="titulo">
        <h1>Busqueda de Pacientes por Nombre</h1>
    </div>
 <br />
 <br />
    <div>
    <fieldset >
    
        <br /> 
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Ingrese Nombre:"></asp:Label>
       
        <asp:TextBox ID="txt_nombre" runat="server" Width="149px"></asp:TextBox>

                <asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" 
                    onclick="btnBuscar_Click" CausesValidation="False" 
            BackColor="#CC0000" />
   </div>
    <br />
    </fieldset>
       </div>
      
    <br />
   
    <fieldset>
    <br />
   
    
   <div align="center">
    <asp:ListBox ID="lista" runat="server" Height="276px" Width="582px" 
        onselectedindexchanged="lista_SelectedIndexChanged">
    </asp:ListBox>
    </div>
    <br />
    <br />
       </fieldset>
       </div>
       <br />
   
    <br />
                <asp:Button ID="btnAceptar" runat="server" CssClass="boton" Text="Aceptar" 
                    onclick="btnAceptar_Click" CausesValidation="False" 
        BackColor="#CC0000" />
                <br />
               
    <br />
    <br />
    <br />
    </div>
</asp:Content>

