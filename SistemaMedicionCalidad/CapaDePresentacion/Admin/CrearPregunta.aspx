<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="CapaDePresentacion.Doc.CrearPregunta" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="HeadContent" >
    <script src="../Scripts/imagen.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div id="divCrear" runat="server">
    <h2 class="text-center">Crear Pregunta</h2>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <label>Competencia</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:DropDownList class="form-control" runat="server" ID="ddCompetencia" AppendDataBoundItems="true">
                <asp:ListItem Value="0"><--Seleccione una competencia--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <label>Tipo de Pregunta</label>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:DropDownList class="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" ID="ddTipoPregunta" OnSelectedIndexChanged="ddTipoPregunta_SelectedIndexChanged">
                <asp:ListItem Value="0"><--Seleccione el tipo de pregunta--></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <br />

    <label class="col-sm-offset-3">Pregunta</label>
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <textarea class="form-control" id="txtAPregunta" runat="server" rows="3"></textarea>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4"> 
            <asp:FileUpload ID="fileImagen" runat="server" onchange="readURL(this);"/>    
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
            ErrorMessage="Tipo de archivo no permitido" oninvalid="setCustomValidity('Solo se permiten imagenes')" ControlToValidate="fileImagen" 
            ValidationExpression= "(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$">
            </asp:RegularExpressionValidator>
            <br />
            
        </div>
    </div>
    <br />
    
    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <img id="blah" src="#" alt="" class="img-responsive"/>
        </div>
    </div>
    <br />

    <div class="row">
        <div class="col-sm-offset-3 col-sm-6">
            <asp:Panel ID="Panel2" runat="server"></asp:Panel>
        </div>
    </div>
    
    <div runat="server" id="AltOCas">
        <label class="col-sm-offset-8">Correcta</label>
        <br />
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
    <br />
    </div>

        <div runat="server" id="VoF">
            <label class="col-sm-offset-6">Correcta</label>
            <div class="row">
                <div class="col-sm-offset-3 col-sm-3">
                    <label id="lblV" runat="server">Verdadero</label>
                </div>                
                <div class="col-sm-3">
                    <asp:CheckBox id="cbV" runat="server"/>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-sm-offset-3 col-sm-3">
                    <label id="lblF" runat="server">Falso</label>
                </div>
                <div class="col-sm-3">
                    <asp:CheckBox id="cbF" runat="server"/>
                </div>
            </div>
           
        </div>
     <div class="row">
        <div class="col-sm-offset-7 col-sm-2">
            <asp:Button class="btn btn-primary btn-block" runat="server" ID="btnCrear" Text="Crear" OnClick="btnCrear_Click" />
        </div>
    </div>
    </div>
    <div id="divSeguir" class="row">
        <br />
        <br />
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Button CssClass="form-control btn btn-block btn-success" ID="btnSeguir" runat="server" Text="Seguir creando" OnClick="btnSeguir_Click" />
        </div>
    </div>
</asp:Content>

