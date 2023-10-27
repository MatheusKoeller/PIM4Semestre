using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Modelo;
using Login.DAL; // Importe a classe HoleriteDAO


namespace Login.Apresentacao
{
    public partial class Pagamento : Form
    {
        private object holeriteTableAdapter;
        private object language_SchoolDataSet;

        public Pagamento()
        {
            InitializeComponent();
        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            conexao minhaConexao = new conexao();
            HoleriteDAO holeriteDAO = new HoleriteDAO(minhaConexao);

            List<Holerite> holerites = holeriteDAO.ListarTodosHolerites();

            if (holerites != null && holerites.Count > 0)
            {
                dtgHolerite.DataSource = holerites;
            }
            else
            {
                MessageBox.Show("Nenhum holerite encontrado.");
            }
        }
        private void btn_sair_Click(object sender, EventArgs e)
        {
            Close();
            BemVindo bv = new BemVindo();
            bv.Show();
            this.Hide();
        }

        private void btnPesquisarIdColaborador_Click(object sender, EventArgs e)
        {
            string idColaboradorText = txtIdColaborador.Text;
            conexao minhaConexao = new conexao();
            HoleriteDAO holeriteDAO = new HoleriteDAO(minhaConexao);

            if (string.IsNullOrEmpty(idColaboradorText))
            {
                // Se o campo de ID do colaborador estiver vazio, traga todos os holerites
                List<Holerite> holerites = holeriteDAO.ListarTodosHolerites();
                dtgHolerite.DataSource = holerites;
            }
            else
            {
                int idColaborador = Convert.ToInt32(idColaboradorText);

                Holerite holerite = holeriteDAO.GerarHolerite(idColaborador);

                if (holerite != null)
                {
                    List<Holerite> holerites = new List<Holerite>();
                    holerites.Add(holerite);

                    dtgHolerite.DataSource = holerites;
                }
                else
                {
                    dtgHolerite.DataSource = null;
                    MessageBox.Show("Holerite não encontrado para o ID do colaborador informado.");
                }
            }
        }


        private void dtgHolerite_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
