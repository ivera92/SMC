<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CapaDePresentacion.Alum.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Datos Personales</h2>
    <asp:TextBox ID="rut" runat="server" Visible="False"></asp:TextBox>
    <h3 id="nombreAlumno" runat="server"></h3>
    <h4 id="nombreEscuela" runat="server"></h4>
    <br />

    <div class="row">
        <div class="col-sm-3">
            <label>Nacionalidad</label>
        </div>
        <div class="col-sm-5">
            <label id="nacionalidad" runat="server"></label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <label>Fecha de nacimiento</label>
        </div>
        <div class="col-sm-5">
            <label id="fechaNacimiento" runat="server"></label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <label>Dirección</label>
        </div>
        <div class="col-sm-5">
            <label id="direccion" runat="server"></label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <label>Telefono</label>
        </div>
        <div class="col-sm-5">
            <label id="telefono" runat="server"></label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <label>Correo</label>
        </div>
        <div class="col-sm-5">
            <label id="correo" runat="server"></label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <label>Promocion</label>
        </div>
        <div class="col-sm-5">
            <label id="promocion" runat="server"></label>
        </div>
    </div>
</asp:Content>
