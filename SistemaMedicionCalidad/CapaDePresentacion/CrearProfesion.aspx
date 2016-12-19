<%@ Page Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearProfesion.aspx.cs" Inherits="CapaDePresentacion.CrearProfesion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <h2>Crear Profesión</h2>
    <br />
    <label>Nombre</label>

    <div class="row">
        <div class="col-sm-4"><asp:TextBox ID="tbxProfesion" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-2"><asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" 
        onclick="btnCrear_Click"/></div>
    </div>
</asp:Content>
