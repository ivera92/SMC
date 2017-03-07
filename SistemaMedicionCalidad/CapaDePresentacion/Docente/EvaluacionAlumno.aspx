<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="EvaluacionAlumno.aspx.cs" Inherits="CapaDePresentacion.EvaluacionAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript">

    function validar_rut(source, arguments) {
        var rut = arguments.Value; suma = 0; mul = 2; i = 0;

        for (i = rut.length - 3; i >= 0; i--) {
            suma = suma + parseInt(rut.charAt(i)) * mul;
            mul = mul == 7 ? 2 : mul + 1;
        }

        var dvr = '' + (11 - suma % 11);
        if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

        if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Evaluacion Alumno</h1>
    <br />

    <label>Rut Alumno</label>
    <div class="row">
        <div class="col-sm-3">
            <asp:TextBox ID="txtRut" runat="server" class="form-control"></asp:TextBox>
            <asp:CustomValidator id="cv_rut" runat="server" ControlToValidate="txtRut" Display="Dynamic" ErrorMessage="El rut no es valido" ClientValidationFunction="validar_rut" />
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnBuscar" runat="server" class="form-control btn btn-block btn-primary" Text="Buscar" OnClick="btnBuscar_Click"/>
        </div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnCargarPreguntas" runat="server" class="form-control btn btn-block btn-primary" Text="Cargar" OnClick="btnCargarPreguntas_Click" />
        </div>
    </div>
    <br />
    
    <div class="row">
        <div class="col-sm-6">
            <label id="lblNombreAlumno" runat="server"></label>
        </div>
    </div>
    <br />

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <br />

    <asp:Button ID="btnGuardar" runat="server" class="form-control btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />

</asp:Content>
