<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="EvaluacionAlumno.aspx.cs" Inherits="CapaDePresentacion.Doc.EvaluacionAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar">
    <h1 class="text-center">Evaluacion Alumno</h1>
    <br />

    <label class="col-sm-offset-3">Rut Alumno</label>
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:TextBox ID="txtRut" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
    <br />

    <asp:CustomValidator CssClass="col-sm-offset-3" id="cv_rut" runat="server" ControlToValidate="txtRut" Display="Dynamic" ErrorMessage="El rut no es valido" ClientValidationFunction="validar_rut" />
        
    <label class="col-sm-offset-3">Asignatura</label>
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    
    <label class="col-sm-offset-3">Evaluacion</label>
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <br />
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Button ID="btnGuardar" runat="server" class="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button runat="server" CssClass="btn btn-block btn-primary" ID="btnSiguiente" Text="Seguir evalaluando" OnClick="btnSiguiente_Click"/>
        </div>
    </div>
</asp:Content>
