<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarEscuelas.aspx.cs" Inherits="CapaDePresentacion.AdministrarEscuelas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div id="tablaAdministrar" runat="server">
    <table id="tadministrar">
    <tr>
    <td>
        &nbsp;</td>
    <td>
        <h2> Administrar Escuelas</h2></td>
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
        <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="false" 
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
    <td></td>
    <td><h2>Editar Escuela</h2></td>
    <td></td>
    </tr>

    <tr>
    <td></td>
    <td></td>
    <td></td>
    </tr>

    <tr>
    <td></td>
    <td><label for="lbl2">Nombre</label></td>
    <td></td>
    </tr>

    <tr>
    <td></td>
    <td>
        <asp:TextBox ID="tbxEscuela" class="form-control" runat="server"></asp:TextBox>
    </td>
    <td></td>
    </tr>

    <tr>
    <td>
        <asp:Menu ID="Menu2" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/CrearEscuela.aspx" Text="Crear Escuela" 
                    Value="Crear Escuela"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/AdministrarEscuelas.aspx" 
                    Text="Administrar Escuelas" Value="Administrar Escuelas"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </td>
    <td><label for="lbl2">ID</label></td>
    <td>
        <asp:Button ID="btbGuardar" class="btn btn-primary" runat="server" Text="Guardar" 
            onclick="btbGuardar_Click"  />
        </td>
    </tr>

    <tr>
    <td></td>
    <td>
        <asp:TextBox ID="txbid" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
        </td>
    <td></td>
    </tr>

    </table>
    </div>
</asp:Content>