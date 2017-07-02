<%@ Page Title="" Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="CapaDePresentacion.Doc.CrearPregunta" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/imagen.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="divCrear" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cPregunta" runat="server" ImageUrl="ImagenesAdmin/cPregunta.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-6">
                    <br />
                    <label>Desempeño</label>
                    <asp:DropDownList class="form-control" runat="server" ID="ddDesempeno" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddDesempeno_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un desempeño</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <br />
                    <label>Tipo de Pregunta</label>
                    <asp:DropDownList class="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" ID="ddTipoPregunta" OnSelectedIndexChanged="ddTipoPregunta_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione el tipo de pregunta</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-sm-2">
                    <br />
                    <label>Nivel</label>
                    <asp:DropDownList class="form-control" runat="server" ID="ddNivel">
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-6">
                    <label>Enunciado</label>
                    <textarea class="form-control" id="txtAPregunta" runat="server" rows="3" required></textarea>
                    <br />
                    <asp:FileUpload ID="fileImagen" runat="server" onchange="readURL(this);" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ErrorMessage="Tipo de archivo no permitido" oninvalid="setCustomValidity('Solo se permiten imagenes')" ControlToValidate="fileImagen"
                        ValidationExpression="(.*).(.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$">
                    </asp:RegularExpressionValidator>
                    <br />

                    <img id="blah" src="#" alt="" class="img-responsive" />
                </div>

                <div runat="server" id="AltOCas">
                    <br />
                    <label>Respuestas</label>
                    <label class="col-sm-offset-4">Correcta</label>
                    <br />
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                    <br />
                </div>

                <div runat="server" id="VoF">
                    <label>Respuestas</label>
                    <label class="col-sm-offset-3">Correcta</label>
                    <div class="col-sm-3">
                        <label id="lblV" runat="server">Verdadero</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:CheckBox ID="cbV" runat="server" />
                    </div>
                    <br />

                    <div class="col-sm-3">
                        <label id="lblF" runat="server">Falso</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:CheckBox ID="cbF" runat="server" />
                    </div>
                    <br />
                </div>
                <div class="col-sm-2">
                    <asp:Button class="btn-success form-control btn-block" runat="server" ID="btnCrear" Text="Crear" OnClick="btnCrear_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesAdmin/iEndSM12.PNG" />
        </div>
    </div>

</asp:Content>

