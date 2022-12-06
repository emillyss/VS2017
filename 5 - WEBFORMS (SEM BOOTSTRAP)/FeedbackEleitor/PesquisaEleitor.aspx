<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PesquisaEleitor.aspx.cs" Inherits="FeedbackEleitor.PesquisaEleitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Nome: <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    <asp:LinkButton runat="server" ID="lnkPesquisar" OnClick="lnkPesquisar_Click">Pesquisar Eleitor</asp:LinkButton>
    <asp:LinkButton runat="server" ID="lnkCadastrar" OnClick="lnkCadastrar_Click">Cadastra Eleitor</asp:LinkButton>

    <asp:GridView runat="server" ID="gridEleitores" AllowPaging="false" AutoGenerateColumns="false" OnRowCommand="gridEleitores_RowCommand">
        <Columns>
            <asp:BoundField DataField="nome" HeaderText="NOME" />
            <asp:ButtonField CommandName="editar" Text="Editar" />
            <asp:ButtonField CommandName="excluir" Text="Excluir" />
        </Columns>
    </asp:GridView>
</asp:Content>
