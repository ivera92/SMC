<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="CapaDePresentacion.Admin.InicioAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Administrar</h2>
    <br />
    <table class="col-sm-offset-2 col-sm-10 table-bordered">
        <tr>
        <!-- On rows -->
            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnAlumno" ImageUrl="ImagenesAdmin/imgAlumno.jpeg"/>
                <asp:HyperLink ID="adminAlumnos" runat="server" NavigateUrl="~/Admin/AdministrarAlumnos.aspx">Administrar Alumnos</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearAlumno" runat="server" NavigateUrl="~/Admin/CrearAlumno.aspx">Crear Alumno</asp:HyperLink>        
            </td>

            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnAsignatura" ImageUrl="ImagenesAdmin/imgAsignatura.jpg" />
                <asp:HyperLink ID="adminAsignaturas" runat="server" NavigateUrl="~/Admin/AdministrarAsignaturas.aspx">Administrar Asignaturas</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearAsignatura" runat="server" NavigateUrl="~/Admin/CrearAsignatura.aspx">Crear Asignatura</asp:HyperLink>
            </td>

            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgCompetencia" ImageUrl="ImagenesAdmin/imgCompetencia.jpg" />
                <asp:HyperLink ID="adminCompetencia" runat="server" NavigateUrl="~/Admin/AdministrarCompetencias.aspx">Administrar Competencias</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearCompetencia" runat="server" NavigateUrl="~/Admin/CrearCompetencia.aspx">Crear Competencia</asp:HyperLink>   
            </td>
        </tr>

        <tr>    
            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnDocente" ImageUrl="ImagenesAdmin/imgDocente.jpg" />
                <asp:HyperLink ID="adminDocentes" runat="server" NavigateUrl="~/Admin/AdministrarDocentes.aspx">Administrar Docentes</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearDocente" runat="server" NavigateUrl="~/Admin/CrearDocente.aspx">Crear Docente</asp:HyperLink>
            </td>   
            
            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnEscuela" ImageUrl="ImagenesAdmin/imgEscuela.jpg" />
                <asp:HyperLink ID="adminEscuela" runat="server" NavigateUrl="~/Admin/AdministrarEscuelas.aspx">Administrar Escuelas</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/CrearEscuela.aspx">Crear Escuela</asp:HyperLink>
            </td>

            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnPregunta" ImageUrl="ImagenesAdmin/imgPregunta.jpg" />
                <asp:HyperLink ID="adminPreguntas" runat="server" NavigateUrl="~/Admin/AdministrarPreguntas.aspx">Administrar Preguntas</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearPregunta" runat="server" NavigateUrl="~/Admin/CrearPregunta.aspx">Crear Pregunta</asp:HyperLink>
            </td>
        </tr>

        <tr>
            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgProfesion" ImageUrl="ImagenesAdmin/imgProfesion.jpg" />
                <asp:HyperLink ID="adminProfesion" runat="server" NavigateUrl="~/Admin/AdministrarProfesiones.aspx">Administrar Profesiones</asp:HyperLink>
                <br />
                <asp:HyperLink ID="crearProfesion" runat="server" NavigateUrl="~/Admin/CrearProfesion.aspx">Crear Profesion</asp:HyperLink>
            </td>

            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnAsociar" ImageUrl="ImagenesAdmin/imgAsociar.jpg" />
                <asp:HyperLink ID="asociarCA" runat="server" NavigateUrl="~/Admin/AsociarAC.aspx">Asociar Competencia a Asignatura</asp:HyperLink>
            </td>
            
            <td>
                <asp:ImageButton CssClass="col-sm-6 img-responsive" runat="server" ID="imgBtnClave" ImageUrl="ImagenesAdmin/imgClave.png" />
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/CambiarClave.aspx">Cambiar Clave</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
