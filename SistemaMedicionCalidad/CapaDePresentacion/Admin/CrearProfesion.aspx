<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearProfesion.aspx.cs" Inherits="CapaDePresentacion.CrearProfesion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
    <h2 class="text-center">Crear Profesión</h2>
    <br />
   
        <div class="row">
            <label class="col-sm-offset-2 col-sm-1">Nombre</label>
            <div class="col-sm-5">
                <asp:TextBox ID="tbxProfesion" class="form-control" runat="server" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre">
                </asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" 
            onclick="btnCrear_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
