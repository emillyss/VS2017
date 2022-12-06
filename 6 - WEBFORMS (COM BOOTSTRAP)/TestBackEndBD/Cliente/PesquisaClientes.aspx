<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PesquisaClientes.aspx.cs" Inherits="TestBackEndBD.PesquisaClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row text-center"><b>Pesquisa de Clientes</b></div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-sm-3">
            <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" placeholder="Digite o nome aqui para buscar"></asp:TextBox>
        </div>
        <div class="col-sm-5">
            <asp:RadioButtonList runat="server" ID="rdoAtivo" RepeatDirection="Horizontal" CssClass="form-control">
                <asp:ListItem Text="Ativos e Inativos" Value="" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Somente Ativos" Value="1"></asp:ListItem>
                <asp:ListItem Text="Somente Inativos" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <br />
    <div class="row text-center">

        <asp:Button runat="server" ID="btnPesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" Text="Pesquisar" />

        <asp:Button runat="server" ID="btnCadastro" CssClass="btn btn-success" OnClick="btnCadastro_Click" Text="Novo Cliente" />
    </div>
    <br />
    <div class="row">
        <asp:GridView runat="server" ID="grdClientes" Width="100%" AutoGenerateColumns="false"
            CssClass="table table-sm table-bordered table-condensed table-responsive-sm table-hover table-striped"
            OnRowCommand="grdClientes_RowCommand" AllowPaging="true" PageSize="10" OnPageIndexChanging="grdClientes_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="nome" HeaderText="NOME" />
                <asp:BoundField DataField="TextoAtivo" HeaderText="ATIVO" />
                <asp:ButtonField ButtonType="Link" CommandName="editar" ControlStyle-CssClass="btn btn-warning" Text="Editar" />
                <asp:ButtonField ButtonType="Link" CommandName="excluir" ControlStyle-CssClass="btn btn-danger" Text="Excluir" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
