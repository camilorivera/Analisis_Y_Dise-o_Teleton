<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Seguimiento_Pacientes.aspx.cs" Inherits="Seguimiento_Pacientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton_fix.css" rel="stylesheet" type="text/css" />
    <link href="Styles/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/reset.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/grid.css" rel="stylesheet" type="text/css" />
    <link href="Styles/960/layout.css" rel="stylesheet" type="text/css" />
    <link href="Styles/ui.spinner.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.13.js" type="text/javascript"></script>
    <script src="Scripts/ui.spinner.js" type="text/javascript"></script>
    <!--[if IE 6]><link rel="stylesheet" type="text/css" href="Styles/960/ie6.css" media="screen" /><![endif]-->
	<!--[if IE 7]><link rel="stylesheet" type="text/css" href="Styles/960/ie.css" media="screen" /><![endif]--> 
    <script type="text/javascript">
        document.onkeypress = KeyPress;
        var isEnter = false;
        function KeyPress(e) {
            var code = (window.event) ? event.keyCode : e.which;
            if (code == 13) { isEnter = true; }
        }

        function openPopUp() {
            var popUrl = 'Seguimiento_Paciente_Quicksearch.aspx';
            var name = 'popUp';
            var appearence = 'dependent=yes,menubar=no,resizable=yes,' +
                                          'status=yes,toolbar=no,titlebar=no,' +
                                          'left=5,width=900px,height=500px';
            var openWindow = window.open(popUrl, name, appearence);
            openWindow.focus();
        }

        function OnKeyUp(obj) {
            if (obj.id == "MainContent_txtnumexp" && (this.isEnter || window.event.keyCode == 13)) {
                this.isEnter = false;
                __doPostBack('', '');
            }
        }
       jQuery().ready(function ($) {
            $('#txt_TDAnios').spinner({ min: 0, max: 100 });
            $('#txt_TDMeses').spinner({ min: 0, max: 12 }); 
            $('#txt_TDDias').spinner({ min: 0, max: 365 }); 
            $('#txt_TSAnios').spinner({ min: 0, max: 100 }); 
            $('#txt_TSMeses').spinner({ min: 0, max: 12 });
            $('#txt_TSDias').spinner({ min: 0, max: 365 });

            $('#enable').click(function () { $('#updowndisable').spinner('enable'); });
            $('#disable').click(function () { $('#updowndisable').spinner('disable'); });
            $('#GetValue').click(function () { alert($('#updown').spinner('value')); });
            $('#destroy').click(function () { $('#updown').spinner('destroy'); });
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id = "content">
        <ContentTemplate>
            <div id="content3">
                <div id="navcenter">
                    <div id="head">
                        <h2>Seguimiento de Pacientes</h2>
                        <h5>Fecha de hoy: <asp:Label ID="LBLDATE" CssClass="h3" runat="server"></asp:Label></h5>
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
                                        <asp:Label ID="LblNumExp" runat="server" Text="Nº de Expediente: " Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnumexp" TabIndex="1" runat="server" CssClass="txtbx_labelD" onKeyUp = "OnKeyUp(this,13);"  Width="45%"></asp:TextBox>
                                        <!--<asp:Button ID="btnSearchButton" runat="server" Width="5%"></asp:Button>-->
                                        <asp:ImageButton ID="busqueda" CssClass="botonbusquedarapida" ImageUrl="~/images/Search.png" runat="server" CausesValidation="False"  Width="5%" />
                                    </p>
					                <p>
                                        <asp:Label ID="Label8" CssClass="labelD" runat="server" Text="Nombre Paciente:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnombrepac" TabIndex="3" runat="server" CssClass="txtbx_labelD" Width="50%"></asp:TextBox>
                                    </p>
					                <p>
                                        <asp:Label ID="Label9" CssClass="labelD" runat="server" Text="Número de Identidad: " Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtnumced" runat="server" TabIndex="5" CssClass="txtbx_labelD" Width="50%"></asp:TextBox>
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
                                        <asp:TextBox ID="txtFuncionEstructura" TabIndex="12" runat="server" CssClass="txtbx_labelD" Width="50%"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label16" CssClass="labelD" runat="server" Text="Actividades y Participacion:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txtActividadesParticipacion" TabIndex="14" runat="server" CssClass="txtbx_labelD" Width="50%"></asp:TextBox>
                                    </p>
						            <p>
                                        <asp:Label ID="LblPat15" CssClass="labelD" runat="server" Text="Ayudas Técnicas Indicadas:" Width="40%"></asp:Label>
                                        <asp:DropDownList ID="cmb_AyudaTecnicaIndicada" TabIndex="16" CssClass="cmbpatologias" runat="server"  Width="50%"></asp:DropDownList>
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
                                        <asp:TextBox ID="txt_TDAnios" runat="server" TabIndex="17" 
                                            ClientIDMode='Static' ValidationGroup="check" Text='0' Width="50%" ></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat9" CssClass="labelD" runat="server" Text="Meses:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TDMeses" runat="server" ClientIDMode='Static' Text='0' TabIndex="18" Width="50%"></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat10" CssClass="labelD" runat="server" Text="Dias:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TDDias" runat="server" ClientIDMode='Static' Text='0' TabIndex="19" Width="50%"></asp:TextBox>
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
                                        <asp:TextBox ID="txt_TSAnios" runat="server" ClientIDMode='Static' Text='0' TabIndex="20" Width="50%"></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="Label10" CssClass="labelD" runat="server" Text="Meses:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TSMeses" runat="server" ClientIDMode='Static' Text='0' TabIndex="21" Width="50%"></asp:TextBox>
                                    </p>
                                </div>
                            </div>
                            <div class="grid_4">
                                <div class="block">
                                    <p>
                                        <asp:Label ID="LblPat14" CssClass="labelD" runat="server" Text="Dias:" Width="40%"></asp:Label>
                                        <asp:TextBox ID="txt_TSDias" runat="server" ClientIDMode='Static' Text='0' TabIndex="22" Width="50%"></asp:TextBox>
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
                                <p><asp:TextBox ID="txtEteologia" runat="server" CssClass="txtbx_labelD" TabIndex="23" TextMode="MultiLine" Width="100%"></asp:TextBox></p>
                            </div>
                        </div>  
                     </fieldset>
                    <div class="clear"></div>  
                    <div class="container_12">
                        <div class="grid_12">
                            <p>
                                <asp:Button ID="btnguardarseguimiento" CssClass="boton" runat="server" Text="Guardar" onclick="btnguardarseguimiento_Click" TabIndex="24" />
                                <asp:ConfirmButtonExtender ID="GuardarConfirmation" runat="server" TargetControlID="btnguardarseguimiento" ConfirmText="Esta Seguro Que Desea Guardar la Informacion?"></asp:ConfirmButtonExtender>
                            </p>
                        </div>
                     </div>
                     <div class="clear"></div>  
                     <fieldset id="Fieldset1">
	                    <legend>Listado Pascientes</asp:Label></legend>
	                    <div class="container_12">
		                    <div class="grid_12">
		                        <asp:GridView ID="GridViewSegPac" 
                                        emptydatatext="----No Hay Pacientes Registrados el Dia de Hoy.----" runat="server" 
                                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" AllowPaging ="True" 
                                        PageSize="25" onpageindexchanging="GridViewSegPac_PageIndexChanging1">      
                                
                                        <pagersettings mode="Numeric"
                                            position="Bottom" 
                                            Visible="True"/>      
                                
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
                                </div>
                            </div>  
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </div>    
 </asp:Content>

