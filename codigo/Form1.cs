using Gerenciamento_de_registros;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace codigo
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var collectionPessoas = Conexao.AbrirColecaoPessoas();
            var listaPessoas = collectionPessoas.Find(p => true).ToList();

            dataGridView1.DataSource = listaPessoas;

            dataGridView1.Columns["Id"].Width = 90;
            dataGridView1.Columns["Nome"].Width = 140;
            dataGridView1.Columns["Email"].Width = 140;
            dataGridView1.Columns["Data_Nasc"].Width = 80;
            dataGridView1.Columns["Telefone"].Width = 90;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                var frm = new FrmPessoas(id, Operacao.CONSULTAR);
                frm.ShowDialog();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                var frm = new FrmPessoas(id, Operacao.ALTERAR);
                frm.ShowDialog();
                AtualizarDataGridView1();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new FrmPessoas("", Operacao.ADICIONAR);
            frm.ShowDialog();
            AtualizarDataGridView1();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                var frm = new FrmPessoas(id, Operacao.EXCLUIR);
                frm.ShowDialog();
                AtualizarDataGridView1();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacoes.NaoPermitirNumeros(e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var collectionPessoa = Conexao.AbrirColecaoPessoas();
            var filter = Builders<Pessoas>.Filter.Regex("Nome", new
                BsonRegularExpression(".*" + txtPesquisa.Text + ".*", "i"));

            var list = collectionPessoa.Find(filter).ToList();
            dataGridView1.DataSource = list;
        }
        private void AtualizarDataGridView1()
        {
            var collectionPessoas = Conexao.AbrirColecaoPessoas();
            var listaPessoas = collectionPessoas.Find(p => true).ToList();
            dataGridView1.DataSource = listaPessoas;
        }
    }
}
