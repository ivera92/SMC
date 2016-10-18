<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Alumnos.aspx.cs" Inherits="CapaDePresentacion.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 125px;
        }
        .style3
        {
            width: 219px;
        }
        .style4
        {
            width: 208px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
    <div
    <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
        <asp:Label ID="Label1" runat="server" Text="Creacion de Alumnos" Font-Size="XX-Large"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label2" runat="server" Text="Rut"></asp:Label>
                </td>
                <td class="style4">
        <asp:TextBox ID="rut" runat="server" Width="85px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Ejemplo: 18205857-2"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label4" runat="server" Text="Escuela"></asp:Label>
                </td>
                <td class="style4">
        <asp:DropDownList ID="escuela" runat="server" Width="162px">
        </asp:DropDownList>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="nombre" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label6" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                </td>
                <td class="style4">
        <asp:TextBox ID="fechaDeNacimiento" runat="server" Width="80px"></asp:TextBox>
                    <asp:Label ID="Label14" runat="server" Text="Ejemplo: 20/11/1992"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="direccion" runat="server" Width="157px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
                </td>
                <td class="style4">
        <asp:TextBox ID="telefono" runat="server" Width="85px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label9" runat="server" Text="Nacionalidad"></asp:Label>
                </td>
                <td class="style4">
        <asp:TextBox ID="nacionalidad" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label10" runat="server" Text="Sexo"></asp:Label>
                </td>
                <td class="style4">
        <asp:RadioButtonList ID="sexo" runat="server">
            <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
            <asp:ListItem Value="Femenino"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label11" runat="server" Text="Correo"></asp:Label>
                </td>
                <td class="style4">
        <asp:TextBox ID="correo" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label12" runat="server" Text="Promocion"></asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="promocion" runat="server" Width="70px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
        <asp:Label ID="Label13" runat="server" Text="Beneficio"></asp:Label>
                </td>
                <td class="style4">
                    <asp:RadioButtonList ID="beneficio" runat="server">
            <asp:ListItem Value="Si"></asp:ListItem>
            <asp:ListItem Selected="True" Value="No"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="btnCrear" runat="server" Text="Crear" Height="39px" 
                        Width="86px" />
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
        </table>
        </div>
                
                
    </p>
</asp:Content>
