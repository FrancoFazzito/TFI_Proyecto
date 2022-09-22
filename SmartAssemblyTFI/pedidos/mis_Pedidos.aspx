<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="mis_Pedidos.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
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
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="border tipoUsoCard">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Computadora pedida</h4>
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
                                <asp:Label runat="server" ID="CpuLabel"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <asp:Label runat="server" ID="Label1"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <asp:Label runat="server" ID="Label2"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9 mx-auto">
                                <asp:Label runat="server" ID="Label3"></asp:Label>
                            </div>
                        </div>
                        <br>
                    </div>
                </div>
                <br>
            </div>
            <a href="../home_page.aspx"><< Atras</a><br>
            <br />
        </div>
    </div>
</asp:Content>
