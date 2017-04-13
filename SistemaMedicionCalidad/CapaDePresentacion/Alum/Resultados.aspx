<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="CapaDePresentacion.Alum.Resultados" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Resultados</h2>
    <br />
    <label class="col-sm-offset-4">Asignatura</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList CssClass="form-control" AutoPostBack="true" ID="ddAsignatura" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Evaluacion</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddEvaluacion" runat="server">
                <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-4">Competencia</label>
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddCompetencia" runat="server">
                <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button id="btnGraficar" runat="server" Text="Graficar" CssClass="btn btn-block btn-primary" OnClick="btnGraficar_Click"/>
        </div>
    </div>
    <br />

    <asp:Panel runat="server" ID="Panel1">
        <asp:Chart ID="chartEvaluacion" runat="server" CssClass="col-sm-offset-4 center-block">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <asp:Chart ID="chartColumna" runat="server">
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

