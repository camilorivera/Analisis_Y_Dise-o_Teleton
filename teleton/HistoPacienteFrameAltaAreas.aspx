<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoPacienteFrameAltaAreas.aspx.cs" Inherits="HistoPacienteFrameAltaAreas"  EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .boton
        {
            height: 26px;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
   <div id = "content">
       <div id="navcenter">
        <div id="titulo">
        </div>
 
    <div class="cajas"> 
      
                <fieldset>
                <ul class="list" >
                   <div>
                        <asp:Label ID="lb_area0" runat="server" Font-Bold="True" ForeColor="Black" 
                            Text="Area :" Visible="False" style="font-size: large"></asp:Label>
                        <asp:Label ID="lb_area" runat="server" Font-Bold="True" ForeColor="Red" 
                            Text="[lb_Area]" Visible="False" style="font-size: large"></asp:Label>
                        <br />
                        <asp:Label ID="lb_Paciente" runat="server" Font-Bold="True" ForeColor="Black"  ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_Expe" runat="server" 
                            Font-Bold="True" ForeColor="Black"></asp:Label>
                        &nbsp;&nbsp;<br />
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server" Enabled="False" 
                            Text="Alta médica" />
                        <br />
                        <br />
                        <asp:TextBox ID="txt_historial" runat="server" Height="83px" 
                            TextMode="MultiLine" Width="96%" BorderStyle="Outset"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btn_guardar"  CssClass="boton" runat="server" Text="Guardar" 
                            onclick="btn_guardar_Click" BackColor="#CC0000" 
                            BorderColor="Black" ForeColor="White" Visible="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lb_mensaje" runat="server"  Font-Bold="true" ForeColor="Red" Enabled="False"></asp:Label>
                    </div>
                </ul>            
       </fieldset>
   
        <br />
        <div>
   

            <fieldset>

                <asp:GridView ID="grd_Historial" CssClass="Grid" runat="server" Width="100%" 
                    AutoGenerateColumns="False" DataKeyNames="Fecha" AllowPaging="True" 
                    onpageindexchanging="grd_Historial_PageIndexChanging" 
                    onrowdatabound="grd_Historial_RowDataBound" > 
                    <HeaderStyle Height="18px" BackColor="Black" ForeColor="White" />
                    <pagerstyle backcolor="ControlLight"/>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Ver" runat="server" CausesValidation="False" 
                                CommandName="View" ImageUrl="~/imagenes/view.png" OnClick="Ver_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Fecha"  DataField="Fecha" ReadOnly="true" SortExpression="Fecha" />
                        <asp:BoundField HeaderText="Expediente" DataField="n_expediente" ReadOnly="true" SortExpression="Expediente"><ItemStyle HorizontalAlign="Center"/></asp:BoundField>
                        <asp:BoundField HeaderText="Doctor" DataField="username" ReadOnly="true" SortExpression="Usuario"><ItemStyle HorizontalAlign="Left"/></asp:BoundField>
                        <asp:BoundField HeaderText="Razón" DataField="historial" ReadOnly="true" Visible="true" SortExpression="historial" />
                        <asp:BoundField HeaderText="Alta" DataField="alta" ReadOnly="true" Visible="true" SortExpression="alta"><ItemStyle HorizontalAlign="Center"/></asp:BoundField>
                        
                    </Columns>
                    <RowStyle Height="20px" />
                    <SelectedRowStyle ForeColor="Red" />
                </asp:GridView>
                <br />
         </fieldset>
        </div>

    </div>
     </div>
     </form>
</body>
</html>

