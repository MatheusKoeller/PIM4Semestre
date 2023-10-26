using System;
using Login.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Login.Modelo;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing;

namespace Login.Apresentacao
{
    public partial class Cadastro : Form
    {
        private object con;
        private string strCon;
        private string strSql;
        private SqlConnection sqlCon;
        private SqlConnection SqlCon;
        private string ConnectionString;
        conexao gg = new conexao();

        public Cadastro()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BemVindo bv = new BemVindo();
            bv.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            BemVindo bv = new BemVindo();
            bv.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btbPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColaborador.Text))
            {
                // O campo está vazio, então liste todos os funcionários.
                conexao minhaConexao = new conexao();
                FuncionarioDAO funcionarioDAO = new FuncionarioDAO(minhaConexao);

                List<Funcionario> funcionarios = funcionarioDAO.ListarTodosFuncionarios();

                if (funcionarios.Count > 0)
                {
                    // Exiba todos os funcionários no DataGridView.
                    dataGridView1.DataSource = funcionarios;

                    // Limpe os campos, já que nenhum funcionário específico foi selecionado.
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Nenhum funcionário encontrado.");
                }
            }
            else
            {
                int idFuncionario;

                if (int.TryParse(txtColaborador.Text, out idFuncionario))
                {
                    // O valor foi convertido com sucesso para um inteiro.
                    // Agora você pode usar idFuncionario para pesquisar por ID, por exemplo.
                    conexao minhaConexao = new conexao();
                    FuncionarioDAO funcionarioDAO = new FuncionarioDAO(minhaConexao);

                    List<Funcionario> funcionariosFiltrados = funcionarioDAO.ListarTodosFuncionarios(idFuncionario);

                    if (funcionariosFiltrados.Count > 0)
                    {
                        // Exiba os funcionários filtrados no DataGridView.
                        dataGridView1.DataSource = funcionariosFiltrados;

                        // Preencha os campos com os dados do primeiro funcionário encontrado.
                        PreencherCamposComFuncionario(funcionariosFiltrados[0]);
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado.");
                    }
                }
                else
                {
                    // A entrada não é um número inteiro válido.
                    MessageBox.Show("Por favor, insira um ID de funcionário válido.");
                }
            }
        }

        private void LimparCampos()
        {
            // Limpe os campos da interface do usuário.
            txtNome.Text = string.Empty;
            mskCpf.Text = string.Empty;
            mskRG.Text = string.Empty;
            mskTelefone.Text = string.Empty;
            cbbSexo.Text = "sexo";
            txtNacionalidade.Text = string.Empty;
            maskAdimissao.Text= string.Empty;
            txtEndereco.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ccbIdcargo.Text = string.Empty;
            mskNascimento.Text = string.Empty;
            ccbStatus.Text = "Ativo";
        }


        // Método para preencher os campos da interface do usuário com os dados do funcionário.
        private void PreencherCamposComFuncionario(Funcionario funcionario)
        {
            txtNome.Text = funcionario.nome;
            mskCpf.Text = funcionario.cpf;
            mskRG.Text = funcionario.rg;
            mskTelefone.Text = funcionario.tel;
            cbbSexo.Text = funcionario.gen;
            maskAdimissao.Text = funcionario.dtAd;
            txtNacionalidade.Text = funcionario.nacio;
            txtEndereco.Text = funcionario.end;
            txtUsuario.Text = funcionario.usuario;
            txtSenha.Text = funcionario.senha;
            txtEmail.Text = funcionario.email;
            ccbIdcargo.Text = funcionario.cargo.ToString();
            mskNascimento.Text = funcionario.nasc;
            ccbStatus.Text = funcionario.status;
        }





        private void testeBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            txtNome.Text = string.Empty;
            mskCpf.Text = string.Empty;
            mskRG.Text = string.Empty;
            mskTelefone.Text = string.Empty;
            cbbSexo.Text = "sexo";
            txtNacionalidade.Text = string.Empty;
            maskAdimissao.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ccbIdcargo.Text = string.Empty;
            mskNascimento.Text = string.Empty;
            ccbStatus.Text = "Ativo";


        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string nome = txtNome.Text;
            string cpf = mskCpf.Text;
            string rg = mskRG.Text;
            string tel = mskTelefone.Text;
            string gen = cbbSexo.Text;
            string dt_ad = maskAdimissao.Text;
            string nacio = txtNacionalidade.Text;
            string end = txtEndereco.Text;
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;
            string email = txtEmail.Text;
            string nasc = mskNascimento.Text;
            string status = ccbStatus.Text;

            // Verificar o índice selecionado em ccbIdcargo
            int ccbIdcargoIndex = ccbIdcargo.SelectedIndex;
            ccbIdcargoIndex += 1;

            if (ccbIdcargoIndex >= 1 && ccbIdcargoIndex <= 7)
            {
                int ccbIdcargo = ccbIdcargoIndex; // Agora ccbIdcargo é um int

                string msg = controle.Cadastro(nome, cpf, rg, tel, gen, dt_ad, nacio, end, usuario, senha, email, ccbIdcargo, nasc, status);

                if (controle.dados) // mensagem de sucesso
                {
                    MessageBox.Show(msg, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(controle.msg); // mensagem de erro
                }
            }
            else
            {
                MessageBox.Show("Selecione um cargo válido (1 a 7).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtColaborador_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ListarFuncionariosNoDataGridView()
        {
            conexao minhaConexao = new conexao();
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO(minhaConexao);

            List<Funcionario> funcionarios = funcionarioDAO.ListarTodosFuncionarios();

            // Associe a lista de funcionários ao DataGridView.
            dataGridView1.DataSource = funcionarios;

            // Renomeie as colunas do DataGridView para os nomes completos dos campos.
            dataGridView1.Columns["nome"].HeaderText = "Nome";
            dataGridView1.Columns["cpf"].HeaderText = "CPF";
            dataGridView1.Columns["rg"].HeaderText = "RG";
            dataGridView1.Columns["tel"].HeaderText = "Telefone";
            dataGridView1.Columns["gen"].HeaderText = "Gênero";
            dataGridView1.Columns["dtad"].HeaderText = "Admissão";
            dataGridView1.Columns["nacio"].HeaderText = "Nacionalidade";
            dataGridView1.Columns["end"].HeaderText = "Endereço";
            dataGridView1.Columns["usuario"].HeaderText = "Usuário";
            dataGridView1.Columns["senha"].HeaderText = "Senha";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["cargo"].HeaderText = "Cargo";
            dataGridView1.Columns["nasc"].HeaderText = "Nascimento";
            dataGridView1.Columns["status"].HeaderText = "Status";
        }

        private void Cadastro_Load_1(object sender, EventArgs e)
        {
            ListarFuncionariosNoDataGridView();
        }

        private void btbAlterar_Click(object sender, EventArgs e)
        {
            int idFuncionario;

            if (int.TryParse(txtColaborador.Text, out idFuncionario))
            {
                conexao minhaConexao = new conexao();
                FuncionarioDAO funcionarioDAO = new FuncionarioDAO(minhaConexao);

                Funcionario funcionarioEncontrado = funcionarioDAO.PesquisarFuncionarioPorId(idFuncionario);

                if (funcionarioEncontrado != null)
                {
                    // Preencha o objeto Funcionario com os dados da interface do usuário, exceto o ID.
                    funcionarioEncontrado.nome = txtNome.Text;
                    funcionarioEncontrado.cpf = mskCpf.Text;
                    funcionarioEncontrado.rg = mskRG.Text;
                    funcionarioEncontrado.tel = mskTelefone.Text;
                    funcionarioEncontrado.gen = cbbSexo.Text;
                    funcionarioEncontrado.dtAd = maskAdimissao.Text;
                    funcionarioEncontrado.nacio = txtNacionalidade.Text;
                    funcionarioEncontrado.end = txtEndereco.Text;
                    funcionarioEncontrado.usuario = txtUsuario.Text;
                    funcionarioEncontrado.senha = txtSenha.Text;
                    funcionarioEncontrado.email = txtEmail.Text;
                    int ccbIdcargoIndex = ccbIdcargo.SelectedIndex;
                    ccbIdcargoIndex += 1;
                    funcionarioEncontrado.nasc = mskNascimento.Text;
                    funcionarioEncontrado.status = ccbStatus.Text;

                    if (ccbIdcargoIndex >= 1 && ccbIdcargoIndex <= 7)
                    {
                        funcionarioEncontrado.cargo = ccbIdcargoIndex; // Define o valor do cargo no objeto Funcionario.
                        bool sucesso = funcionarioDAO.AlterarFuncionario(funcionarioEncontrado);
                        if (sucesso)
                        {
                            MessageBox.Show("Funcionário alterado com sucesso.");
                            // Atualize a exibição no DataGridView se necessário.
                            ListarFuncionariosNoDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao alterar o funcionário.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selecione um cargo válido (1 a 7).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Funcionário não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um ID de funcionário válido.");
            }
        }


        private void ccbIdcargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
