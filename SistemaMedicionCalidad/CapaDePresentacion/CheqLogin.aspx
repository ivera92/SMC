<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheqLogin.aspx.cs" Inherits="CapaDePresentacion.CheqLogin" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%: Page.Title %> - Sistema Medicion Calidad</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <script type="text/javascript">

    function validar_rut(source, arguments) {
        var rut = arguments.Value; suma = 0; mul = 2; i = 0;

        for (i = rut.length - 3; i >= 0; i--) {
            suma = suma + parseInt(rut.charAt(i)) * mul;
            mul = mul == 7 ? 2 : mul + 1;
        }

        var dvr = '' + (11 - suma % 11);
        if (dvr == '10') dvr = 'K'; else if (dvr == '11') dvr = '0';

        if (rut.charAt(rut.length - 2) != "-" || rut.charAt(rut.length - 1).toUpperCase() != dvr)
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }
</script>
     
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
            <div class="col-sm-4 col-sm-offset-4">
                <asp:TextBox class="form-control" ID="rut" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ClientValidationFunction="validar_rut" ControlToValidate="rut" 
            Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True"></asp:CustomValidator>
            </div>
        </div>
        <br />

        <div class="text-center">
            <label>Contraseña</label>
        </div>

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                    <asp:TextBox class="form-control" ID="txtclave" runat="server" TextMode="Password" placeHolder="Ingrese contraseña" required></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="text-center">
            <label>Tipo de usuario</label>
        </div>
        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:DropDownList ID="ddTipoUsuario" runat="server" class="form-control"></asp:DropDownList></div>
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

