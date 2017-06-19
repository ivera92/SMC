<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarEvaluaciones.aspx.cs" EnableEventValidation="false" Inherits="CapaDePresentacion.Admin.AdministrarEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Administrar evaluaciones</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-2 col-sm-6">
            <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre de asignatura o evaluacion" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-12">
            <asp:GridView class="table table-striped" ID="gvEvaluaciones" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting"
                PageSize="10" AllowPaging="true" OnPageIndexChanging="gvEvaluaciones_PageIndexChanging" OnRowCommand="gvEvaluaciones_RowCommand">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No existen evaluaciones!
                </EmptyDataTemplate>
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="true"/>
                    <asp:BoundField DataField="Nombre_evaluacion" HeaderText="Evaluacion" />
                    <asp:BoundField DataField="Asignatura_evaluacion.Nombre_asignatura" HeaderText="Asignatura" />                    
                    <asp:BoundField DataField="Fecha_evaluacion" HeaderText="Fecha" DataFormatString="{0:d}" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="~/imagenes/pdf.png" CommandName="imgBtnPDF" ControlStyle-CssClass="BotonDeImagen" HeaderText="PDF">
                        <ControlStyle CssClass="BotonDeImagen" Width="40" Height="40" />
                    </asp:ButtonField>

                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
