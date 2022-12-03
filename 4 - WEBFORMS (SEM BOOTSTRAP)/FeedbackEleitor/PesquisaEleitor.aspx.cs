using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace FeedbackEleitor
{
    public partial class PesquisaEleitor : System.Web.UI.Page
    {
        private MySqlConnection _conexao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _conexao = new MySqlConnection(SiteMaster.conexao);
        }

        protected void gridEleitores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var tabela = (DataTable)Session["tabela"];
            var index = (gridEleitores.PageSize * gridEleitores.PageCount) + (int)e.CommandArgument;
            var id = (index >= 0)? tabela.Rows[index]["id"].ToString() : "";

            if (e.CommandName == "editar")
            {
                Response.Redirect("EditarEleitor.aspx?id=" + id);
            }

            if (e.CommandName == "excluir")
            {
                new MySqlCommand("DELETE FROM eleitor WHERE id = " + id, _conexao).ExecuteNonQuery();
                lnkPesquisar_Click(null, null);
            }
        }

        protected void lnkPesquisar_Click(object sender, EventArgs e)
        {
            _conexao.Open();
            var command = new MySqlCommand("SELECT * FROM eleitor WHERE (1=1) ", _conexao);

            if (txtNome.Text != "")
            {
                command.CommandText = command.CommandText + " AND nome like @nome";
                command.Parameters.Add(new MySqlParameter("nome", "%" + txtNome.Text + "%"));
            }

            var tabela = new DataTable();
            tabela.Columns.Add("nome");
            tabela.Columns.Add("id");

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var linha = tabela.NewRow();
                linha["nome"] = reader.GetString("nome");
                linha["id"] = reader.GetInt32("id").ToString();
                tabela.Rows.Add(linha);
            }

            Session["tabela"] = tabela;
            gridEleitores.DataSource = tabela;
            gridEleitores.DataBind();
        }

        protected void lnkCadastrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroEleitor.aspx");
        }
    }
}