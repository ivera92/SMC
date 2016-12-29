<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="CapaDePresentacion.CrearPregunta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Crear Pregunta</h2>
    <br />

    <label>Pregunta</label>
    <asp:TextBox class="form-control" runat="server" ID="txtPregunta" required></asp:TextBox>
    <br />
    
    <div class="row">
        <div class="col-sm-4">
            <label>Competencia</label>
        </div>
        <div class="col-sm-4">
            <label>Tipo de Pregunta</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <asp:DropDownList class="form-control" runat="server" ID="ddCompetencia"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <asp:DropDownList class="form-control" runat="server" ID="ddTipoPregunta"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnCrear" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
</asp:Content>
