<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAlumno.aspx.cs" Inherits="CapaDePresentacion.LoginAlumno" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%: Page.Title %> - Sistema Medicion Calidad</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
     
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">

        <br />
        <h2 class="text-center">Iniciar sesión</h2>
        <br />

        <div class="text-center">
            <label>Rut</label>
        </div>

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:TextBox class="form-control" ID="txtRut" runat="server" ></asp:TextBox></div>
        </div>
        <br />

        <div class="text-center">
            <label>Contraseña</label>
        </div>

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:TextBox class="form-control" ID="txtclave" runat="server" TextMode="Password"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:Button ID="btnIngresar" runat="server" class="btn btn-primary btn-block" onclick="btnIngresar_Click" Text="Ingresar" /></></div>
        </div>
        <br />
        </div>
    </form>
</body>
</html>
