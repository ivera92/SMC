<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearAsignatura.aspx.cs" Inherits="CapaDePresentacion.CrearAsignatura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="crear" runat="server">
        <h2 class="text-center">Crear Asignatura</h2>
        <br />

        <label class="col-sm-offset-4">Codigo</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeHolder="Ingrese codigo, ejemplo: CIBA019" required></asp:TextBox>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Escuela</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddEscuela" class="form-control">
                    <asp:ListItem Value="0"><--Seleccione una escuela--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚa-zñáéíóú1234567890]{1}*)+$" placeHolder="Ingrese nombre" required></asp:TextBox>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Duracion</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-2">
                <asp:RadioButtonList ID="rbDuracion" runat="server">
                    <asp:ListItem Selected="True" Value="0">Semestral</asp:ListItem>
                    <asp:ListItem Value="1">Anual</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
