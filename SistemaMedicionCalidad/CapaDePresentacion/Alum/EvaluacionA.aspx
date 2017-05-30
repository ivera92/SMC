<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="EvaluacionA.aspx.cs" Inherits="CapaDePresentacion.Alum.EvaluacionA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar">
        <h1 class="text-center">Responder Evaluacion</h1>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-4">
                <label>Asignatura</label>
                <div>
                    <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-sm-4">
                <label>Evaluacion</label>
                <div>
                    <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AppendDataBoundItems="true" runat="server">
                        <asp:ListItem Value="0"><--Seleccione una evaluacion--></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />

        <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
            <asp:Panel ID="Panel1" runat="server">
            </asp:Panel>
            <br />
        </div>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:Button ID="btnGuardar" runat="server" class="btn btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                <br />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button runat="server" CssClass="btn btn-block btn-primary" ID="btnSiguiente" Text="Seguir evalaluando" OnClick="btnSiguiente_Click" />
        </div>
    </div>

</asp:Content>
