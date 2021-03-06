﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="ResultadosEspecificos.aspx.cs" Inherits="CapaDePresentacion.Evaluador.ResultadosEspecificos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEE" runat="server" ImageUrl="ImagenesEvaluador/rEE.PNG" />
            <div>
                <div class="col-sm-3">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-2">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList ID="ddEvaluacion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione una Evaluación</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-2">
                    <br />
                    <label>Resultados</label>
                    <asp:DropDownList ID="ddOpcion" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddOpcion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Opción</asp:ListItem>
                        <asp:ListItem Value="1">Otros Resultados</asp:ListItem>
                        <asp:ListItem Value="2">Un alumno en específico</asp:ListItem>
                        <asp:ListItem Value="3">Comparar 2 generaciones</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-2" id="divAno1" runat="server">
                    <br />
                    <label>Año 1</label>
                    <asp:DropDownList ID="ddAno1" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-2" id="divAno2" runat="server">
                    <br />
                    <label>Año 2</label>
                    <asp:DropDownList ID="ddAno2" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-2" id="divRut" runat="server">
                    <br />
                    <label>Rut alumno</label>
                    <asp:TextBox ID="txtRut" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                        Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                    </asp:CustomValidator>
                </div>
                <div class="col-sm-1">
                    <br />
                    <br />
                    <asp:Button ID="btnVer" runat="server" Text="Ver" CssClass="form-control btn-block btn-primary" OnClick="btnVer_Click" />
                </div>

                <div class="row" id="divOtrosResultados" runat="server">
                    <div class="col-sm-10 col-sm-offset-1" style="border: solid 2px #ccc; background-color: white">
                        <div>
                            <br />
                            <br />
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

                <div id="divAlumno" runat="server">
                    <div class="col-sm-12">
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
                                    <asp:Legend Name="Legend1" Alignment="Near" Docking="Right" AutoFitMinFontSize="10" Font="Segoe UI, 10pt" IsTextAutoFit="False" BorderColor="Black" Title="Respuestas" TitleFont="Segoe UI, 10pt">
                                    </asp:Legend>
                                </Legends>
                                <Titles>
                                    <asp:Title Docking="Left" Font="Segoe UI, 12pt" Name="Title1" Text="Cantidad de respuestas">
                                    </asp:Title>
                                    <asp:Title Docking="Bottom" Font="Segoe UI, 12pt" Name="Title2" Text="Desempeños">
                                    </asp:Title>
                                </Titles>
                                <BorderSkin BackColor="RoyalBlue" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                            </asp:Chart>
                            <br />
                        <br />
                    </div>
                </div>

                <div class="col-sm-12" id="divCP" runat="server">
                    <br />
                        <asp:Chart ID="chartPuntos" runat="server" CssClass="center-block" Width="970px" Height="505px">
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
                            <BorderSkin BackColor="RoyalBlue" BorderDashStyle="Dash" SkinStyle="FrameTitle6" />
                        </asp:Chart>
                        <br />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView ID="gvDesempenos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="nombre_desempeno" HeaderText="Desempeño" />
                            <asp:BoundField DataField="indicador_desempeno" HeaderText="Indicador de Desempeño" />
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
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesEvaluador/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
