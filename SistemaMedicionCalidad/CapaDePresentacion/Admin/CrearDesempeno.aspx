<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearDesempeno.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearDesempeno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCrear" runat="server">
        <h2 class="text-center">Crear Desempeño</h2>
        <br />

        <label class="col-sm-6">Indicador de desempeño</label>
        <label>Competencia</label>

        <div class="row">
            <div class="col-sm-6">
                <asp:TextBox ID="txtIndicador" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="col-sm-6">
                <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddCompetencia" class="form-control">
                    <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />

        <label class="col-sm-3">Nivel Básico</label>
        <label class="col-sm-3">Nivel Medio</label>
        <label class="col-sm-3">Nivel Superior</label>
        <label class="col-sm-3">Nivel Avanzado</label>
        <div class="row">
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNBasico" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNMedio" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNSuperior" runat="server" rows="8" required></textarea>
            </div>
            <div class="col-sm-3">
                <textarea class="form-control" id="txtNAvanzado" runat="server" rows="8"></textarea>
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
