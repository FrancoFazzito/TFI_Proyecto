<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="abmc_empleados.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web20" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--icono--%>
    <link runat="server" rel="icon" href="../imgs/icono.ico" type="image/ico" />
    <%--jquery--%>
    <script src="../bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%--popper js--%>
    <script src="../bootstrap/js/popper.min.js"></script>
    <%--bootstrap js--%>
    <script src="../bootstrap/js/bootstrap.min.js"></script>
    <%--bootstrap css--%>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--our custom css--%>
    <link href="../css/styles.css" rel="stylesheet" />
    <%--charts js--%>
    <script src="../chartJs/highcharts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="border tipoUsoCard">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Detalle de empleados</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>ID del empleado</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<6" CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID del empleado" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Nombre usuario</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox1" runat="server" placeholder="Nombre usuario"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Correo electronico</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<50" CssClass="form-control" ID="TextBox2" runat="server" TextMode="Email" placeholder="Correo electronico"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Nombre</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox4" runat="server" placeholder="Nombre"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Apellido</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox5" runat="server" placeholder="Apellido"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Contraseña</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox7" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Confirmar contraseña</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox6" runat="server" TextMode="Password" placeholder="Nueva Contraseña"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-6">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Agregar" OnClick="Button2_Click" />
                            </div>
                            <div class="col-6">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Actualizar" OnClick="Button3_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <asp:Label Visible="False" ForeColor="Red" runat="server" ID="labelErrorContrasenaCoincidente" Text="La contraseñas deben ser iguales"></asp:Label>
                    <asp:Label Visible="false" ForeColor="Red" runat="server" ID="labelErrorNombreUsuarioExistente" Text="Nombre de usuario ya registrado"></asp:Label>
                    <asp:Label Visible="False" ForeColor="Red" runat="server" ID="labelErrorContrasena" Text="La contraseña debe tener al menos una mayuscula, una minuscula, un numero y al menos 8 caracteres"></asp:Label>
                    <asp:Label Visible="False" ForeColor="Red" runat="server" ID="labelError" Text="Ingrese todos los datos validos para realizar la gestion"></asp:Label>
                    <asp:Label Visible="False" ForeColor="Red" runat="server" ID="labelErrorEliminacion" Text="No puedes eliminar este usuario"></asp:Label>
                </center>
                <a href="../home_admin.aspx"><< Atras</a><br>
                <br>
            </div>
            <div class="col-md-6">
                <div class="border tipoUsoCard">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Listado de empleados</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="EmpleadosGrid" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="6">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button class="btn btn-primary" ID="Button5" runat="server" Text="Detallar" OnClick="Button5_Click" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button OnClick="BajaButton_Click" class="btn btn-danger" ID="BajaButton" Text="Eliminar" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>