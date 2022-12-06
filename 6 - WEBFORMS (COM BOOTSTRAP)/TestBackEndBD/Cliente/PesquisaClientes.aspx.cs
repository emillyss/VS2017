using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestBackEndBD.Classes;

namespace TestBackEndBD
{
    public partial class PesquisaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var clientes = new Negocio.Cliente().Read("", txtNome.Text, rdoAtivo.SelectedValue);
            Session["dados"] = clientes;
            grdClientes.DataSource = clientes;
            grdClientes.DataBind();
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastrarCliente.aspx");
        }

        protected void grdClientes_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var clientes = (List<Cliente>)Session["dados"];

            if (e.CommandName == "excluir")
            {
                if (new Negocio.Cliente().Delete(clientes[index].Id))
                    SiteMaster.ExibirAlert(this, "Cliente excluído com sucesso!");
                else
                    SiteMaster.ExibirAlert(this, "O cliente não pode ser excluído porque ele está sendo usado! ");
                btnPesquisar_Click(null, null);
            }

            if (e.CommandName == "editar")
            {
                Response.Redirect("EditarCliente.aspx?id=" + clientes[index].Id);
            }
        }

        protected void grdClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var clientes = (List<Cliente>)Session["dados"];
            grdClientes.PageIndex = e.NewPageIndex;
            grdClientes.DataSource = clientes;
            grdClientes.DataBind();
        }
    }
}