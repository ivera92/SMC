<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Administrar Alumnos
    </h2>
    <p>
    <table style="width:100%;">
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
                        onrowdeleting="rowDeletingEvent" onrowediting="rowEditingEvent" 
                        onrowupdating="rowUpdatingEvent">
                    <Columns>
                        <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Nombre_Alumno" HeaderText="Nombre" />
                        <asp:BoundField DataField="Rut_Alumno" HeaderText="Rut" />
                        <asp:BoundField DataField="Id_Escuela" HeaderText="Escuela" />
                        <asp:BoundField DataField="Promocion_Alumno" HeaderText="Promocion" />
                    </Columns>
                    </asp:GridView>
                </td>
                <td class="style4">
                    &nbsp;</td>
                    &nbsp;</p>
                </table>
</asp:Content>
