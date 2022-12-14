<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="home_page.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--icono--%>
    <link runat="server" rel="icon" href="imgs/icono.ico" type="image/ico" />
    <%--jquery--%>
    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%--popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
    <%--bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <%--bootstrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--our custom css--%>
    <link href="css/styles.css" rel="stylesheet" />
    <%--charts js--%>
    <script src="chartJs/highcharts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="containerBienvenida">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h1 class="tituloHome">Armamos tu PC al mejor precio 💻​</h1>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <center>
                        <asp:Button class="btn btn-primary armarPcBoton" type="submit" runat="server" PostBackUrl="/venta/crear_presupuesto.aspx" Text="Arma tu PC" />
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h1>Tu PC ideal en 3 simples pasos</h1>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <div class="card border-0">
                            <center>
                                <img class="homeCard" src="imgs/sign-up.png" alt="imgs/pc.png" />
                            </center>
                            <h4>Registrate</h4>
                            <p class="text-justify">Registrate o ingresa para acceder a nuestros servicios</p>
                        </div>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <div class="card border-0">
                            <center>
                                <img class="homeCard" src="imgs/search-online.png" alt="imgs/pc.png" />
                            </center>
                            <h4>Armamos tu computadora</h4>
                            <p class="text-justify">Nos indicas cuanto queres gastar y para que queres usar tu PC, despues nosotros hacemos todo el trabajo 😉​</p>
                        </div>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <div class="card border-0">
                            <center>
                                <img class="homeCard" src="imgs/pc.png" alt="imgs/pc1.png" />
                            </center>
                            <h4>¡Tu computadora ya esta lista!</h4>
                            <p class="text-justify">Te ofrecemos la mejor computadora para vos y podes realizar el pedido dentro de la misma pagina</p>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="containerBienvenida">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Aca te mostramos algunas de las PCs que armamos</h2>
                        <br />
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc1.png" alt="imgs/pc.png">
                            <div class="card-body">
                                <h4 class="card-title">PC gaming I5 11600K</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: I5 11600K</li>
                                <li class="list-group-item">RAM: 8GB DDR4</li>
                                <li class="list-group-item">SSD: 250GB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>

                        <div class="card">
                            <img class="card-img-top" src="imgs/pc2.png" alt="imgs/pc.png" />
                            <div class="card-body">
                                <h4>PC gaming R9 6900X</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: R9 6900X</li>
                                <li class="list-group-item">RAM: 16GB DDR4</li>
                                <li class="list-group-item">SSD: 500GB</li>
                                <li class="list-group-item">HDD: 2TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc3.png" alt="imgs/pc.png" />
                            <div class="card-body">
                                <h4>Work station R7 5800x</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: R7 5800x</li>
                                <li class="list-group-item">RAM: 16GB DDR4</li>
                                <li class="list-group-item">SSD: 500GB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc4.png" alt="imgs/pc.png" />
                            <div class="card-body">
                                <h4>PC streamer i9 9900k</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: i9 9900k</li>
                                <li class="list-group-item">RAM: 32GB DDR4</li>
                                <li class="list-group-item">SSD: 1TB</li>
                                <li class="list-group-item">HDD: 2TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>