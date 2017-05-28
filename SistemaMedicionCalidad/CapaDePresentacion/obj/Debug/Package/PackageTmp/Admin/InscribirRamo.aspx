<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="InscribirRamo.aspx.cs" Inherits="CapaDePresentacion.Admin.InscribirRamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Inscribir ramo</h2>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Rut</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Asignatura</label>
        <div class="col-sm-4">
            <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddAsignatura" runat="server">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-5 col-sm-2">
            <asp:Button CssClass="btn btn-block btn-primary" runat="server" ID="btnInscribir" Text="Inscribir" OnClick="btnInscribir_Click" />
        </div>
    </div>
</asp:Content>
