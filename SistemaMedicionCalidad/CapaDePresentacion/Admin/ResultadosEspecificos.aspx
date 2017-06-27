<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEspecificos.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEspecificos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Resultados especificos</h2>
    <br />
    <div class="row">
        <div class="col-sm-4">
            <label>Asignatura</label>
            <div>
                <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione asignatura--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div class="col-sm-3">
            <label>Evaluacion</label>
            <div>
                <asp:DropDownList ID="ddEvaluacion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione evaluacion--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div class="col-sm-3">
            <label>Resultados</label>
            <div>
                <asp:DropDownList ID="ddOpcion" AutoPostBack="true" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione opcion--></asp:ListItem>
                    <asp:ListItem Value="1">Mejor alumno de evaluación</asp:ListItem>
                    <asp:ListItem Value="2">Peor alumno de evaluación</asp:ListItem>
                    <asp:ListItem Value="3">Pregunta mejor contestada</asp:ListItem>
                    <asp:ListItem Value="4">Pregunta peor contestada</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div class="col-sm-2">
            <br />
            <asp:Button ID="btnVer" runat="server" Text="Ver" CssClass="form-control btn-block btn-primary" OnClick="btnVer_Click" />
        </div>
    </div>

    <div id="divAlumno" runat="server">
        <div class="text-center">
            <label>Nombre alumno:</label>
        </div>
        <div class="text-center">
            <label id="lblNombreAlumno" runat="server"></label>
        </div>
        <br />

        <div class="text-center">
            <label>Respuestas correctas</label>
        </div>
        <div class="text-center">
            <label id="lblCorrectas" runat="server"></label>
        </div>
        <asp:Panel ID="panelGraficoColumna" runat="server">
            <br />
            <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="1010px" Height="505px">
                <Series>
                    <asp:Series Name="Correctas" Color="#7373FF"></asp:Series>
                    <asp:Series ChartArea="ChartArea1" Color="#FF5353" Name="Incorrectas">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </asp:Panel>
        <br />
    </div>

    <div class="row" id="divPregunta" runat="server">
        <br />
        <div class="col-sm-2 col-sm-offset-1">
            <label>ID</label>
            <br />
            <label id="lblID" runat="server"></label>
        </div>
        <div class="col-sm-6">
            <label>Enunciado</label>
            <textarea class="form-control" id="txtAPregunta" runat="server" rows="4" readonly="readonly"></textarea>
            <br />
        </div>
        <div class="col-sm-3">
            <label>Veces correcta</label>
            <br />
            <label id="lblCorrectasP" runat="server"></label>
        </div>
    </div>

</asp:Content>
