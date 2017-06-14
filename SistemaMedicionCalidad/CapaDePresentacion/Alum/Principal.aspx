<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CapaDePresentacion.Alum.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-offset-4">
        <h2>Datos Personales</h2>
        <br />
        <h3 id="nombreAlumno" runat="server"></h3>
        <h4 id="nombreEscuela" runat="server"></h4>
        <br />
        <h1 id="correoAlumno" runat="server"></h1>
    </div>
</asp:Content>
