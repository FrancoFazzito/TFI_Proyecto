<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="home_page.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="containerBienvenida">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h1 class="tituloHome">Armamos tu PC al mejor precio</h1>
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
                        <h2>Nuestro proceso de armado</h2>
                        <p><b>Contamos con un sencillo proceso de 3 pasos</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/sign-up.png" />
                        <h4>Registrate</h4>
                        <p class="text-justify">Registrate o logueate para acceder a nuestros servicios</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/search-online.png" />
                        <h4>Armamos tu computadora</h4>
                        <p class="text-justify">Nos indicas cuanto queres gastar y para que queres usar tu compu, despues nosotros hacemos todo el trabajo (?</p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/pc.png" />
                        <h4>¡Tu computadora ya esta lista!</h4>
                        <p class="text-justify">Te ofrecemos la mejor computadora para vos y podes realizar el pedido dentro de la misma pagina</p>
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
                        <h2>Aca te mostramos algunas PCs que armamos</h2>
                        <br />
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc1.png">
                            <div class="card-body">
                                <h4 class="card-title">PC gaming I7 12900K</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: I5 11600K</li>
                                <li class="list-group-item">RAM: 16GB</li>
                                <li class="list-group-item">SSD: 250GB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>

                        <div class="card">
                            <img class="card-img-top" src="imgs/pc2.png" />
                            <div class="card-body">
                                <h4>PC gaming R9 6900X</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: R9 6900X</li>
                                <li class="list-group-item">RAM: 16GB</li>
                                <li class="list-group-item">SSD: 500GB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc3.png" />
                            <div class="card-body">
                                <h4>Work station R7 5800x</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: R7 5800x</li>
                                <li class="list-group-item">RAM: 16GB</li>
                                <li class="list-group-item">SSD: 500GB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-md-3">
                    <center>
                        <div class="card">
                            <img class="card-img-top" src="imgs/pc4.png" />
                            <div class="card-body">
                                <h4>PC streamer i9 9900k</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item">CPU: i9 9900k</li>
                                <li class="list-group-item">RAM: 16GB</li>
                                <li class="list-group-item">SSD: 1TB</li>
                                <li class="list-group-item">HDD: 1TB</li>
                            </ul>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>