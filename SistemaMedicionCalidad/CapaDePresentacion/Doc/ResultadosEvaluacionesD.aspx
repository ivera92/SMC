<%@ Page Title="" Language="C#" MasterPageFile="~/Doc/SiteDocente.Master" AutoEventWireup="true" CodeBehind="ResultadosEvaluacionesD.aspx.cs" Inherits="CapaDePresentacion.Doc.ResultadosEvaluacionesD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Resultado Evaluaciones</h2>
    <br />

    <div class="row">
        <div runat="server" id="divAlumno" class="col-sm-4">
            <label>Filtro</label>
            <div>
                <asp:DropDownList ID="ddAlumno" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAlumno_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione filtro--></asp:ListItem>
                    <asp:ListItem Value="1">Todos los alumnos</asp:ListItem>
                    <asp:ListItem Value="2">Pais</asp:ListItem>
                    <asp:ListItem Value="3">Promocion</asp:ListItem>
                    <asp:ListItem Value="4">Rut</asp:ListItem>
                    <asp:ListItem Value="5">Sexo</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>        

        <div runat="server" id="divPais" class="col-sm-4">
            <label>Pais</label>
            <div>
                <asp:DropDownList ID="ddPais" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddPais_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione un pais--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divPromocion" class="col-sm-4">
            <label>Promocion</label>
            <div>
                <asp:DropDownList ID="ddPromocion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddPromocion_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione promocion--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divRut" class="col-sm-4">
            <label>Rut</label>
            <div>
                <asp:TextBox CssClass="form-control" ID="txtRut" runat="server"></asp:TextBox>
            </div>
            <br />
        </div>

        <div runat="server" id="divSexo" class="col-sm-4">
            <label>Sexo</label>
            <div>
                <asp:DropDownList ID="ddSexo" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddSexo_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione sexo--></asp:ListItem>
                    <asp:ListItem Value="1">Masculino</asp:ListItem>
                    <asp:ListItem Value="2">Femenino</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divAsignatura" class="col-sm-4">
            <label>Asignatura</label>
            <div>
                <asp:DropDownList ID="ddAsignatura" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddAsignatura_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione asignatura--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divEvaluacion" class="col-sm-4">
            <label>Evaluacion</label>
            <div>
                <asp:DropDownList ID="ddEvaluacion" AutoPostBack="true" runat="server" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddEvaluacion_SelectedIndexChanged">
                    <asp:ListItem Value="0"><--Seleccione evaluacion--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divCompetencia" class="col-sm-4">
            <label>Competencia</label>
            <div>
                <asp:DropDownList ID="ddCompetencia" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                    <asp:ListItem Value="0"><--Seleccione competencia--></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
        </div>

        <div runat="server" id="divBtnGraficar" class="col-sm-4">
            <div>
                <br />
                <asp:Button runat="server" ID="btnGraficar" CssClass="form-control btn-primary btn-block" Text="Graficar" OnClick="btnGraficar_Click" />
            </div>
        </div>

        <div class="col-sm-4">
            <br />
            <asp:Button runat="server" ID="btnExportar" CssClass="form-control btn-success btn-block" Text="Exportar a Excel" OnClick="btnExportar_Click" />  
        </div>
    </div>

    <asp:Panel ID="panelGrafico" runat="server">
        <asp:Chart ID="chartColumna" runat="server" CssClass="center-block" Width="780px" Height="392px">
            <Series>
                <asp:Series Name="Correctas" Color="Blue"></asp:Series>
                <asp:Series ChartArea="ChartArea1" Color="Red" Name="Incorrectas">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        <br />
    </asp:Panel>
    <br />
    <div class="row" runat="server">
        <div class="col-sm-12">
            <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="false" class="table table-striped" BackColor="White">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                <Columns>
                    <asp:BoundField DataField="estado_respuesta" HeaderText="Estado" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="nombre_competencia.nombre_competencia" HeaderText="Competencia" />
                    <asp:BoundField DataField="rut_docente.nombre_persona" HeaderText="Docente" />
                    <asp:BoundField DataField="rut_alumno.nombre_persona" HeaderText="Alumno" />
                    <asp:BoundField DataField="Id_evaluacion_hpa.nombre_evaluacion" HeaderText="Evaluacion" />
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
