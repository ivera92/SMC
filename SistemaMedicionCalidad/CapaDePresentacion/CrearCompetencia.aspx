<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <table>

        <tr>
            <td></td>
            <td><h2>Crear Competencia</h2></td>
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
            <label>Nombre</label>
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
            <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control"></asp:TextBox>
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
            <label>Tipo</label>
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:RadioButtonList ID="tipoCompetencia" runat="server">
                    <asp:ListItem Selected="True" Value="Generica"></asp:ListItem>
                    <asp:ListItem Value="Especifica"></asp:ListItem>
                </asp:RadioButtonList>
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
            <label>Descripcion</label>
            </td>
            <td></td>
        </tr>

        <tr>
            <td></td>
            <td>
            <textarea id="descripcion" runat="server" cols="20" rows="2"></textarea>
            <asp:Button  ID="brnCrear" class="btn btn-primary" runat="server" Text="Crear" 
                    onclick="brnCrear_Click"/>
            </td>
            <td></td>
        </tr>
    </table>

</asp:Content>
