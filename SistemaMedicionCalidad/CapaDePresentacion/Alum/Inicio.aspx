<%@ Page Title="" Language="C#" MasterPageFile="~/Alum/SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CapaDePresentacion.Alum.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-sm-10 col-sm-offset-1" style="background-color: white">
            <div class="col-sm-4">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Evaluación
                </div>
                <br />
                <div class="text-center">
                    <asp:ImageButton runat="server" ID="imgBtnEvaluacion" ImageUrl="ImagenesAlumno/imgEvaluacion.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="crearEvaluacion" runat="server" NavigateUrl="~/Alum/EvaluacionA.aspx">Responder Evaluación</asp:HyperLink>
                    <br />
                    <br />
                    <div style="text-align: justify">
                        <p>En esta sección podras encontrar las evaluaciones previamente creadas, y habilitadas por tu docente a cargo, estas podran ser respondidas por ti de forma on-line con el fin de agilizar la obtencion de resultados.</p>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Resultados
                </div>
                <div class="col-sm-12 text-center">
                    <br />
                    <asp:ImageButton runat="server" ID="imgBtnResultados" ImageUrl="ImagenesAlumno/imgResultados.png" />
                </div>
                <div class="col-sm-12 text-center">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Alum/Resultados.aspx">Resultados de Evaluaciones</asp:HyperLink>

                    <div style="text-align: justify">
                        <br />
                        <p>En esta sección podras encontrar los resultados de las evaluaciones previamente respondidas on-line, o de forma presencial, previo a esto el docente debe haber cargado tus respuestas al sistema.</p>
                    </div>
                    <br />
                </div>
            </div>
            <div class="col-sm-4">
                <div class="text-center" style="font-weight: bold">
                    <br />
                    Sección Clave
                </div>
                <div class="col-sm-12">
                    <br />
                    <div class="text-center">
                        <asp:ImageButton runat="server" ID="imgBtnContrasena" ImageUrl="ImagenesAlumno/imgContrasena.png" />
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="text-center">
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Alum/CambiarClave.aspx">Cambiar Clave</asp:HyperLink>
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
