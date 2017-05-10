<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
        <br />
        <br />
        <h2 class="text-center">Crear Escuela</h2>
        <br />

        <div class="row">
            <label class="col-sm-offset-2 col-sm-1">Nombre</label>
            <div class="col-sm-5">
                <asp:TextBox ID="tbxEscuela" class="form-control" runat="server" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre">
                </asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btbCrear" class="btn btn-primary btn-block" runat="server" Text="Crear"
                    OnClick="btbCrear_Click" />

                <br />
            </div>
        </div>

    </div>
</asp:Content>
