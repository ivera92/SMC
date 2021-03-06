﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="CrearEvaluacion.aspx.cs" Inherits="CapaDePresentacion.Evaluador.CrearEvaluacion" %>

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
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="cEvaluacion" runat="server" ImageUrl="ImagenesEvaluador/cEvaluacion.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-3">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-3">
                    <br />
                    <label>Tipo de Evaluación</label>
                    <asp:DropDownList runat="server" ID="ddTipoEvaluacion" class="form-control" AutoPostBack="true" AutoGenerateColumns="False" AppendDataBoundItems="true" OnSelectedIndexChanged="ddTipoEvaluacion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Tipo</asp:ListItem>
                        <asp:ListItem Value="1">Todas las preguntas</asp:ListItem>
                        <asp:ListItem Value="2">15 Aleatorias</asp:ListItem>
                        <asp:ListItem Value="3">30 Aleatorias</asp:ListItem>
                        <asp:ListItem Value="4">Seleccionar preguntas manualmente</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-3">
                    <br />
                    <label>Nombre Evaluación</label>
                    <asp:TextBox runat="server" ID="txtNombre" class="form-control" placeHolder="Ingrese nombre de Evaluación" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{4,}([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ01234567890]{1,})+)$" 
                        oninvalid="setCustomValidity('Ingrese al menos una palabra seguida de un espacio, un numero o otra palabra')" oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>
                <div class="col-sm-2">
                <br />
                <label>Exigencia</label>
                <asp:DropDownList runat="server" ID="ddExigencia" class="form-control" AutoPostBack="true" AutoGenerateColumns="False" AppendDataBoundItems="true" OnSelectedIndexChanged="ddTipoEvaluacion_SelectedIndexChanged">
                    <asp:ListItem Value="50">50%</asp:ListItem>
                    <asp:ListItem Value="60">60%</asp:ListItem>
                    <asp:ListItem Value="70">70%</asp:ListItem>
                    <asp:ListItem Value="80">80%</asp:ListItem>
                    <asp:ListItem Value="90">90%</asp:ListItem>
                    <asp:ListItem Value="100">100%</asp:ListItem>
                </asp:DropDownList>
            </div>
                <div class="col-sm-1">
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnCrear" class="btn btn-primary btn-block" Text="Crear" OnClick="btnCrear_Click1" />
                    <br />
                </div>
                <div id="divGV" runat="server">
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
                                <asp:BoundField DataField="id_desempeno.indicador_desempeno" HeaderText="Desempeño" />
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
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesEvaluador/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
