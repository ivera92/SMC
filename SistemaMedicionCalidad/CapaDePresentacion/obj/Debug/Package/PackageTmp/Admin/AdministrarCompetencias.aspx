<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarCompetencias.aspx.cs" Inherits="CapaDePresentacion.AdministrarCompetencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divMostrar" runat="server">
        <h2 class="text-center">Administrar Competencias</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese ambito, tipo o descripción a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvCompetencias" runat="server" AutoGenerateColumns="false"
                    OnRowDeleting="rowDeleting" OnRowEditing="rowEditing" OnPageIndexChanging="gvCompetencias_PageIndexChanging"
                    PageSize="10" AllowPaging="true">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen competencias!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Id_Competencia" HeaderText="Id" />
                        <asp:BoundField DataField="Id_ambito.nombre_ambito" HeaderText="Ambito" />
                        <asp:BoundField DataField="Id_tipo_competencia.nombre_tipo_competencia" HeaderText="Tipo Competencia" />                        
                        <asp:BoundField DataField="nombre_Competencia" HeaderText="Competencia" />
                    </Columns>
                    <PagerStyle HorizontalAlign = "Right" CssClass ="pagination-ys" />
                </asp:GridView>
            </div>
            <asp:TextBox runat="server" ID="txtCompetencia"></asp:TextBox>
        </div>
    </div>

    <div id="divEditar" runat="server">
        <h2 class="text-center">Actualizar Competencia</h2>
        <br />

        <label class="col-sm-offset-3">Ambito</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList ID="ddAmbito" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione ambito--></asp:ListItem>
                </asp:DropDownList>
            </div>            
        </div>
        <br />

        <label class="col-sm-offset-3">Tipo</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList ID="ddTipoCompetencia" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione un tipo de competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>            
        </div>
        <br />

        <label class="col-sm-offset-3">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <textarea class="form-control" id="txtNombre" runat="server" rows="5" required></textarea>
            </div>
        </div>
        <br />
        
        <div class="row">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>

