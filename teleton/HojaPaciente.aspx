<%@ Page Title="" Language="C#" MasterPageFile="~/Reportes.master" AutoEventWireup="true" CodeFile="HojaPaciente.aspx.cs" Inherits="HojaPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Reporte.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
        .style2
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <div id="content">

       <div id="navcenter">
            <table class="table_Paciente">
                <tbody>
                    <tr>
                        <td>           
                            <center>           
                            <asp:Image ID="Imagen" runat="server" />
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="table_Title">
                            <h1><strong class="style2">Información General</strong></h1> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                    <table>
                    <tr class="rowodd">
                        <td colspan="2" class="table_Subtitle">                    
                            <h2>Datos Generales</h2>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nº de Expediente:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="expediente" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
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
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Dirección:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="direccion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
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
                    <tr class="rowodd">
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
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Fecha de Ingreso:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="fechaIngreso" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Telefono:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="telefono" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Celular:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="celular" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Escolaridad:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="escolaridad" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Profesion:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="profesion" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Lugar de Trabajo:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="lugarTrabajo" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td colspan="2" class="table_Subtitle">                    
                            <h2>Datos Familiares</h2>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nombre Madre:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="nombreMadre" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nombre Padre:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="padre" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Nombre Conyugue:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="conyugue" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Estructura Familiar:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="estructuraFamiliar" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td colspan="2" class="table_Subtitle">                    
                            <h2>Datos Medicos</h2>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >¿Ha recibido rehabilitacion antes?:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="recibidoAntes" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Observaciones:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="observaciones" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="table_Paciente_Desc" >Diagnostico:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="diagnostico" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                </tbody>
                <tfoot>
                </tfoot>
            </table>                         
                    <!--<div id="navBotones">
                        <asp:Button runat="server" Visible="true" Text="Cerrar" OnClientClick="window.close()" CssClass="boton" />
                    </div>-->
        </div>
  
   </div>
</asp:Content>

