<%@ Page Language="C#" MasterPageFile="SiteDocente.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrearAlumnoD.aspx.cs" Inherits="CapaDePresentacion.Doc.CrearAlumnoD" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../Scripts/rut.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="row" runat="server" id="divOpcion">
        <div class="col-sm-6 col-sm-offset-3">
            <asp:Image ID="aRA" runat="server" ImageUrl="ImagenesDoc/cAlumno6.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div class="col-sm-offset-2 col-sm-4">
                    <br />
                    <asp:Button ID="btnManual" runat="server" Text="Crear Manual" CssClass="form-control btn-info" OnClick="btnManual_Click" />
                    <br />
                </div>
                <div class="col-sm-4">
                    <br />
                    <asp:Button ID="btnExcel" runat="server" Text="Importar Excel" CssClass="form-control btn-success" OnClick="btnExcel_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM6" runat="server" ImageUrl="ImagenesDoc/iEndSM6.PNG" />
        </div>
    </div>

    <div id="divCrearExcel" runat="server" class="row">
        <div class="col-sm-12">
            <asp:Image ID="cAlumno12" runat="server" ImageUrl="ImagenesDoc/cAlumno12.PNG" />
            <div style="border: solid 1px #ccc">
                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnMostrar" Text="Mostrar" CssClass="form-control" ForeColor="White" BackColor="#7F1734" BorderColor="White" runat="server" OnClick="btnMostrar_Click1" />
                </div>

                <div class="col-sm-12">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvAlumnos" runat="server" AutoGenerateColumns="false">
                        <HeaderStyle BackColor="#7F1734" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                            <asp:BoundField DataField="Rut" HeaderText="Rut" />
                            <asp:BoundField DataField="Nombre Estudiante" HeaderText="Nombre" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Asignatura" HeaderText="Asignatura" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnImportar" Text="Importar" CssClass="form-control" ForeColor="White" BackColor="#7F1734" BorderColor="White" runat="server" OnClick="btnImportar_Click" />
                <br />
            </div>
            <asp:Image ID="iEndSM12" runat="server" ImageUrl="ImagenesDoc/iEndSM12.PNG" />
        </div>
    </div>

    <div id="divCrearManual" runat="server" class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cAlumno" runat="server" ImageUrl="ImagenesDoc/cAlumno.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Rut</label>
                    <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" required></asp:TextBox>
                </div>
                <div>
                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                        ClientValidationFunction="validar_rut" ControlToValidate="txtRut"
                        Display="Dynamic" ErrorMessage="RUT incorrecto" ForeColor="Red" SetFocusOnError="True">
                    </asp:CustomValidator>
                    <br />
                </div>

                <div>
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" pattern="^([A-ZÁÉÍÓÚa-záéíóú]{3,16}*)+$" placeHolder="Ingrese su nombre y apellido" class="form-control"
                        oninvalid="setCustomValidity('Ingrese un nombre de minimo 3 caracteres y maximo 16, solo letras')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>


                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" required></asp:TextBox>
                    <br />
                </div>
                <div>
                    <label>Asignatura (Opcional)</label>
                    <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                        <asp:ListItem Value="0"><--Seleccione una asignatura--></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <asp:Button ID="btnCrear" class="btn-block form-control" ForeColor="White" BackColor="#7F1734" BorderColor="White" runat="server" OnClick="btnCrear_Click" Text="Crear" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesDoc/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
