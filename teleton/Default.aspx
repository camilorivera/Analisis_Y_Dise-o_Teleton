<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="content">
        <div id = "titulo">
            <h1 style="text-align:center">Proyecto Teleton 2011</h1>
        </div>
        <div id = "navcontroles">
            <div id = "about">
            <div class = "parrafo">
                Curso de Análisis y Diseño de Sistemas que inicia en el periodo 1 del 2011 con Análisis y Diseño de Sistemas I, luego en el periodo 2 se sigue con Analisis y Diseño de Sistemas II y concluyendo con Ingenieria de Software en el periodo 4 del año (2011).
            </div>
            <div class = "parrafo">
                Durante el año 2011 se estuvo desarrollando un sistema para Teleton, como parte del proceso de Vinculación y Aporte a la sociedad por parte de UNITEC. Actualmente dicho proyecto sigue en proceso de desarrollo.
            </div>  
            <div class = "parrafo">
                    <asp:Image ID="Image1" runat="server" Height="240px" ImageUrl="~/images/teletonLogoSolid2.png" 
                        Width="180px" /> 
            </div>          
        </div>
    </div>
</asp:Content>

