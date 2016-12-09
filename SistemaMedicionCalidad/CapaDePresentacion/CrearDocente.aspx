<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  
    <h2>Crear Docente</h2>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Nombre</label></div>
        <div class="col-sm-6"><label>Rut (Ejemplo: 18205857-2)</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="nombre" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Fecha de nacimiento (Ejemplo: 20/11/1992)</label></div>
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
        <div class="col-sm-6"><asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox></div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-6"><label>Correo</label></div>
        <div class="col-sm-6"><label>Nacionalidad</label></div>
    </div>

    <div class="row">
        <div class="col-sm-6"><asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-6"><asp:TextBox ID="nacionalidad" class="form-control" runat="server"></asp:TextBox></div>
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
</asp:Content>