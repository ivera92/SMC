<%@ Page Language="C#" MasterPageFile="Site.Master"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
    <h2>Crear Escuela</h2>
    <br />
    <label>Nombre</label>

    <div class="row">
        <div class="col-sm-4"><asp:TextBox ID="tbxEscuela" class="form-control" runat="server" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre" required></asp:TextBox></div>
        <div class="col-sm-2"><asp:Button ID="btbCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" 
            onclick="btbCrear_Click" /></div>
    </div>
        </div>
</asp:Content>