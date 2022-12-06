using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestBackEndBD
{
    public partial class CadastrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cliente = new Classes.Cliente();
            cliente.Nome = txtNome.Text;
            new Negocio.Cliente().Create(cliente);

            SiteMaster.ExibirAlert(this, "Cliente cadastrado com sucesso!","PesquisaClientes.aspx");
            txtNome.Text = "";
        }
    }
}