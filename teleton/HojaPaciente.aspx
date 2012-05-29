<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="HojaPaciente.aspx.cs" Inherits="HojaPaciente" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
    <head>
        <title></title>
        <link href="Styles/Reporte.css" rel="stylesheet" type="text/css" media="all"/>
        <link rel="stylesheet" type="text/css" href="hoja_paciente/reset.css" media="all" />
		<link rel="stylesheet" type="text/css" href="hoja_paciente/text.css" media="all" />
		<link rel="stylesheet" type="text/css" href="hoja_paciente/960.css" media="all" />
		<link rel="stylesheet" type="text/css" href="hoja_paciente/layout.css" media="all" />
		<link rel="stylesheet" type="text/css" href="hoja_paciente/nav.css" media="all" />



        
        
    <style type="text/css" media="all">
        .style4
        {
            background-repeat: no-repeat;
           /* background-image: url('/teleton/images/fondoHoja.png');*/
            background-position: left top;
        }
        </style>
    </head>
    <body>
        <form id="form1" runat="server" class="style4">
    
        <div class="container_12">
        <div class="clear"></div>
        <div class="grid_12">
				<h1 id="branding">
					<asp:Image ID="Imagen0" runat="server" Width="51px" Height="63px" 
                        ImageUrl="~/images/teletonLogoSolid_3.png" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Fundación Teleton 
                    Honduras</h1>
			</div>
			<div class="box grid_12" style="padding:0;">
				<h2 style="margin:6">
					Datos Generales
				</h2>
			</div>
			<div class="clear"></div>
			<div id="grid">

				
				<div class="grid_3">
					<div class="box">
						<p><asp:Image ID="Imagen" runat="server" Width="33px" />
                            </p>
					</div>
				</div>
                <div class="grid_3">
					<div class="box">
						<p>Número de Expediente:<br>     
                            <asp:Label ID="expediente" runat="server" Font-Bold="True" Font-Size=Medium></asp:Label>
                        </p>
					</div>
				</div>
                <div class="grid_3">
					<div class="box">
						<p>Número de Identidad: <br>
                        
                            <asp:Label ID="cedula" runat="server" Font-Bold="True" Font-Size=Medium></asp:Label>
                        
                        </p>
					</div>
				</div>
                <div class="grid_3">
					<div class="box">
						<p>Fecha de Ingreso:<br><asp:Label ID="fechaIngreso" runat="server" Font-Bold="True" Font-Size=Medium></asp:Label>
                        </p>
					</div>
				</div>
                <div class="grid_7">
					<div class="box">
						<p>Nombre del Paciente: &nbsp;&nbsp; <asp:Label ID="nombre" runat="server" Font-Bold="True" Font-Size=Large></asp:Label>
                         </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Género:     
                            <asp:Label ID="sexo" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>
                        </p>
					</div>
				</div>
                <div class="grid_7">
					<div class="box">
						<p>Dirección:    
                            <asp:Label ID="direccion" runat="server" Font-Bold="True" Font-Size=Medium></asp:Label>
                        </p>
					</div>
				</div>
                <br>
                <div class="grid_2">
					<div class="box">
						<p>Estado Civil:    
                            <asp:Label ID="estado" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>
                            &nbsp;</p>
					</div>
				</div>
                <div class="clear"></div>
                <div class="grid_2">
					<div class="box">
						<p>Lugar de Nacimiento: <br>     
                            <asp:Label ID="lugarNac" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>
                        </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Fecha de Nacimiento:   <br> 
                            <asp:Label ID="fechaNac" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>
                        </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Telefono: <br>
                            <asp:Label ID="telefono" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Celular: <br>
                            <asp:Label ID="celular" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Escolaridad: <br>
                            <asp:Label ID="escolaridad" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_2">
					<div class="box">
						<p>Profesion: <br>
                            <asp:Label ID="profesion" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                            <br>
                            
                        </p>
					</div>
				</div>

                <div class="box grid_12" style="padding:0;">
				<h2 style="margin:8">
					Datos Familiares</h2>
			</div>
				<div class="clear"></div>
                <div class="grid_4">
					<div class="box">
						<p>Nombre Madre: <br>
                            <asp:Label ID="nombreMadre" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
						<p>Nombre Padre: <br>
                            <asp:Label ID="padre" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
						<p>Nombre Conyugue: <br>
                            <asp:Label ID="conyugue" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
						<p>Estructura Familiar: <br>
                            <asp:Label ID="estructuraFamiliar" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
						<p>Lugar de Trabajo: <br>
                            <asp:Label ID="lugarTrabajo" runat="server" Font-Bold="True" Font-Size=Small></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
						<p>&nbsp;</p><br>
					</div>
				</div>
                <div class="box grid_12" style="padding:0;">
				<h2 style="margin:8">
					Datos mÉDICOS</h2>
			</div>
            <div class="clear"></div>
            
				
				<div class="grid_6">
					<div class="box">
						<p>¿Ha recibido rehabilitacion antes?: 
                            <asp:Label ID="recibidoAntes" runat="server"></asp:Label>   
                        </p>
					</div>
				</div>
				<div class="grid_6">
					<div class="box">
						<p>Diagnostico: 
                            <asp:Label ID="diagnostico" runat="server"></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="grid_7">
					<div class="box">
						<p>Observaciones: 
                            <asp:Label ID="observaciones" runat="server"></asp:Label>   
                        </p>
					</div>
				</div>
                <div class="clear"></div>
                <div class="clear"></div>
                 <div class="clear"></div>
                  <div class="clear"></div>
                <div class="grid_4">
					<div class="box">
                    <p>__________________________</p>
						<p>FIRMA1</p>
					</div>
				</div>
                <div class="grid_4">
					<div class="box">
                    <p>____________________________</p>
						<p>FIRMA2</p>
					</div>
				</div>
                 <div class="clear"></div>
				
				<div class="clear"></div>
			</div>
			<div class="grid_12" id="site_info">
				<div class="box">
					<p>Centro de Rehabilitación Integral</p>
				</div>
			</div>
			<div class="clear"></div>
		</div>

        </form>

        </body>
   </html>

