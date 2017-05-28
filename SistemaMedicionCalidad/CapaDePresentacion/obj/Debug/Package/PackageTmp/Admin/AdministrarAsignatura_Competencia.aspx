<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAsignatura_Competencia.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarAsignatura_Competencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="divMostrar" runat="server">
        <h2 class="text-center">Administrar Competencias</h2>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvAC" runat="server" AutoGenerateColumns="false"
                    OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen asignaturas asociadas a competencias!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Id_Ac" HeaderText="Id" />
                        <asp:BoundField DataField="Cod_asignatura_ac.Cod_asignatura" HeaderText="Asignatura" />
                        <asp:BoundField DataField="Id_competencia_ac.Nombre_competencia" HeaderText="Competencia" />
                        <asp:BoundField DataField="Nivel_dominio_ac" HeaderText="Nivel" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox runat="server" ID="txtAC"></asp:TextBox>
        </div>
    </div>


    <div id="divEditar" runat="server">
        <h2 class="text-center">Actualizar asociacion</h2>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Competencia</label>
        <div class="col-sm-4">
            <asp:DropDownList CssClass="form-control" ID="ddCompetencia" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Asignatura</label>
        <div class="col-sm-4">
            <asp:DropDownList CssClass="form-control" ID="ddAsignatura" runat="server">
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <label class="col-sm-offset-3 col-sm-2">Nivel de dominio</label>
        <div class="col-sm-4">
            <asp:TextBox ID="txtNivelDominio" placeHolder="Ejemplo: C01" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-5 col-sm-2">
            <asp:Button CssClass="btn btn-block btn-primary" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
            <br />
        </div>
    </div>
    </div>
</asp:Content>
