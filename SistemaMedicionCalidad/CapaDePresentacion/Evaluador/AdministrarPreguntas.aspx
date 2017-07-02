<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="AdministrarPreguntas.aspx.cs" Inherits="CapaDePresentacion.Evaluador.AdministrarPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="administrar" class="row">
        <div class="col-sm-12">
            <asp:Image ID="aPreguntas" runat="server" ImageUrl="ImagenesEvaluador/aPreguntas.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-offset-2 col-sm-6">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese indicador de desempeño, enunciado o nivel" CssClass="form-control"></asp:TextBox>
                    <br />
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
                    <br />
                </div>

                <div class="col-sm-12">
                    <asp:GridView class="table table-striped" ID="gvPreguntas" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting"
                        OnRowEditing="rowEditing" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvPreguntas_PageIndexChanging" OnRowCommand="gvPreguntas_RowCommand">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen preguntas!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" HeaderText="Accion" />
                            <asp:ButtonField ButtonType="Button" CommandName="activo" ControlStyle-CssClass="btnActivo" Text="Cambiar estado" HeaderText="Cambiar Estado">
                                <ControlStyle CssClass="btnActivo form-control btn-primary" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Id_pregunta" HeaderText="ID" />
                            <asp:BoundField DataField="Enunciado_pregunta" HeaderText="Enunciado" />
                            <asp:BoundField DataField="id_desempeno.indicador_desempeno" HeaderText="Desempeño" />
                            <asp:BoundField DataField="Nivel_pregunta.nombre_nivel" HeaderText="Nivel" />
                            <asp:BoundField DataField="estado" HeaderText="Estado" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesEvaluador/iEndSM12.PNG" />
        </div>
    </div>

    <div runat="server" id="editar" class="row">
        <div class="col-sm-12">
            <asp:Image ID="acPregunta" runat="server" ImageUrl="ImagenesEvaluador/acPregunta.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-6">
                    <br />
                    <label>Desempeño</label>
                    <asp:DropDownList class="form-control" runat="server" ID="ddDesempeno" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddDesempeno_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un desempeño</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-6">
                    <br />
                    <label>Nivel</label>
                    <asp:DropDownList class="form-control" runat="server" ID="ddNivel">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-6">
                    <label>Enunciado</label>
                    <textarea class="form-control" id="txtAPregunta" runat="server" rows="8"></textarea>
                    <br />
                </div>

                <div runat="server" id="AltOCas">
                    <label>Respuestas</label>
                    <label class="col-sm-offset-4">Correcta</label>
                    <br />
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <br />
                </div>

                <div runat="server" id="VoF">
                    <label>Respuestas</label>
                    <label class="col-sm-offset-4">Correcta</label>
                    <br />
                    <div class="col-sm-3">
                        <label id="lblV" runat="server">Verdadero</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:CheckBox ID="cbV" runat="server" />
                    </div>
                    <br />

                    <div class="col-sm-3">
                        <label id="lblF" runat="server">Falso</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:CheckBox ID="cbF" runat="server" />
                    </div>
                    <br />
                </div>
                <div class="col-sm-2">
                    <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click1" />
                <br />
                </div>
            </div>
            <asp:Image ID="iEndSM122" runat="server" ImageUrl="ImagenesEvaluador/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
