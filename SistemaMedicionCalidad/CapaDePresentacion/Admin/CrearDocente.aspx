<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/rut.js"></script>    
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server">
        <br />
        <br />
    <h2 class="text-center">Crear Docente</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Nombre</label></div>
        <div class="col-sm-4"><asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre" 
                oninvalid="setCustomValidity('La primera letra del nombre y apellido deben ir en mayuscula')"
                oninput="setCustomValidity('')"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Rut</label></div>
        <div class="col-sm-4"><asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" ></asp:TextBox></div>
    </div>
    <br />

     <div class="row">
           <div class="col-sm-offset-7">
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
            ClientValidationFunction="validar_rut" ControlToValidate="txtRut" 
            Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True"></asp:CustomValidator>
           </div>
       </div>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Fecha de nacimiento</label></div>
        <div class="col-sm-4">
            <asp:TextBox ID="txtFechaDeNacimiento" class="form-control" runat="server" type="date" max="1992-12-31" data-date-format="DD-MM-YYYY HH:mm:ss"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Profesion</label></div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddProfesion" runat="server" class="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="0"><--Seleccione una profesion--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Direccion</label></div>
        <div class="col-sm-4"><asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingrese su dirección"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Telefono</label></div>
        <div class="col-sm-4"><asp:TextBox ID="txtTelefono" class="form-control" runat="server" type="number" placeHolder="Ingrese su telefono" min="940000000" max="9999999999"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Correo</label></div>
        <div class="col-sm-4"><asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-2"><label>Nacionalidad</label></div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddPais" runat="server" class="form-control" AppendDataBoundItems="true">
                <asp:ListItem Value="0"><--Seleccione un pais--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Tiempo</label></div>
        <div class="col-sm-2">
            <asp:RadioButtonList ID="rbDisponibilidad" runat="server">
                    <asp:ListItem Value="Part-Time"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="Full-Time"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-1"><label>Sexo</label></div>
        <div class="col-sm-2">
            <asp:RadioButtonList ID="rbSexo" runat="server">
                    <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Value="Femenino"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-2 col-sm-offset-7"><asp:Button ID="btnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" onclick="btnCrear_Click" /></div>
    </div>          
        </div>
</asp:Content>