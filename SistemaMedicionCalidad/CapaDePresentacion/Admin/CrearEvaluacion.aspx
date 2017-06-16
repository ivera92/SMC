<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearEvaluacion.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .scrolling-table-container {
            height: 378px;
            overflow-y: scroll;
            overflow-x: hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Crear Evaluacion</h2>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <label>Asignatura</label>
            <div>
                <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                    <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-sm-4">
            <label>Tipo Evaluacion</label>
            <div>
                <asp:DropDownList runat="server" ID="ddTipoEvaluacion" class="form-control" AutoPostBack="true" AutoGenerateColumns="False" AppendDataBoundItems="true" OnSelectedIndexChanged="ddTipoEvaluacion_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione tipo de evaluacion--></asp:ListItem>
                    <asp:ListItem Value="1">Todas las preguntas</asp:ListItem>
                    <asp:ListItem Value="2">15 Aleatorias</asp:ListItem>
                    <asp:ListItem Value="3">30 Aleatorias</asp:ListItem>
                    <asp:ListItem Value="4">Seleccionar preguntas manualmente</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-sm-4">
            <label>Nombre Evaluacion</label>
            <div>
                <asp:TextBox runat="server" ID="txtNombre" class="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <div id="divGV" runat="server">
        <div class="row">
            <div class="col-sm-12 scrolling-table-container">
                <asp:GridView class="table table-striped small-top-margin" ID="gvPreguntas" AutoGenerateColumns="False" runat="server">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSeleccionado" runat="server" Style="position: static" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Id_Pregunta" HeaderText="Id" />
                        <asp:BoundField DataField="id_desempeno.indicador_desempeno" HeaderText="Desempeno" />
                        <asp:BoundField DataField="Tipo_Pregunta_Pregunta.nombre_tipo_pregunta" HeaderText="Tipo Pregunta" />
                        <asp:BoundField DataField="Enunciado_Pregunta" HeaderText="Enunciado" />
                        <asp:BoundField DataField="Nivel_Pregunta.nombre_nivel" HeaderText="Nivel" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="GridPager" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen Preguntas!
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-5">
            <label id="nombreAlumno" runat="server" visible="false">Nombre:</label>
        </div>
        <div class="col-sm-2">
            <label id="rut" runat="server" visible="false">Rut:</label>
        </div>
        <div class="col-sm-2">
            <label id="fecha" runat="server" visible="false">Fecha:</label>
        </div>
        <div class="col-sm-1">
            <label id="fechaEvaluacion" runat="server" visible="false">:</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button runat="server" ID="btnCrear" class="btn btn-primary btn-block" Text="Crear" OnClick="btnCrear_Click1" />
        </div>
    </div>
    <br />
</asp:Content>
