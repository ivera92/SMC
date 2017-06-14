<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarCursa.aspx.cs" Inherits="CapaDePresentacion.AdministrarCursa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2 class="text-center">Asignaturas inscritas</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese alumno o asignatura a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvCursa" runat="server" AutoGenerateColumns="false"
                    OnPageIndexChanging="gvCursa_PageIndexChanging"
                    PageSize="10" AllowPaging="true" OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen asignaturas inscritas!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" />
                        <asp:BoundField DataField="rut_alumno_aa.nombre_persona" HeaderText="Alumno" />                        
                        <asp:BoundField DataField="cod_asignatura_aa.nombre_asignatura" HeaderText="Asignatura" />
                    </Columns>
                    <PagerStyle HorizontalAlign = "Right" CssClass ="pagination-ys" />
                </asp:GridView>
            </div>
            <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
        </div>

</asp:Content>
