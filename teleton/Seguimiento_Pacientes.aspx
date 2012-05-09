<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Seguimiento_Pacientes.aspx.cs" Inherits="Seguimiento_Pacientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/reset.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/text.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/grid.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/layout.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/nav.css" rel="stylesheet" type="text/css" />
    <!--[if IE 6]><link rel="stylesheet" type="text/css" href="Styles/960/ie6.css" media="screen" /><![endif]-->
	<!--[if IE 7]><link rel="stylesheet" type="text/css" href="Styles/960/ie.css" media="screen" /><![endif]--> 
    <script type="text/javascript">
        function openPopUp() {
            var popUrl = 'Seguimiento_Paciente_Quicksearch.aspx';
            var name = 'popUp';
            var appearence = 'dependent=yes,menubar=no,resizable=yes,' +
                                          'status=yes,toolbar=no,titlebar=no,' +
                                          'left=5,width=900px,height=500px';
            var openWindow = window.open(popUrl, name, appearence);
            openWindow.focus();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <ContentTemplate>
            <div id="content3">
                <div id="navcenter">
                    <div id="head">
                        <h4 id="branding">Seguimiento de Pacientes</h4>
                        <h5>Fecha de hoy:<asp:Label ID="LBLDATE" CssClass="h3" runat="server"></asp:Label></h5>
                    </div>                    
                    <div class="clear"></div>
                    <fieldset id="IngresoPascientes">
                        <legend>Ingreso de Pacientes</legend>
                        <div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnumexp" ErrorMessage="**Necesario" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </div>
                        <div class="container_16">
			                <div class="grid_8">
				                <div class="block">
					                <p>
                                        <asp:Label ID="LblNumExp" CssClass="labelD" runat="server" Text="Nº de Expediente: " Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnumexp" TabIndex="1" runat="server" CssClass="txtbx_labelD" Width="45%"></asp:TextBox>
                                        <asp:ImageButton ID="busqueda" CssClass="botonbusquedarapida" ImageUrl="~/images/Search.png" runat="server" CausesValidation="False"  Width="5%" />
                                    </p>
					                <p>
                                        <asp:Label ID="Label8" CssClass="labelD" runat="server" Text="Nombre Paciente:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnombrepac" TabIndex="3" runat="server" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%"></asp:TextBox>
                                    </p>
					                <p>
                                        <asp:Label ID="Label9" CssClass="labelD" runat="server" Text="Número de Identidad: " Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnumced" runat="server" TabIndex="5" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%"></asp:TextBox>
                                    </p>
					                <p>
                                        <asp:Label ID="lbobser" CssClass="labelD" runat="server" Text="Observación:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtobser" TabIndex="7" runat="server" CssClass="txtbx_labelD" Width="50%"></asp:TextBox>
                                    </p>
					                <p>
                                        <asp:Label ID="LblPat0" CssClass="labelD" runat="server" Text="Sexo:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_Sexo" TabIndex="9" CssClass="cmbpatologias" runat="server" Width="50%">
                                            <asp:ListItem>Masculino</asp:ListItem>
							                <asp:ListItem>Femenino</asp:ListItem>
						                </asp:DropDownList>
                                    </p>
					                <p>
                                        <asp:Label ID="LblPat2" CssClass="labelD" runat="server" Text="Procedencia:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_Procedencia" TabIndex="11" CssClass="cmbpatologias" runat="server" Width="50%"> 
                                            <asp:ListItem>Rural</asp:ListItem>  
                                            <asp:ListItem>Urbano</asp:ListItem>
                                        </asp:DropDownList>
                                    </p>
					                <p>
                                        <asp:Label ID="Label11" CssClass="labelD" runat="server" Text="Grado de Instrucción:" Width="40%"></asp:Label>
                                        <asp:DropDownList TabIndex="13" ID="cmb_GradoDeInstruccion" CssClass="cmbpatologias" runat="server" Width="50%"></asp:DropDownList>
                                    </p>
					                <p>
                                        <asp:Label ID="LblPat1" CssClass="labelD" runat="server" Text="Ocupación Actual:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_OcupacionActual" TabIndex="15" runat="server" Width="50%"></asp:DropDownList>
                                    </p>
				                </div>	
			                </div>
			                <div class="grid_8">
				                <div class="block">
					                <p>
                                        <asp:Label ID="LblPat3" CssClass="labelD" runat="server" Text="Clasificación de Paciente:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_ClasificacionPaciente" TabIndex="2" CssClass="cmbpatologias" runat="server" Width="50%"></asp:DropDownList>
                                    </p>
					                <p>
                                        <asp:Label ID="LblPat4" CssClass="labelD" runat="server" Text="Condicion:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_Condicion" TabIndex="4" CssClass="cmbpatologias" runat="server" Width="50%"></asp:DropDownList>
                                    </p>
					                <p>
                                        <asp:Label ID="LblPat5" CssClass="labelD" runat="server" Text="Referencias:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_Referencia" TabIndex="6" CssClass="cmbpatologias" runat="server"  Width="50%"></asp:DropDownList>
                                    </p>
                                    <p>
                                        <asp:Label ID="LblPat" CssClass="labelD" runat="server" Text="Diagnostico:"  Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_patologias" TabIndex="8" CssClass="cmbpatologias" runat="server"  Width="50%"></asp:DropDownList>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label13" CssClass="labelD" runat="server" Text="Tipo de Daño:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_TipoDaño" TabIndex="10" CssClass="cmbpatologias" runat="server" Width="50%"></asp:DropDownList>
                                    </p>
				                    <p>
                                        <asp:Label ID="LblPat6" CssClass="labelD" runat="server" Text="Función y Estructura:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtFuncionEstructura" TabIndex="12" runat="server" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label16" CssClass="labelD" runat="server" Text="Actividades y Participacion:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="TextBox9" TabIndex="15" runat="server" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%"></asp:TextBox>
                                    </p>
						            <p>
                                        <asp:Label ID="LblPat15" CssClass="labelD" runat="server" Text="Ayudas Técnicas Indicadas:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_AyudaTecnicaIndicada" TabIndex="14" CssClass="cmbpatologias" runat="server"  Width="50%"></asp:DropDownList>
                                    </p>
						        </div>
			                </div>
		                </div>
                     </fieldset>
                     <div class="clear"></div>
                     <fieldset id="TiempoDiscapacidad">
                        <legend><asp:Label ID="LblPat7" CssClass="labelD" runat="server" Text="Tiempo de Discapacidad"></asp:Label></legend>
                        <div class="container_12">
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="Label20" CssClass="labelD" runat="server" Text="Años:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TDAnios" runat="server" TabIndex="16" CssClass="txtbx_labelD" oninit="TextBox8_Init" ValidationGroup="check" Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat9" CssClass="labelD" runat="server" Text="Meses:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TDMeses" runat="server" TabIndex="17" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat10" CssClass="labelD" runat="server" Text="Dias:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TDDias" runat="server" TabIndex="18" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                        </div>
                     </fieldset>
                     <div class="clear"></div>
                     <fieldset id="TSTDL">
                        <legend><asp:Label ID="LblPat11" CssClass="labelD" runat="server" Text="T.S.T.D.L."></asp:Label></legend>
                        <div class="container_12">
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat12" CssClass="labelD" runat="server" Text="Años:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TSAnios" runat="server" TabIndex="19" CssClass="txtbx_labelD" oninit="TextBox8_Init"  Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="Label10" CssClass="labelD" runat="server" Text="Meses:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TSMeses" runat="server" TabIndex="20" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat14" CssClass="labelD" runat="server" Text="Dias:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TSDias" runat="server" TabIndex="21" CssClass="txtbx_labelD" oninit="TextBox8_Init" Width="50%">0</asp:TextBox>
                                    </p>
                                </div>
                            </div>
                        </div>
                     </fieldset>
                     <div class="clear"></div>  
                     <fieldset id="Etiologia">
                        <legend><asp:Label ID="Label12" CssClass="labelD" runat="server" Text="Etiología"></asp:Label></legend>
                        <div class="container_12">
                            <div class="grid_12">
                                <p><asp:TextBox ID="txtEteologia" runat="server" CssClass="txtbx_labelD" TabIndex="22" TextMode="MultiLine" Width="100%"></asp:TextBox></p>
                            </div>
                        </div>  
                     </fieldset>
                    <div class="clear"></div>  
                        <p>
                            <asp:Button ID="btnguardarseguimiento" CssClass="boton" runat="server" Text="Guardar" onclick="btnguardarseguimiento_Click" />
                            <asp:ConfirmButtonExtender ID="GuardarConfirmation" runat="server" TargetControlID="btnguardarseguimiento" ConfirmText="Esta Seguro Que Desea Guardar la Informacion?"></asp:ConfirmButtonExtender>
                        </p>
                    <fieldset id="RegistroDiario">
                        <legend>Listado de Pacientes</legend>
                        <div class="container_12">
                            <div class="grid_6">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="lbldateinit" CssClass="labelD" runat="server" Text="Fecha Inicial:" Visible="False" Width="30%"></asp:Label>
                                        <asp:TextBox ID="txtdateinit" runat="server" CssClass="txtbx_labelD" onprerender="txtdateinit_PreRender" Visible="False" Width="50%"></asp:TextBox>
                                        <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" TargetControlID="txtdateinit" Format="dd/MM/yyyy" PopupButtonID="imgdateinit"  ClearTime="true"></asp:CalendarExtender>
                                        <img alt="Icon" src="images/calendar_icon.jpg" class="calendar" visible="false" id="imgdateinit" style="display: none" />
                                    </p>
                                </div>
                             </div>
                            <div class="grid_1">
                                <div class="block">
                                    <p>
                                        <asp:ImageButton ID="Refrescar" CssClass="botonbusquedarapida" ImageUrl="~/images/Refresh-32.png" runat="server" CausesValidation="False" onclick="Refrescar_Click1" Visible="False"  />
                                    </p>
                                </div>
                             </div>
                            <div class="grid_5">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="lbldatefini" CssClass="labelD" runat="server" Text="Fecha Final:" Visible="False" Width="30%"></asp:Label>
                                        <asp:TextBox ID="txtdatefini" runat="server" CssClass="txtbx_labelD" Visible="False" Width="50%"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefini" Format="dd/MM/yyyy" PopupButtonID="imgdatefini"></asp:CalendarExtender>
                                        <img alt="Icon" src="images/calendar_icon.jpg" visible="false" class="calendar" id="imgdatefini" style="display: none" />
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="container_12">
                            <p><asp:Label ID="Label1" runat="server" Text="**Fecha Inicial Mayor que la Fecha Final" Visible="False" ForeColor="Red"></asp:Label></p>
                        </div>
                        <div id="separar">
                            <asp:Panel ID="Panel1" CssClass="panelRolesSeg" runat="server" ScrollBars="Auto">
                           <asp:GridView ID="GridViewSegPac" CssClass="Grid" 
                                emptydatatext="----No Hay Pacientes Registrados el Dia de Hoy.----" runat="server" 
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="True" 
                                PageSize="50" onpageindexchanging="GridViewSegPac_PageIndexChanging1" 
                                onselectedindexchanged="GridViewSegPac_SelectedIndexChanged">      
                                
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
                                    <asp:TemplateField HeaderText="Patología" SortExpression="diagnostico1">
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
                                    <asp:TemplateField HeaderText="Observación" SortExpression="observacion">
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

