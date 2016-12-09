<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"  CodeBehind="CrearAlumno.aspx.cs" Inherits="CapaDePresentacion.CrearAlumno" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">           
        <h2>
                        Crear Alumno
        </h2>
         <div class="form-group">
    <label for="exampleInputEmail1">Email address</label>
    <input type="email" class="form-control col-sm-10" id="exampleInputEmail1" placeholder="Email">
  </div>
        <label for="lbl1">Nombre</label>
            <asp:TextBox class="form-control col-sm-10" ID="nombre" runat="server"></asp:TextBox>
        <div class="form-group">

        <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem NavigateUrl="~/CrearAlumno.aspx" Text="Crear Alumno" 
            Value="Crear Escuela"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/AdministrarAlumnos.aspx" 
            Text="Administrar Escuelas" Value="Administrar Alumnos"></asp:MenuItem>
            </Items>
        </asp:Menu>

            

            <label for="lbl2">Rut (Ejemplo: 18205857-2)</label>
            <asp:TextBox ID="rut" class="form-control" runat="server"></asp:TextBox>

            <label for="lbl1">Escuela</label>
                    <asp:DropDownList ID="escuela" runat="server" class="form-control">
                    </asp:DropDownList>
        </div>

                    
                    <label for="lbl1">Fecha de nacimiento (Ejemplo: 20/11/1992)</label>
                    <label for="lbl1">Direccion</label>
                    <label for="lbl1">Telefono</label>
                    <asp:TextBox ID="fechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
                    <asp:TextBox ID="direccion" class="form-control" runat="server"></asp:TextBox>
                    <asp:TextBox ID="telefono" class="form-control" runat="server"></asp:TextBox>
                <label for="lbl1">Nacionalidad</label>
                <label for="lbl1">Correo</label>
                <label for="lbl1">Promocion</label>
                    <asp:TextBox ID="nacionalidad" class="form-control" runat="server" ></asp:TextBox>
                    <asp:TextBox ID="correo" class="form-control" runat="server"></asp:TextBox>
                <asp:TextBox ID="promocion" class="form-control" runat="server"></asp:TextBox>
                    <label for="lbl1">Sexo</label>
                    <label for="lbl1">Beneficio</label>

                    <asp:RadioButtonList ID="sexo" runat="server">
                        <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                        <asp:ListItem Value="Femenino"></asp:ListItem>
                    </asp:RadioButtonList>

                    <asp:RadioButtonList ID="beneficio" runat="server">
                        <asp:ListItem Value="Si"></asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="btnCrear" class="btn btn-primary" runat="server" onclick="btnCrear_Click" 
                        Text="Crear"/>
    </asp:Content>