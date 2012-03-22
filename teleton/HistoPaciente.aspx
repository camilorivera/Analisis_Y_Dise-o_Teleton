<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistoPaciente.aspx.cs" Inherits="HistoPaciente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script runat="server">
    
</script>
<div id = "content">
    <div id="navcenter">
        <div id="titulo">
            <h1>
                Historial Médico
            </h1>
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
                        <asp:DropDownList ID="ddl_centro" runat="server" Height="25px" Width="164px">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_Buscar"  CssClass="boton" runat="server" Text="Buscar" 
                            onclick="Button1_Click" />
                    </li>
                </ul>
            </fieldset>
        </div>
      
        <div>
         <br />
               <fieldset>
               <asp:GridView ID="GridViewAreas"  runat="server" 
                    emptydatatext="----No Hay Pacientes Registrados el Dia de Hoy.----" AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="GridViewAreas_PageIndexChanging" HorizontalAlign="Left" 
                       Width="115px" PageSize="15" ForeColor="Black"> 

                    <HeaderStyle Height="18px" BackColor="Black" ForeColor="White" />

                    <pagerstyle backcolor="ControlLight"/>

                    <Columns>
                        <asp:TemplateField HeaderText="Area">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Label1" runat="server" Text='<%# Eval("area1")!=null ? "<a style=\"color:black;\" href=\"HistoPacienteFrame.aspx?id=" + ((string)Eval("area1")).Substring(0, ((string)Eval("area1")).IndexOf(" ")) + "\" target=\"hitopaciente_frame\">" + ((string)Eval("area1")).Substring(((string)Eval("area1")).IndexOf(" ")+1, ((string)Eval("area1")).Length - ((string)Eval("area1")).IndexOf(" ")-1) + "</a>" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                        </asp:TemplateField>
       
                    </Columns>
                    <RowStyle Height="20px" />
                    <SelectedRowStyle ForeColor="Black" />
                </asp:GridView>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <iframe src="HistoPacienteFrame.aspx" width="600" height="570" frameborder="0" name="hitopaciente_frame"></iframe>
             &nbsp;&nbsp;&nbsp;
             </fieldset>
        </div>

    </div>
</div>
</asp:Content>

