<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEvaluaciones.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEG" runat="server" ImageUrl="ImagenesAdmin/rEG.PNG" />
            <div style="border: solid 1px #ccc">
                <div id="divBotones" runat="server">
                    <br />
                    <div class="col-sm-4 col-sm-offset-2">
                        <asp:Button ID="btnAsignatura" runat="server" Text="Resultados por Asignatura" CssClass="form-control btn-info" OnClick="btnAsignatura_Click" />
                    </div>
                    <div class="col-sm-4">
                        <asp:Button ID="btn" runat="server" Text="Resultados por Evaluación" CssClass="form-control btn-primary" OnClick="btn_Click" />
                    </div>
                </div>
                <div id="divRAsignatura" runat="server" class="col-sm-4">
                    <div runat="server" id="divAsignatura" class="col-sm-12">
                        <br />
                        <label>Asignatura</label>
                        <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div runat="server" id="divEvaluacion" class="col-sm-12">
                        <br />
                        <label>Evaluación</label>
                        <asp:DropDownList ID="ddEvaluacion" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Text="Seleccione Evaluación" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div runat="server" id="divTipoGrafico" class="col-sm-12">
                        <br />
                        <label>Resultados</label>
                        <asp:DropDownList ID="ddTipo" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddTipo_SelectedIndexChanged">
                            <asp:ListItem Text="Seleccione Resultados" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Competencias" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Desempeños" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Desempeños 2 Generaciones" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Notas" Value="4"></asp:ListItem>
                            <asp:ListItem Value="5">Un alumno</asp:ListItem>
                            <asp:ListItem Value="6">Otros Resultados</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-sm-12" id="divAno1" runat="server">
                        <br />
                        <label>Año 1</label>
                        <asp:DropDownList ID="ddAno1" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12" id="divAno2" runat="server">
                        <br />
                        <label>Año 2</label>
                        <asp:DropDownList ID="ddAno2" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12" id="divRut" runat="server">
                        <br />
                        <label>Rut Alumno</label>
                        <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                            ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                            Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                        </asp:CustomValidator>
                    </div>

                    <div runat="server" id="divBtnGraficar" class="col-sm-12">
                        <br />
                        <asp:Button runat="server" ID="btnGraficar" CssClass="form-control btn-info btn-block" Text="Ver Resultados" OnClick="btnGraficar_Click" />
                    </div>

                    <div class="col-sm-12">
                        <br />
                        <asp:Button runat="server" ID="btnExportar" CssClass="form-control btn-success btn-block" Text="Exportar a Excel" OnClick="btnExportar_Click" />
                    </div>
                </div>
                <div id="divRA" runat="server" class="col-sm-4">
                    <div runat="server" id="divDDA" class="col-sm-12">
                        <br />
                        <br />
                        <br />
                        <br />
                        <label>Asignatura</label>
                        <asp:DropDownList ID="ddAsignatura2" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div runat="server" id="divResultado" class="col-sm-12">
                        <br />
                        <label>Resultados</label>
                        <asp:DropDownList ID="ddResultado" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddResultado_SelectedIndexChanged">
                            <asp:ListItem Text="Seleccione Resultados" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Competencias" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Desempeños" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-12">
                        <br />
                        <asp:Button runat="server" ID="btnVerR" CssClass="form-control btn-success btn-block" Text="Ver Resultados" OnClick="btnVerR_Click"/>
                    </div>
                </div>
                <div class="col-sm-8" id="divCC" runat="server">
                    <br />
                    <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="650px" Height="405px">
                        <Series>
                            <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn"></asp:Series>
                            <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 9.75pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Desempeños">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                </div>

                <div class="col-sm-8" id="divDesempeñosAsignatura" runat="server">
                    <br />
                    <asp:Chart ID="chartDesempeñosAsignatura" runat="server" CssClass="center-block" Width="650px" Height="405px">
                        <Series>
                            <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn"></asp:Series>
                            <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 9.75pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Desempeños">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                </div>

                <div class="col-sm-8" id="divCCompe" runat="server">
                    <br />
                    <asp:Chart ID="chartCompe" runat="server" CssClass="center-block" Width="650px" Height="405px">
                        <Series>
                            <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn"></asp:Series>
                            <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 9.75pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Competencias">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                </div>

                <div class="col-sm-8" id="divCompetenciasAsignatura" runat="server">
                    <br />
                    <asp:Chart ID="chartCompetenciasAsignatura" runat="server" CssClass="center-block" Width="650px" Height="405px">
                        <Series>
                            <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn"></asp:Series>
                            <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 9.75pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Competencias">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                </div>

                <div class="col-sm-8" id="divCP" runat="server">
                    <br />
                    <asp:Chart ID="chartPuntos" runat="server" CssClass="center-block" Width="650px" Height="405px">
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
                            <asp:Legend Docking="Right" Name="Legend1" Font="Segoe UI, 10pt" IsTextAutoFit="False" Alignment="Near" BorderColor="Black">
                            </asp:Legend>
                        </Legends>
                        <Titles>
                            <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Nota Alumnos">
                            </asp:Title>
                            <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Cantidad de Alumnos" BackImageAlignment="Center">
                            </asp:Title>
                        </Titles>
                        <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                    </asp:Chart>
                    <br />
                </div>

                <div class="col-sm-8" id="div2Generaciones" runat="server">
                    <asp:Panel ID="panelGrafico" runat="server">
                        <asp:Chart ID="chart2Generaciones" runat="server" CssClass="center-block" Width="650px" Height="405px">
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                            <Legends>
                                <asp:Legend Docking="Right" Name="Legend1" Font="Segoe UI, 10pt" IsTextAutoFit="False" Alignment="Near" BorderColor="Black" Title="Generaciones" TitleFont="Segoe UI, 10pt">
                                </asp:Legend>
                            </Legends>
                            <Titles>
                                <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Promedio por Desempeño de Generacion">
                                </asp:Title>
                                <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Desempeños" BackImageAlignment="Center">
                                </asp:Title>
                            </Titles>
                            <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                        </asp:Chart>
                        <br />
                    </asp:Panel>
                </div>

                <div id="divAlumno" runat="server">
                    <div class="col-sm-8">
                        <br />
                        <asp:Panel ID="panelGraficoColumna" runat="server">
                            <asp:Chart ID="chartColumnaAE" runat="server" CanResize="true" CssClass="table  table-bordered table-condensed table-responsive" Width="650px" Height="405px">
                                <Series>
                                    <asp:Series Name="Correctas" Color="#4F81BC" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn"></asp:Series>
                                    <asp:Series ChartArea="ChartArea1" Color="#C0504E" Name="Incorrectas" IsValueShownAsLabel="True" IsXValueIndexed="True" Legend="Legend1" ChartType="StackedColumn">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </ChartAreas>
                                <Legends>
                                    <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 10pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                                    </asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                                    </asp:Title>
                                    <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Desempeños">
                                    </asp:Title>
                                </Titles>
                                <BorderSkin BackColor="ForestGreen" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                            </asp:Chart>
                            <br />
                        </asp:Panel>
                        <br />
                    </div>
                </div>

                <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
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

                <div>
                    <br />
                    <div class="col-sm-8" style="border: solid 2px #ccc; background-color: white" id="divOtrosResultados" runat="server">
                        <br />
                        <div>
                            <label class="col-sm-3">Puntaje mas alto</label>
                            <label class="col-sm-2">Correctas </label>
                            <label id="lblCorrectasMAC" runat="server" class="col-sm-2"></label>
                            <label class="col-sm-2">Incorrectas </label>
                            <label id="lblCorrectasMAI" runat="server" class="col-sm-1"></label>
                            <br />
                            <br />
                        </div>
                        <div>
                            <label class="col-sm-3">Puntaje mas bajo</label>
                            <label class="col-sm-2">Correctas </label>
                            <label id="lblCorrectasMBC" runat="server" class="col-sm-2"></label>
                            <label class="col-sm-2">Incorrectas </label>
                            <label id="lblCorrectasMBI" runat="server" class="col-sm-1"></label>
                            <br />
                            <br />
                        </div>
                        <div>
                            <label class="col-sm-3">Pregunta mejor contestada</label>
                            <div class="col-sm-6">
                                <textarea class="form-control" id="txtAPreguntaMC" runat="server" rows="4" readonly="readonly"></textarea>
                            </div>
                            <label class="col-sm-2">Veces Correcta</label>
                            <label id="lblCorrectasPMC" runat="server" class="col-sm-1"></label>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </div>
                        <div>
                            <label class="col-sm-3">Pregunta peor contestada</label>
                            <div class="col-sm-6">
                                <textarea class="form-control col-sm-3" id="txtAPreguntaPC" runat="server" rows="4" readonly="readonly"></textarea>
                            </div>
                            <label class="col-sm-2">Veces Correcta</label>
                            <label id="lblCorrectasPPC" runat="server" class="col-sm-1"></label>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Rut" HeaderText="Rut" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                            <asp:BoundField DataField="Correctas" HeaderText="Correctas" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Incorrectas" HeaderText="Incorrectas" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Nota" HeaderText="Nota" ItemStyle-HorizontalAlign="Center" />
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
                            <asp:BoundField DataField="nombre_desempeno" HeaderText="Desempeño" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="indicador_desempeno" HeaderText="Indicador" />
                            <asp:BoundField DataField="nombre_nivel" HeaderText="Nivel" />
                        </Columns>
                    </asp:GridView>
                </div>

                <div class="col-sm-12">
                    <asp:GridView ID="gvCompetencias" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Numero" HeaderText="Numero" ItemStyle-HorizontalAlign="Center" />  
                            <asp:BoundField DataField="Competencia" HeaderText="Competencia"/>                            
                            <asp:BoundField DataField="Ambito" HeaderText="Ambito" />
                            <asp:BoundField DataField="Tipo de Competencia" HeaderText="Tipo de Competencia" />
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
