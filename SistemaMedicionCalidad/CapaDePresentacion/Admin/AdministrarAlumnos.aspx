<%@ Page Language="C#" MasterPageFile="SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdministrarAlumnos.aspx.cs" Inherits="CapaDePresentacion.AdministrarAlumnos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div id='divMostrar' runat='server'>
        <br />
        <br />
        <h2 class="text-center">Administrar Alumnos</h2>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-6">
                <asp:TextBox class="form-control" ID="tbxbuscar" runat="server"></asp:TextBox>  
            </div>
            <div class="col-sm-2">
                <asp:Button class="btn btn-primary btn-block" ID="btnbuscar" runat="server" Text="Buscar" 
                onclick="btnbuscar_Click" />
            </div>
        </div>
        <br />

    <div class ="row">
        <div class="col-sm-offset-3 col-sm-9">
            <asp:GridView class="table table-striped" ID="gvAlumnos" runat="server" AutoGenerateColumns="False" 
            onrowdeleting="rowDeletingEvent" onrowediting="rowEditingEvent">
            <Columns>
            <asp:CommandField ButtonType="Link" ShowEditButton="true"  ShowDeleteButton="true" />
            <asp:BoundField DataField="Nombre_Persona" HeaderText="Nombre" />
            <asp:BoundField DataField="Rut_Persona" HeaderText="Rut" />
            <asp:BoundField DataField="Escuela_Alumno.Nombre_Escuela" HeaderText="Escuela" />
            <asp:BoundField DataField="Promocion_Alumno" HeaderText="Promocion" />
            </Columns>
            </asp:GridView>
        </div>         
    </div>
</div>


    <div id='divEditar' runat='server'>
        <br />
        <br />
        <h2 class="text-center">Actualizar Alumno</h2>
        <br />
        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Nombre
                </label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNombre" runat="server" pattern="^([A-ZÁÉÍÓÚ]{1}[a-zñáéíóú]+[\s]*)+$"  placeHolder="Ingrese su nombre" class="form-control"  
                oninvalid="setCustomValidity('La primera letra del nombre y apellido deben ir en mayuscula')"
                oninput="setCustomValidity('')" >
                </asp:TextBox>
            </div>          
        </div>
        <br />
              
        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl2">Rut 
                </label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtRut" class="form-control" runat="server" placeHolder="Ejemplo: 18205857-2" ReadOnly="true">
                </asp:TextBox>
            </div>
       </div>
       <br />
        
        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Fecha de nacimiento</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFechaDeNacimiento" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
       <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Direccion</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingrese su dirección"></asp:TextBox>
            </div>       
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Correo</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtCorreo" class="form-control" runat="server" type="email" placeHolder="Ejemplo: ejemplo@live.cl" ></asp:TextBox>
            </div>            
       </div>
       <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Telefono</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtTelefono" class="form-control" runat="server" type="number" placeHolder="Ingrese su telefono" min="940000000" max="9999999999"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl9">Nacionalidad</label>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList ID="ddPais" runat="server" class="form-control">
                </asp:DropDownList>
            </div>    
        </div>
       <br />

        <div class="row">  
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl10">Escuela</label>
            </div>                     
            <div class="col-sm-4">
                <asp:DropDownList ID="ddEscuela" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl1">Año ingreso</label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPromocion" class="form-control" runat="server" placeHolder="Ingrese año ingreso" type="number" min="2010"></asp:TextBox>
            </div> 
        </div>
       <br />

        <div class="row">
            <div class="col-sm-offset-3 col-sm-2">
                <label for="lbl10">Sexo</label>
            </div>
            <div class="col-sm-2">
                <asp:RadioButtonList ID="rbSexo" runat="server">
                        <asp:ListItem Selected="True" Value="Masculino"></asp:ListItem>
                        <asp:ListItem Value="Femenino"></asp:ListItem>
                </asp:RadioButtonList>
            </div>   
            <div class="col-sm-1">
                <label for="lbl1">Beneficio</label>
            </div>
            <div class="col-sm-1">
                <asp:RadioButtonList ID="rbBeneficio" runat="server">
                        <asp:ListItem Value="Si"></asp:ListItem>
                        <asp:ListItem Selected="True" Value="No"></asp:ListItem>
                    </asp:RadioButtonList>
            </div>
        </div>
       <br />

       <div class="row">
            <div class="col-sm-offset-7 col-sm-2">
                <asp:Button ID="btnEditar" class="btn btn-primary btn-block btn-lg" runat="server" onclick="btnGuardar_Click" Text="Guardar"/>  
            </div> 
       </div>
       </div>
                
</asp:Content>
