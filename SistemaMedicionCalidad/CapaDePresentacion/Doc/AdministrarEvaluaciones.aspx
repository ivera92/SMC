<%@ Page Title="" Language="C#" MasterPageFile="~/Doc/SiteDocente.Master" AutoEventWireup="true" CodeBehind="AdministrarEvaluaciones.aspx.cs" EnableEventValidation="false" Inherits="CapaDePresentacion.Doc.AdministrarEvaluaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="vEvaluaciones" runat="server" ImageUrl="ImagenesDoc/vEvaluaciones.PNG" />
            <div>
                <div class="col-sm-offset-2 col-sm-6">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre de asignatura o evaluacion" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-block" ForeColor="White" BackColor="#7F1734" BorderColor="White" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvEvaluaciones" runat="server" AutoGenerateColumns="false"
                        PageSize="10" AllowPaging="true" OnPageIndexChanging="gvEvaluaciones_PageIndexChanging" OnRowCommand="gvEvaluaciones_RowCommand">
                        <HeaderStyle BackColor="#7F1734" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen evaluaciones!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:ButtonField ButtonType="Button" CommandName="activo"  ControlStyle-CssClass="btnActivo" Text="Cambiar estado" HeaderText="Cambiar Estado">
                                <ControlStyle CssClass="btnActivo form-control"  ForeColor="White" BackColor="#7F1734" BorderColor="White" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Nombre_evaluacion" HeaderText="Evaluación" />
                            <asp:BoundField DataField="Asignatura_evaluacion.Nombre_asignatura" HeaderText="Asignatura" />
                            <asp:BoundField DataField="activo_evaluacion" HeaderText="Estado" />
                            <asp:BoundField DataField="Fecha_evaluacion" HeaderText="Fecha" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="porcentaje_exigencia_evaluacion" HeaderText="Exigencia(%)" />
                            <asp:ButtonField ButtonType="Image" ImageUrl="~/imagenes/pdf.png" CommandName="imgBtnPDF" ControlStyle-CssClass="BotonDeImagen" HeaderText="PDF">
                                <ControlStyle CssClass="BotonDeImagen" Width="40" Height="40" />
                            </asp:ButtonField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesDoc/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
