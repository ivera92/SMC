<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearDesempeno.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearDesempeno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divCrear" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cDesempeno" runat="server" ImageUrl="ImagenesAdmin/cDesempeño.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-6">
                    <br />
                    <label>Competencia a la que pertenece</label>
                    <asp:DropDownList runat="server" AppendDataBoundItems="true" ID="ddCompetencia" class="form-control">
                        <asp:ListItem Value="0">Seleccione una competencia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-6">
                    <br />
                    <label>Indicador de desempeño</label>
                    <asp:TextBox ID="txtIndicador" runat="server" CssClass="form-control" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Indicador de Desempeño"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>                

                <div class="col-sm-3">
                    <label>Nivel Básico</label>
                    <textarea class="form-control" id="txtNBasico" runat="server" rows="10" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Básico de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Medio</label>
                    <textarea class="form-control" id="txtNMedio" runat="server" rows="10" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Medio de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Superior</label>
                    <textarea class="form-control" id="txtNSuperior" runat="server" rows="10" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Superior de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Avanzado</label>
                    <textarea class="form-control" id="txtNAvanzado" runat="server" rows="10" placeHolder="Ingrese Nivel Avanzado de Competencia en caso de ser necesario"></textarea>
                </div>

                <div class="col-sm-offset-5 col-sm-2">
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn-block btn-success form-control" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
