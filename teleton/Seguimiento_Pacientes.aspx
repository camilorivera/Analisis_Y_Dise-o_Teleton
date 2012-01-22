<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Seguimiento_Pacientes.aspx.cs" Inherits="Seguimiento_Pacientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openPopUp() {
            var popUrl = 'Seguimiento_Paciente_Quicksearch.aspx';
            var name = 'popUp';
            var appearence = 'dependent=yes,menubar=no,resizable=yes,' +
                                          'status=yes,toolbar=no,titlebar=no,' +
                                          'left=5,width=1000px,height=600px';
            var openWindow = window.open(popUrl, name, appearence);
            openWindow.focus();
        }
    </script>
  
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <ContentTemplate>
            <div id="content3">
                <div id = "titulo">
                    <h1>
                        Seguimiento de Pacientes</h1>
                    <h2>
                        <span class="h3">Fecha de Hoy:</span>
                        <asp:Label ID="LBLDATE" CssClass="h3" runat="server"></asp:Label>
                    </h2>
                </div>
                <div id="navcenter">
                    <fieldset id="Seguimiento">
                        <legend>Ingreso de Pacientes</legend>
                        <ul class = "list">
                            <li class = "field">
                                <asp:Label ID="LblNumExp" CssClass="labelD" runat="server" Text="Nº de Expediente:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                <asp:TextBox ID="txtnumexp" runat="server" CssClass="txtbx_labelD" 
                                    Height="20px" Width="150px"></asp:TextBox>                               
                                <asp:FilteredTextBoxExtender ID="txtnumexp_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtnumexp">
                                </asp:FilteredTextBoxExtender>
                                <asp:ImageButton ID="busqueda" CssClass="botonbusquedarapida" ImageUrl="~/images/Search.png" 
                                        runat="server" CausesValidation="False" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LblPat3" CssClass="labelD" runat="server" 
                                    Text="Clasificacion de Paciente"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_ClasificacionPaciente" CssClass="cmbpatologias" 
                                    runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                            <li class = "field">                       
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtnumexp" ErrorMessage="**Debe Ingresar Nº Exp" 
                                        Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                <br />
                                <asp:Label ID="Label8" CssClass="labelD" runat="server" Text="Nombre Paciente: "></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtnombrepac" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Height="20px" Width="150px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="LblPat4" CssClass="labelD" runat="server" Text="Condicion:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_Condicion" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                </asp:DropDownList>
                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                            <li class = "field">                       
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                            <li class = "field">
                                <asp:Label ID="Label9" CssClass="labelD" runat="server" Text="Numero de Identidad: "></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtnumced" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Height="20px" Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LblPat5" CssClass="labelD" runat="server" Text="Referencias:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_Referencia" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                </asp:DropDownList>
                            </li>
                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp; </li>
                            <li class = "field">
                                <asp:Label ID="lbobser" CssClass="labelD" runat="server" Text="Observacion:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtobser" runat="server" CssClass="txtbx_labelD" Height="20px" 
                                    Width="150px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LblPat" CssClass="labelD" runat="server" Text="Diagnostico:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_patologias" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                </asp:DropDownList>
                            </li>
                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </li>
                            <li class = "field">
                                <asp:Label ID="LblPat0" CssClass="labelD" runat="server" Text="Sexo:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_Sexo" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                    <asp:ListItem>Masculino</asp:ListItem>
                                    <asp:ListItem>Femenino</asp:ListItem>
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label13" CssClass="labelD" runat="server" Text="Tipo de Daño: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_TipoDaño" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                </asp:DropDownList>
                            </li>
                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            </li>
                            <li class = "field">
                                <asp:Label ID="LblPat2" CssClass="labelD" runat="server" Text="Procedencia"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_Procedencia" CssClass="cmbpatologias" runat="server" 
                                    Height="20px" Width="150px">
                                    <asp:ListItem>Rural</asp:ListItem>
                                    <asp:ListItem>Urbano</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="LblPat6" CssClass="labelD" runat="server" 
                                    Text="Funcion y Estructura:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="txtFuncionEstructura" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Height="20px" Width="150px"></asp:TextBox>
                            </li>
                            <li class = "field">&nbsp;</li>
                            <li class = "field">
                                <asp:Label ID="Label11" CssClass="labelD" runat="server" 
                                    Text="Grado de Instruccion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_GradoDeInstruccion" CssClass="cmbpatologias" 
                                    runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LblPat15" CssClass="labelD" runat="server" Text="Ayudas Tecnicas Indicadas:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="cmb_AyudaTecnicaIndicada" CssClass="cmbpatologias" 
                                    runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                                </li>
                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                            <li class = "field">
                                <asp:Label ID="LblPat1" CssClass="labelD" runat="server" 
                                    Text="Ocupacion Actual:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:DropDownList ID="cmb_OcupacionActual" 
                                    runat="server" Height="20px" Width="150px">
                                </asp:DropDownList>
                            </li>
                            <li class = "field">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </li>
                            <li class = "field">
                                <asp:Label ID="LblPat7" CssClass="labelD" runat="server" 
                                    Text="Tiempo de Discapacidad:"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <ul class = "list">
                                    <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LblPat8" CssClass="labelD" runat="server" Text="Años:"></asp:Label>
                                &nbsp;
                                        <asp:TextBox ID="txt_TDAnios" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LblPat9" CssClass="labelD" runat="server" Text="Meses:"></asp:Label>
