<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Administrar Alumnos
    </h2>
    <p>
    <table style="width:100%;">
            <tr>
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
                        CellPadding="4" DataKeyNames="RUT_ALUMNO" DataSourceID="SqlDataSource1" 
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="RUT_ALUMNO" HeaderText="RUT" ReadOnly="True" 
                                SortExpression="RUT_ALUMNO" />
                            <asp:BoundField DataField="ID_ESCUELA" HeaderText="ESCUELA" 
                                SortExpression="ID_ESCUELA" />
                            <asp:BoundField DataField="NOMBRE_ALUMNO" HeaderText="NOMBRE" 
                                SortExpression="NOMBRE_ALUMNO" />
                            <asp:BoundField DataField="NACIONALIDAD_ALUMNO" 
                                HeaderText="NACIONALIDAD" SortExpression="NACIONALIDAD_ALUMNO" />
                            <asp:CheckBoxField DataField="SEXO_ALUMNO" HeaderText="SEXO" 
                                SortExpression="SEXO_ALUMNO" />
                            <asp:BoundField DataField="PROMOCION_ALUMNO" HeaderText="PROMOCION" 
                                SortExpression="PROMOCION_ALUMNO" />
                            <asp:CheckBoxField DataField="BENEFICIO_ALUMNO" HeaderText="BENEFICIO" 
                                SortExpression="BENEFICIO_ALUMNO" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:MedicionCalidadConnectionString %>" 
                        SelectCommand="SELECT [RUT_ALUMNO], [ID_ESCUELA], [NOMBRE_ALUMNO], [NACIONALIDAD_ALUMNO], [SEXO_ALUMNO], [PROMOCION_ALUMNO], [BENEFICIO_ALUMNO] FROM [ALUMNO]">
                    </asp:SqlDataSource>
                </td>
                <td class="style4">
                    &nbsp;</td>
                    &nbsp;</p>
                </tr>
                </table>
</asp:Content>
