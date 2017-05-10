<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarDocentes.aspx.cs" Inherits="CapaDePresentacion.Doc.AdministrarDocentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="tablaAdministrar" runat="server">
        <br />
        <br />
        <h2 class="text-center">Administrar Docentes</h2>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvDocentes" runat="server"
                    AutoGenerateColumns="false" OnRowDeleting="rowDeleting"
                    OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen docentes!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Nombre_Persona" HeaderText="Nombre" />
                        <asp:BoundField DataField="Rut_Persona" HeaderText="Rut" />
                        <asp:BoundField DataField="Profesion_Docente.Nombre_profesion" HeaderText="Profesion" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div id="tablaEditar" runat="server">
        <br />
        <br />
        <h2 class="text-center">Actualizar Docente</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Nombre</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre"
                    oninvalid="setCustomValidity('La primera letra del nombre y apellido deben ir en mayuscula')"
                    oninput="setCustomValidity('')"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Rut</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" ReadOnly="True"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Fecha de nacimiento</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFechaDeNacimiento" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Profesion</label></div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddProfesion" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Direccion</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingrese su dirección"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Telefono</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" type="number" placeHolder="Ingrese su telefono" min="940000000" max="9999999999"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Correo</label></div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label>Nacionalidad</label></div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddPais" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-1">
                <label>Tiempo</label></div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="rbDisponibilidad" runat="server">
                    <asp:ListItem Value="Part-Time"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="Full-Time"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-1">
                <label>Sexo</label></div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="rbSexo" runat="server">
                    <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Value="Femenino"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-7 col-sm-2">
                <asp:Button ID="btnGuardar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
