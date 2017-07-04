<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarHPA.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarHPA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="hRA" runat="server" ImageUrl="ImagenesAdmin/hRA.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-2 col-sm-6">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre de alumno o evaluacion" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvHPA" runat="server" AutoGenerateColumns="false" PageSize="15" AllowPaging="true" OnPageIndexChanging="gvHPA_PageIndexChanging">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen datos!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="alumno_hpa.nombre_persona" HeaderText="Alumno" />
                            <asp:BoundField DataField="id_evaluacion_hpa.nombre_evaluacion" HeaderText="Evaluación" />
                            <asp:BoundField DataField="pregunta_hpa.enunciado_pregunta" HeaderText="Pregunta" />
                            <asp:BoundField DataField="respuesta_hpa.nombre_respuesta" HeaderText="Respuesta" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
