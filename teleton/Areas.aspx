<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Areas.aspx.cs" Inherits="Areas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
        <div id="navcenter">
             <div id="titulo">
                <h1>
                    Mantenimiento de Áreas
                </h1>
             </div>
             <div>
                <fieldset>
                    <ul class="list">
                        <li class="field">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Nombre" runat="server" Text="Área: " Enabled="false" Font-Size="Medium"></asp:Label>
                            <asp:TextBox ID="txt_Area" runat="server" Enabled="false" Font-Size="Medium"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Orden" Text="Orden: "  runat="server" Enabled="false" Font-Size="Medium"></asp:Label>
                            <asp:TextBox ID="txt_orden" runat="server" Enabled="false" Font-Size="Medium"></asp:TextBox>
                        </li>
                        <li class ="field">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button 
                                ID="btn_Ver" runat="server" CssClass="boton" Text="Ver Todo"  Width="79px" 
                                onclick="btn_Ver_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_Nuevo" runat="server" CssClass="boton" Text="Nuevo" 
                                onclick="btn_Nuevo_Click" Width="78px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_Guardar" runat="server" CssClass="boton" Text="Guardar" 
                                onclick="btn_Guardar_Click" Width="79px" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                    </ul>
                </fieldset>
            </div>
            <div class="cajas">
                <fieldset>
                    <ul class="list">
                        <li class="field">
                        
                <asp:GridView ID="grd_Area" CssClass="Grid" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataKeyNames="orden" AllowPaging="True" 
                    onpageindexchanging="grd_Area_PageIndexChanging" > 
                    <HeaderStyle Height="18px" />
                    <pagerstyle backcolor="ControlLight"/>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Ver" runat="server" CausesValidation="False" 
                                CommandName="View" ImageUrl="~/imagenes/view.png"  Onclick="Ver_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Eliminar" runat="server" CausesValidation="False" 
                                CommandName="Eliminar" ImageUrl="~/images/delete.png" Onclick="Eliminar_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Id" DataField="id" ReadOnly="true" Visible="false" SortExpression="id"/>
                        <asp:BoundField HeaderText="Area" DataField="area" ReadOnly="true" SortExpression="area"/>
                        <asp:BoundField HeaderText="Orden" DataField="orden" ReadOnly="true" SortExpression="orden"/>
                    </Columns>
                    <RowStyle Height="20px" />
                    <SelectedRowStyle ForeColor="Red" />
                </asp:GridView>
                <br />
                            <asp:Label ID="lb_mensaje" runat="server" Visible="False" ForeColor="Red" Font-Size="Medium" ></asp:Label>
                <br />
                        </li>
                    </ul>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>

