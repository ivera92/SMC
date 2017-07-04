<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarDesempeno.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarDesempeno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="tablaAdministrar" runat="server" class="row">

        <div class="col-sm-12">
            <asp:Image ID="ADesenpeños" runat="server" ImageUrl="ImagenesAdmin/aDesempeños.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese indicador de desempeño" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvDesempenos" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                        OnRowDeleting="rowDeleting" OnRowEditing="rowEditing" OnPageIndexChanging="gvDesempenos_PageIndexChanging">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen desempeños!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Id_desempeno" HeaderText="ID" />
                            <asp:BoundField DataField="Indicador_Desempeno" HeaderText="Indicador de desempeño" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            </div>
            <asp:Image ID="iEnd12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>

    <div id="divEditar" runat="server" class="row">

        <div class="col-sm-12">
            <asp:Image ID="aDesempeños" runat="server" ImageUrl="ImagenesAdmin/acDesempeño.PNG" />
            <div>
                <div class="col-sm-6">
                    <br />
                    <label>Competencia</label>
                    <asp:DropDownList runat="server" ID="ddCompetencia" class="form-control">
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
                    <textarea class="form-control" id="txtNAvanzado" runat="server" rows="10" placeHolder="Ingrese Nivel Avanzado de Competencia en caso de ser necesario">></textarea>
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
