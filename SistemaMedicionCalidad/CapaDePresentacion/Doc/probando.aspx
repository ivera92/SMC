<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="probando.aspx.cs" Inherits="CapaDePresentacion.Doc.probando" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Fotos</title>
    <script src="../Scripts/imagen.js"></script>
    <script>cargarScriptPagina();</script>
</head>
<body style="background-color:aqua">
    <form id="frmRegistro" runat="server">
    <div style="text-align:center">
        <h1>Preview de Imagen con FileReader al usar FileUpload</h1>
        <h2>Registro de Fotos</h2>
        <h3>Selecciona la Foto a enviar:
            <asp:FileUpload ID="fileImagen" runat="server" />
        </h3>
        <img src="a" id="imgFoto" width="200" height="200" alt="" /><br />
        <asp:Button ID="btnEnviar" OnClick="btnEnviar_Click" Text="Enviar" runat="server" />
    </div>
    </form>
</body>
</html>
