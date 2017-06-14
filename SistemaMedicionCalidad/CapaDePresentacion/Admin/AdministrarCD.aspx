<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarCD.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarCD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMostrar" runat="server">
        <h2 class="text-center">Desempeños asociados a competencias</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese competencia o desempeño a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvCD" runat="server" AutoGenerateColumns="false"
                    OnPageIndexChanging="gvCompetencias_PageIndexChanging"
                    PageSize="10" AllowPaging="true">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen asociaciones entre competencias y desempeños!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="Id_competencia.nombre_competencia" HeaderText="Competencia" />                        
                        <asp:BoundField DataField="Id_desempeno.indicador_desempeno" HeaderText="Desempeno" />
                    </Columns>
                    <PagerStyle HorizontalAlign = "Right" CssClass ="pagination-ys" />
                </asp:GridView>
            </div>
            <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
        </div>
    </div>

</asp:Content>
