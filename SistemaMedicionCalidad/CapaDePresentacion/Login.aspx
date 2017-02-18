<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaDePresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
        
    <title><%: Page.Title %> Sistema Medicion Calidad</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">

        <br />
        <h2 class="text-center">Seleccione tipo de usuario</h2>
        <br />

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <asp:Button id="btnAlumno" runat="server" Text="Alumno" class="btn btn btn-block btn-success" OnClick="btnAlumno_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <asp:Button id="btnDocente" runat="server" Text="Docente" class="btn btn btn-block btn-success" OnClick="btnDocente_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <asp:Button id="btnAdministrador" runat="server" Text="Administrador" class="btn btn btn-block btn-success" OnClick="btnAdministrador_Click" />
            </div>
        </div>
        <br />

        </div>
    </form>
</body>
</html>
