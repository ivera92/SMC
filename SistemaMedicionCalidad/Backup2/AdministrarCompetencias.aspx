<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarCompetencias.aspx.cs" Inherits="CapaDePresentacion.AdministrarCompetencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="form-group">
    <h2>Administrar Competencias</h2>
    <br />
    <asp:GridView class="table table-striped" ID="gvCompetencias" runat="server" AutoGenerateColumns="false" 
        onrowdeleting="rowDeleting" onrowediting="rowEditing">
        <Columns>
        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
        <asp:BoundField DataField="Nombre_Competencia" HeaderText="Nombre" />
        <asp:BoundField DataField="Tipo_Competencia" HeaderText="Tipo" />
        <asp:BoundField DataField="Id_Competencia" HeaderText="Id" />
        </Columns>
    </asp:GridView>
</div>


</asp:Content>
