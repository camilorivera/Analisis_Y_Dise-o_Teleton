<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Buscar_Nombres.aspx.cs" Inherits="Buscar_Nombres" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" /> 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
     </p>
  <div id="content">
    <div id="navcenter">
    <div id="titulo">
        <h1>Búsqueda de Pacientes por Nombre</h1>
    </div>
 <br /> 
 
    <div>
    <fieldset >
    
        <br /> 
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Ingrese Nombre:"></asp:Label>
       
        &nbsp;<asp:TextBox ID="txt_nombre" runat="server" Width="149px"></asp:TextBox>

                &nbsp;

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
    <asp:ListBox ID="lista" runat="server" Height="265px" Width="582px" 
           onload="lista_Load">
    </asp:ListBox>
    </div>
    <br />
       </fieldset>
       </div>
       <br />
    <br />
    <br />
    </div>
</asp:Content>

