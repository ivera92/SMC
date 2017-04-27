<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="CapaDePresentacion.Alum.Resultados" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Resultados</h2>
    <br />

    <div class="row">
        <div class="col-sm-4">
            <label>Asignatura</label>
        <div>
            <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddAsignatura" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
        </div>

        <div class="col-sm-3">
             <label>Evaluacion</label>
            <div>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddEvaluacion" runat="server">
                    <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-sm-3">
            <label>Competencia</label>
            <div>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddCompetencia" runat="server">
                    <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div>
        <br />
        <div class="col-sm-2">
            <asp:Button id="btnGraficar" runat="server" Text="Graficar" CssClass="btn btn-block btn-primary" OnClick="btnGraficar_Click"/>
        </div>
        </div>
    </div>
    <br />

    <asp:Panel runat="server" ID="Panel1">
        <asp:Chart ID="chartEvaluacion" runat="server" CssClass="center-block">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </asp:Panel>
    <asp:Panel ID="panelGraficoPie" runat="server">
        <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="780px" Height="392px">
            <Series>
                <asp:Series Name="Correctas" Color="Blue"></asp:Series>
                <asp:Series ChartArea="ChartArea1" Color="Red" Name="Incorrectas">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </asp:Panel>
    <br />
</asp:Content>

