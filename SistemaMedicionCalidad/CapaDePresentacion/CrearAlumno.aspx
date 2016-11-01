<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeBehind="CrearAlumno.aspx.cs" Inherits="CapaDePresentacion.CrearAlumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 232px;
        }
        .style4
        {
            width: 524px
        }
        .style5
        {
            width: 115px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

        <table class="form-group">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                    <h1>
                        Crear Alumno
                    </h1>
                </td>
                <td></td>
                <td class="style5">&nbsp;</td>
                <td class="style4"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td class="style5">&nbsp;</td>
                <td class="style4">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Menu ID="Menu2" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Alumno" NavigateUrl="~/CrearAlumno.aspx" Value="Crear Alumno"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Alumnos" NavigateUrl="~/AdministrarAlumnos.aspx" Value="Administrar Alumnos">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td class="style2">
                <label for="lbl1">Nombre</label>
                </td>
                <td><label for="lbl2">Rut (Ejemplo: 18205857-2)</label></td>
                <td class="style5">&nbsp;</td>
                <td class="style4">
                    <label for="lbl1">Escuela</label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                    <asp:TextBox ID="nombre" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    <asp:DropDownList ID="escuela" runat="server" class="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="style2">
                <label for="lbl1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label></td>
                <td>
                    <label for="lbl1">Direccion</label></td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                <label for="lbl1">Telefono</label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="style2">
                    <asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
                </td>
                    <td>
                    <asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox>
                </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td class="style4">
                    <asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                <label for="lbl1">Nacionalidad</label></td>
                <td>
                <label for="lbl1">Correo</label></td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                <label for="lbl1">Promocion</label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                    <asp:TextBox ID="nacionalidad" class="form-control" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                <asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                <label for="lbl1">Sexo</label></td>
                <td>
                    
                    <label for="lbl1">Beneficio</label></td>
                <td class="style5">
                    
                    &nbsp;</td>
                <td class="style4"></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td class="style2">
                    <asp:RadioButtonList ID="sexo" runat="server">
                        <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                        <asp:ListItem Value="Femenino"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="beneficio" runat="server">
                        <asp:ListItem Value="Si"></asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" onclick="btnCrear_Click" 
                        Text="Crear"/>
                </td>
            </tr>
        </table>    
    </asp:Content>