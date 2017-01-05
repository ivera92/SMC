<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Cambiar contraseña</h2>
    <br />

    <label>Contraseña Actual</label>
    <asp:TextBox runat="server" class="form-control col-sm-4" placeHolder="Ingrese Contraseña actual"></asp:TextBox>
    <br />

    <label>Ingrese nueva contraseña</label>
    <asp:TextBox runat="server" class="form-control col-sm-4" placeHolder="Ingrese nueva contraseña"></asp:TextBox>
    <br />

    <label>Ingrese nuevamente la contraseña</label>
    <asp:TextBox runat="server" class="form-control col-sm-4" placeHolder="Ingrese nuevamente la contraseña"></asp:TextBox>
    <br />
</asp:Content>
