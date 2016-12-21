<%@ Page Language="C#" MasterPageFile="~/Site.master" EnableEventValidation="false" AutoEventWireup="true"  CodeBehind="CrearAlumno.aspx.cs" Inherits="CapaDePresentacion.CrearAlumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <script>
        function validaRut(rut) {
            var rexp = new RegExp(/^([0-9])+\-([kK0-9])+$/);
            if (rut.match(rexp)) {
                var RUT = rut.split("-");
                var elRut = RUT[0].toArray();
                var factor = 2;
                var suma = 0;
                var dv;
                for (i = (elRut.length - 1) ; i >= 0; i--) {
                    factor = factor > 7 ? 2 : factor;
                    suma += parseInt(elRut[i]) * parseInt(factor++);
                }
                dv = 11 - (suma % 11);
                if (dv == 11) {
                    dv = 0;
                } else if (dv == 10) {
                    dv = "k";
                }

                if (dv == RUT[1].toLowerCase()) {
                    alert("El rut es válido!!");
                    return true;
                } else {
                    alert("El rut es incorrecto");
                    return false;
                }
            } else {
                alert("Formato incorrecto");
                return false;
            }
        }
    </script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">  
    <h1 id="creado" class="text-center" runat="server">Alumno creado satisfactoriamente</h1>  

   <div id="crear" runat="server">
        <h2>Crear Alumno</h2>
        <br />
        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Nombre</label></div>
            <div class="col-sm-6"><label for="lbl2">Rut </label></div>
        </div>
              
        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="nombre" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre" class="form-control" required></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Fecha de nacimiento</label></div>
            <div class="col-sm-6"><label for="lbl1">Direccion</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server" type="date" format="data-fv-date-format" required></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="direccion" class="form-control" runat="server" placeHolder="Ingrese su dirección" required></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Correo</label></div>
            <div class="col-sm-6"><label for="lbl1">Telefono</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="correo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="telefono" class="form-control" runat="server" type="number" placeHolder="Ingrese su telefono" min="940000000" max="9999999999" required></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl9">Nacionalidad</label></div>
            <div class="col-sm-6"><label for="lbl10">Escuela</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="nacionalidad" class="form-control" runat="server" pattern="^[a-zA-Z]*$" placeHolder="Ingrese su nacionalidad" required></asp:TextBox></div>
            <div class="col-sm-6"><asp:DropDownList ID="escuela" runat="server" class="form-control"></asp:DropDownList></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Año ingreso</label></div>
            <div class="col-sm-2"><label for="lbl10">Sexo</label></div>
            <div class="col-sm-2"><label for="lbl1">Beneficio</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="promocion" class="form-control" runat="server" placeHolder="Ingrese año ingreso" type="number" min="2010" required></asp:TextBox></div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="sexo" runat="server">
                        <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                        <asp:ListItem Value="Femenino"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="beneficio" runat="server">
                        <asp:ListItem Value="Si"></asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnCrear" class="btn btn-primary btn-block btn-lg" runat="server" onclick="btnCrear_Click" Text="Crear"/>
            </div>        
        </div>
    </div>
</asp:Content>
