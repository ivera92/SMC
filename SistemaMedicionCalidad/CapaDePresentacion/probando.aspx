<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="probando.aspx.cs" Inherits="CapaDePresentacion.probando" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<title>Universidad Austral de Chile</title>
<link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/default.css" type="text/css" media="screen">
<link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/nivo-slider.css" type="text/css" media="screen">
<link rel="stylesheet" href="http://www.uach.cl/uach/_includes/fade/style.css" type="text/css" media="screen">
<!--<link rel="stylesheet" href="http://www.uach.cl/uach/css/sitio.css" type="text/css" media="screen" />-->
<!--<script type="text/javascript" src="_includes/fade/jquery-1.7.1.min.js"></script>-->
<!--script type="text/javascript" src="http://www.uach.cl/uach/_includes/fade/jquery-1.7.1.min.js"></script>-->
<!--ActualizaciÃ³n de libreria Jquery v2 AAGUAYO-->
<script type="text/javascript" async="" src="http://www.google-analytics.com/ga.js"></script><script type="text/javascript" src="http://www.uach.cl/uach/_includes/fade/jquery-2.1.1.js"></script>
<script type="text/javascript" src="http://www.uach.cl/uach/_includes/fade/jquery.nivo.slider.js"></script>
<script type="text/javascript" src="http://www.uach.cl/uach/_includes/buscar.js"></script>
<script type="text/javascript" src="http://www.uach.cl/uach/_includes/basic.js"></script>

<link rel="stylesheet" href="http://www.uach.cl/uach/css/sitio.css" type="text/css" media="screen">   
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/baron/baron.js"></script>
    <script type="text/javascript" src="http://www.uach.cl/uach/_includes/baron/script.js"></script>

    <link rel="stylesheet" type="text/css" href="http://www.uach.cl/uach/_includes/baron/baron.css">
    <link rel="stylesheet" type="text/css" href="http://www.uach.cl/uach/_includes/baron/style.css">
    
