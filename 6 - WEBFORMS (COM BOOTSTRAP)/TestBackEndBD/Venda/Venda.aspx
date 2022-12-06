<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Venda.aspx.cs" Inherits="TestBackEndBD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top: 50px"></div>
    <div class="row">
        <div class="col-sm-8">
            <label class="form-label">Cliente:</label>
            <asp:DropDownList runat="server" ID="ddlCliente" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3">
            <label class="form-label">Produto:</label>
            <asp:DropDownList runat="server" ID="ddlProduto" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <label for="txtValor" class="form-label">Valor:</label>
            <asp:TextBox runat="server" ID="txtValor" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <label for="txtQtd" class="form-label">Qtd:</label>
            <asp:TextBox runat="server" ID="txtQtd" TextMode="Number" CssClass="form-control" Text="1" OnTextChanged="txtQtd_TextChanged" AutoPostBack="true" ></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label class="form-label">Total:</label>
            <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-sm-2" style="padding-top:22px">    
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnAdd" Text="+ Adicionar novo produto" OnClick="btnAdd_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-8">
            
    <asp:GridView runat="server" ID="grdItens" Width="100%" AutoGenerateColumns="false" 
        CssClass="table table-sm table-responsive-sm table-hover"
        OnRowCommand="grdItens_RowCommand" AllowPaging="false" >
        <Columns>
            <asp:BoundField DataField="descricao" HeaderText="DESCRICAO" />
            <asp:BoundField DataField="valor" HeaderText="VALOR UNITÁRIO" />
            <asp:ButtonField ButtonType="Link" CommandName="menos" Text="-" />
            <asp:BoundField DataField="qtd" HeaderText="QTD" />
            <asp:ButtonField ButtonType="Link" CommandName="mais" Text="+" />
            <asp:BoundField DataField="total" HeaderText="VALOR TOTAL" />
            <asp:ButtonField ButtonType="Link" CommandName="remover" Text="Remover" />
        </Columns>
        </asp:GridView>
            </div>
        </div>
    <br />
    <div class="row">
        <div class="col-sm-8">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btnVenda" Text="Realizar Venda" OnClick="btnVenda_Click" />
            <asp:Button runat="server" CssClass="btn btn-warning" ID="btnAviso" Text="Avisos ao Cliente" OnClick="btnAviso_Click" />
            <asp:Button runat="server" CssClass="btn btn-danger" ID="btnRecomecar" Text="Recomeçar Venda" OnClick="btnRecomecar_Click" />
        </div>
    </div>
</asp:Content>
