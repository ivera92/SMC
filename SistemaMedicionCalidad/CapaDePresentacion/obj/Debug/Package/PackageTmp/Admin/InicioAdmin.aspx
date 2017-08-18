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
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnEscuela" ImageUrl="ImagenesAdmin/imgEscuela.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/CrearEscuela.aspx">Crear Escuela</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminEscuela" runat="server" NavigateUrl="~/Admin/AdministrarEscuelas.aspx">Administrar Escuelas</asp:HyperLink>
                    </div>
                </td>

                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnAsignatura" ImageUrl="ImagenesAdmin/imgAsignatura.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearAsignatura" runat="server" NavigateUrl="~/Admin/CrearAsignatura.aspx">Crear Asignatura</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminAsignaturas" runat="server" NavigateUrl="~/Admin/AdministrarAsignaturas.aspx">Administrar Asignaturas</asp:HyperLink>
                    </div>
                </td>

                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgCompetencia" ImageUrl="ImagenesAdmin/imgCompetencia.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearCompetencia" runat="server" NavigateUrl="~/Admin/CrearCompetencia.aspx">Crear Competencia</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminCompetencia" runat="server" NavigateUrl="~/Admin/AdministrarCompetencias.aspx">Administrar Competencias</asp:HyperLink>
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnDocente" ImageUrl="ImagenesAdmin/imgDocente.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearDocente" runat="server" NavigateUrl="~/Admin/CrearDocente.aspx">Crear Docente</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminDocentes" runat="server" NavigateUrl="~/Admin/AdministrarDocentes.aspx">Administrar Docentes</asp:HyperLink>
                    </div>
                </td>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnAlumno" ImageUrl="ImagenesAdmin/imgAlumno.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearAlumno" runat="server" NavigateUrl="~/Admin/CrearAlumno.aspx">Crear Alumno</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminAlumnos" runat="server" NavigateUrl="~/Admin/AdministrarAlumnos.aspx">Administrar Alumnos</asp:HyperLink>
                    </div>
                </td>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnPregunta" ImageUrl="ImagenesAdmin/imgPregunta.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearPregunta" runat="server" NavigateUrl="~/Admin/CrearPregunta.aspx">Crear Pregunta</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminPreguntas" runat="server" NavigateUrl="~/Admin/AdministrarPreguntas.aspx">Administrar Preguntas</asp:HyperLink>
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnEvaluacion" ImageUrl="ImagenesAdmin/imgEvaluacion.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="crearEvaluacion" runat="server" NavigateUrl="~/Admin/CrearEvaluacion.aspx">Crear Evaluación</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="adminEvaluacion" runat="server" NavigateUrl="~/Admin/AdministrarEvaluaciones.aspx">Administrar Evaluaciones</asp:HyperLink>
                    </div>
                </td>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnResultados" ImageUrl="ImagenesAdmin/imgResultados.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/ResultadosEvaluaciones.aspx">Resultados Generales</asp:HyperLink>
                        <br />
                    </div>
                </td>
                <td>
                    <div class="col-sm-5">
                        <asp:ImageButton runat="server" ID="imgBtnContrasena" ImageUrl="ImagenesAdmin/imgContrasena.png" />
                    </div>
                    <div class="col-sm-7">
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/CambiarClave.aspx">Cambiar Clave</asp:HyperLink>
                    </div>
                </td>
            </tr>
        </table>
        <br />
    </div>
</asp:Content>
