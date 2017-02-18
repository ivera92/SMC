<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="AdministrarPreguntas.aspx.cs" Inherits="CapaDePresentacion.AdministrarPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="administrar">
    <h2> Administrar Preguntas</h2>
    <br />

    <div class="row">
            <div class="col-sm-8">
                <asp:GridView class="table table-striped" ID="gvPreguntas" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting">
                    <Columns>
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true"/>
                    <asp:BoundField DataField="Nombre_pregunta" HeaderText="Nombre" />
                    <asp:BoundField DataField="Id_pregunta" HeaderText="ID" />
                    </Columns>
                </asp:GridView>
            </div>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
        </div>

    <div runat="server" id="editar">
        <h2>Editar Pregunta</h2>
    <br />

    <label>Pregunta</label>
    <asp:TextBox class="form-control" runat="server" ID="txtPregunta" placeHolder="Ingrese pregunta" required></asp:TextBox>
    <br />
    
    <div class="row">
        <div class="col-sm-4">
            <label>Competencia</label>
        </div>
        <div class="col-sm-4">
            <label>Tipo de Pregunta</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-4">
            <asp:DropDownList class="form-control" runat="server" ID="ddCompetencia"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <asp:DropDownList class="form-control" runat="server" ID="ddTipoPregunta"></asp:DropDownList>
        </div>
        <br />
    </div>

        <br />
        <h2>Respuestas</h2>
        <label class="col-sm-offset-6">Correcta</label>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <br />
        <div class="row">
            <div class="col-sm-2">
            <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnGuardar" Text="Guardar"/>
            </div>
        </div>
    </div>

</asp:Content>
