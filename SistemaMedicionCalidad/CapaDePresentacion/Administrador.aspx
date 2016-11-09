<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="CapaDePresentacion.Administrador" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<table>
    <tr>
        <td></td>
        <td><h2>Administrar</h2></td>
        <td></td>
    </tr>

    <tr>
        <td> 
        <asp:ImageButton ID="ImageUpdateButton" PostBackUrl="CrearAlumno.aspx" runat="server" Width=172px  Height=183px ImageUrl="imagenes/alumno.jpg" />
        </td>
        <td>
        <asp:ImageButton ID="ImageButton1" PostBackUrl="CrearDocente.aspx" runat="server" Width=225px  Height=246px ImageUrl="imagenes/profesor.jpg" />
        </td>
        <td>
        <asp:ImageButton ID="ImageButton2" PostBackUrl="CrearEscuela.aspx" runat="server" Width=225px  Height=246px ImageUrl="imagenes/escuela.jpg" />
        </td>
    </tr>

    <tr>
        <td>
        <asp:ImageButton ID="ImageButton3" PostBackUrl="CrearProfesion.aspx" runat="server" Width=225px  Height=246px ImageUrl="imagenes/profesion.jpg"/></a>
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

</asp:Content>
