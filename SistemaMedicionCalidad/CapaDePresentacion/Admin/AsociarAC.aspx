<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AsociarAC.aspx.cs" Inherits="CapaDePresentacion.Admin.AsociarAC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <h2 class="text-center">Asociar competencia a asignatura</h2>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Competencia</label>
        <div class="col-sm-4">
            <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddCompetencia" runat="server">
                <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
            </asp:DropDownList>
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
            <asp:Button CssClass="btn btn-block btn-primary" runat="server" ID="btnAsociar" Text="Asociar" OnClick="btnAsociar_Click" />
        </div>
    </div>

</asp:Content>
