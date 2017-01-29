<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearAsignatura.aspx.cs" Inherits="CapaDePresentacion.CrearAsignatura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="crear" runat="server">
    <h2>Crear Asignatura</h2>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Nombre</label></div>
        <div class="col-sm-6"><label>Año</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre" required></asp:TextBox>
        </div>
        <div class="col-sm-6">
            <asp:TextBox ID="txtAno" runat="server" class="form-control" placeHolder="Ingrese año" type="number" min="2010" required></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Escuela</label></div>
        <div class="col-sm-6"><label>Docente</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <asp:DropDownList runat="server" ID="ddEscuela" class="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-6">
            <asp:DropDownList runat="server" ID="ddDocente" class="form-control"></asp:DropDownList>
        </div>
    </div>
    <br />

    <div><label>Duración</label></div>
    <div class="row">
        <div class="col-sm-6">
            <asp:RadioButtonList ID="duracion" runat="server">
                <asp:ListItem Selected="True" Value="Semestral"></asp:ListItem>
                <asp:ListItem Value="Anual"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click"/>
        </div>
    </div>
        </div>
</asp:Content>
