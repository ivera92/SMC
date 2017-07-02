<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarCompetencias.aspx.cs" Inherits="CapaDePresentacion.AdministrarCompetencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMostrar" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cCompetencia" runat="server" ImageUrl="ImagenesAdmin/aCompetencias.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese ambito, tipo o descripción a buscar" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvCompetencias" runat="server" AutoGenerateColumns="false"
                        OnRowDeleting="rowDeleting" OnRowEditing="rowEditing" OnPageIndexChanging="gvCompetencias_PageIndexChanging"
                        PageSize="10" AllowPaging="true">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen competencias!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Id_Competencia" HeaderText="Id" />
                            <asp:BoundField DataField="Id_ambito.nombre_ambito" HeaderText="Ambito" />
                            <asp:BoundField DataField="Id_tipo_competencia.nombre_tipo_competencia" HeaderText="Tipo Competencia" />
                            <asp:BoundField DataField="nombre_Competencia" HeaderText="Competencia" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <asp:TextBox runat="server" ID="txtCompetencia"></asp:TextBox>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>

    <div id="divEditar" runat="server" class="row">
        <div class="col-sm-6 col-sm-offset-3">
            <asp:Image ID="acCompetencia" runat="server" ImageUrl="ImagenesAdmin/acCompetencia.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Ambito</label>
                    <asp:DropDownList ID="ddAmbito" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <br />
                </div>

                <div>
                    <label>Tipo</label>
                    <asp:DropDownList ID="ddTipoCompetencia" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <div>
                    <br />
                    <label>Nombre</label>
                    <textarea class="form-control" id="txtNombre" runat="server" rows="5" required></textarea>
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <br />
                    <asp:Button ID="btnGuardar" class="btn btn-success btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM6" runat="server" ImageUrl="ImagenesAdmin/iEndSM6.PNG" />
        </div>
    </div>
</asp:Content>

