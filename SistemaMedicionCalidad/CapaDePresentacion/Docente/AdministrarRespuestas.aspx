<%@ Page Title="" Language="C#" MasterPageFile="SiteDocente.Master" AutoEventWireup="true" CodeBehind="AdministrarRespuestas.aspx.cs" Inherits="CapaDePresentacion.AdministrarRespuestas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Administrar Respuestas</h2>
    <br />
    <div class="row">
        <div class="col-sm-8">
            <asp:GridView class="table table-striped" ID="gvRespuestas" runat="server" AutoGenerateColumns="false" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing" >
                <Columns>
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ShowEditButton="true" />
                    <asp:BoundField DataField="Id_Respuesta" HeaderText="ID" />
                    <asp:BoundField DataField="Pregunta_Respuesta.Nombre_Pregunta" HeaderText="Pregunta" />
                    <asp:BoundField DataField="Nombre_Respuesta" HeaderText="Respuesta" />
                    </Columns>
            </asp:GridView>
        </div>
        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
    </div>
    </asp:Content>
