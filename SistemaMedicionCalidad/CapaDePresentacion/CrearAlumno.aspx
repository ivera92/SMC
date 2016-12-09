<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeBehind="CrearAlumno.aspx.cs" Inherits="CapaDePresentacion.CrearAlumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">           
   
        <h2>
                        Crear Alumno
        </h2>
        <br />
        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Nombre</label></div>
            <div class="col-sm-6"><label for="lbl2">Rut (Ejemplo: 18205857-2)</label></div>
        </div>
              
        <div class="row">
            <div class="col-sm-6"><asp:TextBox class="form-control" ID="nombre" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label></div>
            <div class="col-sm-6"><label for="lbl1">Direccion</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Correo</label></div>
            <div class="col-sm-6"><label for="lbl1">Telefono</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl9">Nacionalidad</label></div>
            <div class="col-sm-6"><label for="lbl10">Escuela</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="nacionalidad" class="form-control" runat="server" ></asp:TextBox></div>
            <div class="col-sm-6"><asp:DropDownList ID="escuela" runat="server" class="form-control"></asp:DropDownList></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Año ingreso</label></div>
            <div class="col-sm-2"><label for="lbl10">Sexo</label></div>
            <div class="col-sm-2"><label for="lbl1">Beneficio</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox></asp:TextBox></div>
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
    </asp:Content>
