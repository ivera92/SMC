<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Editar Alumno
    </h2>

    <div id='divMostrar' runat='server'>
    <table style="width:100%;" id="tablaMostrar">
                <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    <asp:TextBox ID="tbxbuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" Text="Buscar" 
                        onclick="btnbuscar_Click" />
                </td>
                <td class="style4">
                    &nbsp;</td>
                    </tr>
                <td class="style2">
                    <asp:Menu ID="Menu1" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Alumno" NavigateUrl="~/CrearAlumno.aspx" Value="Crear Alumno"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Alumnos" NavigateUrl="~/AdministrarAlumnos.aspx" Value="Administrar Alumnos">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td class="style5">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
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
                <td class="style4">
                    &nbsp;
                </td>
    </table>
    </div>

    <div id='divEditar' runat='server'>
    <table style="width:100%;" id="tablaEditar">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:Label ID="Label5" runat="server" Text="Nombre"></asp:Label>
                </td>
                <td class="style4">
        <asp:Label ID="Label2" runat="server" Text="Rut"></asp:Label>
                </td>
                <td class="style3">
        <asp:Label ID="Label4" runat="server" Text="Escuela"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Menu ID="Menu2" runat="server">
                        <Items>
                            <asp:MenuItem Text="Crear Alumno" NavigateUrl="~/CrearAlumno.aspx" Value="Crear Alumno"></asp:MenuItem>
                            <asp:MenuItem Text="Administrar Alumnos" NavigateUrl="~/AdministrarAlumnos.aspx" Value="Administrar Alumnos">
                            </asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td class="style5">
                    <asp:TextBox ID="nombre" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style4">
        <asp:TextBox ID="rut" runat="server" Width="85px" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text="Ejemplo: 18205857-2"></asp:Label>
                </td>
                <td class="style3">
        <asp:DropDownList EnableViewState = "true" ID="escuela" runat="server" Width="162px">
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:Label ID="Label6" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    <br />
                    <asp:Label ID="Label14" runat="server" Text="Ejemplo: 20/11/1992"></asp:Label>
                </td>
                <td class="style4">
        <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
                </td>
                <td class="style3">
        <asp:Label ID="Label8" runat="server" Text="Telefono"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:TextBox ID="fechaDeNacimiento" runat="server" Width="180px"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:TextBox ID="direccion" runat="server" Width="157px"></asp:TextBox>
                </td>
                <td class="style3">
        <asp:TextBox ID="telefono" runat="server" Width="85px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:Label ID="Label9" runat="server" Text="Nacionalidad"></asp:Label>
                </td>
                <td class="style4">
        <asp:Label ID="Label11" runat="server" Text="Correo"></asp:Label>
                </td>
                <td class="style3">
        <asp:Label ID="Label12" runat="server" Text="Promocion"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:TextBox ID="nacionalidad" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="style4">
        <asp:TextBox ID="correo" runat="server"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:TextBox ID="promocion" runat="server" Width="70px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:Label ID="Label10" runat="server" Text="Sexo"></asp:Label>
                </td>
                <td class="style4">
        <asp:Label ID="Label13" runat="server" Text="Beneficio"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
        <asp:RadioButtonList ID="sexo" runat="server">
            <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
            <asp:ListItem Value="Femenino"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td class="style4">
                    <asp:RadioButtonList ID="beneficio" runat="server">
            <asp:ListItem Value="Si"></asp:ListItem>
            <asp:ListItem Selected="True" Value="No"></asp:ListItem>
        </asp:RadioButtonList>
                </td>
                <td class="style3">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Height="39px" 
                        Width="86px" onclick="btnGuardar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    </td>
                <td class="style5">
                    </td>
                <td class="style4">
                </td>
                <td class="style7">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
            </tr>
        </table>  
    </div>

    
</asp:Content>
