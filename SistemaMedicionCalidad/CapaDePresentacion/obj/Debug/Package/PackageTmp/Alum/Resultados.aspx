<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="CapaDePresentacion.Alum.Resultados" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div style="border: solid 1px #ccc">
                <asp:Image ID="rEvaluacion" runat="server" ImageUrl="ImagenesAlumno/rEvaluacion.PNG" />
                <div class="col-sm-4">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddAsignatura" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-3">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddEvaluacion" runat="server">
                        <asp:ListItem Value="0">Seleccione una Evaluación</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-3">
                    <br />
                    <label>Resultados</label>
                    <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddOpcion" runat="server">
                        <asp:ListItem Value="0">Seleccione Resultado</asp:ListItem>
                        <asp:ListItem Value="1">Revisar Evaluación</asp:ListItem>
                        <asp:ListItem Value="2">Ver Notas del Curso</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-2">
                    <br />
                    <br />
                    <asp:Button ID="btnGraficar" runat="server" Text="Ver" CssClass="btn btn-block" BackColor="Orange" BorderColor="White" ForeColor="White" OnClick="btnGraficar_Click" />
                </div>

                <div class="col-sm-12">
                    <asp:Panel ID="panelGraficoColumna" runat="server">
                        <br />
                        <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="970px" Height="505px">
                            <Series>
                                <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1"></asp:Series>
                                <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom" ItemColumnSpacing="350">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                                </asp:Title>
                            </Titles>
                            <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                        </asp:Chart>
                        <br />
                    </asp:Panel>
                    <br />
                </div>
                <div class="col-sm-12">
                    <asp:Panel ID="panelGrafico" runat="server">


                        <asp:Chart ID="chartPuntos" runat="server" CssClass="center-block" Width="970px" Height="505px">
                            <Series>
                                <asp:Series ChartArea="ChartArea1" Color="Green" Name="Tu Nota" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="Point">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" Name="Aprobado" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="Point" YValuesPerPoint="4"></asp:Series>
                                <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Reprobado" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="Point" XValueType="Double" YValuesPerPoint="4">
                                </asp:Series>
                                <asp:Series ChartArea="ChartArea1" Color="Orange" Name="Promedio Curso" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="Point" XValueType="Double" YValuesPerPoint="4">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Docking="Right" Name="Legend1" Font="Segoe UI, 10pt" IsTextAutoFit="False" Alignment="Near" BorderColor="Black">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Nota Alumnos">
                                </asp:Title>
                                <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Cantidad de Alumnos" BackImageAlignment="Center">
                                </asp:Title>
                            </Titles>
                            <BorderSkin BackColor="Orange" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                        </asp:Chart>
                        <br />
                    </asp:Panel>
                </div>
                <div class="col-sm-12">
                    <asp:GridView ID="gvDesempenos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="orange" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="id_desempeno" HeaderText="ID" />
                            <asp:BoundField DataField="indicador_desempeno" HeaderText="Desempeño" />
                            <asp:BoundField DataField="nombre_nivel" HeaderText="Nivel" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
                    <br />

                    <div class="text-center">
                        <label id="lblnEvaluacion" runat="server"></label>
                    </div>
                    <br />
                    <div class="text-center">
                        <label id="lblNota" runat="server"></label>
                    </div>
                    <div class="text-center">
                        <label id="lblCorrectas" runat="server"></label>
                    </div>
                    <div class="text-center">
                        <label id="lblIncorrectas" runat="server"></label>
                    </div>
                    <br />
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAlumno/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>

