﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    

    <div id='divMostrar' runat='server'>

        <h2>Administrar Alumnos</h2>
        <br />

        <div class="row">
            <div class="col-sm-4">
                <asp:TextBox class="form-control" ID="tbxbuscar" runat="server"></asp:TextBox>  
            </div>
            <div class="col-sm-2">
                <asp:Button class="btn btn-primary btn-block" ID="btnbuscar" runat="server" Text="Buscar" 
                onclick="btnbuscar_Click" />
            </div>
        </div>
        <br />

    <div class ="row">
        <div class="col-sm-8">
            <asp:GridView class="table table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowdeleting="rowDeletingEvent" onrowediting="rowEditingEvent">
            <Columns>
            <asp:CommandField ButtonType="Link" ShowEditButton="true"  ShowDeleteButton="true" />
            <asp:BoundField DataField="Nombre_Alumno" HeaderText="Nombre" />
            <asp:BoundField DataField="Rut_Alumno" HeaderText="Rut" />
            <asp:BoundField DataField="Id_Escuela_Alumno" HeaderText="Escuela" />
            <asp:BoundField DataField="Promocion_Alumno" HeaderText="Promocion" />
            </Columns>
            </asp:GridView>
        </div>         
    </div>
</div>


    <div id='divEditar' runat='server'>
        <h2>
                        Editar Alumno
        </h2>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Nombre</label></div>
            <div class="col-sm-6"><label for="lbl2">Rut (Ejemplo: 18205857-2)</label></div>
        </div>
              
        <div class="row">
            <div class="col-sm-6"><asp:TextBox class="form-control" ID="nombre" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="rut" class="form-control" runat="server" ReadOnly="True"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label></div>
            <div class="col-sm-6"><label for="lbl1">Direccion</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Correo</label></div>
            <div class="col-sm-6"><label for="lbl1">Telefono</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox></div>
            <div class="col-sm-6"><asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl9">Nacionalidad</label></div>
            <div class="col-sm-6"><label for="lbl10">Escuela</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="nacionalidad" class="form-control" runat="server" ></asp:TextBox></div>
            <div class="col-sm-6"><asp:DropDownList ID="escuela" runat="server" class="form-control"></asp:DropDownList></div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-6"><label for="lbl1">Año ingreso</label></div>
            <div class="col-sm-2"><label for="lbl10">Sexo</label></div>
            <div class="col-sm-2"><label for="lbl1">Beneficio</label></div>
        </div>

        <div class="row">
            <div class="col-sm-6"><asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox></div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="sexo" runat="server">
                        <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                        <asp:ListItem Value="Femenino"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="beneficio" runat="server">
                        <asp:ListItem Value="Si"></asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnEditar" class="btn btn-primary btn-block btn-lg" runat="server" onclick="btnGuardar_Click" Text="Guardar"/>
            </div>        
        </div>
    </div>    
</asp:Content>
