<%@ Page Title="" Language="C#" MasterPageFile="~/Evaluador/SiteEvaluador.Master" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="CapaDePresentacion.Evaluador.CrearPregunta" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/imagen.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="divCrear" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cPregunta" runat="server" ImageUrl="ImagenesEvaluador/cPregunta.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-6">
                    <br />
                    <label>Desempeño</label>
                    <asp:DropDownList class="form-control" runat="server" ID="ddDesempeno" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddDesempeno_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione un Desempeño</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-sm-4">
                    <br />
                    <label>Tipo de Pregunta</label>
                    <asp:DropDownList class="form-control" AutoPostBack="true" AppendDataBoundItems="true" runat="server" ID="ddTipoPregunta" OnSelectedIndexChanged="ddTipoPregunta_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione el Tipo de Pregunta</asp:ListItem>
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
                    <input type="file" name="file" onchange="ValidarImagen(this);">
                    <br />

                    <img id="blah" src="#" alt="" class="img-responsive" />
                </div>

                <div runat="server" id="AltOCas" class="col-sm-6">
                    <asp:Panel ID="Panel1" runat="server">
                        <label>Respuestas</label>
                        <label class="col-sm-offset-8">Correcta</label>
                    </asp:Panel>
                    <br />
                </div>

                <div runat="server" id="VoF">
                    <label>Respuestas</label>
                    <br />
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
                    <asp:Button class="form-control btn-block btn-primary" runat="server" ID="btnCrear" Text="Crear" OnClick="btnCrear_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesEvaluador/iEndSM12.PNG" />
        </div>
    </div>
    <script>
        function ValidarImagen(obj) {
            var uploadFile = obj.files[0];
            if (!window.FileReader) {
                alert('El navegador no soporta la lectura de archivos');
                return;
            }

            if (!(/\.(jpg|png|gif|JPG|PNG|GIF)$/i).test(uploadFile.name)) {
                alert('El archivo a adjuntar no es una imagen');
            }
            else {
                var img = new Image();
                img.onload = function () {
                    if (this.width.toFixed(0) >= 600 || this.height.toFixed(0) >= 600) {
                        alert('Las medidas deben ser como maximo: 600 * 600');
                    }
                    else if (uploadFile.size > 1000000) {
                        alert('El peso de la imagen no puede exceder los 1MB')
                    }
                    else {
                        blah.src = URL.createObjectURL(uploadFile);
                        alert('Imagen correcta')
                    }
                };
                img.src = URL.createObjectURL(uploadFile);
            }
        }
    </script>
</asp:Content>

