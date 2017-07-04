<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/rut.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:Image ID="cDocente" runat="server" ImageUrl="ImagenesAdmin/cDocente.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">                
                <div>
                    <br />
                    <label>Rut</label>
                    <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox>
                </div>

                <div>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                        Display="Dynamic" ErrorMessage="RUT incorrecto" SetFocusOnError="True" ForeColor="Red"></asp:CustomValidator>
                    <br />
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,}([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,})+)$" placeHolder="Ingrese su nombre y apellido"
                        oninvalid="setCustomValidity('Ingrese nombre y apellido separados por un espacio, ambos de 3 letras a lo menos, solo letras')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>


                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" pattern="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" 
                        placeHolder="Ejemplo: ejemplo@live.cl" oninvalid="setCustomValidity('Correo ingresado no cumple con el formato')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Asignatura (Opcional)</label>
                    <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>


                <div class="col-sm-6">
                    <label>Contrato</label>
                    <asp:RadioButtonList ID="rbDisponibilidad" runat="server">
                        <asp:ListItem Selected="True" Value="0">Part-Time</asp:ListItem>
                        <asp:ListItem Value="1">Full-Time</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-6">
                    <br />
                    <asp:Button ID="btnCrear" class="btn btn-success btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
