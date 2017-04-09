<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.Alum.CambiarClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Cambiar contraseña</h2>
    <br />

    
    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Contraseña Actual</label>
        <div class="col-sm-4">
            <asp:TextBox id="txtPwActual" runat="server" class="form-control col-sm-" placeHolder="Ingrese contraseña actual" TextMode="Password"></asp:TextBox>
        </div>
    </div>    
    <br />
    
    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Nueva contraseña</label>
        <div class="col-sm-4">
            <asp:TextBox id="txtPwNueva1" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nueva contraseña" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />
    
    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Repita la contraseña</label>
        <div class="col-sm-4">
            <asp:TextBox id="txtPwNueva2" runat="server" class="form-control col-sm-4" placeHolder="Ingrese nuevamente la contraseña"  TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-5 col-sm-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-block  btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>

</asp:Content>
