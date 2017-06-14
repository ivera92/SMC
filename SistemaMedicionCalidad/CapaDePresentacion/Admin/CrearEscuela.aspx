<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
        <h2 class="text-center">Crear Escuela</h2>
        <br />

        <label class="col-sm-offset-3">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:TextBox ID="tbxEscuela" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese nombre de escuela" required>
                </asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btbCrear" class="btn btn-primary btn-block" runat="server" Text="Crear"
                    OnClick="btbCrear_Click" />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
