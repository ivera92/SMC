<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.Alum.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Cambiar contraseña</h2>
    <br />
    <label id="lblRut" runat="server"></label>

    <label>Contraseña Actual</label>
    <div class="row">
        <div class="col-sm-4">
            <asp:TextBox id="pwActual" runat="server" class="form-control col-sm-4" placeHolder="Ingrese contraseña actual" required TextMode="Password"></asp:TextBox>
        </div>
    </div>    
    <br />

    <label>Nueva contraseña</label>
    <div class="row">
        <div class="col-sm-4">
            <asp:TextBox id="pwNueva1" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nueva contraseña" required TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <label>Repita la contraseña</label>
    <div class="row">
        <div class="col-sm-4">
            <asp:TextBox id="pwNueva2" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nuevamente la contraseña" required TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-block  btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>

</asp:Content>