<script type="text/javascript">
$(window).load(function() {
	$('#slider').nivoSlider({
        animSpeed: 1000, // Slide transition speed
        pauseTime: 7000, // How long each slide will show
    });
});
$(window).load(function() {
	$('#slider_left_1').nivoSlider({
		effect: 'fade',
        animSpeed: 500, // Slide transition speed
        pauseTime: 5000, // How long each slide will show
		directionNav: false, // Next - Prev navigation
        controlNav: false
    });
});
$(window).load(function() {
	$('#slider_left_2').nivoSlider({
		effect: 'fade',
        animSpeed: 500, // Slide transition speed
        pauseTime: 5000, // How long each slide will show
		directionNav: false, // Next - Prev navigation
        controlNav: false
    });
});
$(window).load(function() {
	$('#slider_left_3').nivoSlider({
		effect: 'fade',
        animSpeed: 500, // Slide transition speed
        pauseTime: 5000, // How long each slide will show
		directionNav: false, // Next - Prev navigation
        controlNav: false
    });
});
$(window).load(function() {
	$('#slider_cont').nivoSlider({
		effect: 'fade',
        animSpeed: 500, // Slide transition speed
        pauseTime: 5000, // How long each slide will show
		directionNav: false, // Next - Prev navigation
        controlNav: false
    });
});
$(window).load(function() {
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
	width:auto;
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
.navbar-toggle{
  background-color: #008000;
  background-image: none;
}
</style>
</head>
<body onload="$(&quot;#agente&quot;).trigger(&quot;click&quot;);">

<div id="top">
    <div id="buscar">
        <form id="filterForm" name="filterForm" method="get" action="http://www.uach.cl/uach/inicio-uach/resultados" accept-charset="UTF-8" onsubmit="return validarFormulario ()">
            <!--<input type="image" name="imageField" src="http://www.uach.cl/uach/_imag/buscar.jpg" style="float: right; border-radius: 0;" />-->       
            <input style="float: left;" type="text" id="q" name="q" class="search" placeholder="Buscar" onkeypress="pulsarr(event)">
            <button style="margin: 0;  padding: 0;  border: 0; float: right; "><img src="http://www.uach.cl/uach/_imag/buscar.jpg"></button>
        </form>
    </div>
    <div id="menu_1">
<p>
	<a href="/inicio-uach/contacto">Contacto</a>&nbsp;| <a href="/inicio-uach/mapa">Mapa del Sitio</a> |&nbsp;<a href="http://intranet.uach.cl">Intranet</a></p>    </div>
</div>

<div id="barra_top"></div>
    <div id="banner_top">
		<img src="http://www.uach.cl/uach/_file/5151be071d10c.jpg" width="1010" height="105" alt="" border="0">
</div>    <div id="scroll">
    
		<div id="contenedor">
<div id="logo"><img src="http://www.uach.cl/uach/_imag/logo.jpg" border="0" alt="" style="margin-top: 21px;"></div><div id="menu_2">
 
  
</div><div id="menu_3">
<!--<a href="inicio-uach" style="color: #999;">Inicio UACh</a><img src="_imag/menu_f.jpg" border="0" alt="" style="margin: 0 13px;" />-->

				<a href="CheqLogin.aspx">Alumnos</a>    <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="CheqLogin.aspx">Docentes</a>        <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="CheqLogin.aspx">Administrador</a>  
  <!--<img src="_imag/facebook.jpg" width="18" height="18" border="0" alt="" style="margin-left: 13px; margin-top: 6px; position: absolute;" /><img src="_imag/twitter.jpg" width="18" height="18" border="0" alt="" style="margin-right: 11px; margin-left: 7px; margin-top: 6px; position: absolute;" />-->
</div><div id="pix"></div>
</div>

<div id="banner_bottom">
	    <a href="http://www.uach.cl/">
	      <!--<img src="http://www.uach.cl/uach/_file/518d15c15279d.jpg" alt="" width="1010" height="105" border="0" usemap="#Map3" />-->
          <img src="http://www.uach.cl/uach/_file/518d15c15279d.jpg" alt="" class="img-responsive" height="105" border="0" usemap="#Map3">
          <map name="Map3" id="Map3">
            <area shape="rect" coords="0,3,48,16" href="#" alt="subir">
            <area shape="rect" coords="964,3,1012,16" href="#" alt="bajar">
          </map>
        </a>
</div><div id="footer_direccion">Universidad Austral de Chile · Independencia 631 · Tel: <a href="tel:+56 63 2221500">+56 63 2221500</a> · Valdivia · Chile</div>
    
<div id="footer_links"><p>
	<a href="https://secure01.uach.cl/certificados/" target="_blank">Validación de Certificados</a>&nbsp;|&nbsp;<a href="http://empleos.uach.cl" target="_blank">Portal de Empleos</a>&nbsp;| <a href="http://vinculacion.uach.cl/index.php/unidades-adscritas/radio-uach" target="_blank">Radio UACh Online</a> | <a href="http://www.consejoderectores.cl" target="_blank">Consejo de Rectores</a> | <a href="http://redg9.cl" target="_blank">Red G9</a>&nbsp;| <a href="http://www.explora.cl/rios" target="_blank">Programa Explora</a> |&nbsp;<a href="http://www.universia.cl" target="_blank">Universia</a> |&nbsp;<a href="http://www.reuna.cl" target="_blank">Reuna</a></p> 
	</div>	
<div id="footer_derechos">© Todos los derechos reservados</div>
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-27179444-1']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>

</body>
</html>

<body onload="$(&quot;#agente&quot;).trigger(&quot;click&quot;);">

<div id="top">
    <div id="buscar">
        <form id="filterForm" name="filterForm" method="get" action="http://www.uach.cl/uach/inicio-uach/resultados" accept-charset="UTF-8" onsubmit="return validarFormulario ()">
            <!--<input type="image" name="imageField" src="http://www.uach.cl/uach/_imag/buscar.jpg" style="float: right; border-radius: 0;" />-->       
            <input style="float: left;" type="text" id="q" name="q" class="search" placeholder="Buscar" onkeypress="pulsarr(event)">
            <button style="margin: 0;  padding: 0;  border: 0; float: right; "><img src="http://www.uach.cl/uach/_imag/buscar.jpg"></button>
        </form>
    </div>
    <div id="menu_1">
<p>
	<a href="/inicio-uach/contacto">Contacto</a>&nbsp;| <a href="/inicio-uach/mapa">Mapa del Sitio</a> |&nbsp;<a href="http://intranet.uach.cl">Intranet</a></p>    </div>
</div>

<div id="barra_top"></div><div id="banner_top">
		<img src="http://www.uach.cl/uach/_file/5151be071d10c.jpg" width="1010" height="105" alt="" border="0">
</div>    <div id="scroll">
    
		<div id="contenedor">
<div id="logo"><img src="http://www.uach.cl/uach/_imag/logo.jpg" border="0" alt="" style="margin-top: 21px;"></div><div id="menu_2">
 
  <ul>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/" class="nivel1" style=" color: #FFF; ">Inicio UACh</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="  ">Facultades</a>
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
                <li><a href="http://www.uach.cl/facultades/medicina" style=" padding-bottom: 20px; border-radius: 0 0 7px 7px; ">Medicina</a></li>
            </ul>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="  ">Sedes y Campus</a>
            <ul>
                <li><a href="http://www.uach.cl/sedes-y-campus/informacion-general" style="padding-top: 10px;">Información General</a></li>
                <li><a href="http://www.uach.cl/sedes-y-campus/sede-puerto-montt" style="">Sede Puerto Montt</a></li>
                <li><a href="http://www.uach.cl/sedes-y-campus/campus-patagonia" style=" padding-bottom: 20px; border-radius: 0 0 7px 7px; ">Campus Patagonia</a></li>
            </ul>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/pregrado/principal" class="nivel1" style="  ">Pregrado</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/postgrado/principal" class="nivel1" style="  ">Postgrado</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;#" class="nivel1" style="  ">Organización</a>
            <ul>
                <li><a href="http://www.uach.cl/organizacion/rectoria" style="padding-top: 10px;">Rectoría</a></li>
                <li><a href="http://www.uach.cl/organizacion/prorrectoria" style="">Prorrectoría</a></li>
                <li><a href="http://www.uach.cl/organizacion/cuerpos-colegiados" style="">Cuerpos Colegiados</a></li>
                <li><a href="http://www.uach.cl/organizacion/vicerrectoria-academica" style="">Vicerrectoría Académica</a></li>
                <li><a href="http://www.uach.cl/organizacion/vicerrectoria-sede-puerto-montt" style="">Vicerrectoría Sede Puerto Montt</a></li>
                <li><a href="http://www.uach.cl/organizacion/vicerrectoria-gestion-economica" style="">Vicerrectoría Gestión Económica</a></li>
                <li><a href="http://www.uach.cl/organizacion/secretaria-general" style="">Secretaría General</a></li>
                <li><a href="http://www.uach.cl/organizacion/contraloria" style="">Contraloría</a></li>
                <li><a href="http://www.uach.cl/organizacion/asociaciones-gremiales" style=" padding-bottom: 20px; border-radius: 0 0 7px 7px; ">Asociaciones Gremiales</a></li>
            </ul>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/investigacion/direccion-de-investigacion" class="nivel1" style="  ">Investigación</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/vinculacion/principal" class="nivel1" style="  ">Vinculación</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/servicios/principal" class="nivel1" style="  ">Servicios</a>
        </li>
        <li class="nivel1"><a href="&#10;&#9;&#9;http://www.uach.cl/internacional/principal" class="nivel1" style="  border-bottom: none">Internacional</a>
        </li>
  </ul>
  
</div><div id="menu_3">
<!--<a href="inicio-uach" style="color: #999;">Inicio UACh</a><img src="_imag/menu_f.jpg" border="0" alt="" style="margin: 0 13px;" />-->

				<a href="http://www.uach.cl/futuros-alumnos">Futuros Alumnos</a>        <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="http://www.uach.cl/alumnos">Alumnos</a>        <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="http://www.uach.cl/academicos">Académicos</a>        <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="http://www.uach.cl/funcionarios">Funcionarios</a>        <img src="http://www.uach.cl/uach/_imag/pix_menu3.jpg" border="0" alt="" style="margin: 0 10px;">  
				<a href="http://www.uach.cl/exalumnos">Exalumnos</a>  
  <!--<img src="_imag/facebook.jpg" width="18" height="18" border="0" alt="" style="margin-left: 13px; margin-top: 6px; position: absolute;" /><img src="_imag/twitter.jpg" width="18" height="18" border="0" alt="" style="margin-right: 11px; margin-left: 7px; margin-top: 6px; position: absolute;" />-->
</div><div id="pix"></div><div id="banner_center">
      <div id="wrapper">
	    <div class="slider-wrapper theme-default">
	      <div id="slider" class="nivoSlider">          
		        <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102811" class="nivo-imageLink" style="display: none;">
                  <img src="http://www.uach.cl/uach/_file/58ef9dca0d062.jpg" width="1010" height="350" title="" alt="" border="0" style="width: 1010px; visibility: hidden; display: inline;">
                </a>
		        <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102507" class="nivo-imageLink" style="display: none;">
                  <img src="http://www.uach.cl/uach/_file/58e7f86dc025f.jpg" width="1010" height="350" title="" alt="" border="0" style="width: 1010px; visibility: hidden; display: inline;">
                </a>
		        <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102607" class="nivo-imageLink" style="display: block;">
                  <img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" width="1010" height="350" title="" alt="" border="0" style="width: 1010px; visibility: hidden; display: inline;">
                </a>
          <img class="nivo-main-image" src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="display: inline; height: 350px;"><div class="nivo-caption"></div><div class="nivo-directionNav"><a class="nivo-prevNav">Prev</a><a class="nivo-nextNav">Next</a></div><div class="nivo-slice" name="0" style="left: 0px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-0px;"></div><div class="nivo-slice" name="1" style="left: 67px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-67px;"></div><div class="nivo-slice" name="2" style="left: 134px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-134px;"></div><div class="nivo-slice" name="3" style="left: 201px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-201px;"></div><div class="nivo-slice" name="4" style="left: 268px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-268px;"></div><div class="nivo-slice" name="5" style="left: 335px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-335px;"></div><div class="nivo-slice" name="6" style="left: 402px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-402px;"></div><div class="nivo-slice" name="7" style="left: 469px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-469px;"></div><div class="nivo-slice" name="8" style="left: 536px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-536px;"></div><div class="nivo-slice" name="9" style="left: 603px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-603px;"></div><div class="nivo-slice" name="10" style="left: 670px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-670px;"></div><div class="nivo-slice" name="11" style="left: 737px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-737px;"></div><div class="nivo-slice" name="12" style="left: 804px; width: 67px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-804px;"></div><div class="nivo-slice" name="13" style="left: 871px; width: 67px; height: 350px; opacity: 1; overflow: hidden; bottom: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-871px;"></div><div class="nivo-slice" name="14" style="left: 938px; width: 72px; height: 350px; opacity: 1; overflow: hidden; top: 0px;"><img src="http://www.uach.cl/uach/_file/58ef7c8f23c3c.jpg" style="position:absolute; width:1010px; height:auto; display:block !important; top:0; left:-938px;"></div></div><div class="nivo-controlNav"><a class="nivo-control" rel="0">1</a><a class="nivo-control" rel="1">2</a><a class="nivo-control active" rel="2">3</a></div>
        </div>
      </div>
</div><div style="width: 1010px; margin: 0 auto; background-color: #E8E8E8; height: 40px; padding-top: 10px; padding-bottom: 15px;">

<div id="logos">
	    <a href="//www.uach.cl/transparencia"><img src="http://www.uach.cl/uach/_file/55953fdce59cf.gif" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="/sedes-y-campus/informacion-general/mapas"><img src="http://www.uach.cl/uach/_file/518972375b5cf.gif" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="https://siveduc.uach.cl/" target="_blank"><img src="http://www.uach.cl/uach/_file/5151cafdd0ffb.gif" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="http://tvaustral.uach.cl" target="_blank"><img src="http://www.uach.cl/uach/_file/5151cb23eee24.gif" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="//www.uach.cl/dw/nuevaguiatelefonica/indice.php" target="_blank"><img src="http://www.uach.cl/uach/_file/5151ca6a14b04.gif" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="https://www.facebook.com/UAustraldeChile/" target="_blank"><img src="http://www.uach.cl/uach/_file/547cd3a385136.png" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="https://twitter.com/UAustraldeChile" target="_blank"><img src="http://www.uach.cl/uach/_file/547cd3fe4f9ac.png" height="32" border="0" alt=""></a>
        <img src="http://www.uach.cl/uach/_imag/pix_logos.jpg" width="1" height="29" border="0" alt="" class="separador">
	    <a href="http://www.youtube.com/channel/UCSOfVd-zX6nYtIgY1DyHhfQ" target="_blank"><img src="http://www.uach.cl/uach/_file/547cd483900bd.png" height="32" border="0" alt=""></a>
</div>

</div><div id="info">
          
  <div id="banner_left">
      <div id="wrapper1">
        <div class="slider-wrapper theme-default" style="width: 260px; height: 100px;">
          <div id="slider_left_1" class="nivoSlider" style="width: 260px; height: 100px;">
                <a href="http://www.uach.cl/organizacion/vicerrectoria/academica/oficina/autoevaluacion/?go=institucional" class="nivo-imageLink" style="display: block;"><img src="http://www.uach.cl/uach/_file/564b24838a9f1.jpg" width="260" height="100" alt="" border="0" style="display: none;"></a>
          <img class="nivo-main-image" src="http://www.uach.cl/uach/_file/564b24838a9f1.jpg" style="display: inline;"><div class="nivo-caption"></div></div>
        </div>
      </div>
      <div style="width: 260px; height: 18px;"></div>
      <div id="wrapper2">
        <div class="slider-wrapper theme-default" style="width: 260px; height: 100px;">
          <div id="slider_left_2" class="nivoSlider" style="width: 260px; height: 100px;">
                <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102807" class="nivo-imageLink" style="display: none;"><img src="http://www.uach.cl/uach/_file/5862bb9f7c324.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
                <a href="http://www.economicas.uach.cl/postgrado/diplomado-en-estadistica-aplicada" class="nivo-imageLink" style="display: none;"><img src="http://www.uach.cl/uach/_file/58dc274b18476.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
                <a href="http://www.cineclubuach.cl/" class="nivo-imageLink" style="display: block;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
          <img class="nivo-main-image" src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="display: inline; height: 100px;"><div class="nivo-caption"></div><div class="nivo-slice" name="0" style="left: 0px; width: 260px; height: 100px; opacity: 1; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-0px;"></div><div class="nivo-slice" name="1" style="left: 17px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-17px;"></div><div class="nivo-slice" name="2" style="left: 34px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-34px;"></div><div class="nivo-slice" name="3" style="left: 51px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-51px;"></div><div class="nivo-slice" name="4" style="left: 68px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-68px;"></div><div class="nivo-slice" name="5" style="left: 85px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-85px;"></div><div class="nivo-slice" name="6" style="left: 102px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-102px;"></div><div class="nivo-slice" name="7" style="left: 119px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-119px;"></div><div class="nivo-slice" name="8" style="left: 136px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-136px;"></div><div class="nivo-slice" name="9" style="left: 153px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-153px;"></div><div class="nivo-slice" name="10" style="left: 170px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-170px;"></div><div class="nivo-slice" name="11" style="left: 187px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-187px;"></div><div class="nivo-slice" name="12" style="left: 204px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-204px;"></div><div class="nivo-slice" name="13" style="left: 221px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-221px;"></div><div class="nivo-slice" name="14" style="left: 238px; width: 22px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58e3924d8ad29.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-238px;"></div></div>
        </div>
      </div>
      <div style="width: 260px; height: 18px;"></div>
      <div id="wrapper3">
        <div class="slider-wrapper theme-default" style="width: 260px; height: 100px;">
          <div id="slider_left_3" class="nivoSlider" style="width: 260px; height: 100px;">
                <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102883" class="nivo-imageLink" style="display: none;">
                	<img src="http://www.uach.cl/uach/_file/58efa0418d434.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
                <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102727" class="nivo-imageLink" style="display: none;">
                	<img src="http://www.uach.cl/uach/_file/58ed41b50fa5c.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
                <a href="http://noticias.uach.cl/principal.php?pag=noticia-externo&amp;cod=102747" class="nivo-imageLink" style="display: block;">
                	<img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" width="260" height="100" alt="" border="0" style="width: 260px; visibility: hidden; display: inline;"></a>
          <img class="nivo-main-image" src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="display: inline; height: 100px;"><div class="nivo-caption"></div><div class="nivo-slice" name="0" style="left: 0px; width: 260px; height: 100px; opacity: 1; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-0px;"></div><div class="nivo-slice" name="1" style="left: 17px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-17px;"></div><div class="nivo-slice" name="2" style="left: 34px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-34px;"></div><div class="nivo-slice" name="3" style="left: 51px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-51px;"></div><div class="nivo-slice" name="4" style="left: 68px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-68px;"></div><div class="nivo-slice" name="5" style="left: 85px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-85px;"></div><div class="nivo-slice" name="6" style="left: 102px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-102px;"></div><div class="nivo-slice" name="7" style="left: 119px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-119px;"></div><div class="nivo-slice" name="8" style="left: 136px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-136px;"></div><div class="nivo-slice" name="9" style="left: 153px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-153px;"></div><div class="nivo-slice" name="10" style="left: 170px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-170px;"></div><div class="nivo-slice" name="11" style="left: 187px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-187px;"></div><div class="nivo-slice" name="12" style="left: 204px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-204px;"></div><div class="nivo-slice" name="13" style="left: 221px; width: 17px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-221px;"></div><div class="nivo-slice" name="14" style="left: 238px; width: 22px; height: 100px; opacity: 0; overflow: hidden;"><img src="http://www.uach.cl/uach/_file/58efc1095729c.jpg" style="position:absolute; width:260px; height:auto; display:block !important; top:0; left:-238px;"></div></div>
        </div>
      </div>
  </div>
 
  <div id="noticias">
        
    <div id="barra_not"></div>
    <div id="titulo">NOTICIAS
    					<div id="vermas"><a href="http://noticias.uach.cl">... Ver más</a></div>
			    	</div>
      <div class="wrapper">
        <div class="scroller">
          <div class="container">
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	12 de Abril                	</span>
                <h2>UACh inauguró Año Cultural en La Unión</h2>
                * Desde hace tres años que la Universidad Austral de Chile realiza esta ceremonia fuera de... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102859" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102859-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	13 de Abril                	</span>
                <h2>Curso Internacional en Valdivia se centró en diversos aspectos de las...</h2>
                * Una vez más el Instituto de Pediatría de la Facultad de Medicina realizó con alta participación... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102899" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102899-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	13 de Abril                	</span>
                <h2>CERAM UACh ofrecerá análisis de toxinas en choritos</h2>
                * Adquisición de equipamiento tecnológico, a través de Proyecto FIC, posiciona al Centro... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102895" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102895-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	13 de Abril                	</span>
                <h2>MINEDUC y UACh abren convocatoria a postítulos gratuitos para docentes...</h2>
                * Centro de Educación Continua UACh dictará postítulos en Regiones de Los Ríos, Los Lagos... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102871" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102871-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	13 de Abril                	</span>
                <h2>Urgencia por Protección de Suelos Post Mega incendios</h2>
                * Declaración de Científicos afines a las Ciencias del Suelo Universidad Austral de Chile.... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102875" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102875-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          <div class="noticia">
            <table width="360" border="0" cellspacing="0" cellpadding="0" style="margin-left: 20px;">
              <tbody><tr>
                <td height="140" width="230">
                <span>                	11 de Abril                	</span>
                <h2>Edward Rojas: "El lugar hace la arquitectura y la arquitectura hace...</h2>
                * El arquitecto Edward Rojas Vega, Premio Nacional de Arquitectura 2016, dictó la clase magistral... <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102791" target="_blank" class="ver_mas">Ver más...</a>
                </td>
                <td align="right" width="130"><img src="/uach/cache/not-102791-fotografia" width="120" height="100" border="0" alt="" style="text-align:right;"></td>
              </tr>
            </tbody></table>
          </div>
          </div>   
		<div class="scroller__bar"></div>
        </div>   
      </div>  
   
  </div>
      
  <div id="banner_right">
      <div id="barra_age"></div>
      <div id="age_titulo">AGENDA</div>
        <div class="wrapper" style="width: 261px; float: right;">
          <div class="scroller">
            <div class="container">
    <table border="0" cellspacing="0" cellpadding="0" width="235">
            <tbody><tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style=" background-image: url(/uach/_imag/pix_age2.jpg); background-repeat: repeat-x;  ">
                <div class="dia">13</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                La OCV interpretará el cuarteto de cuerdas Op.51 de Joseph Haydn en conciertos de...                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102535">Ver más</a>
              </td>
            </tr>  
            <tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style="  ">
                <div class="dia">17</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                "El cordero" se estrena en el Cine Club                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102723">Ver más</a>
              </td>
            </tr>  
            <tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style="  ">
                <div class="dia">18</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                Invitan a la Ceremonia de Inauguración del Año Explora 2017                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102811">Ver más</a>
              </td>
            </tr>  
            <tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style="  ">
                <div class="dia">21</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                Culmina proyecto que analizó impacto de "pesticidas" para Caligus o "piojo de mar"...                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102891">Ver más</a>
              </td>
            </tr>  
            <tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style="  ">
                <div class="dia">24</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                Inscripciones para Torneo de Debate Delibera finalizan el lunes 24 de abril                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102883">Ver más</a>
              </td>
            </tr>  
            <tr>
              <td height="83" bgcolor="#FFFFFF" width="47" style="  ">
                <div class="dia">26</div>
                <div class="mes">ABR</div>
              </td>
              <td class="age_contenido" width="188">
                Seminario "Igualdad de oportunidades e inclusión social de personas con discapacidad"                <a href="http://noticias.uach.cl/titulares/noticias.php?pag=noticia-externo%26cod%3D102727">Ver más</a>
              </td>
            </tr>  
    <tr>
        <td height="33" width="47" style="background-image: url(/uach/_imag/pix_age3.jpg); background-repeat: repeat-x;">&nbsp;</td>
          <td height="33" width="188">&nbsp;</td>
        </tr>
    </tbody></table>
            </div>   
		  <div class="scroller__bar"></div>
          </div>   
        </div>  

  </div>
      
</div>        
    	</div>
      
    </div>
    
<div id="barra_bottom"></div>

<div id="banner_bottom">
	    <a href="http://www.uach.cl/">
	      <!--<img src="http://www.uach.cl/uach/_file/518d15c15279d.jpg" alt="" width="1010" height="105" border="0" usemap="#Map3" />-->
          <img src="http://www.uach.cl/uach/_file/518d15c15279d.jpg" alt="" class="img-responsive" height="105" border="0" usemap="#Map3">
          <map name="Map3" id="Map3">
            <area shape="rect" coords="0,3,48,16" href="#" alt="subir">
            <area shape="rect" coords="964,3,1012,16" href="#" alt="bajar">
          </map>
        </a>
</div><div id="footer_direccion">Universidad Austral de Chile · Independencia 631 · Tel: <a href="tel:+56 63 2221500">+56 63 2221500</a> · Valdivia · Chile</div>
    
<div id="footer_links"><p>
	<a href="https://secure01.uach.cl/certificados/" target="_blank">Validación de Certificados</a>&nbsp;|&nbsp;<a href="http://empleos.uach.cl" target="_blank">Portal de Empleos</a>&nbsp;| <a href="http://vinculacion.uach.cl/index.php/unidades-adscritas/radio-uach" target="_blank">Radio UACh Online</a> | <a href="http://www.consejoderectores.cl" target="_blank">Consejo de Rectores</a> | <a href="http://redg9.cl" target="_blank">Red G9</a>&nbsp;| <a href="http://www.explora.cl/rios" target="_blank">Programa Explora</a> |&nbsp;<a href="http://www.universia.cl" target="_blank">Universia</a> |&nbsp;<a href="http://www.reuna.cl" target="_blank">Reuna</a></p> 
	</div>	
<div id="footer_derechos">© Todos los derechos reservados</div>
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-27179444-1']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>

</body>
