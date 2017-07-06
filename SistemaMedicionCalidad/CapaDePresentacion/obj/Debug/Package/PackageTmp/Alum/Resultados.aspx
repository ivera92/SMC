<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="CapaDePresentacion.Alum.Resultados" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div style="border: solid 1px #ccc">
                <asp:Image ID="rEvaluacion" runat="server" ImageUrl="ImagenesAlumno/rEvaluacion.PNG" />
                <div class="col-sm-5">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddAsignatura" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-5">
                    <br />
                    <label>Evaluación</label>
                    <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddEvaluacion" runat="server">
                        <asp:ListItem Value="0">Seleccione una Evaluación</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-2">
                    <br />
                    <br />
                    <asp:Button ID="btnGraficar" runat="server" Text="Graficar" CssClass="btn btn-block" BackColor="Orange" BorderColor="White" ForeColor="White" OnClick="btnGraficar_Click" />
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
                                <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </asp:Panel>
                    <br />
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
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAlumno/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>

