<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="EvaluacionA.aspx.cs" Inherits="CapaDePresentacion.Alum.EvaluacionA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar">
        <h1 class="text-center">Responder evaluacion</h1>
        <br />

        <div class="row">
            <div class="col-sm-offset-1 col-sm-5">
                <label>Asignatura</label>
                <div>
                    <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-sm-5">
                <label>Evaluaciones pendientes</label>
                <div>
                    <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddEvaluacion_SelectedIndexChanged">
                        <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />

        <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            <br />
        </div>        
        <div class="row">
            <br />
            <div class="col-sm-offset-4 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" class="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
