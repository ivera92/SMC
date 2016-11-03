<%@ Page Title="Login" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="CapaDePresentacion.Login" %>
    
    <html>
    <head>
        <title></title>
        <link href="~/Scripts/jquery-1.4.1.min.js">
        <link href="~/Scripts/bootstrap.min.js">
        <link href="~/Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
    <div runat="server">
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
            <asp:TextBox class="form-control" ID="txtRut" runat="server"></asp:TextBox>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
        <asp:TextBox class="form-control" ID="txtclave" runat="server"></asp:TextBox>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td> 
        <asp:Button class="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar"/>
        </td>
        </tr>

    </table>
    </div>
    </body>
    </html>