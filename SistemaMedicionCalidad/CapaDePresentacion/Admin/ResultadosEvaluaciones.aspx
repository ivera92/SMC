<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEvaluaciones.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEG" runat="server" ImageUrl="ImagenesAdmin/rEG.PNG" />
            <div style="border: solid 1px #ccc">
                <div runat="server" id="divAsignatura" class="col-sm-3">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div runat="server" id="divEvaluacion" class="col-sm-3">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList ID="ddEvaluacion" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Seleccione Evaluación" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div runat="server" id="divTipoGrafico" class="col-sm-2">
                    <br />
                    <label>Tipo Grafico</label>
                    <asp:DropDownList ID="ddTipo" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Seleccione Tipo" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Por Desempeño" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Notas" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div runat="server" id="divBtnGraficar" class="col-sm-2">
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnGraficar" CssClass="form-control btn-info btn-block" Text="Graficar" OnClick="btnGraficar_Click" />
                </div>

                <div class="col-sm-2">
                    <br />
                    <br />
                    <asp:Button runat="server" ID="btnExportar" CssClass="form-control btn-success btn-block" Text="Exportar a Excel" OnClick="btnExportar_Click" />
                </div>

                <div class="col-sm-12" id="divCC" runat="server">
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
                            <asp:Legend Name="Legend1" Alignment="Center" Docking="Bottom" AutoFitMinFontSize="10" Font="Segoe UI, 9.75pt" IsTextAutoFit="False">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                    <br />
                </div>

                <div class="col-sm-12" id="divCP" runat="server">
                    <br />
                    <asp:Chart ID="chartPuntos" runat="server" CssClass="center-block" Width="970px" Height="505px">
                        <Series>
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
                            <asp:Legend Docking="Bottom" Name="Legend1" Font="Segoe UI, 12pt" IsTextAutoFit="False" Alignment="Center">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Nota Alumno">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                    <br />
                </div>

                <div class="col-sm-6 col-sm-offset-3">
                    <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Rut" HeaderText="Rut" />
                            <asp:BoundField DataField="Correctas" HeaderText="Correctas" />
                            <asp:BoundField DataField="Incorrectas" HeaderText="Incorrectas" />
                            <asp:BoundField DataField="Promedio" HeaderText="Promedio" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-sm-12">
                    <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="false" class="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
                            <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" />
                            <asp:BoundField DataField="Correctas" HeaderText="Correctas" />
                            <asp:BoundField DataField="Incorrectas" HeaderText="Incorrectas" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="col-sm-12">
                    <asp:GridView ID="gvResultadosGenerales" runat="server" AutoGenerateColumns="false" class="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="estado_respuesta" HeaderText="Estado" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad de Respuestas" />
                            <asp:BoundField DataField="indicador_desempeno.nombre_desempeno" HeaderText="Desempeño" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="col-sm-12">
                    <asp:GridView ID="gvDesempenos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre_desempeno" HeaderText="Desempeño" />
                            <asp:BoundField DataField="indicador_desempeno" HeaderText="Indicador" />
                            <asp:BoundField DataField="nombre_nivel" HeaderText="Nivel" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
