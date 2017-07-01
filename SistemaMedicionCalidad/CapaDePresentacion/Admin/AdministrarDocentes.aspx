<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarDocentes.aspx.cs" Inherits="CapaDePresentacion.Doc.AdministrarDocentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="tablaAdministrar" runat="server">
        <h2 class="text-center">Administrar Docentes</h2>
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
                <asp:GridView class="table table-striped" ID="gvDocentes" runat="server"
                    AutoGenerateColumns="false" OnRowDeleting="rowDeleting" PageSize="10" AllowPaging="true"
                    OnRowEditing="rowEditing" OnPageIndexChanging="gvDocentes_PageIndexChanging">
                    <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                    <EmptyDataTemplate>
                        ¡No existen docentes!
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

    <div id="tablaEditar" runat="server" class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:Image ID="cAlumno" runat="server" ImageUrl="ImagenesAdmin/acDocente.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <label>Rut</label>
                    <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" ReadOnly="True"></asp:TextBox>
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese su nombre y apellido"
                        oninvalid="setCustomValidity('Ingrese un nombre de minimo 3 caracteres y maximo 16, solo letras')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox>
                    <br />
                </div>


                <div class="col-sm-6">
                    <label>Contrato</label>
                    <asp:RadioButtonList ID="rbDisponibilidad" runat="server">
                        <asp:ListItem Selected="True" Value="0">Part-Time</asp:ListItem>
                        <asp:ListItem Value="1">Full-Time</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-sm-6">
                    <br />
                    <asp:Button ID="btnGuardar" class="btn btn-success btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="Image1" runat="server" ImageUrl="ImagenesAdmin/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
