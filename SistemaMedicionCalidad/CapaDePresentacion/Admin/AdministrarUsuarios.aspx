<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarUsuarios.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="aUsuarios" runat="server" ImageUrl="ImagenesAdmin/aUsuarios.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre de usuario o tipo" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView CssClass="table table-striped" ID="gvUsuarios" runat="server" AutoGenerateColumns="False" PageSize="10" AllowPaging="True"
                        BackColor="White" OnRowCommand="gvUsuarios_RowCommand" OnPageIndexChanging="gvUsuarios_PageIndexChanging">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen usuarios!
                        </EmptyDataTemplate>

                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="activo" ControlStyle-CssClass="btnActivo" Text="Cambiar estado" HeaderText="Cambiar Estado">
                                <ControlStyle CssClass="btnActivo form-control btn-success" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="nombre_usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="tipo_usuario_usuario.nombre_tipo_usuario" HeaderText="Rol" />
                            <asp:BoundField DataField="Correo_usuario" HeaderText="Correo" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
