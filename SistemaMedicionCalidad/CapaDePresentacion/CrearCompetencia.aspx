<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <h2>Crear Competencia</h2>
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
            <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control"></asp:TextBox>
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
            <asp:Button  ID="brnCrear" class="btn btn-primary btn-block btn-lg" runat="server" Text="Crear" onclick="brnCrear_Click"/>
        </div>
    </div>     
</asp:Content>
