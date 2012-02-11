<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NoAccess.aspx.cs" Inherits="Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <meta http-equiv="refresh" content="5; url=Default.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        Lo siento, usted no posee privilegios suficientes para accesar a este recurso, para obtener acceso contacte al administrador de sistema
    </div>
    <div>
        Si su explorador no lo redirecciona automáticamente, haga click <a href="Default.aspx">aquí.</a>
    </div>
</asp:Content>

