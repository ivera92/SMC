<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AsociarAsignaturaDocente.aspx.cs" Inherits="CapaDePresentacion.Admin.AsociarAsignaturaDocente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Asociar asignatura a docente</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
        <label">Rut</label>  
            <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" required></asp:TextBox>
        </div>
        <br />
        <div class="col-sm-4">
                <asp:CustomValidator ID="CustomValidator1" runat="server"
                    ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                    Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                </asp:CustomValidator>
            </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <label>Asignatura</label>
            <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddAsignatura" runat="server">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-5 col-sm-2">
            <asp:Button CssClass="btn btn-block btn-primary" runat="server" ID="btnAsociar" Text="Asociar" OnClick="btnAsociar_Click"/>
        </div>
    </div>

</asp:Content>
