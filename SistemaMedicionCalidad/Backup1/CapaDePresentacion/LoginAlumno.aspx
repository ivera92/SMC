<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAlumno.aspx.cs" Inherits="CapaDePresentacion.LoginAlumno" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <title><%: Page.Title %> - Sistema Medicion Calidad</title>

    <script src="Scripts/jquery-1.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js" ></script>
     
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    
    <link href="Styles/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/bootstrap-theme.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="form-control">
            <tr>
                <td>
                </td>
                <td>
                    <h2>Inicio de Sesion alumnos</h2>
                    </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>
                </td>
                <td>
                    <label>
                    Rut</label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:TextBox class="form-control" ID="txtRut" runat="server" ></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <label>
                    Contraseña</label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:TextBox class="form-control" ID="txtclave" runat="server" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnIngresar" runat="server" class="btn btn-primary" 
                        onclick="btnIngresar_Click" Text="Ingresar" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
    <script src="~/Scripts/jquery-1.4.1.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js" ></script>
    <link href="Styles/bootstrap.min.css" rel="stylesheet"/>
    <link href="Styles/bootstrap-theme.css" rel="stylesheet"/>
</body>
</html>
