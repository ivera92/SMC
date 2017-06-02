<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="CapaDePresentacion.Alum.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-offset-4">
        <h2>Datos Personales</h2>
        <br />
        <h3 id="nombreAlumno" runat="server"></h3>
        <h4 id="nombreEscuela" runat="server"></h4>
        <br />

        <div class="row">
            <div class="col-sm-3">
                <label>Nacionalidad</label>
            </div>
            <div class="col-sm-5">
                <asp:DropDownList ID="ddPais" runat="server" class="form-control" AppendDataBoundItems="true">
                    <asp:ListItem Value="0"><--Seleccione un pais--></asp:ListItem>
                </asp:DropDownList>
                <label id="nacionalidad" runat="server"></label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <label>Fecha de nacimiento</label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtFechaDeNacimiento" class="form-control" runat="server" type="date" max="1999-12-31" format="data-fv-date-format"></asp:TextBox>
                <label id="fechaNacimiento" runat="server"></label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <label>Dirección</label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingrese su dirección"></asp:TextBox>
                <label id="direccion" runat="server"></label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <label>Telefono</label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" type="number" placeHolder="Ejemplo: 993073695" min="940000000" max="9999999999"></asp:TextBox>
                <label id="telefono" runat="server"></label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <label>Correo</label>
            </div>
            <div class="col-sm-5">
                <label id="correo" runat="server"></label>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-3">
                <label>Promocion</label>
            </div>
            <div class="col-sm-5">
                <asp:TextBox ID="txtPromocion" class="form-control" runat="server" placeHolder="Ingrese año ingreso" type="number" min="2005" max="2017"></asp:TextBox>
                <label id="promocion" runat="server"></label>
            </div>
        </div>

        <div id="divSexo" class="row" runat="server">
            <div class="col-sm-3">
                <label>Sexo</label>
            </div>
            <div class="col-sm-5">
                <asp:RadioButtonList ID="rbSexo" runat="server">
                    <asp:ListItem Value="0">Masculino</asp:ListItem>
                    <asp:ListItem Value="1">Femenino</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div id="divBeneficio" class="row" runat="server">
            <div class="col-sm-3">
                <label>Beneficio</label>
            </div>
            <div class="col-sm-5">
                <asp:RadioButtonList ID="rbBeneficio" runat="server">
                    <asp:ListItem Value="0">Si</asp:ListItem>
                    <asp:ListItem Value="1">No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnActualizar" runat="server" CssClass="form-control btn-block btn-primary" Text="Actualizar datos" OnClick="btnActualizar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-sm-offset-2 col-sm-4">
                <asp:Button ID="btnGuardar" runat="server" CssClass="form-control btn-block btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
