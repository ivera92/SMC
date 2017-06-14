<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarEscuelas.aspx.cs" Inherits="CapaDePresentacion.AdministrarEscuelas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="tablaAdministrar" runat="server">
        <h2 class="text-center">Administrar Escuelas</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-8">
                <asp:GridView class="table table-striped" ID="gvEscuelas" runat="server" AutoGenerateColumns="false"
                    OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen escuelas!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                        <asp:BoundField DataField="Nombre_Escuela" HeaderText="Escuela" />
                        <asp:BoundField DataField="Id_Escuela" HeaderText="ID" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
    </div>

    <div id="tablaEditar" runat="server">
        <h2 class="text-center">Actualizar Escuela</h2>
        <br />

        <label class="col-sm-offset-3">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:TextBox ID="tbxEscuela" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese nombre" required>
                </asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class=" col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
