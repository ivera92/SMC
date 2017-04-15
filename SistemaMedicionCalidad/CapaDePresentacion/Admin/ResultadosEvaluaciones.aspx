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
                <asp:ListItem Value="2">Beneficio</asp:ListItem>
                <asp:ListItem Value="3">Edad</asp:ListItem>
                <asp:ListItem Value="4">Escuela</asp:ListItem>
                <asp:ListItem Value="5">Pais</asp:ListItem>
                <asp:ListItem Value="6">Promocion</asp:ListItem>
                <asp:ListItem Value="7">Rut</asp:ListItem>
                <asp:ListItem Value="8">Sexo</asp:ListItem>
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

    <div runat="server" id="divBeneficioA" class="row">
        <label class="col-sm-offset-4">Beneficio</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddBeneficioA" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddBeneficioA_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione si tiene beneficio--></asp:ListItem>
                <asp:ListItem Value="1">Si</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div runat="server" id="divEdad" class="row">
        <label class="col-sm-offset-4">Edad</label>
        <div class="col-sm-offset-4 col-sm-4">
            <asp:DropDownList ID="ddEdad" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddEdad_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione edad--></asp:ListItem>
                <asp:ListItem Value="1">17</asp:ListItem>
                <asp:ListItem Value="2">18</asp:ListItem>
                <asp:ListItem Value="3">19</asp:ListItem>
                <asp:ListItem Value="4">20</asp:ListItem>
                <asp:ListItem Value="5">21</asp:ListItem>
                <asp:ListItem Value="6">22</asp:ListItem>
                <asp:ListItem Value="7">23</asp:ListItem>
                <asp:ListItem Value="8">24</asp:ListItem>
                <asp:ListItem Value="9">25</asp:ListItem>
                <asp:ListItem Value="10">26</asp:ListItem>
                <asp:ListItem Value="11">27</asp:ListItem>
                <asp:ListItem Value="12">28</asp:ListItem>
                <asp:ListItem Value="13">29</asp:ListItem>
                <asp:ListItem Value="14">30</asp:ListItem>
                <asp:ListItem Value="15">mas de 30</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

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
