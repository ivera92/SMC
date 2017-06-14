<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAsignaturasAsociadas.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarAsignaturasAsociadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Asignaturas asociadas</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese docente o asignatura a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvImparte" runat="server" AutoGenerateColumns="false"
                    OnPageIndexChanging="gvImparte_PageIndexChanging"
                    PageSize="10" AllowPaging="true" OnRowDeleting="rowDeleting">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen asignaturas asociadas!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
                        <asp:BoundField DataField="id_imparte" HeaderText="ID" />  
                        <asp:BoundField DataField="rut_docente_imparte.nombre_persona" HeaderText="Docente" />                        
                        <asp:BoundField DataField="cod_asignatura_imparte.nombre_asignatura" HeaderText="Asignatura" />
                    </Columns>
                    <PagerStyle HorizontalAlign = "Right" CssClass ="pagination-ys" />
                </asp:GridView>
            </div>
            <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
        </div>

</asp:Content>
