<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="CrearEvaluacion.aspx.cs" Inherits="CapaDePresentacion.Doc.CrearEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Crear Evaluacion</h2>
    <br />

    <label class="col-sm-offset-3">Asignatura</label>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-3">Nombre Evaluacion</label>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:TextBox runat="server" ID="txtNombre" class="form-control"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-5">
            <label id="nombreAlumno" runat="server" visible="false">Nombre:</label>
        </div>
        <div class="col-sm-2">
            <label id="rut" runat="server" visible="false">Rut:</label>
        </div>
        <div class="col-sm-2">
            <label id="fecha" runat="server" visible="false">Fecha:</label>
        </div>
        <div class="col-sm-1">
            <label id="fechaEvaluacion" runat="server" visible="false">:</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Button runat="server" ID="btnCrear" class="btn btn-primary btn-block" Text="Crear" OnClick="btnCrear_Click1" />
        </div>
    </div>
</asp:Content>
