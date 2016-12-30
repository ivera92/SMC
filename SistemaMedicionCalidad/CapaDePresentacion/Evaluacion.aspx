<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Evaluacion.aspx.cs" Inherits="CapaDePresentacion.Evaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Evaluacion</h2>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <label>Asignatura</label>
        </div>
        <div class="col-sm-6">
            <label>Nombre Evaluacion</label>
        </div>
        <div class="col-sm-2">
            <label>Fecha</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-4">
            <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-6">
            <asp:TextBox runat="server" ID="txtNombre" class="form-control" required></asp:TextBox>
        </div>        
        <div class="col-sm-2">
            <label runat="server" id="fecha"></label>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6">    
            <label id="nombreAlumno" runat="server">Nombre:</label>
        </div>
        <div class="col-sm-3">    
            <label id="puntaje" runat="server">Puntaje:</label>
        </div>
        <div class="col-sm-3">    
            <label id="nota" runat="server">Nota:</label>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-2">    
            <asp:Button runat="server" ID="btnCrear" class="btn btn-primary btn-block" Text="Crear" OnClick="btnCrear_Click1"/>
        </div>
    </div>
</asp:Content>
