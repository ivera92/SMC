<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CrearDocente.aspx.cs" Inherits="CapaDePresentacion.CrearDocente" %>

    <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
        <style type="text/css">
            .style1
            {
                width: 312px
            }
            .style2
            {
                width: 221px;
            }
        </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div>

    <table class="form-group">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <h1>Crear Docente</h1>
                </td>
                <td></td>
                <td>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                    <asp:Menu ID="Menu2" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Docente" NavigateUrl="~/CrearDocente.aspx" Value="Crear Docente"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Docentes" NavigateUrl="~/AdministrarDocentes.aspx" Value="Administrar Docentes">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td>
                <label form="label1">Nombre</label></td>
                <td>
                    <label form="label1">Rut</label></td>
                <td>
                <label form="label1">Fecha de nacimiento</label></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <asp:TextBox ID="nombre" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <label form="label1">Profesion</label></td>
                <td>
                    <label form="label1">Direccion</label></td>
                <td>
                    <label form="label1">Telefono</label></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <asp:DropDownList ID="profesion" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <label form="label1">Correo</label></td>
                <td>
                    <label form="label1">Nacionalidad</label></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="nacionalidad" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <label form="label1">Disponibilidad</label>
                </td>
                <td>
                    <label form="label1">Sexo</label></td>
                <td></td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <asp:RadioButtonList ID="disponibilidad" runat="server">
                    <asp:ListItem Value="Part-Time"></asp:ListItem>
                    <asp:ListItem Selected="True" Value="Full-Time"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="sexo" runat="server">
                    <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                    <asp:ListItem Value="Femenino"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" Text="Crear" onclick="btnCrear_Click" />
                </td>
            </tr>
        </table>
    </div>
    </asp:Content>