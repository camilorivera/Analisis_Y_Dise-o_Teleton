<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Exportar_Seguimiento.aspx.cs" Inherits="Exportar_Seguimiento" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <div id="content3">
            <div id = "titulo">
                <h1>Exportar Seguimiento</h1>
            </div>
        </div>

        <div id="navcenter">
            <fieldset id="Seguimiento">
                <legend>Seguimiento de Pacientes</legend>
                <ul class="list">
                    <li class="field">
                        <div class="fieldIzquierdo">
                            <asp:Label runat="server" ID="lblFechaInicio">Fecha Inicio:</asp:Label>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ErrorMessage="Fecha inicial mayor que la final" 
                                ControlToCompare="txtFechaFinal" ControlToValidate="txtFechaInicio" 
                                ForeColor="Red" Operator="LessThanEqual" Type="Date" 
                                ValidationGroup="TodoError">*</asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fecha inicial requerida."
                                ValidationGroup="TodoError" ControlToValidate="txtFechaInicio" 
                                ForeColor="Red">*
                            </asp:RequiredFieldValidator>
                            <asp:TextBox runat="server" ID="txtFechaInicio" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaInicio" runat="server" 
                                TargetControlID="txtFechaInicio" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaInicio">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" id="imgFechaInicio" />
                        </div>
                        
                        <div class="fieldDerecho">
                            <asp:Label runat="server" ID="lblFechaFinal">Fecha Final:</asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtFechaFinal" ErrorMessage="Fecha final requerida" 
                                ForeColor="Red" ValidationGroup="TodoError">*</asp:RequiredFieldValidator>
                            <asp:TextBox runat="server" ID="txtFechaFinal" CssClass="requerido"></asp:TextBox>
                            <asp:CalendarExtender ID="ceFechaFinal" runat="server" 
                                TargetControlID="txtFechaFinal" Format="dd/MM/yyyy"
                                PopupButtonID="imgFechaFinal">
                            </asp:CalendarExtender>
                            <img alt="icon" src="images/calendar_icon.jpg" class="calendar" id="imgFechaFinal" />
                        </div>
                    </li>

                    <li class="field">
                        <asp:ValidationSummary runat="server" ID="svErrores" 
                            HeaderText="Campos con conflictos:" ValidationGroup="TodoError" 
                            CssClass="failureNotification" DisplayMode="SingleParagraph" />
                    </li>

                    <li class="field">
                        <asp:Button runat="server" ID="btEjecutar" Text="Ejecutar" 
                            ValidationGroup="TodoError" CssClass="boton" onclick="btEjecutar_Click" />
                    </li>
                </ul>
            </fieldset>
        </div>
        

        <div>
            <fieldset>
                <legend>Resultados</legend>
                <ul class="list">
                    <li class="field">
                        <asp:Button runat="server" ID="btExportar" Text="Exportar a Excel" 
                            CssClass="boton" Visible="false" onclick="btExportar_Click"/>
                    </li>
                </ul>
                <asp:Panel runat="server" ID="gridPanel" ScrollBars="Auto" CssClass="panel">
                    <asp:GridView ID="gvSeguimientoPaciente" runat="server" CssClass="Grid" EmptyDataText="----Su busqueda no genero resultados intente con otra fecha.----"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true">
                    
                        <PagerSettings Mode="Numeric" Position="Bottom" Visible="true" />
                        <PagerStyle BackColor="ControlLight" />

                        <Columns>
                    
                            <asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:d}" />
                            <asp:BoundField HeaderText="Expediente" DataField="expediente" />
                            <asp:BoundField HeaderText="Clasificacion Paciente" DataField="clasificacion" />
                            <asp:BoundField HeaderText="Nombre Paciente" DataField="nombres" />
                            <asp:BoundField HeaderText="Condicion" DataField="condicion1" />
                            <asp:BoundField HeaderText="Identidad" DataField="cedula" />
                            <asp:BoundField HeaderText="Observacion" DataField="notas" />
                            <asp:BoundField HeaderText="Diagnostico" DataField="diagnostico1" />
                            <asp:BoundField HeaderText="Tipo De Daño" DataField="tipo" />
                            <asp:BoundField HeaderText="Procedencia" DataField="procedencia1" />
                            <asp:BoundField HeaderText="Funcion Y Estructura" DataField="funcion_estructura" />
                            <asp:BoundField HeaderText="Grado De Instruccion" DataField="Grado" />
                            <asp:BoundField HeaderText="Ayudas Tecnicas Ind." DataField="ayuda" />
                            <asp:BoundField HeaderText="Ocupacion Actual" DataField="ocupacion" />
                            <asp:BoundField HeaderText="Años Discapacidad" DataField="años_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Meses Discapacidad" DataField="meses_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Dias Discapacidad" DataField="dias_tiempo_discapacidad" />
                            <asp:BoundField HeaderText="Años T.S.T.D.L." DataField="años_TSTDL" />
                            <asp:BoundField HeaderText="Meses T.S.T.D.L." DataField="meses_TSTDL" />
                            <asp:BoundField HeaderText="Dias T.S.T.D.L." DataField="dias_TSTDL" />
                            <asp:BoundField HeaderText="Etiologia" DataField="eteologia" />

                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </fieldset>
        </div>
    </div>
</asp:Content>

