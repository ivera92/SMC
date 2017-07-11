<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaDePresentacion.Evaluador.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-sm-10 col-sm-offset-1" style="background-color: white">
            <div class="col-sm-3">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Preguntas
                </div>
                <br />
                <div class="text-center">
                    <asp:ImageButton runat="server" ID="imgBtnPreguntas" ImageUrl="ImagenesEvaluador/imgPregunta.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="cPregunta" runat="server" NavigateUrl="~/Evaluador/CrearPregunta.aspx">-Crear Pregunta</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Evaluador/AdministrarPreguntas.aspx">-Adm. Preguntas</asp:HyperLink>
                    <br />
                    <br />
                    <div style="text-align: justify">
                        <p>En esta sección podras crear preguntas y administrarlas para su posterior uso en las evaluaciones.</p>
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
                    <asp:ImageButton runat="server" ID="imgBtnEvaluacion" ImageUrl="ImagenesEvaluador/imgEvaluacion.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Evaluador/CrearEvaluacion.aspx">-Crear Evaluación</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Evaluador/AdministrarEvaluaciones.aspx">-Adm. Evaluaciones</asp:HyperLink>
                    <div style="text-align: justify">
                        <br />
                        <p>En esta sección podras crear evaluaciones, ya sea con todas las preguntas existentes, o las seleccionadas manualmente, ademas de administrarlas.</p>
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
                    <asp:ImageButton runat="server" ID="imgBtnResultados" ImageUrl="ImagenesEvaluador/imgResultados.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Evaluador/ResultadosEspecificos.aspx">-Resultados Específicos</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Evaluador/ResultadosEvaluaciones.aspx">-Resultados Generales</asp:HyperLink>
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
                        <asp:ImageButton runat="server" ID="imgBtnContrasena" ImageUrl="ImagenesEvaluador/imgContrasena.png" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="text-center">
                        <br />
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Evaluador/CambiarClave.aspx">-Cambiar Clave</asp:HyperLink>
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
