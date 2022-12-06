using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestBackEndBD.Classes;

namespace TestBackEndBD
{
    public partial class _Default : Page
    {
        private MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {

            connection = new MySqlConnection(SiteMaster.ConnectionString);

            if (IsPostBack == false)
            {
                SiteMaster.ExibirAlert(this, "Bem vindo");

                connection.Open();
                ddlProduto.Items.Clear();
                var reader = new MySqlCommand("SELECT descricao, id FROM produtos", connection).ExecuteReader();
                while (reader.Read())
                {
                    var item = new ListItem(reader.GetString("descricao"), reader.GetInt32("id").ToString());
                    ddlProduto.Items.Add(item);
                }
                connection.Close();

                connection.Open();
                ddlCliente.Items.Clear();
                reader = new MySqlCommand("SELECT nome, id FROM clientes WHERE ativo = 1", connection).ExecuteReader();
                while (reader.Read())
                {
                    var item = new ListItem(reader.GetString("nome"), reader.GetInt32("id").ToString());
                    ddlCliente.Items.Add(item);
                }
                connection.Close();

                Session["itens"] = new List<Item>();

                CalculaValorProduto();
            }

        }

        private void CalculaValorProduto()
        {
            if (txtQtd.Text == "")
                txtTotal.Text = "1";

            int qtd = Convert.ToInt32(txtQtd.Text);
            if (qtd <= 0)
                qtd = 1;

            connection.Open();
            var reader = new MySqlCommand("SELECT valor FROM produtos WHERE id = " + ddlProduto.SelectedValue, connection).ExecuteReader();
            reader.Read();
            var valor = reader.GetFloat(0);
            connection.Close();

            txtQtd.Text = qtd.ToString();
            txtValor.Text = valor.ToString("C");
            txtTotal.Text = (qtd * valor).ToString("C");
        }

        protected void txtQtd_TextChanged(object sender, EventArgs e)
        {
            CalculaValorProduto();
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculaValorProduto();
        }

        protected void btnRecomecar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Venda.aspx");
        }

        protected void btnAviso_Click(object sender, EventArgs e)
        {

            SiteMaster.ExibirAlert(this, "Escolha o nome do cliente e o Produto para efetuar a venda, Atenção a venda não pode ser desfeita");
        }

        protected void btnVenda_Click(object sender, EventArgs e)
        {
            var lista_itens = (List<Item>)Session["itens"];
            foreach (var i in lista_itens)
            {
                connection.Open();
                var reader = new MySqlCommand("SELECT estoque FROM produtos WHERE id =" + i.Id_Produto, connection).ExecuteReader();
                reader.Read();
                int estoque = reader.GetInt32(0);
                connection.Close();

                if (estoque < i.Qtd)
                {
                    SiteMaster.ExibirAlert(this, $"Estoque insuficiente do produto {i.Descricao}! Existem apenas {estoque}");
                    return;
                }
            }

            connection.Open();
            var command = new MySqlCommand($@"INSERT INTO vendas (id_cliente,datahora) VALUES ({ddlCliente.SelectedValue},NOW())", connection);
            command.ExecuteNonQuery();

            var readerId = new MySqlCommand("SELECT MAX(id) FROM vendas", connection).ExecuteReader();
            readerId.Read();
            int id_venda = readerId.GetInt32(0);
            connection.Close();

            foreach (var i in lista_itens)
            {
                connection.Open();
                command = new MySqlCommand($"INSERT INTO itens_venda (qtd, valor, id_venda, id_produto) VALUES (@qtd,@valor,@id_venda,@id_produto)", connection);
                command.Parameters.Add(new MySqlParameter("qtd", i.Qtd));
                command.Parameters.Add(new MySqlParameter("valor", i.Valor.ToString().Replace(",", ".")));
                command.Parameters.Add(new MySqlParameter("id_venda", id_venda));
                command.Parameters.Add(new MySqlParameter("id_produto", i.Id_Produto));
                command.ExecuteNonQuery();
                new MySqlCommand($"UPDATE produtos SET estoque = estoque - {i.Qtd} WHERE id = {i.Id_Produto}", connection).ExecuteNonQuery();
                connection.Close();
            }
            SiteMaster.ExibirAlert(this, "Venda realizada com sucesso!","Venda.aspx");
        }

        protected void grdItens_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var lista_itens = (List<Item>)Session["itens"];

            if (e.CommandName == "remover")
            {
                lista_itens.RemoveAt(index);
                Session["itens"] = lista_itens;
                grdItens.DataSource = lista_itens;
                grdItens.DataBind();
            }

            if (e.CommandName == "mais" || e.CommandName == "menos")
            {
                var qtd_atual = lista_itens[index].Qtd;
                lista_itens[index].Qtd = (e.CommandName == "mais") ? qtd_atual + 1 : qtd_atual - 1;
                Session["itens"] = lista_itens;
                grdItens.DataSource = lista_itens;
                grdItens.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var lista_itens = (List<Item>)Session["itens"];
            var item = lista_itens.FirstOrDefault(x => x.Id_Produto == Convert.ToInt32(ddlProduto.SelectedValue));
            if (item == null)
            {
                lista_itens.Add(new Item
                {
                    Descricao = ddlProduto.SelectedItem.Text,
                    Id_Produto = Convert.ToInt32(ddlProduto.SelectedValue),
                    Qtd = Convert.ToInt32(txtQtd.Text),
                    Valor = Convert.ToDouble(txtValor.Text.Replace("R$", "").Replace("$", ""))
                });
            }
            else
            {
                item.Qtd += Convert.ToInt32(txtQtd.Text);
            }
            Session["itens"] = lista_itens;
            grdItens.DataSource = lista_itens;
            grdItens.DataBind();
        }
    }
}