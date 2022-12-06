<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="TestBackEndBD.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <br />
        <br />
        <div class="row justify-content-center">
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fas fa-money-bill-alt"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Valor de Todas as Vendas</h4>
                        <div class="progress-bar progress-bar-success" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTotalVenda" Text="R$ 0,00"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fas fa-cash-register"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Valor do Ticket Médio</h4>
                        <div class="progress-bar progress-bar-primary" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTicketMedio" Text="R$ 0,00"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fas fa-boxes"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Valor Total em Estoque</h4>
                        <div class="progress-bar progress-bar-warning" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTotalEstoque" Text="R$ 0,00"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fa fa-user"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Total de Clientes Ativos</h4>
                        <div class="progress-bar progress-bar-success" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTotalClientesAtivos" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fas fa-user-alt-slash"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Total de Clientes Inativos</h4>
                        <div class="progress-bar progress-bar-danger" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTotalClientesInativos" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-12">
                <div class="row">
                    <div class="col-lg-2">
                        <h1><i class="fas fa-box"></i></h1>
                    </div>
                    <div class="col-lg-6 text-center">
                        <h4>Total de Produtos em Estoque</h4>
                        <div class="progress-bar progress-bar-info" role="progressbar" style="width: 100%">
                            <asp:Label runat="server" ID="lblTotalProdutos" Text="0"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
