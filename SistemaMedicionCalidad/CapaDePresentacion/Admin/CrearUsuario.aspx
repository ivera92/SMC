<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cUsuario" runat="server" ImageUrl="ImagenesAdmin/cUsuario.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Tipo de usuario</label>
                    <asp:DropDownList ID="ddTipoUsuario" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione tipo de usuario</asp:ListItem>
                        <asp:ListItem Value="3">Administrador</asp:ListItem>
                        <asp:ListItem Value="4">Evaluador</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div>
                    <label>Nombre de usuario</label>
                    <asp:TextBox runat="server" ID="txtNombreUsuario" class="form-control" placeHolder="Ingrese nombre usuario" required></asp:TextBox>
                    <br />
                </div>


                <div>
                    <label>Correo</label>
                    <asp:TextBox runat="server" ID="txtCorreo" class="form-control" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="form-control btn-block btn-success" OnClick="btnCrear_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
