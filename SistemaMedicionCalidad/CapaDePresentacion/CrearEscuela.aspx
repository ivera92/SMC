﻿<%@ Page Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeBehind="CrearEscuela.aspx.cs" Inherits="CapaDePresentacion.CrearEscuela" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <h2>Crear Escuela</h2>
    <br />
    <label>Nombre</label>

    <div class="row">
        <div class="col-sm-4"><asp:TextBox ID="tbxEscuela" class="form-control" runat="server"></asp:TextBox></div>
        <div class="col-sm-2"><asp:Button ID="btbCrear" class="btn btn-primary btn-block" runat="server" Text="Crear" 
            onclick="btbCrear_Click" /></div>
    </div>
</asp:Content>