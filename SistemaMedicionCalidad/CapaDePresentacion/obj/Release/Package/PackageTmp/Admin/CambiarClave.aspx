<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Cambiar contraseña</h2>
    <br />

    <label class="col-sm-offset-4">Contraseña Actual</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwActual" runat="server" class="form-control col-sm-4" placeHolder="Ingrese contraseña actual" TextMode="Password" MaxLength="10"></asp:TextBox>
        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "pwActual" ID="re1" ValidationExpression = "^[\s\S]{6,10}$" runat="server" ErrorMessage="La contraseña debe tener un minimo de 6 caracteres y un maximo de 10."></asp:RegularExpressionValidator>
        <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />
        </div>
    </div>    
    <br />

    <label class="col-sm-offset-4">Nueva contraseña</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwNueva1" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nueva contraseña" TextMode="Password" MaxLength="10"></asp:TextBox>
            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "pwNueva1" ID="re2" ValidationExpression = "^[\s\S]{6,10}$" runat="server" ErrorMessage="La contraseña debe tener un minimo de 6 caracteres y un maximo de 10."></asp:RegularExpressionValidator>
            <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Repita la contraseña</label>
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox id="pwNueva2" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nuevamente la contraseña" TextMode="Password" MaxLength="10"></asp:TextBox>
            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "pwActual" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{6,10}$" runat="server" ErrorMessage="La contraseña debe tener un minimo de 6 caracteres y un maximo de 10."></asp:RegularExpressionValidator>
            <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" />
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-block  btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
