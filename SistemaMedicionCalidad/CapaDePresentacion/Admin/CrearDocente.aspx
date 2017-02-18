<%@ Page Language="C#" MasterPageFile="Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

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

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
    <h2>Crear Docente</h2>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Nombre</label></div>
        <div class="col-sm-6"><label>Rut</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="nombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre" required
                oninvalid="setCustomValidity('La primera letra del nombre y apellido deben ir en mayuscula')"
                oninput="setCustomValidity('')"></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox></div>
     </div>
     <div class="row">
           <div class="col-sm-offset-7">
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ClientValidationFunction="validar_rut" ControlToValidate="rut" 
            Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True"></asp:CustomValidator>
           </div>
       </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Fecha de nacimiento</label></div>
        <div class="col-sm-6"><label>Profesion</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server" type="date" format="data-fv-date-format" required></asp:TextBox></div>
        <div class="col-sm-6"><asp:DropDownList ID="profesion" runat="server" class="form-control"></asp:DropDownList></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Direccion</label></div>
        <div class="col-sm-6"><label>Telefono</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="direccion" class="form-control" runat="server" placeHolder="Ingrese su dirección" required></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="telefono" class="form-control" runat="server" type="number" placeHolder="Ingrese su telefono" min="940000000" max="9999999999" required></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Correo</label></div>
        <div class="col-sm-6"><label>Nacionalidad</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="correo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox></div>
        <div class="col-sm-6"><asp:DropDownList ID="ddPais" runat="server" class="form-control"></asp:DropDownList></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-3"><label>Disponibilidad</label></div>
        <div class="col-sm-3"><label>Sexo</label></div>
    </div>

    <div class="row">
        <div class="col-sm-3">
            <asp:RadioButtonList ID="disponibilidad" runat="server">
                    <asp:ListItem Value="Part-Time"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="Full-Time"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-3">
            <asp:RadioButtonList ID="sexo" runat="server">
                    <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Value="Femenino"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2"><asp:Button ID="btnCrear" class="btn btn-primary btn-lg btn-block" runat="server" Text="Crear" onclick="btnCrear_Click" /></div>
    </div>          
        </div>
</asp:Content>