<%@ Page Title="Crear presupuesto" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="crear_presupuesto.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web13" %>

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
    <div class="container">
        <div class="row">
            <div class="col-md-7 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img class="homeCard" src="../imgs/presupuesto.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Ingrese los datos necesarios para poder crear el presupuesto</h3>
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
                                <label>Cantidad de dinero en pesos</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Number" step="1000" placeholder="Cantidad de dinero"></asp:TextBox>
                                </div>
                                <label>Para que vas a usar la PC</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
                                </div>
                                <label>Importancia</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Pedir mi computadora" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <center>
                        <asp:Label Visible="false" ForeColor="Red" runat="server" ID="labelError" Text="Error al crear tu presupuesto, intente con un presupuesto mayor"></asp:Label>
                    </center>
                </div>
                <a href="../home_page.aspx"><< Atras</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>