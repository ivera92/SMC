<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarProfesiones.aspx.cs" Inherits="CapaDePresentacion.AdministrarProfesiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="administrar" runat="server">

        <h2 class="text-center">Administrar Profesiones</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-8">
                <asp:GridView class="table table-striped" ID="gvProfesiones" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                    <Columns>
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ShowEditButton="true" />
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

    <label class="col-sm-offset-3">Nombre</label>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-4"><asp:TextBox ID="tbxProfesion" class="form-control" runat="server" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre" required></asp:TextBox></div>
        <div class="col-sm-2"><asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/></div>
    </div>
    </div>
</asp:Content>
