<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarDocentes.aspx.cs" Inherits="CapaDePresentacion.AdministrarDocentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<div id="tablaAdministrar" runat="server">
<table>

    <tr>
        <td></td>
        <td>
            <h2>Administrar Docentes</h2>
        </td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>

        <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>

    <tr>
        <td></td>
        <td></td>
        <td></td>
        </tr>

        <tr>
        <td></td>
        <td class="form-inline">
            <asp:TextBox class="form-control" ID="tbxbuscar" runat="server"></asp:TextBox>
            <asp:Button class="btn btn-primary" ID="btnbuscar" runat="server" Text="Buscar" 
                onclick="btnbuscar_Click"/>
        </td>
        <td></td>
        </tr>

        <tr>
        <td>&nbsp;</td>
        <td class="form-inline">
            &nbsp;</td>
        <td>&nbsp;</td>
        </tr>

        <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server">
                <Items>
                    <asp:MenuItem Text="Crear Docente" NavigateUrl="~/CrearDocente.aspx" Value="Crear Docente"></asp:MenuItem>
                    <asp:MenuItem Text="Administrar Docentes" NavigateUrl="~/AdministrarDocentes.aspx" Value="Administrar Docentes">
                    </asp:MenuItem>
                </Items>
             </asp:Menu>
        </td>
        <td>
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
        </td>
        <td></td>
    </tr>

</table>
</div>

<div id="tablaEditar" runat="server">
<table class="form-group">
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td></td>
        <td>
            <h2>Editar Docente</h2>
        </td>
        <td></td>
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
            <label form="label1">Rut (Ejemplo: 18205857-2)</label></td>
        <td>
            <label form="label1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label>
        </td>
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
            <label form="label1">Telefono</label>
        </td>
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
            <asp:ListItem Value="Full-Time"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:RadioButtonList ID="sexo" runat="server">
            <asp:ListItem Value="Masculino"></asp:ListItem>
            <asp:ListItem Value="Femenino"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" 
                Text="Guardar" onclick="btnGuardar_Click"/>
        </td>
    </tr>
</table>
</div>

</asp:Content>
