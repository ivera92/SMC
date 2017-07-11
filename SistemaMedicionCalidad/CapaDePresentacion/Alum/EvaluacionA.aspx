<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="EvaluacionA.aspx.cs" Inherits="CapaDePresentacion.Alum.EvaluacionA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar" class="row">
        <div class="col-sm-12">
            <asp:Image ID="rEvaluacion" runat="server" ImageUrl="ImagenesAlumno/respEvaluacion.PNG" />
            <div style="border: solid 1px #ccc" class="col-sm-12">
                <div class="col-sm-offset-1 col-sm-5">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-5">
                    <br />
                    <label>Evaluaciones pendientes</label>
                    <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddEvaluacion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Evaluación</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
                    <br />
                    <div class="text-center">
                        <label id="lblnEvaluacion" runat="server"></label>
                    </div>
                    <br /
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <br />
                </div>
                <div class="col-sm-offset-4 col-sm-4">
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-block" BackColor="Orange" BorderColor="White" ForeColor="White" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAlumno/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
