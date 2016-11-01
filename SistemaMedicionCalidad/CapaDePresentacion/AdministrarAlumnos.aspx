<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 74px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    

    <div id='divMostrar' runat='server'>
    <table class=  "form-group"id="tablaMostrar">
                <tr>
                <td></td>
                <td>
                    <h1>Administrar Alumnos</h1>
                </td>
                <td></td>
                </tr>

                <tr>
                <td></td>
                <td></td>
                <td></td>
                </tr>

                <tr>              
                <td></td>
                <td class="form-inline">
                    <asp:TextBox class="form-control" ID="tbxbuscar" runat="server" Width="172px"></asp:TextBox>
                    <asp:Button class="btn btn-primary" ID="btnbuscar" runat="server" Text="Buscar" 
                        onclick="btnbuscar_Click" />
                </td>
                <td></td>
                </tr>

                <tr>
                <td></td>
                <td></td>
                <td></td>
                </tr>

                <tr>
                <td>
                    <asp:Menu ID="Menu1" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Alumno" NavigateUrl="~/CrearAlumno.aspx" Value="Crear Alumno"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Alumnos" NavigateUrl="~/AdministrarAlumnos.aspx" Value="Administrar Alumnos">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td>
                    <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        onrowdeleting="rowDeletingEvent" onrowediting="rowEditingEvent">
                    <Columns>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true"  ShowDeleteButton="true" />
                        <asp:BoundField DataField="Nombre_Alumno" HeaderText="Nombre" />
                        <asp:BoundField DataField="Rut_Alumno" HeaderText="Rut" />
                        <asp:BoundField DataField="Id_Escuela_Alumno" HeaderText="Escuela" />
                        <asp:BoundField DataField="Promocion_Alumno" HeaderText="Promocion" />
                    </Columns>
                    </asp:GridView>
                </td>
                <td></td>
                </tr>
    </table>
    </div>

    <div id='divEditar' runat='server'>
    <table class="form-group" id="tablaEditar">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
                    <h1>Editar Alumno</h1>
                </td>
                <td></td>
                <td class="style1">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td></td>
                <td class="style1">&nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Menu ID="Menu2" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Alumno" NavigateUrl="~/CrearAlumno.aspx" Value="Crear Alumno"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Alumnos" NavigateUrl="~/AdministrarAlumnos.aspx" Value="Administrar Alumnos">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td><label for="lbl2">Nombre</label></td>
                <td><label for="lbl2">Rut (Ejemplo: 18205857-2)</label></td>
                <td class="style1">&nbsp;</td>
                <td><label for="lbl2">Escuela</label></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="nombre" class="form-control" runat="server" ></asp:TextBox>
                </td>
                <td>
        <asp:TextBox ID="rut" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style4">
        <asp:DropDownList EnableViewState = "true" class="dropdown" ID="escuela" runat="server" Width="177px">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td><label for="lbl2">Fecha de nacimiento (Ejemplo: 20/11/1992)</label></td>
                <td><label for="lbl2">Direccion</label></td>
                <td class="style1">&nbsp;</td>
                <td><label for="lbl2">Telefono</label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td>
        <asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td>
        <asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td></td>
                <td><label for="lbl2">Nacionalidad</label></td>
                <td><label for="lbl2">Correo</label></td>
                <td class="style1">&nbsp;</td>
                <td><label for="lbl2">Promocion</label></td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:TextBox ID="nacionalidad" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="style4">
        <asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td class="style3">
                    <asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td><label for="lbl2">Sexo</label></td>
                <td><label for="lbl2">Beneficio</label></td>
                <td class="style5">&nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>

            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td class="style2">
        <asp:RadioButtonList ID="sexo" runat="server">
            <asp:ListItem Value="Masculino"></asp:ListItem>
            <asp:ListItem Value="Femenino"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="beneficio" runat="server">
            <asp:ListItem Value="Si"></asp:ListItem>
            <asp:ListItem Value="No"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar" onclick="btnGuardar_Click"/>
                </td>
            </tr>
            </table>  
    </div>    
</asp:Content>