&nbsp;
                                        <asp:TextBox ID="txt_TDMeses" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="LblPat10" CssClass="labelD" runat="server" Text="Dias:"></asp:Label>
&nbsp;&nbsp;
                                        <asp:TextBox ID="txt_TDDias" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
                                    </li>
                                        <ul class = "list">
                                            <li class = "field">&nbsp;&nbsp;&nbsp; </li>
                                            <li class = "field">&nbsp;<asp:Label ID="LblPat11" CssClass="labelD" runat="server" 
                                                            Text="T.S.T.D.L."></asp:Label>
                                            </li>
                                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="LblPat12" CssClass="labelD" runat="server" Text="Años:"></asp:Label>
                                &nbsp;
                                                        <asp:TextBox ID="txt_TSAnios" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="LblPat13" CssClass="labelD" runat="server" Text="Meses:"></asp:Label>
&nbsp;
                                                <asp:TextBox ID="txt_TSMeses" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="LblPat14" CssClass="labelD" runat="server" Text="Dias:"></asp:Label>
&nbsp;&nbsp;
                                                <asp:TextBox ID="txt_TSDias" runat="server" 
                                    CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="80px" Height="20px"></asp:TextBox>
                                            </li>
                                            <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp; </li>
                                            <li class = "field">
                                                <asp:Label ID="Label12" CssClass="labelD" runat="server" Text="Etiologia: "></asp:Label>
                                                <ul class = "list">
                                                    <li class = "field">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtEteologia" runat="server" CssClass="txtbx_labelD" Height="150px" 
                                            TextMode="MultiLine" Width="335px"></asp:TextBox>
                                                    </li>
                                                </ul>
                                            </li>
                                        </ul>
                                    <li class = "field">&nbsp;&nbsp;
                                        </li>
                                </ul>
                            </li>
                            <li class = "field">
                                <asp:Button ID="btnguardarseguimiento" CssClass="boton" runat="server" 
                                        Text="Guardar" onclick="btnguardarseguimiento_Click" />
                                <asp:ConfirmButtonExtender ID="GuardarConfirmation" runat="server" TargetControlID="btnguardarseguimiento"
                                        ConfirmText="Esta Seguro Que Desea Guardar la Informacion?" >
                                </asp:ConfirmButtonExtender>
                            </li>
                        </ul>
                    </fieldset>                    
                    <fieldset id="RegistroDiario">
                        <legend>Listado de Pacientes</legend>
                        <asp:Label ID="lbldateinit" CssClass="labelD" runat="server" 
             Text="Fecha Inicial:"></asp:Label>
                        <asp:TextBox ID="txtdateinit" runat="server" CssClass="txtbx_labelD"></asp:TextBox>
                        <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" 
                            TargetControlID="txtdateinit" Format="m/dd/yyyy" 
             PopupButtonID="imgdateinit">
                        </asp:CalendarExtender>
                        <img alt="Icon" src="images/calendar_icon.jpg" class="calendar" 
             id="imgdateinit" />
                        <asp:Label ID="lbldatefini" CssClass="labelD" runat="server" 
             Text="Fecha Final:"></asp:Label>
                        <asp:TextBox ID="txtdatefini" runat="server" 
             CssClass="txtbx_labelD"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        TargetControlID="txtdatefini" 
             Format="m/dd/yyyy" PopupButtonID="imgdatefini">
                        </asp:CalendarExtender>
                        <img alt="Icon" src="images/calendar_icon.jpg" 
             class="calendar" id="imgdatefini" />
                        <asp:ImageButton ID="Refrescar" 
             CssClass="botonbusquedarapida" ImageUrl="~/images/Refresh-32.png" 
             runat="server" CausesValidation="False" onclick="Refrescar_Click1"  />
                        <asp:Label ID="Label1" runat="server" 
             Text="**Fecha Inicial Mayor que la Fecha Final" Visible="False" 
             ForeColor="Red"></asp:Label>
                        <div id="separar">
                        <asp:Panel ID="Panel1" CssClass="panelRolesSeg" runat="server" ScrollBars="Auto">
                           <asp:GridView ID="GridViewSegPac" CssClass="Grid" 
                                emptydatatext="----No Hay Pacientes Registrados el Dia de Hoy.----" runat="server" 
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="True" 
                                PageSize="50" onpageindexchanging="GridViewSegPac_PageIndexChanging1">      
                                
                                <pagersettings mode="Numeric"
                                    position="Bottom" 
                                    Visible="True"
                                               
                                    />      
                                
                                <pagerstyle backcolor="ControlLight"/>
                                <Columns>   
                                    <asp:TemplateField HeaderText="Fecha" SortExpression="fecha" FooterStyle-HorizontalAlign="NotSet">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha", "{0:M-dd-yyyy}") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("fecha", "{0:M-dd-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expediente" SortExpression="expediente">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("expediente") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("expediente") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre" SortExpression="nombres">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("NOMBRE")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("NOMBRE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("primer_apellido")%>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("primer_apellido")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Patologia" SortExpression="diagnostico1">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("diagnostico1") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("diagnostico1") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Evaluador" SortExpression="evaluador">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("nombres") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("nombres") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observacion" SortExpression="observacion">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("notas") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("notas") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            </asp:Panel>
                            
                        </div>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </div>    
 </asp:Content>

