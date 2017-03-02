<%@ Page Language="C#" MasterPageFile="~/Admin/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="crear" runat="server">
    <h2 class="text-center">Crear Competencia</h2>
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
            <textarea class="form-control" id="descripcion" runat="server" rows="5"></textarea>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1">
            <label>Tipo</label>
        </div>
        <div class="col-sm-3">
            <asp:RadioButtonList ID="tipoCompetencia" runat="server">
            <asp:ListItem Selected="True" Value="Generica"></asp:ListItem>
            <asp:ListItem Value="Especifica"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2">
            <asp:Button  ID="brnCrear" class="btn btn-primary btn-block btn-lg" runat="server" Text="Crear" onclick="brnCrear_Click"/>
        </div>
    </div>
    </div>
</asp:Content>
