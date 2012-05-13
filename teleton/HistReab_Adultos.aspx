<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistReab_Adultos.aspx.cs" 
Inherits="HistReab_Adultos" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/Login.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
   
   <!-- TinyMCE -->

    <script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
     <script type="text/javascript">
         tinyMCE.init({
             // General options
             mode: "textareas",
             theme: "advanced",
             plugins: "autolink,lists,spellchecker,pagebreak,style,layer,advhr,advimage,iespell,insertdatetime,searchreplace,contextmenu,paste",

             // Theme options
             theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,formatselect,fontselect,fontsizeselect,search,replace,|,bullist,numlist,|,outdent,indent,|,insertdate,inserttime,|,forecolor,backcolor",
             theme_advanced_buttons2: "",
             theme_advanced_buttons3: "",
             theme_advanced_toolbar_location: "top",
             theme_advanced_toolbar_align: "left",
             theme_advanced_resizing: false,
             width: "100%",
             height: "200"
         });
    </script>

    <!-- /TinyMCE -->

    <div id="content">
        <div id="navcenter">
            <div id="titulo">
                <h1>
                    Historia Clinica De Rehabilitación Adultos
                    <br />
                    <br />
                </h1>
            </div>
            <div>
                <fieldset>
                    <ul class="list">
                        <li class="list">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lb_Expediente" runat="server" Text="Expediente:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Expediente" runat="server" Font-Size="Medium"  
                                Width="136px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lb_Edad" runat="server" Text="Edad:" Visible="false" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Edad" runat="server" Font-Size="Medium" height="22px" 
                                width="235px" BorderStyle="None" Visible="false" Enabled="False"></asp:TextBox>
                            <br />
                            <asp:Panel  ID="asp_Panel" runat="server" Visible="false">
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:Label  ID="lb_Nombre" runat="server" Text="Nombre:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox runat="server" ID="txt_Nombre" Font-Size="Medium" Width="360px" 
                                BorderStyle="None" Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Sexo" runat="server" Text="Sexo:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Sexo" runat="server" Text="" Font-Size="Medium" 
                                BorderStyle="None" Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:Label ID="lb_Historiador" runat="server" Text="Historiador(a):" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Historiador" runat="server" Font-Size="Medium" BorderStyle="None"
                                height="22px" width="235px" Enabled="False" style="font-size: small"></asp:TextBox>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Informante" runat="server" Text="Informante:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Informante" runat="server" 
                                Font-Size="Medium" height="22px" width="420px" Enabled="False"></asp:TextBox>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Remitente" runat="server" Text="Remitente:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txt_Remitente" runat="server" Font-Size="Medium" Width="235px" 
                                Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="lb_Lateralidad" runat="server" Text="Lateralidad:" Font-Size="Medium"></asp:Label>
                            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="dls_Lateralidad" runat="server" 
                                Height="22px" Width="235px" Enabled="false">
                            </asp:DropDownList>
                            </asp:Panel>
                        </li>
                        <li class="list">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btn_Aceptar" runat="server" CssClass="boton" Text="Buscar" 
                                onclick="btn_Aceptar_Click" />
                            <asp:Button ID="btn_Nuevo" runat="server" CssClass="boton" Text="Nuevo" Enabled="false" Visible="false"
                                OnClick="btn_Nuevo_Click" />
                            <asp:Button ID="btn_Guardar" runat="server" CssClass="boton" Text="Guardar"
                                OnClick="btn_Guardar_Click" Enabled="false" Visible="false"/>
                        </li>
                    </ul>
                </fieldset>
            </div>
            <div>
                 <ul>
                        <li class="list">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lb_Mensaje" runat="server" Font-Size="Medium" ForeColor="Red" ></asp:Label>
                            <br />
                            <textarea id="elm1" name="elm1" rows="15" cols="80" style="width: 100%" 
                                runat="server" enableviewstate="True" visible="False"></textarea>
                        </li>
                 </ul>
                 <ul>
                    <li class="list">
                        <br />
                            <asp:GridView ID="grd_Historial" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="Fecha" AllowPaging="True" 
                            onpageindexchanging="grd_Historial_PageIndexChanging" > 
                            <HeaderStyle Height="18px" />
                            <pagerstyle backcolor="ControlLight"/>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imb_Ver" runat="server" CausesValidation="false" CommandName="View" 
                                        ImageUrl="~/imagenes/view.png" OnClick="Ver_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" ReadOnly="false" SortExpression="Nombre" />
                                <asp:BoundField HeaderText="Edad" DataField="Edad" ReadOnly="false" SortExpression="Edad" />
                                <asp:BoundField HeaderText="Informante" DataField="Informante" ReadOnly="false" SortExpression="Informante" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" ReadOnly="false" SortExpression="Fecha" />
                                <asp:BoundField HeaderText="FNacimiento" DataField="FNacimiento" ReadOnly="false" SortExpression="FNacimiento" />
                            </Columns>
                            <RowStyle Height="20px" />
                            <SelectedRowStyle ForeColor="Red" />
                        </asp:GridView>
                    </li>
                 </ul>
            </div>
        </div>
    </div>

                    

</asp:Content>

