<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheqLogin.aspx.cs" Inherits="CapaDePresentacion.CheqLogin" %>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="Scripts/rut.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Universidad Austral de Chile</title>
    <link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/default.css" type="text/css" media="screen">
    <link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/nivo-slider.css" type="text/css" media="screen">
    <link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/style.css" type="text/css" media="screen">
    <script type="text/javascript" async="" src="http://www.google-analytics.com/ga.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/fade/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/fade/jquery.nivo.slider.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/buscar.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/basic.js"></script>
    <link rel="stylesheet" href="http://www.uach.cl/uach/css/sitio.css" type="text/css" media="screen">
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/baron/baron.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/baron/script.js"></script>
    <link rel="stylesheet" type="text/css" href="http://www.uach.cl/uach/_includes/baron/baron.css">
    <link rel="stylesheet" type="text/css" href="http://www.uach.cl/uach/_includes/baron/style.css">

    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider({
                animSpeed: 1000, // Slide transition speed
                pauseTime: 7000, // How long each slide will show
            });
        });
        $(window).load(function () {
            $('#slider_left_1').nivoSlider({
                effect: 'fade',
                animSpeed: 500, // Slide transition speed
                pauseTime: 5000, // How long each slide will show
                directionNav: false, // Next - Prev navigation
                controlNav: false
            });
        });
        $(window).load(function () {
            $('#slider_left_2').nivoSlider({
                effect: 'fade',
                animSpeed: 500, // Slide transition speed
                pauseTime: 5000, // How long each slide will show
                directionNav: false, // Next - Prev navigation
                controlNav: false
            });
        });
        $(window).load(function () {
            $('#slider_left_3').nivoSlider({
                effect: 'fade',
                animSpeed: 500, // Slide transition speed
                pauseTime: 5000, // How long each slide will show
                directionNav: false, // Next - Prev navigation
                controlNav: false
            });
        });
        $(window).load(function () {
            $('#slider_cont').nivoSlider({
                effect: 'fade',
                animSpeed: 500, // Slide transition speed
                pauseTime: 5000, // How long each slide will show
                directionNav: false, // Next - Prev navigation
                controlNav: false
            });
        });
        $(window).load(function () {
            $('#slider_cont_responsive').nivoSlider({
                effect: 'fade',
                animSpeed: 500, // Slide transition speed
                pauseTime: 5000, // How long each slide will show
                directionNav: false, // Next - Prev navigation
                controlNav: false
            });
        });
    </script>
    <style type="text/css">
        body {
            background-color: #787887;
        }

        #barra_top {
            background-color: #008000;
        }

        #barra_bottom {
            background-color: #008000;
        }

        #scroll #contenedor #noticias #barra_not {
            background-color: #008000;
        }

        #scroll #contenedor #banner_right #barra_age {
            background-color: #008000;
        }

        #scroll #contenedor #pix {
            background-image: url(http://www.uach.cl/uach/_imag/pix_menu.jpg);
        }

        #scroll #contenedor #menu_2 {
            background-image: url(http://www.uach.cl/uach/_imag/transparente_menu.png);
        }

        #scroll #contenedor #logos {
            width: auto;
            background-image: url(http://www.uach.cl/uach/_imag/pix_menu.jpg);
        }

        .nivo-caption {
            background-image: url(http://www.uach.cl/uach/_imag/transparente.png);
        }

        .theme-default .nivo-controlNav {
            /*width: 112px;*/
            width: 100%;
            max-width: 150px;
        }
        /* Responsive */
        .navbar-toggle {
            background-color: #008000;
            background-image: none;
        }
    </style>
</head>

<body onload="$(&quot;#agente&quot;).trigger(&quot;click&quot;);">

    <div id="top">
        <div id="buscar">
            <form id="filterForm" name="filterForm" method="get" action="http://www.uach.cl/uach/inicio-uach/resultados" accept-charset="UTF-8" onsubmit="return validarFormulario ()">
                <input style="float: left;" type="text" id="q" name="q" class="search" placeholder="Buscar" onkeypress="pulsarr(event)">
                <button style="margin: 0; padding: 0; border: 0; float: right;">
                    <img src="http://www.uach.cl/uach/_imag/buscar.jpg"></button>
            </form>
        </div>
        <div id="menu_1">
            <p>
                <a href="/inicio-uach/contacto">Contacto</a>&nbsp;| <a href="/inicio-uach/mapa">Mapa del Sitio</a> |&nbsp;<a href="http://intranet.uach.cl">Intranet</a>
            </p>
        </div>
    </div>

    <div id="barra_top"></div>
    <div id="banner_top">
        <img src="http://www.uach.cl/uach/_file/5151be071d10c.jpg" width="1010" height="105" alt="" border="0">
    </div>
    <div id="scroll">

        <div id="contenedor">
            <div id="logo">
                <img src="http://www.uach.cl/uach/_imag/logo.jpg" border="0" alt="" style="margin-top: 21px;"></div>
            <div id="menu_2">

                <ul>
                    <li class="nivel1"><a href="&#10;&#9;&#9;Inicio.aspx" class="nivel1" style="color: #FFF;">Inicio</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="">Facultades</a>
                        <ul>
                            <li><a href="http://www.uach.cl/facultades/arquitectura-y-artes" style="padding-top: 10px;">Arquitectura y Artes</a></li>
                            <li><a href="http://www.uach.cl/facultades/ciencias" style="">Ciencias</a></li>
                            <li><a href="http://www.uach.cl/facultades/ciencias-agrarias" style="">Ciencias Agrarias</a></li>
                            <li><a href="http://www.uach.cl/facultades/cs-economicas-y-administrativas" style="">Cs. Económicas y Administrativas</a></li>
                            <li><a href="http://www.uach.cl/facultades/cs-forestales-y-recursos-naturales" style="">Cs. Forestales y Recursos Naturales</a></li>
                            <li><a href="http://www.uach.cl/facultades/ciencias-juridicas-y-sociales" style="">Ciencias Jurídicas y Sociales</a></li>
                            <li><a href="http://www.uach.cl/facultades/ciencias-veterinarias" style="">Ciencias Veterinarias</a></li>
                            <li><a href="http://www.uach.cl/facultades/ciencias-de-la-ingenieria" style="">Ciencias de la Ingeniería</a></li>
                            <li><a href="http://www.uach.cl/facultades/filosofia-y-humanidades" style="">Filosofía y Humanidades</a></li>
                            <li><a href="http://www.uach.cl/facultades/medicina" style="padding-bottom: 20px; border-radius: 0 0 7px 7px;">Medicina</a></li>
                        </ul>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="">Sedes y Campus</a>
                        <ul>
                            <li><a href="http://www.uach.cl/sedes-y-campus/informacion-general" style="padding-top: 10px;">Información General</a></li>
                            <li><a href="http://www.uach.cl/sedes-y-campus/sede-puerto-montt" style="">Sede Puerto Montt</a></li>
                            <li><a href="http://www.uach.cl/sedes-y-campus/campus-patagonia" style="padding-bottom: 20px; border-radius: 0 0 7px 7px;">Campus Patagonia</a></li>
                        </ul>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/pregrado/principal" class="nivel1" style="">Pregrado</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/postgrado/principal" class="nivel1" style="">Postgrado</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="">Organización</a>
                        <ul>
                            <li><a href="http://www.uach.cl/organizacion/rectoria" style="padding-top: 10px;">Rectoría</a></li>
                            <li><a href="http://www.uach.cl/organizacion/prorrectoria" style="">Prorrectoría</a></li>
                            <li><a href="http://www.uach.cl/organizacion/cuerpos-colegiados" style="">Cuerpos Colegiados</a></li>
                            <li><a href="http://www.uach.cl/organizacion/vicerrectoria-academica" style="">Vicerrectoría Académica</a></li>
                            <li><a href="http://www.uach.cl/organizacion/vicerrectoria-sede-puerto-montt" style="">Vicerrectoría Sede Puerto Montt</a></li>
                            <li><a href="http://www.uach.cl/organizacion/vicerrectoria-gestion-economica" style="">Vicerrectoría Gestión Económica</a></li>
                            <li><a href="http://www.uach.cl/organizacion/secretaria-general" style="">Secretaría General</a></li>
                            <li><a href="http://www.uach.cl/organizacion/contraloria" style="">Contraloría</a></li>
                            <li><a href="http://www.uach.cl/organizacion/asociaciones-gremiales" style="padding-bottom: 20px; border-radius: 0 0 7px 7px;">Asociaciones Gremiales</a></li>
                        </ul>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/investigacion/direccion-de-investigacion" class="nivel1" style="">Investigación</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/vinculacion/principal" class="nivel1" style="">Vinculación</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/servicios/principal" class="nivel1" style="">Servicios</a>
                    </li>
                    <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/internacional/principal" class="nivel1" style="border-bottom: none">Internacional</a>
                    </li>
                </ul>

            </div>
            <div id="menu_3">
                <a href="CheqLogin.aspx">Iniciar Sesion</a>
            </div>
            <div id="banner_center">
                <form runat="server">
                    <div id="divLogin" class="col-sm-offset-4 col-sm-4" runat="server" style="border: solid 2px #ccc">
                        <div>
                            <br />
                            <h2 class="text-center">Inicio Sesión</h2>
                            <br />
                        </div>

                        <div class="row">
                            <div class="col-sm-offset-1 col-sm-10">
                                <asp:TextBox class="form-control text-center" ID="rut" runat="server" placeHolder="Rut, ejemplo: 18205857-2"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator1" runat="server"
                                    ClientValidationFunction="validar_rut" ControlToValidate="rut"
                                    Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True"></asp:CustomValidator>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-sm-offset-1 col-sm-10">
                                <asp:TextBox class="form-control text-center" ID="txtclave" runat="server" TextMode="Password" placeHolder="Contraseña"></asp:TextBox>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-sm-offset-1 col-sm-10 tex">
                                <asp:DropDownList ID="ddTipoUsuario" runat="server" class="form-control" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0"><--Seleccione un tipo de usuario--></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />


                        <div>
                            <div class="row">
                                <div class="col-sm-offset-1 col-sm-5">
                                    <asp:Button ID="btnIngresar" runat="server" class="btn btn-default btn-block" OnClick="btnIngresar_Click" Text="Ingresar" />
                                </div>
                                <asp:LinkButton ID="recuperar" runat="server" OnClick="recuperar_Click">¿Olvidaste tu contraseña?</asp:LinkButton>

                            </div>
                            <br />
                        </div>
                    </div>


                    <div class="col-sm-offset-4 col-sm-4" id="divRut" runat="server" style="border: solid 2px #ccc">
                        <br />
                        <br />
                        <h2 class="text-center">Recuperar tu contraseña</h2>
                        <br />
                        <div class="row">
                            <div class="col-sm-offset-1 col-sm-10">
                                <asp:TextBox class="form-control" ID="rutRC" runat="server" placeHolder="Rut, ejemplo: 18205857-2"></asp:TextBox>
                                <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validar_rut"
                                    ControlToValidate="rutRC" Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True">
                                </asp:CustomValidator>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-sm-offset-4 col-sm-4">
                                <asp:Button ID="btnVerificarRut" Text="Verificar" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnVerificarRut_Click" />
                            </div>
                        </div>
                        <br />
                    </div>

                    <div class="text-center col-sm-offset-3 col-sm-6" id="divCorreo" runat="server" style="border: solid 2px #ccc">
                        <br />
                        <h2 class="text-center">Recuperar tu contraseña</h2>
                        <br />

                        <label>La cuenta asociada al rut es la siguiente:</label>
                        <br />
                        <label id="lblCorreo" runat="server"></label>
                        <br />
                        <label>¿Desea enviar un correo para verificar su clave?</label>
                        <br />
                        <div class="row">
                            <div class="col-sm-offset-4 col-sm-2">
                                <asp:Button ID="btnEnviarC" runat="server" CssClass="btn btn-success btn-block" OnClick="btnEnviarC_Click" Text="Si" />
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnNoEnviar" runat="server" CssClass="btn btn-danger btn-block" Text="No" OnClick="btnNoEnviar_Click" />
                            </div>
                        </div>
                        <br />
                    </div>
                </form>
            </div>
        </div>

    </div>

    <div id="barra_bottom"></div>

    <div id="banner_bottom">
        <a href="http://www.uach.cl/">
            <img src="http://www.uach.cl/uach/_file/518d15c15279d.jpg" alt="" class="img-responsive" height="105" border="0" usemap="#Map3">
            <map name="Map3" id="Map3">
                <area shape="rect" coords="0,3,48,16" href="#" alt="subir">
                <area shape="rect" coords="964,3,1012,16" href="#" alt="bajar">
            </map>
        </a>
    </div>
    <div id="footer_direccion">
        Sistema desarrollado por Iván Vera Ruiz
    <br />
        Correo: ivera@ic.uach.cl
    </div>

    <div id="footer_links">
        <p>
            <a href="https://secure01.uach.cl/certificados/" target="_blank">Validación de Certificados</a>&nbsp;|&nbsp;<a href="http://empleos.uach.cl" target="_blank">Portal de Empleos</a>&nbsp;| <a href="http://vinculacion.uach.cl/index.php/unidades-adscritas/radio-uach" target="_blank">Radio UACh Online</a> | <a href="http://www.consejoderectores.cl" target="_blank">Consejo de Rectores</a> | <a href="http://redg9.cl" target="_blank">Red G9</a>&nbsp;| <a href="http://www.explora.cl/rios" target="_blank">Programa Explora</a> |&nbsp;<a href="http://www.universia.cl" target="_blank">Universia</a> |&nbsp;<a href="http://www.reuna.cl" target="_blank">Reuna</a>
        </p>
    </div>
    <div id="footer_derechos">© Todos los derechos reservados</div>
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-27179444-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
</body>
</html>

