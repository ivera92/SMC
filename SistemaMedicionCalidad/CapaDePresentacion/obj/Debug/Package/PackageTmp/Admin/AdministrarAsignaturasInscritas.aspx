<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAsignaturasInscritas.aspx.cs" Inherits="CapaDePresentacion.AdministrarAsignaturasInscritas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="aAI" runat="server" ImageUrl="ImagenesAdmin/aAIA.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese alumno o asignatura a buscar" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvCursa" runat="server" AutoGenerateColumns="false"
                        OnPageIndexChanging="gvCursa_PageIndexChanging"
                        PageSize="10" AllowPaging="true" OnRowDeleting="rowDeleting">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen asignaturas inscritas!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="id_aa" HeaderText="ID" />
                            <asp:BoundField DataField="rut_alumno_aa.nombre_persona" HeaderText="Alumno" />
                            <asp:BoundField DataField="cod_asignatura_aa.nombre_asignatura" HeaderText="Asignatura" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <asp:TextBox runat="server" ID="txtId"></asp:TextBox>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
