<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ResultadosEvaluaciones.aspx.cs" Inherits="CapaDePresentacion.Admin.ResultadosEvaluaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center">Resultado Evaluaciones</h2>
    <br />

    <div class="row">
        <label class="col-sm-offset-4">Usuario</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddUsuario" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddUsuario_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione tipo de usuario--></asp:ListItem>
                <asp:ListItem Value="1">Alumno</asp:ListItem>
                <asp:ListItem Value="2">Docente</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div runat="server" id="divAlumno" class="row">
        <label class="col-sm-offset-4">Filtro</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddAlumno" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAlumno_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione filtro--></asp:ListItem>
                <asp:ListItem Value="1">Todos los alumnos</asp:ListItem>
                <asp:ListItem Value="2">Escuela</asp:ListItem>
                <asp:ListItem Value="3">Pais</asp:ListItem>
                <asp:ListItem Value="4">Promocion</asp:ListItem>
                <asp:ListItem Value="5">Rut</asp:ListItem>
                <asp:ListItem Value="6">Sexo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div runat="server" id="divDocente" class="row">
        <label class="col-sm-offset-4">Filtro</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddDocente" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                <asp:ListItem Value="0"><--Seleccione filtro--></asp:ListItem>
                <asp:ListItem Value="1">Disponibilidad</asp:ListItem>
                <asp:ListItem Value="2">Edad</asp:ListItem>
                <asp:ListItem Value="3">Pais</asp:ListItem>
                <asp:ListItem Value="4">Rut</asp:ListItem>
                <asp:ListItem Value="5">Sexo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div runat="server" id="divEscuela" class="row">
        <label class="col-sm-offset-4">Escuela</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddEscuela" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddEscuela_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione escuela--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div runat="server" id="divPais" class="row">
        <label class="col-sm-offset-4">Pais</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddPais" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddPais_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione un pais--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div runat="server" id="divPromocion" class="row">
        <label class="col-sm-offset-4">Promocion</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddPromocion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddPromocion_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione promocion--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div runat="server" id="divRut" class="row">
        <label class="col-sm-offset-4">Rut</label>
        <div class="col-sm-4 col-sm-offset-4">
            <asp:TextBox CssClass="form-control" ID="txtRut" runat="server"></asp:TextBox>
        </div>
    </div>

    <div runat="server" id="divSexo" class="row">
        <label class="col-sm-offset-4">Sexo</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddSexo" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddBeneficioA_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione sexo--></asp:ListItem>
                <asp:ListItem Value="1">Masculino</asp:ListItem>
                <asp:ListItem Value="2">Femenino</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

</asp:Content>
