<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="CapaDePresentacion.Admin.InicioAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <table class="center-block table-bordered" style="background-color: white">
            <tr>
                <!-- On rows -->
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnEscuela" ImageUrl="ImagenesAdmin/imgEscuela.jpg" />
                    <br />
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/CrearEscuela.aspx">Crear Escuela</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminEscuela" runat="server" NavigateUrl="~/Admin/AdministrarEscuelas.aspx">Administrar Escuelas</asp:HyperLink>
                </td>

                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnAsignatura" ImageUrl="ImagenesAdmin/imgAsignatura.jpg" />
                    <br />
                    <asp:HyperLink ID="crearAsignatura" runat="server" NavigateUrl="~/Admin/CrearAsignatura.aspx">Crear Asignatura</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminAsignaturas" runat="server" NavigateUrl="~/Admin/AdministrarAsignaturas.aspx">Administrar Asignaturas</asp:HyperLink>
                </td>

                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgCompetencia" ImageUrl="ImagenesAdmin/imgCompetencia.jpg" />
                    <br />
                    <asp:HyperLink ID="crearCompetencia" runat="server" NavigateUrl="~/Admin/CrearCompetencia.aspx">Crear Competencia</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminCompetencia" runat="server" NavigateUrl="~/Admin/AdministrarCompetencias.aspx">Administrar Competencias</asp:HyperLink>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnDocente" ImageUrl="ImagenesAdmin/imgDocente.jpg" />
                    <br />
                    <asp:HyperLink ID="crearDocente" runat="server" NavigateUrl="~/Admin/CrearDocente.aspx">Crear Docente</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminDocentes" runat="server" NavigateUrl="~/Admin/AdministrarDocentes.aspx">Administrar Docentes</asp:HyperLink>
                </td>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnAlumno" ImageUrl="ImagenesAdmin/imgAlumno.jpeg" />
                    <br />
                    <asp:HyperLink ID="crearAlumno" runat="server" NavigateUrl="~/Admin/CrearAlumno.aspx">Crear Alumno</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminAlumnos" runat="server" NavigateUrl="~/Admin/AdministrarAlumnos.aspx">Administrar Alumnos</asp:HyperLink>
                </td>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnPregunta" ImageUrl="ImagenesAdmin/imgPregunta.jpg" />
                    <br />
                    <asp:HyperLink ID="crearPregunta" runat="server" NavigateUrl="~/Admin/CrearPregunta.aspx">Crear Pregunta</asp:HyperLink>
                    <br />
                    <br />
                    <asp:HyperLink ID="adminPreguntas" runat="server" NavigateUrl="~/Admin/AdministrarPreguntas.aspx">Administrar Preguntas</asp:HyperLink>
                    </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnEvaluacion" ImageUrl="ImagenesAdmin/imgEvaluacion.jpg" />
                    <br />
                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/CrearEvaluacion.aspx">Crear Evaluacion</asp:HyperLink>
                </td>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnResultados" ImageUrl="ImagenesAdmin/imgResultados.jpg" />
                    <br />
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/ResultadosEvaluaciones.aspx">Resultados evaluaciones</asp:HyperLink>
                </td>
                <td>
                    <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnClave" ImageUrl="ImagenesAdmin/imgClave.png" />
                    <br />
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/CambiarClave.aspx">Cambiar Clave</asp:HyperLink>
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
