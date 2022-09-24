<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="home_admin.aspx.cs" Inherits="SmartAssemblyTFI.Formulario_web15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="containerBienvenidaAdmin">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Gestiones disponibles</h2>
                        <p><b>Actualmente se pueden realizar las siguientes gestiones</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/Inventario.png" />
                        <h4>Inventario</h4>
                        <asp:Button class="btn btn-primary" type="submit" runat="server" PostBackUrl="/gestiones/abmc_componentes.aspx" Text="Ir a gestion de inventario" />
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/empleados.png" />
                        <h4>Empleados</h4>
                        <asp:Button class="btn btn-primary" type="submit" runat="server" PostBackUrl="/gestiones/abmc_empleados.aspx" Text="Ir a gestion de empleados" />
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img class="homeCard" src="imgs/tiposUso.png" />
                        <h4>Tipos de uso</h4>
                        <asp:Button class="btn btn-primary" type="submit" runat="server" PostBackUrl="/gestiones/abmc_tipouso.aspx" Text="Ir a gestion de tipos de uso" />
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="containerBienvenidaAdmin">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Valor total de los pedidos hechos durante este año</h2>
                        <div id="adminChartcontainer"></div>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="containerBienvenidaAdmin">
            <div class="row">
                <div class="col-md-8 mx-auto">
                    <center>
                        <h2>Clientes segmentados</h2>
                        <br />
                        <div class="table-responsive border">
                            <table class="table">
                                <thead>
                                    <tr class="cardHeaderResumen">
                                        <th scope="col" class="text-center">#</th>
                                        <th scope="col" class="text-center">Tipo de uso</th>
                                        <th scope="col" class="text-center">Presupuesto promedio en pesos</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <% for (int i = 0; i < ClientesSegmentados.Count(); i++)
                                        {%>
                                    <tr>
                                        <th scope="row" class="text-center"><%=i%></th>
                                        <td class="text-center"><%=ClientesSegmentados.ElementAt(i).Key%></td>
                                        <td class="text-center">$<%=ClientesSegmentados[ClientesSegmentados.ElementAt(i).Key]%></td>
                                    </tr>
                                    <% } %>
                                </tbody>
                            </table>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="containerBienvenidaAdmin">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Resumen de los pedidos realizados</h2>
                        <br />
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    <center>
                        <div class="resumenCard border">
                            <div class="card-header cardHeaderResumen">
                                <h4 class="card-title">Top componentes mas pedidos</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <% foreach (var componente in Componentes)
                                    { %>
                                <li class="list-group-item"><%Response.Write(componente.Key);%> (cantidad:<%Response.Write(componente.Value);%>)</li>
                                <% } %>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-sm-4">
                    <center>
                        <div class="resumenCard border">
                            <div class="card-header cardHeaderResumen">
                                <h4 class="card-title">Ganancias mensuales de los ultimos 3 meses</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <% foreach (var mesGanancia in MesesGanancias)
                                    { %>
                                <li class="list-group-item"><%Response.Write(mesGanancia.Key);%>: $<%Response.Write(mesGanancia.Value);%></li>
                                <% } %>
                            </ul>
                        </div>
                    </center>
                </div>
                <div class="col-sm-4">
                    <center>
                        <div class="resumenCard border">
                            <div class="card-header cardHeaderResumen">
                                <h4>Tipos de uso mas solicitados</h4>
                            </div>
                            <ul class="list-group list-group-flush">
                                <% foreach (var tipoUso in TiposUsoMasSolicitados)
                                    { %>
                                <li class="list-group-item"><%Response.Write(tipoUso.Key);%> (cantidad:<%Response.Write(tipoUso.Value);%>)</li>
                                <% } %>
                            </ul>
                        </div>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <br />
    <br />
    <br />
    <script>
        $('#adminChartcontainer').highcharts({
            chart: {
                type: 'spline',
            },
            title: {
                text: ''
            },
            xAxis: {
                title: {
                    enabled: true,
                    text: 'Mes'
                },
                labels: {
                    format: '{value}'
                },
                maxPadding: 0.05
            },
            yAxis: {
                title: {
                    text: 'Valor en pesos'
                },
                labels: {
                    format: '${value}'
                },
                lineWidth: 0.5
            },
            legend: {
                enabled: false
            },
            tooltip: {
                headerFormat: '<b>{series.name}</b><br />',
                pointFormat: '{point.x} mes: ${point.y}'
            },
            plotOptions: {
                spline: {
                    marker: {
                        enable: false
                    }
                }
            },
            series: [{
                name: 'Pesos',
                data: <%Response.Write(LineData);%>,
            }]
        });
    </script>
</asp:Content>