<%@ Page Title="" Language="C#" MasterPageFile="SiteAlumno.Master" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="CapaDePresentacion.Alum.CambiarClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-offset-4 col-sm-4">
            <asp:Image ID="cClave" runat="server" ImageUrl="ImagenesAlumno/cClave.PNG" />
            <div class="col-sm-12" style="border: solid 1px #ccc">
                <div>
                    <br />
                    <label>Clave Actual</label>
                    <asp:TextBox ID="txtPwActual" runat="server" class="form-control col-sm-" placeHolder="Ingrese clave actual" TextMode="Password"
                        oninvalid="setCustomValidity('Minimo 6 caracteres, maximo 10')"
                        oninput="setCustomValidity('')"></asp:TextBox>
                    <br />
                </div>

                <div>
                    <label>Nueva Clave</label>
                    <asp:TextBox ID="txtPwNueva1" runat="server" class="form-control" placeHolder="Ingrese nueva clave" TextMode="Password"
                        oninvalid="setCustomValidity('Minimo 6 caracteres, maximo 10')"
                        oninput="setCustomValidity('')"></asp:TextBox>
                </div>

                <div>
                    <br />
                    <label>Repita la Clave</label>
                    <asp:TextBox ID="txtPwNueva2" runat="server" class="form-control" placeHolder="Ingrese nuevamente la clave" TextMode="Password"
                        oninvalid="setCustomValidity('Minimo 6 caracteres, maximo 10')"
                        oninput="setCustomValidity('')">
                    </asp:TextBox>
                    <br />
                </div>

                <div class="col-sm-offset-2 col-sm-8">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-block" BackColor="Orange" BorderColor="White" ForeColor="White" OnClick="btnGuardar_Click" />
                    <br />
                </div>
            </div>
            <asp:Image ID="iEndSM4" runat="server" ImageUrl="ImagenesAlumno/iEndSM4.PNG" />
        </div>
    </div>
</asp:Content>
