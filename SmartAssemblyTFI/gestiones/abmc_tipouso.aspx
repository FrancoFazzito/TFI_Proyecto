<%@ Page Title="Tipos de uso" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="abmc_tipouso.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web16" %>

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
                                    <h4>Detalle de tipo de uso</h4>
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
                                <label>ID del tipo de uso</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<3" CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID del tipo de uso" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <label>Nombre</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<20" CssClass="form-control" ID="TextBox1" runat="server" placeholder="Nombre"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row fieldABMC">
                            <div class="col-md-9 mx-auto">
                                <label>Calidad minima del CPU para el tipo de uso</label>
                                <div class="input-group">
                                    <asp:TextBox onkeypress="return this.value.length<3" CssClass="form-control" ID="TextBox2" runat="server" TextMode="Number" placeholder="Calidad del 1 al 100"></asp:TextBox>
                                </div>
                                <label class="labelAclaracion">(1 muy baja - 100 muy alta)</label>
                            </div>
                        </div>
                        <div class="row fieldABMC">
                            <div class="col-md-9 mx-auto">
                                <label>Calidad minima del GPU para el tipo de uso</label>
                                <div class="input-group">
                                    <asp:TextBox onkeypress="return this.value.length<3" CssClass="form-control" ID="TextBox4" runat="server" TextMode="Number" placeholder="Calidad del 1 al 100"></asp:TextBox>
                                </div>
                                <label class="labelAclaracion">(1 muy baja - 100 muy alta)</label>
                            </div>
                        </div>
                        <div class="row fieldABMC">
                            <div class="col-md-9 mx-auto">
                                <label>Cantidad de RAM en GB</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<3" CssClass="form-control" ID="TextBox5" runat="server" TextMode="Number" Step="4" placeholder="Cantidad de GB"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row fieldTipoDeUso">
                            <div class="col-md-9 mx-auto">
                                <label>Cantidad de HDD en GB</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<5" CssClass="form-control" ID="TextBox6" runat="server" TextMode="Number" Step="10" placeholder="Cantidad de GB"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row fieldABMC">
                            <div class="col-md-9 mx-auto">
                                <label>Cantidad de SSD en GB</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox onkeypress="return this.value.length<5" CssClass="form-control" ID="TextBox7" runat="server" TextMode="Number" Step="10" placeholder="Cantidad de GB"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br>
                        <div class="row">

                            <div class="col-6">
                                <asp:Button OnClick="Button2_Click" ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Agregar" />
                            </div>
                            <div class="col-6">
                                <asp:Button OnClick="Button3_Click" ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Actualizar" />
                            </div>
                        </div>
                    </div>
                </div>
                <center>
                    <asp:Label Visible="False" ForeColor="Red" runat="server" ID="labelError" Text="Ingrese todos los datos validos para realizar la gestion"></asp:Label>
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
                                    <h4>Listado de tipos de uso</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button OnClick="Button5_Click" class="btn btn-primary" ID="Button5" runat="server" Text="Detallar" />
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