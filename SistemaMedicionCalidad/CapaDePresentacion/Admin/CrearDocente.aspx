<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/rut.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h2 class="text-center">Crear Docente</h2>
    <br />

    <label class="col-sm-offset-4">Rut</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox>
        </div>
        <div class="col-sm-4">
            <asp:CustomValidator ID="CustomValidator1" runat="server"
                ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True" ForeColor="Red"></asp:CustomValidator>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Nombre</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese su nombre y apellido"
                oninvalid="setCustomValidity('Ingrese un nombre de minimo 3 caracteres y maximo 16, solo letras')"
                oninput="setCustomValidity('')" required></asp:TextBox>
        </div>
    </div>
    <br />    

    <label class="col-sm-offset-4">Correo</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Contrato</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-2">
            <asp:RadioButtonList ID="rbDisponibilidad" runat="server">
                <asp:ListItem Selected="True" Value="0">Part-Time</asp:ListItem>
                <asp:ListItem Value="1">Full-Time</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
    <br />
</asp:Content>
