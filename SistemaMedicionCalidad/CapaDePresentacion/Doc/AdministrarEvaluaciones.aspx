<%@ Page Title="" Language="C#" MasterPageFile="~/Doc/SiteDocente.Master" AutoEventWireup="true" CodeBehind="AdministrarEvaluaciones.aspx.cs" EnableEventValidation="false" Inherits="CapaDePresentacion.Doc.AdministrarEvaluaciones" %>

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
                OnRowEditing="rowEditing" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvEvaluaciones_PageIndexChanging" 
                DataKeyNames="nombre_evaluacion">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No existen evaluaciones!
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="PDF">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnPDF" runat="server" CommandName="imgBtnPDF" ImageUrl="~/imagenes/pdf.png"
                                Width="40px" Height="40px" CssClass="center-block" OnClick="btnPDF_Click"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                    <asp:BoundField DataField="Asignatura_evaluacion.Nombre_asignatura" HeaderText="Asignatura" />
                    <asp:BoundField DataField="Nombre_evaluacion" HeaderText="Evaluacion" />
                    <asp:BoundField DataField="Fecha_evaluacion" HeaderText="Fecha" DataFormatString="{0:d}" />                    
                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
