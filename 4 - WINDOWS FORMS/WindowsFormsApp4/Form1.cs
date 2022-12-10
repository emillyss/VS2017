using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class frmPrincipal : Form
    {
        public static List<Teste> testes = new List<Teste>();
        public static int idEscolhido = -1;

        public frmPrincipal()
        {
            InitializeComponent();
            SetupDataGridView();
            Limpar();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 6;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;


            dataGridView1.Columns[0].Name = "Alterar";
            dataGridView1.Columns[1].Name = "Excluir";
            dataGridView1.Columns[2].Name = "Id";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Name = "DataHora";
            dataGridView1.Columns[4].Name = "Texto";
            dataGridView1.Columns[5].Name = "Numero";
            
        }


        private void lblPesquisa_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var novo = new Teste();
            novo.Numero = ddlInteiro.Value;
            novo.Texto = txtString.Text;
            novo.DataHora = dtpData.Value;
            novo.Id = (testes.Count() == 0) ? 1 : testes.Max(x => x.Id);
            testes.Add(novo);
            Limpar();
        }

        private void Limpar()
        {
            ddlInteiro.Value = 0;
            dtpDe.Value = DateTime.Now.AddYears(-1);
            dtpAte.Value = DateTime.Now;
            dtpData.Value = DateTime.Now.AddDays(-1);
            txtString.Text = "";
            idEscolhido = -1;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = true;
            txtPesquisa.Text = "";            
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            var testesFiltrado = testes.Where(x => x.DataHora >= dtpDe.Value && x.DataHora <= dtpAte.Value);
            if (!txtPesquisa.Text.Equals(""))
            testesFiltrado = testesFiltrado.Where(x => x.Texto.Contains(txtPesquisa.Text));

            dataGridView1.Rows.Clear();
            foreach(var i in testesFiltrado)
            {
                dataGridView1.Rows.Add(new object[] { "Clique para Alterar", "Clique para Excluir", i.Id.ToString(), i.DataHora.ToString(), i.Texto, i.Numero.ToString()});
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnExcluir_Click(null, null);
            btnNovo_Click(null, null);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            testes.RemoveAll(x => x.Id == idEscolhido);
            Limpar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           int index = dataGridView1.CurrentRow.Index;
            var row = dataGridView1.Rows[index];
            idEscolhido = Convert.ToInt32(row.Cells[2].Value.ToString());
            dtpData.Value = Convert.ToDateTime(row.Cells[3].Value.ToString());
            txtString.Text = row.Cells[4].Value.ToString();
            ddlInteiro.Value = Convert.ToDecimal(row.Cells[5].Value.ToString());
            btnEditar.Enabled = (e.ColumnIndex == 0);
            btnExcluir.Enabled = (e.ColumnIndex == 1);
            btnNovo.Enabled = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
