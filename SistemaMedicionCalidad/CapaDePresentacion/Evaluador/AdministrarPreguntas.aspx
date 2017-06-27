<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="AdministrarPreguntas.aspx.cs" Inherits="CapaDePresentacion.Evaluador.AdministrarPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="administrar">
        <h2 class="text-center">Administrar Preguntas</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-6">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese indicador de desempeño, enunciado o nivel" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvPreguntas" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting"
                    OnRowEditing="rowEditing" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvPreguntas_PageIndexChanging" OnRowCommand="gvPreguntas_RowCommand">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen preguntas!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                        <asp:ButtonField ButtonType="Button" CommandName="activo" ControlStyle-CssClass="btnActivo" Text="Cambiar estado">
                            <ControlStyle CssClass="btnActivo form-control btn-danger" />
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
    </div>

    <div runat="server" id="editar">
        <h2 class="text-center">Actualizar Pregunta</h2>
        <br />

        <div class="row">
            <div class="col-sm-6">
                <label>Desempeno</label>
                <asp:DropDownList class="form-control" runat="server" ID="ddDesempeno" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddDesempeno_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione un desempeno--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-6">
                <label>Nivel</label>
                <asp:DropDownList class="form-control" runat="server" ID="ddNivel">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
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
            </div>
        </div>
        <br />
    </div>

</asp:Content>
