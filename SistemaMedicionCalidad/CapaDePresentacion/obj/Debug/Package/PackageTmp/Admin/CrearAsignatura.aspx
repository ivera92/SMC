<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearAsignatura.aspx.cs" Inherits="CapaDePresentacion.CrearAsignatura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="crear" runat="server" class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cAsignatura" runat="server" ImageUrl="ImagenesAdmin/cAsignatura.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Codigo</label>
                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" pattern="(([a-zA-Z]{4}[0123456789]{3})*([a-zA-Z]{5}[0123456789]{2})*){7}"
                        placeHolder="Ingrese codigo, ejemplo CIBA019" oninvalid="setCustomValidity('El codigo debe tener 4 letras seguidas de 3 numeros o 5 letras y 2 numeros, maximo 7 caracteres')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Escuela</label>
                    <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddEscuela" class="form-control">
                        <asp:ListItem Value="0">Seleccione una escuela</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{5,})([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ0123456789]{1,})*" placeHolder="Ingrese nombre"
                        oninvalid="setCustomValidity('Primera palabra minimo 5 letras, separada de un espacio, seguido o no de uno o mas numeros o letras')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-6">
                    <label>Duracion</label>
                    <asp:RadioButtonList ID="rbDuracion" runat="server">
                        <asp:ListItem Selected="True" Value="0">Semestral</asp:ListItem>
                        <asp:ListItem Value="1">Anual</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-6">
                    <br />
                    <asp:Button ID="btnCrear" class="btn btn-success btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                    <br />
                </div>
                <br />
            </div>
            <asp:Image ID="cAsignaturaEnd" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
