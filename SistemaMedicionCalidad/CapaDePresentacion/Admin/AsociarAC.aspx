<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="AsociarAC.aspx.cs" Inherits="CapaDePresentacion.Admin.AsociarAC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Asociando Competencia a Asignatura</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-2">
            <label>Asignatura</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList CssClass="form-control" ID="ddAsignatura" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-2">
            <label>Competencia</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList CssClass="form-control" ID="ddCompetencia" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-6 col-sm-2">
            <asp:Button CssClass="btn btn-block btn-primary" runat="server" ID="btnAsociar" Text="Asociar" OnClick="btnAsociar_Click" />
        </div>
    </div>

</asp:Content>
