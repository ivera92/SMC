<%@ Page Language="C#" MasterPageFile="SiteDocente.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearAlumnoD.aspx.cs" Inherits="CapaDePresentacion.Doc.CrearAlumnoD" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script src="../Scripts/rut.js"></script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        
        <h2 class="text-center">Crear Alumno</h2>
    <br />
    <div class="row" runat="server" id="divOpcion">
        <div class="col-sm-offset-3 col-sm-3">
            <asp:Button ID="btnManual" runat="server" Text="Crear Manual" CssClass="form-control btn-info" OnClick="btnManual_Click" />
        </div>
        <div class="col-sm-3">
            <asp:Button ID="btnExcel" runat="server" Text="Importar Excel" CssClass="form-control btn-success" OnClick="btnExcel_Click" />
        </div>
    </div>
    <br />
    <div id="divCrearExcel" runat="server">

        <div class="row">            
            <div class="col-sm-offset-3 col-sm-4">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnMostrar" Text="Mostrar" CssClass="form-control btn-primary" runat="server" OnClick="btnMostrar_Click1"/>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
            <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="false">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="Rut" HeaderText="Rut" />
                    <asp:BoundField DataField="Nombre Estudiante" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Carrera" HeaderText="Carrera" />
                    <asp:BoundField DataField="Asignatura" HeaderText="Asignatura" />
                </Columns>
            </asp:GridView>
            </div>
        </div>
        <div class="row">
            <br />
            <div class="col-sm-offset-4 col-sm-4">
                <asp:Button ID="btnImportar" Text="Importar" CssClass="form-control btn-primary" runat="server" OnClick="btnImportar_Click"/>
            </div>
        </div>
        </div>

        <div id="divCrearManual" runat="server">
        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Nombre</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNombre" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre y apellido" class="form-control"
                    oninvalid="setCustomValidity('La primera letra del nombre y apellido deben ir en mayuscula')"
                    oninput="setCustomValidity('')">
                </asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl2">Rut </label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2"></asp:TextBox>
                <asp:CustomValidator ID="CustomValidator1" runat="server"
                    ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                    Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True">
                </asp:CustomValidator>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Fecha de nacimiento</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFechaDeNacimiento" class="form-control" runat="server" type="date" max="1999-12-31" format="data-fv-date-format"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Direccion</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingrese su dirección"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Correo</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Telefono</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" type="number" placeHolder="Ejemplo: 993073695" min="940000000" max="9999999999"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl9">Nacionalidad</label></div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddPais" runat="server" class="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="0"><--Seleccione un pais--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl10">Escuela</label></div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddEscuela" runat="server" class="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="0"><--Seleccione una escuela--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Año ingreso</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPromocion" class="form-control" runat="server" placeHolder="Ingrese año ingreso" type="number" min="2005" max="2017"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl10">Sexo</label></div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="rbSexo" runat="server">
                    <asp:ListItem Value="0">Masculino</asp:ListItem>
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-1">
                <label for="lbl1">Beneficio</label></div>
            <div class="col-sm-1">
                <asp:RadioButtonList ID="rbBeneficio" runat="server">
                    <asp:ListItem Value="0">Si</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-5 col-sm-4">
                <asp:Button ID="btnCrear" class="btn-primary btn-block form-control" runat="server" OnClick="btnCrear_Click" Text="Crear" />
            </div>
            <br />
        </div>
        </div>
</asp:Content>
