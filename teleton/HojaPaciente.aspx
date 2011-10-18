<%@ Page Title="" Language="C#" MasterPageFile="~/Reportes.master" AutoEventWireup="true" CodeFile="HojaPaciente.aspx.cs" Inherits="HojaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Reporte.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="content">

        <div id="navcenter">
            <table class="table_Paciente">
                <thead>
                    <tr> 
                        <td colspan="2" class="table_Title">
                        <h1>Información General</h1> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="table_Subtitle">
                    
                            <h2>Datos Personales</h2>
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nº de Expediente:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="expediente" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr class="row">
                        <td class="table_Paciente_Desc" >Nº de Identidad:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="cedula" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nombre del Paciente:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="nombre" runat="server"></asp:Label>
                         </td>
                    </tr> 
                    <tr class="row">
                        <td class="table_Paciente_Desc" >Sexo:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="sexo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Estado Civil:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="estado" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="row">
                        <td class="table_Paciente_Desc" >Lugar de Nacimiento:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="lugarNac" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Fecha de Nacimiento:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="fechaNac" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="row">
                        <td class="table_Paciente_Desc" >Dirección:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="direccion" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Fecha de Ingreso:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="fechaIngreso" runat="server"></asp:Label>
                        </td>
                    </tr>
                </tbody>
                <tfoot>
                </tfoot>
            </table>
                         
                    <div id="navBotones">
                        <asp:Button runat="server" Visible="true" Text="Cerrar" OnClientClick="window.close()" CssClass="boton" />
                    </div>   
        </div>
   </div>
</asp:Content>

