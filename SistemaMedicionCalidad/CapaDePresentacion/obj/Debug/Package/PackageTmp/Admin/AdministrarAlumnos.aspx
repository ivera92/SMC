<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id='divMostrar' runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="aAlumnos" runat="server" ImageUrl="ImagenesAdmin/aAlumnos.PNG" />
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
                    <asp:GridView CssClass="table table-striped" ID="gvAlumnos" runat="server" AutoGenerateColumns="False" OnRowDeleting="rowDeletingEvent"
                        OnRowEditing="rowEditingEvent" PageSize="10" AllowPaging="True" OnPageIndexChanging="Grid_PageIndexChanging" BackColor="White">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen alumnos!
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
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
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
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,}([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,})+)$" placeHolder="Ingrese su nombre y apellido"
                        oninvalid="setCustomValidity('Ingrese nombre y apellido separados por un espacio, ambos de 3 letras a lo menos, solo letras')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" pattern="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$" 
                        placeHolder="Ejemplo: ejemplo@live.cl" oninvalid="setCustomValidity('Correo ingresado no cumple con el formato')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
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
