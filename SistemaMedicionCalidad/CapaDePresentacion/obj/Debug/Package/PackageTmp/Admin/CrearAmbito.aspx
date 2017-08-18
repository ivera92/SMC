<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearAmbito.aspx.cs" Inherits="CapaDePresentacion.Admin.CrearAmbito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="crear" runat="server" class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Image ID="cAmbito" runat="server" ImageUrl="ImagenesAdmin/cAmbito.PNG" />
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
                    <asp:Button ID="btnCrear" class="btn btn-success btn-block" runat="server" Text="Crear" OnClick="btnCrear_Click"
                       />
                    <br />
                </div>
            </div>
            <asp:Image ID="cAmbitoEnd" runat="server" ImageUrl="ImagenesAdmin/iEndSM6.PNG" />
        </div>
        <br />
    </div>

</asp:Content>
