<%@ Page Title="" Language="C#" MasterPageFile="~/Doc/SiteDocente.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaDePresentacion.Doc.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-sm-10 col-sm-offset-1" style="background-color: white">
            <div class="col-sm-3">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Alumno
                </div>
                <br />
                <div class="text-center">
                    <asp:ImageButton runat="server" ID="imgBtnAlumno" ImageUrl="ImagenesDoc/imgAlumno.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="crearAlumno" runat="server" NavigateUrl="~/Doc/CrearAlumnoD.aspx">-Crear Alumno</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Doc/AdministrarAsignaturasInscritas.aspx">-Adm. Asignaturas</asp:HyperLink>
                    <br />
                    <br />
                    <div style="text-align: justify">
                        <p>En esta sección podras crear alumnos de forma manual o importando una tabla de excel, además podras admi- nistrar sus asignaturas inscritas.</p>
                    </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Evaluacion
                </div>
                <div class="col-sm-12 text-center">
                    <br />
                    <asp:ImageButton runat="server" ID="imgBtnEvaluacion" ImageUrl="ImagenesDoc/imgEvaluacion.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Doc/AdministrarEvaluaciones.aspx">-Ver Evaluaciones</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Doc/EvaluacionAlumno.aspx">-Cargar Respuestas</asp:HyperLink>
                    <div style="text-align: justify">
                        <br />
                        <p>En esta sección podras ver las evaluaciones, habilitarlas en caso de querer realizar la evaluación de forma on-line, además de cargar las respuestas de los alumnos.</p>
                   </div>
                    <br />
                </div>
            </div>
            <div class="col-sm-3">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Resultados
                </div>
                <div class="col-sm-12 text-center">
                    <br />
                    <asp:ImageButton runat="server" ID="imgBtnResultados" ImageUrl="ImagenesDoc/imgResultados.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Doc/ResultadosEspecificos.aspx">-Resultados Específicos</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Doc/ResultadosEvaluaciones.aspx">-Resultados Generales</asp:HyperLink>
                    <br />
                    <br />
                    <div style="text-align: justify">
                        <p>En esta sección podras encontrar resultados generales como el gráfico de desempeños, y especificos como el mejor y peor puntaje.</p>
                    </div>
                    <br />
                </div>
            </div>
            <div class="col-sm-3">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Clave
                </div>
                <div class="col-sm-12">
                    <br />
                    <div class="text-center">
                        <asp:ImageButton runat="server" ID="imgBtnContrasena" ImageUrl="ImagenesDoc/imgContrasena.png" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="text-center">
                        <br />
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Doc/CambiarClave.aspx">-Cambiar Clave</asp:HyperLink>
                    </div>
                    <div style="text-align: justify">
                        <br />
                        <p>En esta sección podras cambiar tu clave en caso de encontrarla insegura.</p>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
