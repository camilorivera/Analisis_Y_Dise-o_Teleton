<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistoPacienteAlta.aspx.cs" Inherits="HistoPaciente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script runat="server">
    
</script>
<div id = "content">
    <div id="navcenter">
        <div id="titulo">
            <h1>
                Hoja de Alta</h1>
        </div>
        <div>
            <fieldset>
                <ul class="list">
                    <li class="field" >
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       &nbsp;<asp:Label ID="lb_Expediente" runat="server" Text="Expediente :" Font-Size="Medium"></asp:Label>
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txt_buscar"
                            runat="server" TabIndex="1" Width="165px" Height="19px" Font-Size="Medium"></asp:TextBox>
                       &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lb_centro" runat="server" Text="Centro :" Font-Size="Medium"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:DropDownList ID="ddl_centro" runat="server" Height="25px" Width="164px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Buscar"  CssClass="boton" runat="server" Text="Buscar" 
                            onclick="Button1_Click" />
                    </li>
                </ul>
            </fieldset>
        </div>
        <div class="cajas"> 
            <fieldset> 
                
                <ul class="list">
                    <li class="field">
                        <asp:Label ID="lb_Paciente" runat="server" Font-Bold="True" ForeColor="Red"  ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lb_Expe" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_historial" runat="server" Height="83px" 
                            TextMode="MultiLine" Width="100%" BorderStyle="Outset" Enabled="False"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_guardar"  CssClass="boton" runat="server" Text="Dar de alta" 
                            onclick="btn_guardar_Click" Enabled="False" EnableTheming="True" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lb_mensaje" runat="server"  Font-Bold="true" ForeColor="Red" Enabled="False"></asp:Label>
                    </li>
                </ul>            
            </fieldset> 
        </div>
        <div>
            <fieldset>



                <asp:GridView ID="grd_Historial" CssClass="Grid" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataKeyNames="Fecha" AllowPaging="True" 
                    onpageindexchanging="grd_Historial_PageIndexChanging" > 
                    <HeaderStyle Height="18px" />
                    <pagerstyle backcolor="ControlLight"/>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Ver" runat="server" CausesValidation="False" 
                                CommandName="View" ImageUrl="~/imagenes/view.png"  Onclick="Ver_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" ReadOnly="true" SortExpression="Fecha"/>
                        <asp:BoundField HeaderText="Expediente" DataField="n_expediente" ReadOnly="true" SortExpression="Expediente"/>
                        <asp:BoundField HeaderText="Doctor" DataField="username" ReadOnly="true" SortExpression="Usuario"/>
                        <asp:BoundField HeaderText="Razón" DataField="historial" ReadOnly="true" Visible="true" SortExpression="historial" />
                    </Columns>
                    <RowStyle Height="20px" />
                    <SelectedRowStyle ForeColor="Red" />
                </asp:GridView>
                <br />
            </fieldset>
        </div>

    </div>
</div>
</asp:Content>

