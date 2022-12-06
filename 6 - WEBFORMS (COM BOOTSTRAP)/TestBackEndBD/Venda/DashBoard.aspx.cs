using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestBackEndBD
{
    public partial class DashBoard : System.Web.UI.Page
    {
        private MySqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(SiteMaster.ConnectionString);

            connection.Open();
            var command = new MySqlCommand("SELECT SUM(qtd * valor) FROM itens_venda", connection);
            var reader = command.ExecuteReader();
            reader.Read();
            lblTotalVenda.Text = reader.GetFloat(0).ToString("C");
            connection.Close();

            connection.Open();
            command = new MySqlCommand("SELECT AVG(qtd * valor) FROM itens_venda", connection);
            reader = command.ExecuteReader();
            reader.Read();
            lblTicketMedio.Text = reader.GetFloat(0).ToString("C");
            connection.Close();

            connection.Open();
            command = new MySqlCommand("SELECT SUM(estoque * valor) FROM produtos", connection);
            reader = command.ExecuteReader();
            reader.Read();
            lblTotalEstoque.Text = reader.GetFloat(0).ToString("C");
            connection.Close();


            connection.Open();
            command = new MySqlCommand("SELECT COUNT(*) FROM clientes WHERE ativo = 1", connection);
            reader = command.ExecuteReader();
            reader.Read();
            lblTotalClientesAtivos.Text = reader.GetInt32(0).ToString();
            connection.Close();

            connection.Open();
            command = new MySqlCommand("SELECT COUNT(*) FROM clientes WHERE ativo = 0", connection);
            reader = command.ExecuteReader();
            reader.Read();
            lblTotalClientesInativos.Text = reader.GetInt32(0).ToString();
            connection.Close();

            connection.Open();
            command = new MySqlCommand("SELECT SUM(estoque) FROM produtos", connection);
            reader = command.ExecuteReader();
            reader.Read();
             lblTotalProdutos.Text= reader.GetInt32(0).ToString();
            connection.Close();


        }
    }
}