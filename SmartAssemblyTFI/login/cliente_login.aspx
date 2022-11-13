<%@ Page Title="Login" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="cliente_login.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web1" %>

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
                                    <h3>Ingreso de cliente</h3>
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
                                <label>Correo electronico</label>
                                <div class="form-group">
                                    <asp:TextBox onkeypress="return this.value.length<50" CssClass="form-control" ID="TextBox1" runat="server" placeholder="Correo Electronico" TextMode="Email"></asp:TextBox>
                                </div>
                                <label>Contraseña</label>
                                <div class="form-group">
                                    <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                                </div>
                                <div class="form-group">
                                    <a href="cliente_signup.aspx">
                                        <input class="btn btn-info btn-block btn-lg" id="Button2" type="button" value="Registrarse" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <center>
                            <asp:Label Visible="false" ForeColor="Red" runat="server" ID="labelError" Text="Contraseña o usuario invalido!"></asp:Label>
                        </center>
                    </div>
                </div>
                <a href="../homepage.aspx"><< Atras</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>