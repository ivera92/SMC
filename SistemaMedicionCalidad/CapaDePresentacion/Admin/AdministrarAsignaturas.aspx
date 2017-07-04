<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarAsignaturas.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarAsignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divAdministrar" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="aAsignatura" runat="server" ImageUrl="ImagenesAdmin/aAsignaturas.PNG" />
            <div style="border: solid 1px #ccc">
                <br />
                <div class="col-sm-offset-3 col-sm-4">
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre o codigo a buscar" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                <br />
                </div>
                <div class="col-sm-12">
                    <asp:GridView class="table table-striped" ID="gvAsignatura" runat="server" AutoGenerateColumns="False" OnRowDeleting="rowDeleting" OnRowEditing="rowEditing"
                        PageSize="10" AllowPaging="true" OnPageIndexChanging="gvAsignatura_PageIndexChanging">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen asignaturas!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Cod_Asignatura" HeaderText="Codigo" />
                            <asp:BoundField DataField="Escuela_Asignatura.Nombre_Escuela" HeaderText="Escuela" />
                            <asp:BoundField DataField="Nombre_Asignatura" HeaderText="Asignatura" />
                            <asp:BoundField DataField="Duracion_Asignatura" HeaderText="Duracion" Visible="false" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <asp:Image ID="aEND" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
            </div>
        </div>
    </div>

    <div id="divEditar" runat="server" class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cAsignatura" runat="server" ImageUrl="ImagenesAdmin/acAsignatura.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Codigo</label>
                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" placeHolder="Ingrese codigo, ejemplo: CIBA019" ReadOnly="True"></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Escuela</label>
                    <asp:DropDownList runat="server" ID="ddEscuela" class="form-control">
                    </asp:DropDownList>
                    <br />
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" class="form-control" pattern="([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,})([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ0123456789]{1,})*" placeHolder="Ingrese nombre"
                        oninvalid="setCustomValidity('Primera palabra minimo 3 letras, separada de un espacio, seguido o no de uno o mas numeros o letras')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-6">
                    <label>Duracion</label>
                    <asp:RadioButtonList ID="rbDuracion" runat="server">
                        <asp:ListItem Value="Semestral"></asp:ListItem>
                        <asp:ListItem Value="Anual"></asp:ListItem>
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
