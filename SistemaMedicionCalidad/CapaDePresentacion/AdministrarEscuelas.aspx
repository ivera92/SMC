<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarEscuelas.aspx.cs" Inherits="CapaDePresentacion.AdministrarEscuelas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 235px;
        }
        .style2
        {
            width: 256px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2> Administrar Escuelas</h2>
    <div id="tablaAdministrar" runat="server">
    <table id="tadministrar">
    <tr>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
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
    <td>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            onrowdeleting="rowDeleting" onrowediting="rowEditing">
            <Columns>
            <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ShowEditButton="true" />
            <asp:BoundField DataField="Nombre_Escuela" HeaderText="Nombre" />
            <asp:BoundField DataField="Id_Escuela" HeaderText="ID" />
            </Columns>
        </asp:GridView>
    </td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    </table>
    </div>
    
    <div id="tablaEditar" runat="server">
    <table id="teditar">
    <tr>
    <td class="style1">
    </td>
    <td class="style2">
        <asp:Label ID="Label1" runat="server" Text="Nombre de Escuela"></asp:Label>
        </td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td class="style1">
        &nbsp;</td>
    <td class="style2">
        <asp:TextBox ID="tbxEscuela" runat="server" Width="231px"></asp:TextBox>
    </td>
    <td>
        &nbsp;</td>
    </tr>

    <tr>
    <td class="style1">
        <asp:Menu ID="Menu2" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/CrearEscuela.aspx" Text="Crear Escuela" 
                    Value="Crear Escuela"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/AdministrarEscuelas.aspx" 
                    Text="Administrar Escuelas" Value="Administrar Escuelas"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </td>
    <td class="style2">
        <asp:Label ID="Label2" runat="server" Text="ID"></asp:Label>
        </td>
    <td>
        <asp:Button ID="btbGuardar" runat="server" Text="Guardar" 
            onclick="btbGuardar_Click"  />
        </td>
    </tr>

    <tr>
    <td class="style1">
        &nbsp;</td>
    <td class="style2">
        <asp:TextBox ID="txbid" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    <td>
        &nbsp;</td>
    </tr>

    </table>
    </div>
</asp:Content>