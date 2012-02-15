<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="HojaPaciente.aspx.cs" Inherits="HojaPaciente" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head>
        <title></title>
        <link href="Styles/Reporte.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            font-size: x-large;
        }
        .style3
        {
            /*font-size: x-small;*/
            width: 20%;
        }
        .style4
        {
            background-repeat: no-repeat;
            background-image: url('/teleton/images/fondoHoja.png');
            background-position: left top;
        }
    </style>
    </head>
    <body>
        <form id="form1" runat="server" class="style4">
    <div id="content" >       
        <center>
        <div> <!--id="navcenter">-->
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
                        <center>
                    <table>
                    <tr class="rowodd">
                        <td colspan="2" class="table_Subtitle">                    
                            <h2>Datos Generales</h2>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Nº de Expediente:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="expediente" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Nº de Identidad:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="cedula" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr class="rowodd">
                        <td class="style3" >Nombre del Paciente:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="nombre" runat="server"></asp:Label>
                         </td>
                    </tr>                     
                    <tr class="rowodd">
                        <td class="style3" >Dirección:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="direccion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Sexo:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="sexo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Estado Civil:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="estado" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Lugar de Nacimiento:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="lugarNac" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Fecha de Nacimiento:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="fechaNac" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Fecha de Ingreso:</td>
                        <td class="tb_crearRol">    
                            <asp:Label ID="fechaIngreso" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Telefono:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="telefono" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Celular:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="celular" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Escolaridad:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="escolaridad" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Profesion:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="profesion" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Lugar de Trabajo:</td>
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
                        <td class="style3" >Nombre Madre:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="nombreMadre" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Nombre Padre:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="padre" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Nombre Conyugue:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="conyugue" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Estructura Familiar:</td>
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
                        <td class="style3">¿Ha recibido rehabilitacion antes?:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="recibidoAntes" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Observaciones:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="observaciones" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    <tr class="rowodd">
                        <td class="style3" >Diagnostico:</td>
                        <td class="tb_crearRol"> 
                            <asp:Label ID="diagnostico" runat="server"></asp:Label>   
                        </td>
                    </tr>
                    </table>
                    </center>
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
  
   </center>
   </div>
        </form>
   </body>
   </html>

