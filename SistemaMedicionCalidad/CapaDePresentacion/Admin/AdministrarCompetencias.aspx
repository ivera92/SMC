<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarCompetencias.aspx.cs" Inherits="CapaDePresentacion.AdministrarCompetencias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMostrar" runat="server">

    <h2 class="text-center">Administrar Competencias</h2>
    <br />
    <div class ="row">
        <div class="col-sm-offset-2 col-sm-8">
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

<div id="divEditar" runat="server">
    <h2 class="text-center">Actualizar Competencia</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1">
            <label>Nombre</label>
        </div>
        <div class="col-sm-5">
            <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre" ></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1">
            <label>Descripcion</label>
        </div>
        <div class="col-sm-5">
            <textarea class="form-control" id="txtADescripcion" runat="server" rows="5"></textarea>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1">
            <label>Tipo</label>
        </div>
        <div class="col-sm-3">
            <asp:RadioButtonList ID="rbTipoCompetencia" runat="server">
            <asp:ListItem Selected="True" Value="Generica"></asp:ListItem>
            <asp:ListItem Value="Especifica"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2">
            <asp:Button  ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
        </div>
    </div>
    </div>
</asp:Content>
