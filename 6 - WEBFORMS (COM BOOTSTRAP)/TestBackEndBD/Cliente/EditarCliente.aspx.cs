using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestBackEndBD
{
    public partial class EditarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                var cliente = new Negocio.Cliente().Read(id);
                if (cliente == null)
                {
                    SiteMaster.ExibirAlert(this, "Cliente não identificado, realize a pesquisa novamente", "PesquisaClientes.aspx");
                    return;
                }
                txtNome.Text = cliente.Nome;
                rdoAtivo.SelectedValue = cliente.NumeroAtivo;
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var cliente = new Classes.Cliente();
            cliente.Id = Convert.ToInt32(Request.QueryString["id"].ToString());
            cliente.Nome = txtNome.Text;
            cliente.Ativo = (rdoAtivo.SelectedValue == "1");
            new Negocio.Cliente().Update(cliente);
            SiteMaster.ExibirAlert(this, "Cliente alterado com sucesso!", "PesquisaClientes.aspx");
        }
    }
}