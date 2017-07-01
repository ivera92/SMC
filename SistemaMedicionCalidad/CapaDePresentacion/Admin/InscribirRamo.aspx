<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="InscribirRamo.aspx.cs" Inherits="CapaDePresentacion.Admin.InscribirRamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cAlumno" runat="server" ImageUrl="ImagenesAdmin/iAA.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Rut</label>
                    <asp:TextBox ID="txtRut" runat="server" CssClass="form-control" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox>
                </div>
                <div>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                        Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                    </asp:CustomValidator>
                    <br />
                </div>

                <div>
                    <label>Asignatura</label>
                    <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddAsignatura" runat="server">
                        <asp:ListItem Value="0">Seleccione una asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <asp:Button CssClass="btn btn-block btn-success" runat="server" ID="btnInscribir" Text="Inscribir" OnClick="btnInscribir_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
