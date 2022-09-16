<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="crear_pedido.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                    <img class="homeCard" src="../imgs/pc.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Esta es la mejor computadora para vos</h3>
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
                                <div class="form-group">
                                    <ul class="list-group list-group-flush" selectmethod="GetData">
                                        <li class="list-group-item">CPU: <%=NombreCpu%></li>
                                        <li class="list-group-item">GPU: <%=NombreGpu%></li>
                                        <li class="list-group-item">MOTHER: <%=NombreMother%></li>
                                        <li class="list-group-item">RAM: <%=NombreRam%></li>
                                        <li class="list-group-item">SSD: <%=NombreSsd%></li>
                                        <li class="list-group-item">HDD: <%=NombreHdd%></li>
                                        <li class="list-group-item">PRECIO: <%=Precio%></li>
                                    </ul>
                                </div>
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Crear tu pedido con esta computadora" PostBackUrl="/venta/crear_pedido.aspx" OnClick="Button1_Click" />
                                </div>
                                <center>
                                    <asp:Label visible="false" ForeColor="Green" runat="server" ID="labelConfirmacion" Text="Error de presupuesto! intenta con un presupuesto mayor u otro tipo de uso"></asp:Label>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="/venta/crear_presupuesto.aspx"><< Atras</a><br>
                <br>
            </div>
        </div>
    </div>
</asp:Content>