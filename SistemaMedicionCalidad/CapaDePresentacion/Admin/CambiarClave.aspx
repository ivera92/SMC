<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Cambiar contraseña</h2>
    <br />

    <label class="col-sm-offset-4">Contraseña Actual</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwActual" runat="server" class="form-control col-sm-4" placeHolder="Ingrese contraseña actual" TextMode="Password"></asp:TextBox>
        </div>
    </div>    
    <br />

    <label class="col-sm-offset-4">Nueva contraseña</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwNueva1" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nueva contraseña" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Repita la contraseña</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwNueva2" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nuevamente la contraseña" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-block  btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
