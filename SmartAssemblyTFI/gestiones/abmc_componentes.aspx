<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="abmc_componentes.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web19" %>

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
            <div class="col-md-6">
                <div class="border tipoUsoCard">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Detalle de componentes</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <label>ID del componente</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="idtxt" runat="server" placeholder="ID"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto">
                                <label>Nombre</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="nombretxt" runat="server" placeholder="Nombre"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <label>Tipo componente</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:DropDownList class="form-control" ID="tiposComponenteDll" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto">
                                <label>Perfomance</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="perfomancetxt" runat="server" TextMode="Number" placeholder="Perfomance"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <label>Stock</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="stocktxt" runat="server" TextMode="Number" placeholder="Stock"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto">
                                <label>Limite de stock</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="limiteStocktxt" runat="server" TextMode="Number" placeholder="Limite de stock"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto">
                                <label>Precio</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="preciotxt" runat="server" placeholder="Precio"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto">
                                <label>Consumo en Watts</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="consumotxt" runat="server" TextMode="Number" Step="10" placeholder="Consumo en watts"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto" runat="server" id="Socket" visible="false">
                                <asp:Label runat="server" ID="LabelSocket">Socket</asp:Label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="sockettxt" AutoPostBack="true" runat="server" placeholder="Socket"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto" runat="server" id="TieneVideoIntegrado" visible="false">
                                <div class="form-check">
                                    <br />
                                    <asp:CheckBox CssClass="form-check-input" ID="videoIntegradoCheck" runat="server"></asp:CheckBox>
                                    <label class="form-check-label" for="exampleCheck1">Tiene video integrado</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto" runat="server" id="Canales" visible="false">
                                <label>Canales</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="canalestxt" runat="server" TextMode="Number" placeholder="Canales"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto" runat="server" id="AltaFrecuencia" visible="false">
                                <div class="form-check">
                                    <br />
                                    <asp:CheckBox CssClass="form-check-input" ID="altaFrecuenciaCheck" runat="server"></asp:CheckBox>
                                    <label class="form-check-label" for="exampleCheck1">Necesita alta frecuencia</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto" runat="server" id="TipoMemoria" visible="false">
                                <label>Tipo de memoria</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:DropDownList class="form-control" ID="tiposMemoriaDll" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto" runat="server" id="TamanoFan" visible="false">
                                <label>Tamaño de FAN</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="tamanoFantxt" runat="server" TextMode="Number" Step="40" placeholder="Tamaño de FAN"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto" runat="server" id="NivelFan" visible="false">
                                <label>Nivel de FAN (fan stock)</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="nivelFantxt" runat="server" TextMode="Number" placeholder="Nivel de FAN"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto" runat="server" id="FrecuenciaMaxima" visible="false">
                                <label>Frecuencia maxima</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox class="form-control" ID="frecuenciaMaximatxt" TextMode="Number" runat="server"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mx-auto" runat="server" id="Capacidad" visible="false">
                                <label>Capacidad</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="capacidadtxt" runat="server" TextMode="Number" placeholder="Capacidad"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto" runat="server" id="TipoFormato" visible="false">
                                <label>Tipo de formato</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:DropDownList class="form-control" ID="tiposFormatoDll" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-7 mx-auto" runat="server" id="NivelVideoIntegrado" visible="false">
                                <label>Nivel de video (video integrado)</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="nivelVideoIntregadotxt" runat="server" TextMode="Number" placeholder="Nivel de video"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
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
                                    <h4>Listado de componentes</h4>
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
                                <asp:GridView class="table table-striped table-bordered" ID="ComponentesGrid" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="9">
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