<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarEscuelas.aspx.cs" Inherits="CapaDePresentacion.AdministrarEscuelas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div id="tablaAdministrar" runat="server">

        <h2> Administrar Escuelas</h2>
        <br />
        
        <div class="row">
            <div class="col-sm-8">
                <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="false" 
                    onrowdeleting="rowDeleting" onrowediting="rowEditing">
                    <Columns>
                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" ShowEditButton="true" />
                    <asp:BoundField DataField="Nombre_Escuela" HeaderText="Nombre" />
                    <asp:BoundField DataField="Id_Escuela" HeaderText="ID" />
                    </Columns>
                </asp:GridView>
            </div>
                <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        </div>
    </div>
    
    <div id="tablaEditar" runat="server">
        <h2>Editar Escuela</h2>
    <br />

    <div class="row">
        <div class="col-sm-4"><label>Nombre</label></div>
    </div>
    <div class="row">
        <div class="col-sm-4"><asp:TextBox ID="tbxEscuela" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-2"><asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/></div>
    </div>
    </div>
</asp:Content>