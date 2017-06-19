﻿<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarAsignaturas.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarAsignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divAdministrar" runat="server">
        <h2 class="text-center">Administrar Asignaturas</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre o codigo a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvAsignatura" runat="server" AutoGenerateColumns="False" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing"
                    PageSize="10" AllowPaging="true" OnPageIndexChanging="gvAsignatura_PageIndexChanging">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen asignaturas!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Cod_Asignatura" HeaderText="Codigo" />
                        <asp:BoundField DataField="Escuela_Asignatura.Nombre_Escuela" HeaderText="Escuela" />
                        <asp:BoundField DataField="Nombre_Asignatura" HeaderText="Asignatura" />
                        <asp:BoundField DataField="Duracion_Asignatura" HeaderText="Duracion" Visible="false" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
    </div>

    <div id="divEditar" runat="server">
        <h2 class="text-center">Actualizar Asignatura</h2>
        <br />

        <label class="col-sm-offset-4">Codigo</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeHolder="Ingrese codigo, ejemplo: CIBA019" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Escuela</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:DropDownList runat="server" ID="ddEscuela" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚa-zñáéíóú1234567890]{1}*)+$" placeHolder="Ingrese nombre" required></asp:TextBox>
            </div>
        </div>
        <br />

        <label class="col-sm-offset-4">Duracion</label>
        <div class="row">
            <div class="col-sm-offset-4 col-sm-2">
                <asp:RadioButtonList ID="rbDuracion" runat="server">
                    <asp:ListItem Value="Semestral"></asp:ListItem>
                    <asp:ListItem Value="Anual"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
        <br />
    </div>

</asp:Content>