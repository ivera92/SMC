<%@ Page Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div>
    <table>
    <tr>
    <td>
        &nbsp;</td>
    <td><h2>
        Crear Escuela
    </h2></td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>
    </td>
    <td class="style2">
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>
        &nbsp;</td>
    <td><label for="lbl2">Nombre</label></td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/CrearEscuela.aspx" Text="Crear Escuela" 
                    Value="Crear Escuela"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/AdministrarEscuelas.aspx" 
                    Text="Administrar Escuelas" Value="Administrar Escuelas"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </td>
    <td class="style2">
        <asp:TextBox ID="tbxEscuela" class="form-control" runat="server" Width="231px"></asp:TextBox>
        </td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td>
        &nbsp;</td>
    <td class="style2">
        <asp:Button ID="btbCrear" class="btn btn-primary" runat="server" Text="Crear" 
            onclick="btbCrear_Click" />
        </td>
    <td>
        &nbsp;</td>
    </tr>

    </table>
    </div>


</asp:Content>