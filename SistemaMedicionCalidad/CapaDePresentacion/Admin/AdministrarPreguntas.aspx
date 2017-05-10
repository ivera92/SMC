<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarPreguntas.aspx.cs" Inherits="CapaDePresentacion.AdministrarPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="administrar">
        <br />
        <br />
        <h2 class="text-center">Administrar Preguntas</h2>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView class="table table-striped" ID="gvPreguntas" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen preguntras!
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" />
                        <asp:BoundField DataField="Enunciado_pregunta" HeaderText="Nombre" />
                        <asp:BoundField DataField="Competencia_pregunta.Nombre_competencia" HeaderText="Competencia" />
                        <asp:BoundField DataField="Nivel_pregunta" HeaderText="Nivel" />
                        <asp:BoundField DataField="Id_pregunta" HeaderText="ID" />
                    </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
    </div>

    <div runat="server" id="editar">
        <br />
        <br />
        <h2 class="text-center">Actualizar Pregunta</h2>
        <br />

        <label class="col-sm-offset-3">Enunciado</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <textarea class="form-control" id="txtAPregunta" runat="server" rows="3"></textarea>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-4 col-sm-4">
                <asp:FileUpload ID="fileImagen" runat="server" onchange="showimagepreview(this)" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <img runat="server" alt="" src="s" id="imgFoto" class="img-responsive" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <label>Competencia</label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList class="form-control" runat="server" ID="ddCompetencia">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <label>Tipo de Pregunta</label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList class="form-control" AutoPostBack="true" runat="server" ID="ddTipoPregunta">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <br />

        <label class="col-sm-offset-8">Correcta</label>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <br />
        <div class="row">
            <div class="col-sm-offset-7 col-sm-2">
                <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click1" />
                <br />
            </div>
        </div>
    </div>

</asp:Content>
