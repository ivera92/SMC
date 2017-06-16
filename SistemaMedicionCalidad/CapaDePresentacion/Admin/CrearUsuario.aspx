<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Crear Usuario</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <label>Tipo de usuario</label>
            <asp:DropDownList ID="ddTipoUsuario" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                <asp:ListItem Value="0"><--Seleccione tipo de usuario--></asp:ListItem>
                <asp:ListItem Value="3">Administrador</asp:ListItem>
                <asp:ListItem Value="4">Evaluador</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <label>Nombre de usuario</label>
            <asp:TextBox runat="server" ID="txtNombreUsuario" class="form-control" required></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <label>Correo</label>
            <asp:TextBox runat="server" ID="txtCorreo" class="form-control" type="email" placeHolder="Ingrese nombre usuario" required></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-5 col-sm-2">
            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="form-control btn-block btn-primary" OnClick="btnCrear_Click" />
            <br />
        </div>
    </div>

</asp:Content>
