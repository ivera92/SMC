<%@ Page Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarDocentes.aspx.cs" Inherits="CapaDePresentacion.AdministrarDocentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <h1 id="guardado" class="text-center" runat="server">Cambios guardados satisfactoriamente</h1>  
    <div id="tablaAdministrar" runat="server">

        <h2>Administrar Docentes</h2>
        <br />

        <div class="row">
            <div class="col-sm-4">
                <asp:TextBox class="form-control" ID="tbxbuscar" runat="server"></asp:TextBox>  
            </div>
            <div class="col-sm-2">
                <asp:Button class="btn btn-primary btn-block" ID="btnbuscar" runat="server" Text="Buscar" 
                onclick="btnbuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-10">
                <asp:GridView class="table table-striped" ID="Gridview1" runat="server" 
                AutoGenerateColumns="false" onrowdeleting="rowDeleting" 
                onrowediting="rowEditing">
                    <Columns>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Nombre_Docente" HeaderText="Nombre" />
                        <asp:BoundField DataField="Rut_Docente" HeaderText="Rut" />
                        <asp:BoundField DataField="Id_Profesion_Docente" HeaderText="Profesion" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</div>

<div id="tablaEditar" runat="server">
    <h2>Editar Docente</h2>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Nombre</label></div>
        <div class="col-sm-6"><label>Rut</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="nombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$" placeHolder="Ingrese su nombre" required></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server" ReadOnly="True"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Fecha de nacimiento</label></div>
        <div class="col-sm-6"><label>Profesion</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox></div>
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
        <div class="col-sm-6"><asp:TextBox ID="nacionalidad" class="form-control" runat="server" pattern="^[a-zA-Z]*$" placeHolder="Ingrese su nacionalidad" required></asp:TextBox></div>
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
        <div class="col-sm-2"><asp:Button ID="btnGuardar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Guardar" onclick="btnGuardar_Click" /></div>
    </div>          
</div>

</asp:Content>
