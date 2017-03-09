<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarAsignaturas.aspx.cs" Inherits="CapaDePresentacion.AdministrarAsignaturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="divAdministrar" runat="server">
    <h2> Administrar Asignaturas</h2>
    <br />

    <div class="row">
        <div class="col-sm-8">
            <asp:GridView class="table table-striped" id="gvAsignatura" runat="server" AutoGenerateColumns="False" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                <Columns>
                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" />
                    <asp:BoundField DataField="Id_Asignatura" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre_Asignatura" HeaderText="Nombre" />
                    <asp:BoundField DataField="Escuela_Asignatura.Nombre_Escuela" HeaderText="Escuela" />
                    <asp:BoundField DataField="Docente_Asignatura.Nombre_Persona" HeaderText="Docente"/>
                    <asp:BoundField DataField="Ano_Asignatura" HeaderText="Año" />
                    <asp:BoundField DataField="Duracion_Asignatura" HeaderText="Duracion" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:TextBox runat="server" ID="txtID"></asp:TextBox>
    </div>
    </div>

    <div id="divEditar" runat="server">
        <h2>Editar Asignatura</h2>
        <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Nombre</label></div>
        <div class="col-sm-5">
            <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="^([a-zA-ZÁÉÍÓÚ]{1}[a-zñáéíóú]*[\s]*)+$" placeHolder="Ingrese nombre"></asp:TextBox>
        </div>        
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Año</label></div>
        <div class="col-sm-5">
            <asp:TextBox ID="txtAno" runat="server" class="form-control" placeHolder="Ingrese año" type="number" min="2010"></asp:TextBox>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Escuela</label></div>
        <div class="col-sm-5">
            <asp:DropDownList runat="server" ID="ddEscuela" class="form-control"></asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Docente</label></div>
        <div class="col-sm-5">
            <asp:DropDownList runat="server" ID="ddDocente" class="form-control"></asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-1"><label>Duracion</label></div>
        <div class="col-sm-3">
            <asp:RadioButtonList ID="rbDuracion" runat="server">
                <asp:ListItem Selected="True" Value="Semestral"></asp:ListItem>
                <asp:ListItem Value="Anual"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnGuardar" class="btn btn-primary btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
        </div>
    </div>
    <br />
    </div>

</asp:Content>
