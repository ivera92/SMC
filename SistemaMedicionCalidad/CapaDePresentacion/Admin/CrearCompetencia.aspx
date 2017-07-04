<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="crear" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cCompetencia" runat="server" ImageUrl="ImagenesAdmin/cCompetencia.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-6">
                    <br />
                    <label>Ambito</label>
                    <asp:DropDownList ID="ddAmbito" AppendDataBoundItems="true" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione ambito</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-6">
                    <br />
                    <label>Tipo</label>
                    <asp:DropDownList ID="ddTipoCompetencia" AppendDataBoundItems="true" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione un tipo de competencia</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-6">
                    <br />
                    <label>Nombre</label>
                    <textarea class="form-control" id="txtNombre" runat="server" rows="3" type="text" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese nombre de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                    <br />
                </div>
                <div class="col-sm-6">
                    <br />
                    <label>Indicador de Desempeño</label>
                    <textarea class="form-control" id="txtIndicador" runat="server" rows="3" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Indicador de Desempeño"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                    <br />
                </div>

                <div class="col-sm-3">
                    <label>Nivel Básico</label>
                    <textarea class="form-control" id="txtNBasico" runat="server" rows="6" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Básico de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Medio</label>
                    <textarea class="form-control" id="txtNMedio" runat="server" rows="6" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Medio de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Superior</label>
                    <textarea class="form-control" id="txtNSuperior" runat="server" rows="6" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,}(([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\,][\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})?([\-][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1})?)+)$" placeHolder="Ingrese Nivel Superior de Competencia"
                        oninvalid="setCustomValidity('Solo letras, separada por un espacio, coma y espacio, o dos palabras juntas por un guión')"
                        oninput="setCustomValidity('')" required></textarea>
                </div>
                <div class="col-sm-3">
                    <label>Nivel Avanzado</label>
                    <textarea class="form-control" id="txtNAvanzado" runat="server" rows="6" placeHolder="Ingrese Nivel Avanzado de Competencia en caso de ser necesario"></textarea>
                    <br />
                </div>

                <div class="col-sm-offset-1 col-sm-4">
                    <asp:Button ID="brnCrear" class="btn btn-success btn-block" runat="server" Text="Crear y salir" OnClick="brnCrear_Click" />
                </div>
                <div class="col-sm-offset-2 col-sm-4">
                    <asp:Button ID="btnSeguir" class="btn btn-success btn-block" runat="server" Text="Crear y seguir asignando desempeños" OnClick="btnSeguir_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
