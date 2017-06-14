<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearCompetencia.aspx.cs" Inherits="CapaDePresentacion.CrearCompetencia" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="crear" runat="server">
        <h2 class="text-center">Crear Competencia</h2>
        <br />

        
        
        <div class="row">
            <div class="col-sm-6">
                <label">Ambito</label>
                <asp:DropDownList ID="ddAmbito" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione ambito--></asp:ListItem>
                </asp:DropDownList>
            </div>  
            <div class="col-sm-6">
                <label>Tipo</label>
                <asp:DropDownList ID="ddTipoCompetencia" AppendDataBoundItems="true"  runat="server" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione un tipo de competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>             
        </div>
        <br />        
        
        <div class="row">
            <div class="col-sm-6">
                <label>Nombre</label>
                <textarea class="form-control" id="txtNombre" runat="server" rows="3" required></textarea>
            </div>
            <div class="col-sm-6">
                <label>Indicador de Desempeño</label>
                <textarea class="form-control" id="txtIndicador" runat="server" rows="3" required></textarea>
            </div>
        </div>
        <br />
        
        <div class="row">
            <div class="col-sm-3">
                <label>Nivel Básico</label>
                <textarea class="form-control" id="txtNBasico" runat="server" rows="6" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Medio</label>
                <textarea class="form-control" id="txtNMedio" runat="server" rows="6" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Superior</label>
                <textarea class="form-control" id="txtNSuperior" runat="server" rows="6" required></textarea>
            </div>
            <div class="col-sm-3">
                <label>Nivel Avanzado</label>
                <textarea class="form-control" id="txtNAvanzado" runat="server" rows="6"></textarea>
            </div>
        </div>
        <br />
        
        <div class="row">
            <div class="col-sm-offset-1 col-sm-4">
                <asp:Button ID="brnCrear" class="btn btn-primary btn-block" runat="server" Text="Crear y salir" OnClick="brnCrear_Click" />
            </div>
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnSeguir" class="btn btn-primary btn-block" runat="server" Text="Crear y seguir asignando desempeños" OnClick="btnSeguir_Click"/>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
