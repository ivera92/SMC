<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="crear" runat="server" class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Image ID="cEscuela" runat="server" ImageUrl="ImagenesAdmin/cEscuela.PNG" />
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
                    <asp:Button ID="btbCrear" class="btn btn-success btn-block" runat="server" Text="Crear"
                        OnClick="btbCrear_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="cEscuelaEnd" runat="server" ImageUrl="ImagenesAdmin/iEndSM6.PNG" />
        </div>
        <br />
    </div>
</asp:Content>
