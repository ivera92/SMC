<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarDesempeno.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarDesempeno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="tablaAdministrar" runat="server">
        <h2 class="text-center">Administrar Desempeños</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese indicador de desempeño" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvDesempenos" runat="server" AutoGenerateColumns="false"
                    OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen desempeños!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                        <asp:BoundField DataField="Id_desempeno" HeaderText="ID" />
                        <asp:BoundField DataField="Indicador_Desempeno" HeaderText="Nombre" />                        
                    </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
    </div>
    <div id="divEditar" runat="server">
        <h2 class="text-center">Actualizar Desempeño</h2>
        <br />

        <label class="col-sm-6">Indicador de desempeño</label>
        <label>Competencia</label>

        <div class="row">
            <div class="col-sm-6">
                <asp:TextBox ID="txtIndicador" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm-6">
                <asp:DropDownList runat="server" ID="ddCompetencia" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />

        <label class="col-sm-3">Nivel Básico</label>
        <label class="col-sm-3">Nivel Medio</label>
        <label class="col-sm-3">Nivel Superior</label>
        <label class="col-sm-3">Nivel Avanzado</label>
        <div class="row">
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNBasico" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNMedio" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNSuperior" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNAvanzado" runat="server" rows="8"></textarea>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn-block btn-primary form-control" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
