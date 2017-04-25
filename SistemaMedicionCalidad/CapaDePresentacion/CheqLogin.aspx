<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheqLogin.aspx.cs" Inherits="CapaDePresentacion.CheqLogin" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="Scripts/rut.js"></script>


    <title>Universidad Austral de Chile</title>
</head>
<body>
    <br />
    <form runat="server">
        <div id="divLogin" class="col-sm-offset-4 col-sm-4" runat="server" style="border: solid 2px #ccc">
        <div>
            <br />
            <h2 class="text-center">Iniciar sesión</h2>
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
                <asp:Button ID="btnIngresar" runat="server" class="btn btn-default btn-block" onclick="btnIngresar_Click" Text="Ingresar" />
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

        <div class="text-center col-sm-offset-4 col-sm-4" id="divCorreo" runat="server" style="border: solid 2px #ccc">
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
</body>
</html>

