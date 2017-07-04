<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AsociarDesempenoAsignatura.aspx.cs" Inherits="CapaDePresentacion.Admin.AsociarDesempenoAsignatura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .dropdown-menu {
            min-width: 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <asp:Image ID="aDA" runat="server" ImageUrl="ImagenesAdmin/aDA.PNG" />
            <div class="col-sm-12">
                <br />
                <label>Desempeño</label>
                <asp:DropDownList CssClass="form-control" AutoPostBack="true" AppendDataBoundItems="true" ID="ddDesempeno" runat="server" OnSelectedIndexChanged="ddDesempeno_SelectedIndexChanged">
                    <asp:ListItem Value="0">Seleccione un desempeño</asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>

            <div class="col-sm-6">
                <label>Asignatura</label>
                <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddAsignatura" runat="server">
                    <asp:ListItem Value="0">Seleccione una asignatura</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <label>Nivel</label>
                <asp:DropDownList CssClass="form-control" AppendDataBoundItems="true" ID="ddNivel" runat="server">
                    <asp:ListItem Value="0">Seleccione un nivel</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <br />
                <asp:Button CssClass="btn btn-block btn-success" runat="server" ID="btnAsociar" Text="Asignar" OnClick="btnAsociar_Click" />
                <br />
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>
</asp:Content>
