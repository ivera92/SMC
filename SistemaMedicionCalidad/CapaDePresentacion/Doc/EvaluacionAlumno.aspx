<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="EvaluacionAlumno.aspx.cs" Inherits="CapaDePresentacion.Doc.EvaluacionAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar">
        <h1 class="text-center">Cargar resultados</h1>
        <br />

        <div class="row">
            <div class="col-sm-offset-1 col-sm-3">
                <label>Rut Alumno</label>
                <div>
                    <asp:TextBox ID="txtRut" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <asp:CustomValidator ID="cv_rut" runat="server" ControlToValidate="txtRut" Display="Dynamic" ErrorMessage="RUT no valido" ClientValidationFunction="validar_rut" />
            <div class="col-sm-4">
                <label>Asignatura</label>
                <div>
                    <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-sm-3">
                <label>Evaluacion</label>
                <div>
                    <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                        <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />

        <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            <br />
        </div>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:Button ID="btnGuardar" runat="server" class="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button runat="server" CssClass="btn btn-block btn-primary" ID="btnSiguiente" Text="Seguir evalaluando" OnClick="btnSiguiente_Click" />
        </div>
    </div>
</asp:Content>
