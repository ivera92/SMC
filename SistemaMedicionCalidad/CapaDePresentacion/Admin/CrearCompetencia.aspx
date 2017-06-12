<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="crear" runat="server">
        <h2 class="text-center">Crear Competencia</h2>
        <br />

        <label class="col-sm-offset-3">Ambito</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList ID="ddAmbito" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione ambito--></asp:ListItem>
                </asp:DropDownList>
            </div>            
        </div>
        <br />

        <label class="col-sm-offset-3">Tipo</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:DropDownList ID="ddTipoCompetencia" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione un tipo de competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>            
        </div>
        <br />

        <label class="col-sm-offset-3">Nombre</label>
        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <textarea class="form-control" id="txtNombre" runat="server" rows="5"></textarea>
            </div>
        </div>
        <br />
        
        <div class="row">
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="brnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" OnClick="brnCrear_Click" />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
