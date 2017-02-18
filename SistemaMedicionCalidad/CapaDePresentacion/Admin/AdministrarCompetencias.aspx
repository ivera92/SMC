<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarCompetencias.aspx.cs" Inherits="CapaDePresentacion.AdministrarCompetencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMostrar" runat="server">

    <h2>Administrar Competencias</h2>
    <br />
    <div class ="row">
        <div class="col-sm-8">
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
            <asp:TextBox runat="server" ID="txtCompetencia"></asp:TextBox>
    </div>
</div>

<div id="editar" runat="server">
    <h2>Editar Competencia</h2>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <label>Nombre</label>
        </div>
        <div class="col-sm-2">
            <label>Tipo</label>
        </div>
        <div class="col-sm-6">
            <label>Descripcion</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre" required></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:RadioButtonList ID="tipoCompetencia" runat="server">
            <asp:ListItem Selected="True" Value="Generica"></asp:ListItem>
            <asp:ListItem Value="Especifica"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-4">
            <textarea id="descripcion" runat="server" cols="20" rows="2"></textarea>
        </div>
        <div class="col-sm-2">
            <asp:Button  ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
        </div>
    </div>     
</div>

</asp:Content>
