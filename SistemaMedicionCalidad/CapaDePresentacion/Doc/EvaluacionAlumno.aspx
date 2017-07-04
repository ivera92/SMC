<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="EvaluacionAlumno.aspx.cs" Inherits="CapaDePresentacion.Doc.EvaluacionAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="divEvaluar" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cRA" runat="server" ImageUrl="ImagenesDoc/cRA.PNG" />
            <div>
                <div class="col-sm-offset-1 col-sm-3">
                    <br />
                    <label>Rut Alumno</label>
                    <asp:TextBox ID="txtRut" runat="server" class="form-control" required></asp:TextBox>
                </div>
                <div class="col-sm-4">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList ID="ddAsignatura" class="form-control" runat="server" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-sm-3">
                    <br />
                    <label>Evaluaciones pendientes</label>
                    <asp:DropDownList ID="ddEvaluacion" CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" OnSelectedIndexChanged="ddEvaluacion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una Evaluación</asp:ListItem>
                    </asp:DropDownList>
                </div>


                <div class="col-sm-offset-1 col-sm-3">
                    <asp:CustomValidator ID="cv_rut" runat="server" ControlToValidate="txtRut" Display="Dynamic" ErrorMessage="RUT no valido" ClientValidationFunction="validar_rut" ForeColor="Red" />
                    <br />
                </div>


                <div runat="server" id="divPreguntas" style="border: solid 2px #ccc; background-color: white" class="col-sm-offset-1 col-sm-10">
                    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                    <br />
                </div>
                <div class="col-sm-offset-4 col-sm-4">
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-block" ForeColor="White" BackColor="#7F1734" BorderColor="White" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesDoc/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
