<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="row">
    <h2>Crear Competencia</h2>
    <br />
            
            <label>Nombre</label>
            
            <div class="col-md-5">
            <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control"></asp:TextBox>
            </div>
            <label>Tipo</label>
                <asp:RadioButtonList ID="tipoCompetencia" runat="server">
                    <asp:ListItem Selected="True" Value="Generica"></asp:ListItem>
                    <asp:ListItem Value="Especifica"></asp:ListItem>
                </asp:RadioButtonList>
            
            <label>Descripcion</label>
            <textarea id="descripcion" runat="server" cols="20" rows="2"></textarea>
            <asp:Button  ID="brnCrear" class="btn btn-primary" runat="server" Text="Crear" 
                    onclick="brnCrear_Click"/>
                    </div>
</asp:Content>
