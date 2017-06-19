<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearDesempeno.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearDesempeno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCrear" runat="server">
        <h2 class="text-center">Crear Desempeño</h2>
        <br />

        <div class="row">
            <div class="col-sm-6">
                <label>Indicador de desempeño</label>
                <asp:TextBox ID="txtIndicador" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm-6">
                <label>Competencia</label>
                <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddCompetencia" class="form-control">
                    <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />

        <div class="row">
            <div class="col-sm-3">
                <label>Nivel Básico</label>
                <textarea class="form-control" id="txtNBasico" runat="server" rows="10" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Medio</label>
                <textarea class="form-control" id="txtNMedio" runat="server" rows="10" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Superior</label>
                <textarea class="form-control" id="txtNSuperior" runat="server" rows="10" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Avanzado</label>
                <textarea class="form-control" id="txtNAvanzado" runat="server" rows="10"></textarea>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn-block btn-primary form-control" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
