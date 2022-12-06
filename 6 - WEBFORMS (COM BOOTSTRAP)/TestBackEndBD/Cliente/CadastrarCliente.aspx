<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarCliente.aspx.cs" Inherits="TestBackEndBD.CadastrarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center"><b>Cadastro de Clientes</b></div>
        <br />
        <div class="row">
            <div class="col-sm-2">Nome:</div>
            <div class="col-sm-6">
                <asp:TextBox runat="server" ID="txtNome" CssClass="form-control"  placeholder="Digite o nome do cliente"></asp:TextBox></div>
        </div>
        <br />
        <div class="row text-center">
            <asp:Button runat="server" ID="btnCadastrar" CssClass="btn btn-success" OnClick="btnCadastrar_Click" Text="Efetuar Cadastro" />
        </div>
        <br />
    </div>
</asp:Content>
