<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Diagnosticos.aspx.cs" Inherits="Diagnosticos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 401px;
        }
        .style2
        {
            width: 226px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
<div id = "content">
    <div id="titulo">
        <h1>Mantenimiento de Patologías</h1>
    </div> 
    <div id = "navcenter">
        <fieldset>
                  

            <table style="width: 60%;" align="center">
                <tr>
                    <td class="style2">
                  

            <asp:Label ID="Label2" CssClass="labelD" runat="server" Text=" Patología: "></asp:Label>
                    </td>
                    <td class="style1">
            <asp:TextBox ID="diagnostico_txt" CssClass="txtbx_Diagnostico" runat="server" Width="169px"></asp:TextBox>

           

                    </td>
                    <td rowspan="2">
     <asp:Button ID="Button1" CssClass= "boton" runat="server" Text="Guardar" 
                onclick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                  

            <asp:Label ID="Label3" CssClass="labelD" runat="server" Text="Código Internacional:"></asp:Label>
                    </td>
                    <td class="style1">
            <asp:TextBox ID="cod" CssClass="txtbx_Diagnostico" runat="server" Height="16px" 
                            Width="170px"></asp:TextBox>

           

                    </td>
                </tr>
            </table>
            <br />
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="diagnostico_txt" ErrorMessage="**Ingrese la patología" 
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:GridView ID="GridView1" CssClass="Grid" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="EntityDataSource1" 
                 AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                onrowdatabound="GridView1_RowDataBound" PageSize="20" AllowSorting="True"> <pagerstyle backcolor="ControlLight"/>
                <Columns>                   
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:ImageButton ID="Refresh" runat="server" CausesValidation="False" 
                                CommandName="Update" ImageUrl="~/images/update.png" Text="" />
                            <asp:ImageButton ID="Cancel" runat="server" CausesValidation="False" 
                                CommandName="Cancel" ImageUrl="~/images/cancel_2.png" Text="Cancelar" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="Edit" runat="server" CausesValidation="False" 
                                CommandName="Edit" ImageUrl="~/images/edit.jpg" Text="" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="Delete" runat="server" CausesValidation="False" 
                                CommandName="Delete" ImageUrl="~/images/Red-Delete.png" Text="" />
                            
                            <asp:ConfirmButtonExtender ID="WinError" 
                            runat="server" TargetControlID="Delete"
                            ConfirmText="Esta seguro que desea eliminar el registro" ></asp:ConfirmButtonExtender>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                     
                    <asp:BoundField DataField="id" HeaderText="Id" ReadOnly="True" 
                        SortExpression="id" >
                    <HeaderStyle HorizontalAlign="Center"  Width="20px" />
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="diagnostico1" HeaderText="Nom. Patologia" 
                        SortExpression="diagnostico1" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigoInter" HeaderText="Código Internacional" 
                        SortExpression="codigoInter" >
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
           

            <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                ConnectionString="name=teletonEntities" DefaultContainerName="teletonEntities" 
                EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
                EnableUpdate="True" EntitySetName="diagnosticos">
            </asp:EntityDataSource>

         </fieldset>
    </div>

</div>
</asp:Content>

