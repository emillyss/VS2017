<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroEleitor.aspx.cs" Inherits="FeedbackEleitor.CadastroEleitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Nome: <asp:TextBox runat="server" ID="txtNome"></asp:TextBox>
    <br />
    <asp:LinkButton runat="server" ID="btnCadastrar" OnClick="btnCadastrar_Click">Cadastrar Novo Eleitor</asp:LinkButton>
    <asp:LinkButton runat="server" ID="btnTelaPesquisa" OnClick="btnTelaPesquisa_Click">Tela de Pesquisa</asp:LinkButton>
</asp:Content>
