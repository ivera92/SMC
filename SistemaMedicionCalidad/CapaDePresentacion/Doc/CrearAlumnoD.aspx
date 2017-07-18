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
                    <asp:Button ID="btnManual" runat="server" Text="Crear Manual" CssClass="form-control"  BackColor="#7F1734" ForeColor="White" OnClick="btnManual_Click" />
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
                <div class="col-sm-5 col-sm-offset-3" style="text-align: justify">
                    <br />
                    Para poder importar alumnos desde una plantilla excel, esta debera tener el formato que se descarga al hacer click en el icono de excel, en la Hoja1 es donde debera ingresar los datos de los alumnos a importar, ademas debera seleccionar la asignatura que cursaran estos.
                </div>
                <div class="col-sm-1">
                    <br />
                    <br />
                    <asp:ImageButton ID="imgExcelBtn" runat="server" ImageUrl="ImagenesDoc/imgExcel.PNG" Width="50" Height="50" OnClick="imgExcelBtn_Click" />
                </div>
                <div class="col-sm-offset-3 col-sm-6">
                    <br />
                    <label>Asignatura</label>
                    <asp:DropDownList runat="server" ID="ddAsignaturaC" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-4">
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="col-sm-2">
                    <br />
                    <asp:Button ID="btnMostrar" Text="Mostrar" CssClass="form-control" BackColor="#7F1734" ForeColor="White" runat="server" OnClick="btnMostrar_Click1" />
                </div>

                <div class="col-sm-10 col-sm-offset-1">
                    <br />
                    <asp:GridView class="table table-striped" ID="gvAlumnos" runat="server" AutoGenerateColumns="false">
                        <HeaderStyle BackColor="#7F1734" Font-Bold="True" ForeColor="White" />
                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                        <Columns>
                            <asp:BoundField DataField="Rut" HeaderText="Rut" />
                            <asp:BoundField DataField="Nombre Estudiante" HeaderText="Nombre" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-sm-offset-5 col-sm-2">
                <asp:Button ID="btnImportar" Text="Importar" CssClass="form-control" BackColor="#7F1734" ForeColor="White" runat="server" OnClick="btnImportar_Click" /> 
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
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" pattern="^([a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,}([\s][a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]{3,})+)$" placeHolder="Ingrese su nombre y apellido"
                        oninvalid="setCustomValidity('Ingrese nombre y apellido separados por un espacio, ambos de 3 letras a lo menos, solo letras')"
                        oninput="setCustomValidity('')" required>
                    </asp:TextBox>
                    <br />
                </div>


                <div>
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" class="form-control" runat="server" pattern="^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$"
                        placeHolder="Ejemplo: ejemplo@live.cl" oninvalid="setCustomValidity('Correo ingresado no cumple con el formato')"
                        oninput="setCustomValidity('')" required></asp:TextBox>
                    <br />
                </div>
                <div>
                    <label>Asignatura (Opcional)</label>
                    <asp:DropDownList runat="server" ID="ddAsignatura" class="form-control" AutoGenerateColumns="False" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Seleccione una Asignatura</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>

                <div class="col-sm-offset-3 col-sm-6">
                    <asp:Button ID="btnCrear" class="btn-block form-control" BackColor="#7F1734" ForeColor="White" runat="server" OnClick="btnCrear_Click" Text="Crear" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesDoc/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
