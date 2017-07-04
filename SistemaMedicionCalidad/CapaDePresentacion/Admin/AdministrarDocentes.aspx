<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarDocentes.aspx.cs" Inherits="CapaDePresentacion.Doc.AdministrarDocentes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="tablaAdministrar" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="aDocente" runat="server" ImageUrl="ImagenesAdmin/aDocentes.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:TextBox ID="txtBuscar" runat="server" placeHolder="Ingrese nombre o rut a buscar" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="form-control btn-success btn-block" OnClick="btnBuscar_Click" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvDocentes" runat="server"
                        AutoGenerateColumns="false" OnRowDeleting="rowDeleting" PageSize="10" AllowPaging="true"
                        OnRowEditing="rowEditing" OnPageIndexChanging="gvDocentes_PageIndexChanging">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen docentes!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Rut_Persona" HeaderText="Rut" />
                            <asp:BoundField DataField="Nombre_Persona" HeaderText="Nombre" />
                            <asp:BoundField DataField="Correo_Persona" HeaderText="Correo" />
                        </Columns>
                        <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="iEnd12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>

    <div id="tablaEditar" runat="server" class="row">
        <div class="col-sm-4 col-sm-offset-4">
            <asp:Image ID="cAlumno" runat="server" ImageUrl="ImagenesAdmin/acDocente.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Rut</label>
                    <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" ReadOnly="True"></asp:TextBox>
                </div>

                <div>
                    <br />
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,}([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,})+)$" placeHolder="Ingrese su nombre y apellido"
                        oninvalid="setCustomValidity('Ingrese nombre y apellido separados por un espacio, ambos de 3 letras a lo menos, solo letras')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" pattern="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" 
                        placeHolder="Ejemplo: ejemplo@live.cl" oninvalid="setCustomValidity('Correo ingresado no cumple con el formato')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
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
