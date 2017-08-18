<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAmbitos.aspx.cs" Inherits="CapaDePresentacion.Admin.AdministrarAmbitos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="tablaAdministrar" runat="server" class="row">
        <div class="col-sm-offset-2 col-sm-8">
            <asp:Image ID="aAmbito" runat="server" ImageUrl="ImagenesAdmin/aAmbitos.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">                
                <div>
                    <asp:GridView class="table table-striped" ID="gvAmbitos" runat="server" AutoGenerateColumns="false"
                        OnRowDeleting="rowDeleting" OnRowEditing="rowEditing">
                        <HeaderStyle BackColor="#4ed34e" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <EmptyDataTemplate>
                            ¡No existen ambitos!
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="true" ShowEditButton="true" HeaderText="Accion" />
                            <asp:BoundField DataField="Nombre_Ambito" HeaderText="Ambito" />
                            <asp:BoundField DataField="Id_Ambito" HeaderText="ID" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <asp:Image ID="aEND" runat="server" ImageUrl="ImagenesAdmin/iEndSM8.PNG" />
        </div>
        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
    </div>

    <div id="tablaEditar" runat="server" class="row">
        <div id="crear" runat="server" class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Image ID="cAmbito" runat="server" ImageUrl="ImagenesAdmin/acAmbito.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">                    
                <br />
                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="tbxAmbito" class="form-control" runat="server" pattern="([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{5,})([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{1,})*"
                        placeHolder="Ingrese nombre de ambito" oninvalid="setCustomValidity('Ingrese solo letras, palabras separadas por solo un espacio, primera palabra minimo 5 caracteres, ejemplo: Ingeniería en Computación')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-offset-4 col-sm-4">
                    <asp:Button ID="btnGuardar" class="btn btn-success btn-block" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="cAmbitoEnd" runat="server" ImageUrl="ImagenesAdmin/iEndSM6.PNG" />
        </div>
        <br />
    </div>
    </div>

</asp:Content>
