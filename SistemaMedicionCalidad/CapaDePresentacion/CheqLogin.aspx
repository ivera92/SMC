<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheqLogin.aspx.cs" Inherits="CapaDePresentacion.CheqLogin" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%: Page.Title %> - Sistema Medicion Calidad</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="Scripts/rut.js"></script>
     
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
                <asp:TextBox class="form-control" ID="rut" runat="server" placeHolder="Ejemplo: 18205857-2"></asp:TextBox>
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
                    <asp:TextBox class="form-control" ID="txtclave" runat="server" TextMode="Password" placeHolder="Ingrese contraseña"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="text-center">
            <label>Tipo de usuario</label>
        </div>
        <div class="row">
            <div class="col-sm-4 col-sm-offset-4">
                <asp:DropDownList ID="ddTipoUsuario" runat="server" class="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="0"><--Seleccione un tipo de usuario--></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <asp:LinkButton ID="recuperar" runat="server" OnClick="recuperar_Click">Recuperar Contraseña</asp:LinkButton>

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:Button ID="btnIngresar" runat="server" class="btn btn-primary btn-block" onclick="btnIngresar_Click" Text="Ingresar" /></></div>
        </div>
        <br />
        </div>
    </form>
</body>
</html>

