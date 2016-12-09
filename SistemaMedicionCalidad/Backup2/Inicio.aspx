<%@ Page Title="" Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaDePresentacion.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <h2>Seleccione tipo de usuario</h2>
    <br />
    <asp:Button class="form-control" ID="btnAlumno" Text="Alumno" runat="server" 
        onclick="btnAlumno_Click"/>
    <asp:Button class="form-control" ID="btnDocente" Text="Docente" runat="server" />
    <asp:Button class="form-control" ID="btnDireccionA" Text="Direccion Academica" runat="server"/>
    </div>
</asp:Content>
