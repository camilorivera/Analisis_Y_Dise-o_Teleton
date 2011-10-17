<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>
            :-(
        </h1>
        <br/>
        <h2>
            ¡Ha ocurrido un error!
        </h2>
    </div>
    <div>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Label">(Mostrar Detalles...)</asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Label">Error Message Placeholder</asp:Label>
    </asp:Panel>
        <asp:CollapsiblePanelExtender ID="Panel2_CollapsiblePanelExtender" 
            runat="server" Enabled="True" Collapsed="true" TargetControlID="Panel2" CollapseControlID="Panel1" ExpandControlID="Panel1"
            SuppressPostBack="true" TextLabelID="Label1" ExpandedText="(Ocultar Detalles...)" CollapsedText="(Mostrar Detalles...)">
        </asp:CollapsiblePanelExtender>
    </div>
    <br />
    <br />
    <div>
        Para volver a la página anterior, haga click
        <asp:HyperLink ID="HyperLink1" runat="server">aquí.</asp:HyperLink>
    </div>
</asp:Content>

