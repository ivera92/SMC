<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id='divMostrar' runat="server">
        <h2 class="text-center">Administrar Alumnos</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-4">
                <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre o rut a buscar" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-primary btn-block" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView CssClass="table table-striped" ID="gvAlumnos" runat="server" AutoGenerateColumns="False" OnRowDeleting="rowDeletingEvent"
                    OnRowEditing="rowEditingEvent" PageSize="10" AllowPaging="True" OnPageIndexChanging="Grid_PageIndexChanging" BackColor="White">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen alumnos!
                    </EmptyDataTemplate>

                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                        <asp:BoundField DataField="Rut_Persona" HeaderText="Rut" />
                        <asp:BoundField DataField="Nombre_Persona" HeaderText="Nombre" />
                        <asp:BoundField DataField="Correo_Persona" HeaderText="Correo" />
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </div>
    </div>


    <div id='divEditar' runat='server' class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cAlumno" runat="server" ImageUrl="ImagenesAdmin/acAlumno.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Rut </label>
                    <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required ReadOnly="True"></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese su nombre y apellido" class="form-control"
                        oninvalid="setCustomValidity('Ingrese un nombre de minimo 3 caracteres y maximo 16, solo letras')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <asp:Button ID="btnEditar" class="btn btn-success btn-block" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
