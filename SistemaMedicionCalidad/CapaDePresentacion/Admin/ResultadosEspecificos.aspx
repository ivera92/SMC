<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEspecificos.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEspecificos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/rut.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEE" runat="server" ImageUrl="ImagenesAdmin/rEE.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-3">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una asignatura</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-3">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList ID="ddEvaluacion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Value="0">Seleccione una evaluación</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-3">
                    <br />
                    <label>Resultados</label>
                    <asp:DropDownList ID="ddOpcion" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddOpcion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione opcion</asp:ListItem>
                        <asp:ListItem Value="1">Mejor alumno de evaluación</asp:ListItem>
                        <asp:ListItem Value="2">Peor alumno de evaluación</asp:ListItem>
                        <asp:ListItem Value="3">Pregunta mejor contestada</asp:ListItem>
                        <asp:ListItem Value="4">Pregunta peor contestada</asp:ListItem>
                        <asp:ListItem Value="5">Un alumno en específico</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-2" id="divRut" runat="server">
                    <br />
                    <label>Rut alumno</label>
                    <asp:TextBox ID="txtRut" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                        Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                    </asp:CustomValidator>
                </div>

                <div class="col-sm-1">
                    <br />
                    <br />
                    <asp:Button ID="btnVer" runat="server" Text="Ver" CssClass="form-control btn-block btn-success" OnClick="btnVer_Click" />
                </div>

                <div id="divAlumno" runat="server">
                    <div class="text-center">
                        <label id="nombre" runat="server">Nombre alumno:</label>
                    </div>
                    <div class="text-center">
                        <label id="lblNombreAlumno" runat="server"></label>
                    </div>
                    <br />

                    <div class="text-center">
                        <label id="respuestas" runat="server">Respuestas correctas</label>
                    </div>
                    <div class="text-center">
                        <label id="lblCorrectas" runat="server"></label>
                    </div>
                    <div class="col-sm-12">
                        <asp:Panel ID="panelGraficoColumna" runat="server">
                            <br />
                            <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="970px" Height="505px">
                                <Series>
                                    <asp:Series Name="Correctas" Color="#7373FF" ChartType="StackedBar"></asp:Series>
                                    <asp:Series ChartArea="ChartArea1" Color="#FF5353" Name="Incorrectas" ChartType="StackedBar">
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                        <Area3DStyle Enable3D="True" />
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        </asp:Panel>
                        <br />
                    </div>


                    <div class="row" id="divPregunta" runat="server">
                        <br />
                        <div class="col-sm-6 col-sm-offset-2">
                            <label>Enunciado</label>
                            <textarea class="form-control" id="txtAPregunta" runat="server" rows="4" readonly="readonly"></textarea>
                            <br />
                        </div>
                        <div class="col-sm-2">
                            <label>Veces correcta</label>
                            <br />
                            <label id="lblCorrectasP" runat="server"></label>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <br />
                        <asp:GridView ID="gvDesempenos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" BackColor="White">
                            <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="id_desempeno" HeaderText="ID" />
                                <asp:BoundField DataField="indicador_desempeno" HeaderText="Desempeño" />
                                <asp:BoundField DataField="nombre_nivel" HeaderText="Nivel" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
            </div>
        </div>
    </div>
</asp:Content>
