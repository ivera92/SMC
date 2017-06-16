<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarHPA.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarHPA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Administrar evaluaciones</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-2 col-sm-6">
            <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre de alumno o evaluacion" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-12">
            <asp:GridView class="table table-striped" ID="gvHPA" runat="server" AutoGenerateColumns="false" PageSize="15" AllowPaging="true" OnPageIndexChanging="gvHPA_PageIndexChanging">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                <EmptyDataTemplate>
                    ¡No existen datos!
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="alumno_hpa.nombre_persona" HeaderText="Alumno" />
                    <asp:BoundField DataField="id_evaluacion_hpa.nombre_evaluacion" HeaderText="Evaluacion" />                    
                    <asp:BoundField DataField="pregunta_hpa.enunciado_pregunta" HeaderText="Pregunta" />
                    <asp:BoundField DataField="respuesta_hpa.nombre_respuesta" HeaderText="Respuesta"/>
                </Columns>
                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>
