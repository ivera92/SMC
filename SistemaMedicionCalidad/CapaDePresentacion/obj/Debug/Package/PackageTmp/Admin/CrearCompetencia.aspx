<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="crear" runat="server">
        <h2 class="text-center">Crear Competencia</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-1">
                <label>Tipo</label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="ddTipoCompetencia" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione un tipo de competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>            
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-1">
                <label>Nombre</label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox runat="server" ID="txtNombreCompetencia" class="form-control" placeHolder="Ingrese nombre"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-1">
                <label>Descripcion</label>
            </div>
            <div class="col-sm-5">
                <textarea class="form-control" id="txtADescripcion" runat="server" rows="5"></textarea>
            </div>
        </div>
        <br />
        
        <div class="row">
            <div class="col-sm-offset-5 col-sm-3">
                <asp:Button ID="brnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" OnClick="brnCrear_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
