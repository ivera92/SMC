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
    <div class="container" id="divLogin" runat="server">

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
        

        <asp:LinkButton CssClass="col-sm-offset-4" ID="recuperar" runat="server" OnClick="recuperar_Click">Recuperar Contraseña</asp:LinkButton>
        <br />

        <div class="row">
            <div class="col-sm-4 col-sm-offset-4"><asp:Button ID="btnIngresar" runat="server" class="btn btn-primary btn-block" onclick="btnIngresar_Click" Text="Ingresar" /></div>
        </div>
        </div>

        <div class="container"  id="divRut" runat="server">
            <br />
            <br />
            <h2 class="text-center">Recuperar tu contraseña</h2>
            <br />
            <label class="col-sm-offset-4">Rut</label>
            <div class="row">
                <div class="col-sm-offset-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="rutRC" runat="server" placeHolder="Ejemplo: 18205857-2"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="validar_rut" 
                            ControlToValidate="rutRC" Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True">
                        </asp:CustomValidator>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-sm-offset-5 col-sm-2">
                    <asp:Button ID="btnVerificarRut" Text="Verificar" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnVerificarRut_Click" />
                </div>
            </div>
        </div>

        <div class="container text-center" id="divCorreo" runat="server">
            <br />
            <br />
            <h2 class="text-center">Recuperar tu contraseña</h2>
            <br />

            <label>La cuenta asociada al rut es la siguiente:</label>
            <br />
            <label id="lblCorreo" runat="server"></label>
            <br />
            <label>Desea enviar un correo para verificar su clave?</label>
            <br />
            <div class="row">
                <div class="col-sm-offset-5 col-sm-1">
                    <asp:Button ID="btnEnviarC" runat="server" CssClass="btn btn-success btn-block" OnClick="btnEnviarC_Click" Text="Si" />
                </div>
                <div class="col-sm-1">
                    <asp:Button ID="btnNoEnviar" runat="server" CssClass="btn btn-danger btn-block" Text="No" OnClick="btnNoEnviar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

