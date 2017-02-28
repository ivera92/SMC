<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="CapaDePresentacion.Alum.Resultados" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-4">
            <asp:DropDownList CssClass="form-control" ID="ddCompetencia" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-offset-1 col-sm-6">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
         </div>
        <div class="col-sm-offset-1 col-sm-2">
            <asp:Button id="btnGraficar" runat="server" Text="Graficar" CssClass="btn btn-block btn-primary" OnClick="btnGraficar_Click"/>
        </div>
    </div>
    
</asp:Content>

