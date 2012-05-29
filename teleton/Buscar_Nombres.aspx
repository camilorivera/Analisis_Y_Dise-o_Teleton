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
                <fieldset>
                    <br /> 
                    <div align="center">
                        <asp:Panel runat="server" ID="pnlBusquedaAvanzada" Width="100%">
                            <div style="padding-left: 50px; padding-right: 50px">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Ingrese Nombre:"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_nombre" runat="server" Width="149px" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnBuscar" runat="server" CssClass="boton" Text="Buscar" 
                                                onclick="btnBuscar_Click" CausesValidation="False" BackColor="#CC0000" />
                                        </td>
                                        <td>
                                            <asp:LinkButton runat="server" ID="lbBusquedaAvanzada" Text="Busqueda Avanzada" 
                                                onclick="lbBusquedaAvanzada_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblIdentidad" Visible="false">Identidad:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtIdentidad" runat="server" Visible="false" Width="149px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblFechaIngreso" Visible="false">Fecha de ingreso:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtFechaIngreso" Visible="false" Width="149px"></asp:TextBox>
                                            <asp:Image ImageUrl="images/calendar_icon.jpg" id="imgCalendarIcon" width="24px" runat="server" Visible="false"/>
                                            <asp:CalendarExtender ID="ceFechaIngreso" runat="server" TargetControlID="txtFechaIngreso" Format="dd-MM-yyyy"
                                                PopupButtonID="imgCalendarIcon">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align:center">
                                            <asp:Label runat="server" ID="lblElecciones" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td colspan="2" style="text-align: right; padding-right: 50px">
                                            <asp:Button runat="server" ID="btBuscar" Text="Buscar" CssClass="boton" 
                                                Visible="false" onclick="btBuscar_Click"/>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                    <br />
                </fieldset>
            </div>
            <br />
            
            <fieldset>
                <br />
                <div align="center">
                    <asp:ListBox ID="lista" runat="server" Height="265px" Width="582px" onload="lista_Load"></asp:ListBox>
                </div>
                <br />
            </fieldset>
        </div>
        <br />
        <br />
        <br />
    </div>
</asp:Content>

