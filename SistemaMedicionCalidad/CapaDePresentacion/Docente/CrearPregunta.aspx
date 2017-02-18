<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="CapaDePresentacion.CrearPregunta" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="HeadContent" >
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" >

    <h2>Crear Pregunta</h2>
    <br />

    <label>Pregunta</label>
    <asp:TextBox class="form-control" runat="server" ID="txtPregunta" placeHolder="Ingrese pregunta" required></asp:TextBox>
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
    </div>
    <br />
    <h2>Respuestas</h2>

    <label class="col-sm-offset-6">Correcta</label>
    <div class="row">
        <div class="col-sm-6">
            <asp:TextBox ID="txtRespuesta" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <asp:CheckBox id="cbCorrecta" runat="server"/>
        </div>
        <div class="col-sm-1">
            <asp:Button id="btnMas" runat="server" Text="+" class="btn btn-primary btn-block" OnClick="btnMas_Click"/>
        </div>
    </div>
    <br />
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <br />

    <div class="row">
        <div class="col-sm-2">
            <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnCrear" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
</asp:Content>
