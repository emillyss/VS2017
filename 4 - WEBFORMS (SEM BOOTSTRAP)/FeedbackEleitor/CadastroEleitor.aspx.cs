using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FeedbackEleitor
{
    public partial class CadastroEleitor : System.Web.UI.Page
    {
        private MySqlConnection conexao;

        protected void Page_Load(object sender, EventArgs e)
        {
            conexao = new MySqlConnection(SiteMaster.conexao);
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            conexao.Open();
            var comando = new MySqlCommand("INSERT INTO eleitor (nome) VALUES (@nome)", conexao);
            comando.Parameters.Add(new MySqlParameter("nome", txtNome.Text));
            comando.ExecuteNonQuery();
            conexao.Close();

            SiteMaster.ExibirAlert(this, "Eleitor Cadastrado Com sucesso!");
            txtNome.Text = "";
        }

        protected void btnTelaPesquisa_Click(object sender, EventArgs e)
        {

        }
    }
}