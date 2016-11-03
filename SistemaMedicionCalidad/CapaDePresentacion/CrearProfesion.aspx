<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CrearProfesion.aspx.cs" Inherits="CapaDePresentacion.CrearProfesion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<table>

<tr>
<td></td>
<td>
    <h1>Crear Profesión</h1>
</td>
<td></td>
</tr>

<tr>
<td></td>
<td></td>
<td></td>
</tr>

<tr>
<td></td>
<td>
    <label for="lbl1">Nombre</label>
</td>
<td></td>
</tr>

<tr>
<td></td>
<td class="form-inline">
    <asp:TextBox ID="tbxProfesion" class="form-control" runat="server"></asp:TextBox>
    <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" Text="Crear" 
        onclick="btnCrear_Click"/>
</td>
<td></td>
</tr>

</table>


</asp:Content>
