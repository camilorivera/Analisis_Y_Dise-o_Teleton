<%@ Page Title="" ValidateRequest="true" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Crear_Paciente.aspx.cs" Inherits="Crear_Paciente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="Styles/Teleton.css" rel="stylesheet" type="text/css" />    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script type="text/javascript">
        function validateForm() {
            //var x = document.getElementById("MainContent_txtCedula");
            //var pattx = new RegExp("[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]");
            //var boolx = pattx.test(x.value);

            var y = document.getElementById("MainContent_txtFechaNacimiento");
            var patty = new RegExp("(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-[1-9][0-9][0-9][0-9]");
            var booly = patty.test(y.value);

            var z = document.getElementById("MainContent_txtFechaIngreso");
            var boolz = patty.test(z.value);            

            /*if (!boolx) {
                alert("Numero de cedula invalido");
            }*/

            if (!booly) {
                alert("Fecha de nacimiento invalida");
            }

            if (!boolz) {
                alert("Fecha de ingreso invalida");
            }

            return booly && boolz;
        }

        function printInfo() {
            var text1 = document.getElementById("MainContent_txtExp");
            var text2 = document.getElementById("MainContent_txtCedula");
            var text3 = document.getElementById("MainContent_txtNombres");
            var text4 = document.getElementById("MainContent_txtPrimerApellido");
            var text5 = document.getElementById("MainContent_txtSegundoApellido");
            var text6 = document.getElementById("MainContent_txtDireccion");
            var radio1 = document.getElementById("MainContent_rdSexo_0");
            var radio2 = document.getElementById("MainContent_rdSexo_1");
            var text7 = document.getElementById("MainContent_ddEstado");
            var text7options = document.getElementById("MainContent_ddEstado").options;
            var text8 = document.getElementById("MainContent_txtLugarNacimiento");
            var text9 = document.getElementById("MainContent_txtFechaNacimiento");
            var text10 = document.getElementById("MainContent_txtFechaIngreso");

            var printWindow = window.open(document.URL, window.name, 'left=50000,top=50000,width=0,height=0');

            printWindow.document.write("Nº de Expediente: " + text1.value + "<br />");
            printWindow.document.write("Nº de Cédula: " + text2.value + "<br />");
            printWindow.document.write("Nombres: " + text3.value + "<br />");
            printWindow.document.write("Primer Apellido: " + text4.value + "<br />");
            printWindow.document.write("Segundo Apellido: " + text5.value + "<br />");
            printWindow.document.write("Dirección:" + text6.value + "<br />");
            if (radio1.checked) {
                printWindow.document.write("Sexo: Masculino" + "<br />");
            }
            if (radio2.checked) {
                printWindow.document.write("Sexo: Femenino" + "<br />");
            }
            printWindow.document.write("Estado Civil: " + text7options[text7.selectedIndex].text + "<br />");
            printWindow.document.write("Lugar de Nacimiento: " + text8.value + "<br />");
            printWindow.document.write("Fecha de Nacimiento: " + text9.value + "<br />");
            printWindow.document.write("Fecha de Ingreso: " + text10.value + "<br />");
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();

            return false;
        }
    </script>

    <div id="content">
        <div id = "titulo">
            <h1>Registro de Pacientes</h1> 
            <h2>Información General</h2>
        </div>

        <div id="navcenter">
        <fieldset>
            <legend>Datos Generales</legend>
                <div class="centrar">
                    <ul class = "list">
                        <li class="field">
                            <asp:Label ID="Label11" CssClass="label" runat="server" 
                                Text="Nº de Expediente:"></asp:Label>
                            <asp:TextBox ID="txtExp" runat="server" CssClass="tb_Requerido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                ControlToValidate="txtExp" ErrorMessage="*Campo Requerido" ForeColor="Red" 
                                ValidationGroup="TodoError"></asp:RequiredFieldValidator>
                        </li>
                    
                        <li class="field">
                            <asp:Label ID="Label2" CssClass="label" runat="server" 
                                Text="Nº de Cédula:"></asp:Label>
                            <asp:TextBox ID="txtCedula" runat="server" CssClass="tb_Requerido" 
                                MaxLength="15"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Campo Requerido"
                            ForeColor="Red" ControlToValidate="txtCedula" ValidationGroup="TodoError" ></asp:RequiredFieldValidator>
                        </li>
                    
                        <li class="field">
                            <asp:Label ID="Label3" CssClass="label" runat="server" 
                                Text="Nombres:"></asp:Label>
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="tb_Requerido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ErrorMessage="*Nombre Requerido" ForeColor="Red" 
                                ControlToValidate="txtNombres" ValidationGroup="TodoError"></asp:RequiredFieldValidator>
                        </li>
                    
                        <li class="field">
                            <asp:Label ID="Label4" CssClass="label" runat="server" 
                                Text="Primer Apellido:"></asp:Label>
                            <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="tb_Requerido"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*Apellido Requerido" ForeColor="Red" 
                                    ControlToValidate="txtPrimerApellido" ValidationGroup="TodoError"></asp:RequiredFieldValidator>
                        </li>
                    
                        <li class="field">
                            <asp:Label ID="Label1" CssClass="label" runat="server" 
                                Text="Segundo Apellido:"></asp:Label>
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="tb_Permiso"></asp:TextBox>
                        </li>
                    
                        <li class="field">
                            <asp:Label ID="Label5" CssClass="label" runat="server" 
                                Text="Dirección:"></asp:Label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="tb_Requerido" 
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ErrorMessage="*Dirección Requerida" ForeColor="Red" 
                                    ControlToValidate="txtDireccion" ValidationGroup="TodoError"></asp:RequiredFieldValidator>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label22" CssClass="label">Departamento:</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="tb_Permiso" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlDepartamento_SelectedIndexChanged">
                            </asp:DropDownList>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label23" CssClass="label">Municipio:</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlMunicipio" CssClass="tb_Permiso">
                            </asp:DropDownList>
                        </li>

                        <li class="field">
                            <asp:Label ID="Label6" CssClass="label" runat="server" 
                                Text="Sexo:"></asp:Label>
                            <asp:radiobuttonlist id="rdSexo" runat="server" RepeatDirection="Horizontal">
                                <asp:listitem id="rdMasculino" Selected="true" runat="server" value="Masculino" />
                                <asp:listitem id="rdFemenino" runat="server" value="Femenino" />
                            </asp:radiobuttonlist>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label7" CssClass="label" runat="server" 
                                Text="Estado Civil:"></asp:Label>
                            <asp:DropDownList ID="ddEstado" runat="server" CssClass="tb_Permiso">
                                <asp:ListItem Selected="True" Value="0">Soltero</asp:ListItem>
                                <asp:ListItem Value="1">Casado</asp:ListItem>
                                <asp:ListItem Value="2">Divorciado</asp:ListItem>
                                <asp:ListItem Value="3">Viudo</asp:ListItem>
                                <asp:ListItem Value="4">Unión libre</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label8" CssClass="label" runat="server" 
                                Text="Lugar de Nacimiento:"></asp:Label>
                            <asp:TextBox ID="txtLugarNacimiento" runat="server" CssClass="tb_Requerido"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="*Campo Requerido" ForeColor="Red" 
                                    ControlToValidate="txtLugarNacimiento" ValidationGroup="TodoError"></asp:RequiredFieldValidator>
                        </li>
                        <li class="field">
                            <asp:Label ID="Label9" CssClass="label" runat="server" 
                                Text="Fecha de Nacimiento:"></asp:Label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="requerido" ></asp:TextBox>
                            <img alt="Icon" src="images/calendar_icon.jpg" id="img_fecha_nacimiento" width="24px"/>
                            <asp:CalendarExtender ID="FechaNacimientoExtender" runat="server" TargetControlID="txtFechaNacimiento" Format="dd-MM-yyyy" PopupButtonID="img_fecha_nacimiento">
                            </asp:CalendarExtender>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ErrorMessage="*Fecha de Nacimiento Requerida" ForeColor="Red" 
                                ControlToValidate="txtFechaNacimiento" ValidationGroup="TodoError"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="TodoError"
                                runat="server" ControlToValidate="txtFechaNacimiento" ForeColor="Red" ErrorMessage="*Formato valido es dd-MM-yyyy"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-[1-9][0-9][0-9][0-9]"
                                />
                        </li>
                        <li class="field">
                            <asp:Label ID="Label10" CssClass="label" runat="server" 
                                Text="Fecha de Ingreso:"></asp:Label>
                            <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="requerido" ></asp:TextBox>
                            <img alt="Icon" src="images/calendar_icon.jpg" id="img1" width="24px" />

                            <asp:CalendarExtender ID="FechaIngresoExtender" runat="server" 
                                TargetControlID="txtFechaIngreso" Format="dd-MM-yyyy" PopupButtonID="img1">
                            </asp:CalendarExtender>                                                       

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                ErrorMessage="*Fecha de Ingreso Requerida" ForeColor="Red" 
                                ControlToValidate="txtFechaIngreso" ValidationGroup="TodoError"></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="TodoError"
                                runat="server" ControlToValidate="txtFechaIngreso" ForeColor="Red" ErrorMessage="*Formato valido es dd-MM-yyyy"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[012])-[1-9][0-9][0-9][0-9]"
                                />

                            
                        </li>

                        <li class="field">
                            <asp:Label ID="Label12" CssClass="label" runat="server" 
                                Text="Foto:"></asp:Label>
                            <asp:FileUpload ID="FileUpload_Foto" runat="server" />
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label13" CssClass="label">Teléfono:</asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" MaxLength="8" 
                                ToolTip="Telefono sin guion" CssClass="requerido"></asp:TextBox>

                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Formato no valido"
                                ForeColor="Red" ControlToValidate="txtTelefono" Type="Integer" 
                                Operator="DataTypeCheck" ValidationGroup="TodoError"></asp:CompareValidator>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label14" CssClass="label">Celular:</asp:Label>
                            <asp:TextBox runat="server" ID="txtCelular" MaxLength="8" 
                                ToolTip="Celular sin guion" CssClass="requerido"></asp:TextBox>

                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*Formato no valido"
                                ForeColor="Red" ControlToValidate="txtCelular" Type="Integer" 
                                Operator="DataTypeCheck" ValidationGroup="TodoError"></asp:CompareValidator>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label30" CssClass="label">Escolaridad:</asp:Label>
                            <asp:DropDownList runat="server" ID="ddlEscolaridad" CssClass="tb_Permiso">
                            </asp:DropDownList>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label15" CssClass="label">Profesión:</asp:Label>
                            <asp:DropDownList ID="ddlProfesion" runat="server" CssClass="tb_Permiso">
                            </asp:DropDownList>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label16" CssClass="label">Lugar De Trabajo:</asp:Label>
                            <asp:TextBox runat="server" ID="txtLugarTrabajo" CssClass="tb_Permiso">
                            </asp:TextBox>

                        </li>
                    </ul>
                </div>
            </fieldset>                    
        </div>

        <div class="navcenter">
            <fieldset>
                <legend>Datos Familiares</legend>

                <div class="centrar">
                    <ul class = "list">
                        <li class="field">
                            <asp:Label runat="server" ID="Label17" CssClass="label">Nombre Madre:</asp:Label>
                            <asp:TextBox runat="server" ID="txtMadre" CssClass="tb_Permiso" MaxLength="45"></asp:TextBox>
                        
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label18" CssClass="label">Nombre Padre:</asp:Label>
                            <asp:TextBox runat="server" ID="txtPadre" CssClass="tb_Permiso" MaxLength="45"></asp:TextBox>

                          
                        </li>

                        <li class="field">
                            <asp:Label ID="Label20" runat="server" CssClass="label">Nombre Conyugue:</asp:Label>
                            <asp:TextBox ID="txtConyugue" runat="server" CssClass="tb_Permiso" EnableTheming="true"
                                MaxLength="45"></asp:TextBox>
                        </li>

                        <li class="field">
                            <asp:Label ID="Label21" runat="server" CssClass="label">Nombre Familiar:</asp:Label>
                            <asp:TextBox ID="txtFamiliar" runat="server" CssClass="tb_Permiso" EnableTheming="true"
                                MaxLength="45"></asp:TextBox>
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label19" CssClass="label">Estructura Familiar:</asp:Label>
                            <asp:TextBox runat="server" ID="txtEstructuraFamiliar" CssClass="tb_Permiso" 
                                MaxLength="45"></asp:TextBox>

                        </li>
                    </ul>
                </div>
            </fieldset>
        </div>

        <div class="navcenter">
            <fieldset>
                <legend>Datos Medicos</legend>
                <div class="centrar">
                    <ul class="list">
                        <li class="field">
                            <asp:Label runat="server" ID="Label24" ForeColor="Black" 
                                CssClass="label">¿Recibido rehabilitación antes?</asp:Label>
                            <br />
                            <asp:RadioButtonList runat="server" ID="rblRehabilitacion" 
                                RepeatDirection="Horizontal">
                                <asp:listitem Selected="true" value="Sí"/>
                                <asp:listitem value="No"/>
                            </asp:RadioButtonList>
                        </li>

                        <li class="field">
                        </li>

                        <li class="field">
                        </li>

                        <li class="field">
                            <asp:Label runat="server" ID="Label27" ForeColor="Black" 
                                CssClass="label">Observaciones:</asp:Label>
                            <asp:TextBox runat="server" ID="txtObservaciones" CssClass="tb_Permiso" TextMode="MultiLine">
                            </asp:TextBox>
                        </li>
                    </ul>
                </div>
            </fieldset>
        </div>
        
        <div id="navBotones">
            <asp:Button ID="btIngresar" ValidationGroup="TodoError" CssClass="boton" runat="server" Text="Ingresar Paciente" 
                 OnClientClick="return validateForm()" onclick="btIngresar_Click" />
                        
            <asp:Button ID="btnClean" CssClass="boton" runat="server" Text="Limpiar" 
                CausesValidation="False" onclick="btnClean_Click"/>
                <asp:Button ID="btnPrint" CssClass="boton" runat="server" Text="Imprimir" 
                onclick="btnPrint_Click" />
        </div>        
    </div>
</asp:Content>

