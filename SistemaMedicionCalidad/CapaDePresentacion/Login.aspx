<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaDePresentacion.Login" %>
 
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table>
        <tr>
            <td></td>
            <td>
            <h2>Inicio de Sesion</h2>
            </td>
            <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
            <label>Rut</label>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
            <asp:TextBox class="form-control" ID="txtRut" runat="server"></asp:TextBox>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
            <label>Contraseña</label>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
        <asp:TextBox class="form-control" ID="txtclave" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
        <asp:Button class="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" 
                onclick="btnIngresar_Click"/>
        </td>
        </tr>

    </table>
    </asp:Content>