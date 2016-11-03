<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeBehind="CrearAlumno.aspx.cs" Inherits="CapaDePresentacion.CrearAlumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

        <table >

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <h2>
                        Crear Alumno
                    </h2>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td>
                    &nbsp;</td>
                <td>
                    <label for="lbl1">Nombre</label>
                </td>
                <td>
                    <label for="lbl2">Rut (Ejemplo: 18205857-2)</label>
                </td>
                <td></td>
                <td>
                    <label for="lbl1">Escuela</label></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:TextBox ID="nombre" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:DropDownList ID="escuela" runat="server" class="dropdown">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                <label for="lbl1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label></td>
                <td>
                    <label for="lbl1">Direccion</label></td>
                <td></td>
                <td>
                <label for="lbl1">Telefono</label></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
                </td>
                    <td>
                    <asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox>
                </td>
                    <td></td>
                    <td>
                    <asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox>
                    </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                <label for="lbl1">Nacionalidad</label></td>
                <td>
                <label for="lbl1">Correo</label></td>
                <td></td>
                <td>
                <label for="lbl1">Promocion</label></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <asp:TextBox ID="nacionalidad" class="form-control" runat="server" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td></td>
                <td>
                <asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox>
                </td>
                
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
                    <label for="lbl1">Sexo</label>
                </td>
                <td>
                    <label for="lbl1">Beneficio</label>
                </td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td>
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
                <td></td>
                <td>
                    <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" onclick="btnCrear_Click" 
                        Text="Crear"/>
                </td>
            </tr>
        </table>    
    </asp:Content>