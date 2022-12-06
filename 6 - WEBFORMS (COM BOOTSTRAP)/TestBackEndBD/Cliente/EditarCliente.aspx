<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCliente.aspx.cs" Inherits="TestBackEndBD.EditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center">
            <b>Edição de Clientes</b>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-2">Nome:</div>
            <div class="col-sm-4">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNome"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-2">Ativo:</div>
            <div class="col-sm-4">
                <asp:RadioButtonList runat="server" CssClass="form-control" RepeatDirection="Horizontal" ID="rdoAtivo">
                    <asp:ListItem Value="1" Text="Ativo"></asp:ListItem>
                    <asp:ListItem Value="0" Text="Inativo"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <br />
        <div class="row text-center">
            <asp:Button runat="server" ID="btnEditar" CssClass="btn btn-success" OnClick="btnEditar_Click" Text="Editar Cliente" />
        </div>
    </div>
</asp:Content>
