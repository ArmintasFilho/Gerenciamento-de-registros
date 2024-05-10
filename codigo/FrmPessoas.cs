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

namespace Gerenciamento_de_registros
{
    public partial class FrmPessoas : Form
    {
        private Pessoas _pessoa = new Pessoas();
        private Operacao _operacao = new Operacao();
        public FrmPessoas(string id, Operacao operacao)
        {
            InitializeComponent();
            _pessoa.Id = id;
            _operacao = operacao;

            TipoOperacao(); //Método para verificar qual operação será feita.
        }

        private void TipoOperacao()
        {
            if (_operacao == Operacao.ADICIONAR)
            {
                this.Text = "Adicionar";
                btnSalvar.Visible = true;
            }
            else if (_operacao == Operacao.CONSULTAR)
            {
                this.Text = "Consulta";
                MostrarInformacoes();
                BloquearControles(true);
            }
            else if (_operacao == Operacao.ALTERAR)
            {
                this.Text = "Alteração";
                MostrarInformacoes();
                btnSalvar.Visible = true;
            }
            else if (_operacao == Operacao.EXCLUIR)
            {
                this.Text = "Exclusão";
                MostrarInformacoes();
                BloquearControles(true);
                btnExcluir.Visible = true;
            }
        }

        private void MostrarInformacoes()
        {
            var filter = Builders<Pessoas>.Filter.Eq(x => x.Id, _pessoa.Id);
            var collectionPessoa = Conexao.AbrirColecaoPessoas();
            _pessoa = collectionPessoa.Find(filter).FirstOrDefault();

            txtId.Text = _pessoa.Id;
            txtNome.Text = _pessoa.Nome;
            txtEmail.Text = _pessoa.Email;
            dateTimePicker1.Value = _pessoa.Data_Nasc;
            txtTelefone.Text = _pessoa.Telefone;
        }

        private void BloquearControles(bool travar)
        {
            travar = !travar;
            txtId.Enabled = travar;
            txtNome.Enabled = travar;
            txtEmail.Enabled = travar;
            dateTimePicker1.Enabled = travar;
            txtTelefone.Enabled = travar;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (Validacoes.EmailValido(txtEmail.Text) && Validacoes.NomeValido(txtNome.Text) && Validacoes.TelefoneValido(txtTelefone.Text))
            {
                _pessoa.Id = txtId.Text;
                _pessoa.Nome = txtNome.Text;
                _pessoa.Email = txtEmail.Text;
                _pessoa.Data_Nasc = dateTimePicker1.Value.Date;
                _pessoa.Telefone = txtTelefone.Text;

                var collectionPessoas = Conexao.AbrirColecaoPessoas();
                if (_pessoa.Id == "") //Caso seja um novo usuário
                    collectionPessoas.InsertOne(_pessoa);
                else //Alterar dados do usuário existente
                {
                    var filter = Builders<Pessoas>.Filter.Eq(x => x.Id, _pessoa.Id);
                    var atualizacao = Builders<Pessoas>.Update
                        .Set("Nome", txtNome.Text)
                        .Set("Email", txtEmail.Text)
                        .Set("Data_Nasc", dateTimePicker1.Value)
                        .Set("Telefone", txtTelefone.Text);
                    collectionPessoas.UpdateOne(filter, atualizacao);
                }
                Close();
            }
            else
            {
                if (Validacoes.EmailValido(txtEmail.Text))
                    lblEmail.Visible = false;
                else
                    lblEmail.Visible = true;

                if (Validacoes.NomeValido(txtNome.Text))
                    lblNome.Visible = false;
                else
                    lblNome.Visible = true;

                if (Validacoes.TelefoneValido(txtTelefone.Text))
                    lblTelefone.Visible = false;
                else
                    lblTelefone.Visible = true;
            }
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.Yes)
            {
                var collectionPessoas = Conexao.AbrirColecaoPessoas();
                var filtro = Builders<Pessoas>.Filter.Eq("_id", ObjectId.Parse(txtId.Text)); // Construção do filtro para encontrar o documento a ser excluido
                collectionPessoas.DeleteOne(filtro);
                Close();
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacoes.NaoPermitirNumeros(e);
        }
    }
}
