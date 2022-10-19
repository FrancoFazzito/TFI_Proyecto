<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="cliente_signup.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img class="homeCard" src="../imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Completa los datos para poder registrarte</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Nombre</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Nombre"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Apellido</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Apellido"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Fecha de nacimiento</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Numero de telefono</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Numero de telefono" TextMode="Phone"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Correo electronico</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Correo electronico" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Provincia</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Barrio</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Contraseña</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" TextMode="Password" placeholder="contraseña"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Repita su contraseña</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" TextMode="Password" placeholder="repita su contraseña"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Registrarse" OnClick="Button1_Click" />
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="../home_page.aspx"><< Ir a inicio</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>