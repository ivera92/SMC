<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdministrarEscuelas.aspx.cs" Inherits="CapaDePresentacion.AdministrarEscuelas" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="tablaAdministrar" runat="server" class="row">
        <div class="col-sm-offset-2 col-sm-8">
            <asp:Image ID="aEscuela" runat="server" ImageUrl="ImagenesAdmin/aEscuelas.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">                
                <div>
                    <asp:GridView class="table table-striped" ID="gvEscuelas" runat="server" AutoGenerateColumns="false"
                        OnRowDeleting="rowDeleting" OnRowEditing="rowEditing" Font-Names="Sengoe-UI" Font-Size="12">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen escuelas!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Nombre_Escuela" HeaderText="Escuela" />
                            <asp:BoundField DataField="Id_Escuela" HeaderText="ID" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="aEND" runat="server" ImageUrl="ImagenesAdmin/iEndSM8.PNG" />
        </div>
        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
    </div>

    <div id="tablaEditar" runat="server" class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Image ID="cEscuela" runat="server" ImageUrl="ImagenesAdmin/acEscuela.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <br />
                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="tbxEscuela" class="form-control" runat="server" pattern="([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{2,})+"
                        placeHolder="Ingrese nombre de escuela" oninvalid="setCustomValidity('El nombre debe contener solo letras, minimo 4')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>
                <div class="col-sm-offset-4 col-sm-4">
                    <asp:Button ID="btnGuardar" class="btn btn-success btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="cEscuelaEnd" runat="server" ImageUrl="ImagenesAdmin/iEndSM6.PNG" />
        </div>
    </div>
</asp:Content>
