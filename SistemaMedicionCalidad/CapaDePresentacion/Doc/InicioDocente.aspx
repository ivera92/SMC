<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="InicioDocente.aspx.cs" Inherits="CapaDePresentacion.Doc.InicioDocente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-offset-4">
        <h2>Datos Personales</h2>
        <br />
        <asp:TextBox ID="rut" runat="server" Visible="False"></asp:TextBox>
        <h3 id="nombreDocente" runat="server"></h3>
        <h4 id="profesionDocente" runat="server"></h4>
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
        <br />
    </div>
</asp:Content>
