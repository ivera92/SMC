<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEvaluaciones.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEG" runat="server" ImageUrl="ImagenesAdmin/rEG.PNG" />
            <div style="border: solid 1px #ccc">
                <div runat="server" id="divAsignatura" class="col-sm-4">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div runat="server" id="divEvaluacion" class="col-sm-4">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList ID="ddEvaluacion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control">
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

                <div class="col-sm-12">
                    <asp:Panel ID="panelGrafico" runat="server">
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
                        <br />
                    </asp:Panel>
                </div>
                <div class="col-sm-12">
                    <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="false" class="table table-striped" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="estado_respuesta" HeaderText="Estado" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="indicador_desempeno.id_desempeno" HeaderText="Desempeno" />
                            <asp:BoundField DataField="rut_docente.nombre_persona" HeaderText="Docente" />
                            <asp:BoundField DataField="rut_alumno.nombre_persona" HeaderText="Alumno" />
                            <asp:BoundField DataField="Id_evaluacion_hpa.nombre_evaluacion" HeaderText="Evaluacion" />
                        </Columns>
                    </asp:GridView>
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
</asp:Content>
