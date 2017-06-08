<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarProfesiones.aspx.cs" Inherits="CapaDePresentacion.AdministrarProfesiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="administrar" runat="server">
        <h2 class="text-center">Administrar Profesiones</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre profesión" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-8">
                <asp:GridView class="table table-striped" ID="gvProfesiones" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting" 
                    OnRowEditing="rowEditing" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvProfesiones_PageIndexChanging">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen profesiones!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                        <asp:BoundField DataField="Nombre_profesion" HeaderText="Nombre" />
                        <asp:BoundField DataField="Id_profesion" HeaderText="ID" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
    </div>

    <div id="editar" runat="server">
        <h2 class="text-center">Actualizar Profesión</h2>
        <br />
        <div class="row">
            <label class="col-sm-offset-2 col-sm-1">Nombre</label>
            <div class="col-sm-5">
                <asp:TextBox ID="tbxProfesion" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese nombre">
                </asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
