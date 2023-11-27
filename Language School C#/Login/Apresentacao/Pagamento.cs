using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; // Adicionando a diretiva necessária
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login.Modelo;
using Login.DAL;
using System.Drawing.Printing;

namespace Login.Apresentacao
{
    public partial class Pagamento : Form
    {
        private object holeriteTableAdapter;
        private object language_SchoolDataSet;
        private int currentPageIndex = 0;

        public Pagamento()
        {
            InitializeComponent();

        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            AtualizarDataGridView();
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
            int ano = Convert.ToInt32(txtAno.Text);
            string mes = cbxMes.Text;

            if (string.IsNullOrEmpty(idColaboradorText))
            {
                // Se o campo de ID do colaborador estiver vazio, traga todos os holerites
                AtualizarDataGridView();
            }
            else
            {
                int idColaborador = Convert.ToInt32(idColaboradorText);

                Holerite holerite = holeriteDAO.GerarHolerite(idColaborador, GetMesRef(mes), ano);

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter o ano e mês selecionados
                int ano = Convert.ToInt32(txtAno.Text);
                string mes = cbxMes.Text;

                // Obter todos os funcionários do banco de dados
                FuncionarioDAO funcionarioDAO = new FuncionarioDAO(new conexao());
                List<Funcionario> funcionarios = funcionarioDAO.ListarTodosFuncionarios();

                // Iniciar o DAO do Holerite
                HoleriteDAO holeriteDAO = new HoleriteDAO(new conexao());

                int proximoIdHolerite = holeriteDAO.ObterProximoIdHolerite(); // Implemente esse método
                foreach (var funcionario in funcionarios)
                {
                    // Gerar o holerite para o funcionário no ano e mês especificados
                    Holerite holerite = holeriteDAO.GerarHolerite(funcionario.ID, GetMesRef(mes), ano);

                    if (holerite != null)
                    {
                        Console.WriteLine($"Holerite gerado para funcionário {funcionario.ID}");
                        // Inserir o holerite na tabela de holerites
                        holeriteDAO.InserirHolerite(holerite, GetMesRef(mes), ano, funcionario.ID);
                    }
                    else
                    {
                        Console.WriteLine($"Holerite não gerado para funcionário {funcionario.ID}");
                    }
                }


                MessageBox.Show("Holerites gerados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Restante do código...

        private void AtualizarDataGridView()
        {
            conexao minhaConexao = new conexao();
            HoleriteDAO holeriteDAO = new HoleriteDAO(minhaConexao);

            List<Holerite> holerites = holeriteDAO.ListarTodosHolerites();

            if (holerites != null && holerites.Count > 0)
            {
                dtgHolerite.DataSource = holerites;

                // Remover a coluna "Cargo" (coluna 9, começando do índice 0)
                if (dtgHolerite.Columns.Count > 9)
                {
                    dtgHolerite.Columns.RemoveAt(9);
                }
            }
            else
            {
                MessageBox.Show("Nenhum holerite encontrado.");
            }
        }


        // Método auxiliar para obter o número do mês a partir do seu nome
        private int GetMesRef(string mes)
        {
            switch (mes.ToLower())
            {
                case "janeiro": return 1;
                case "fevereiro": return 2;
                case "março": return 3;
                case "abril": return 4;
                case "maio": return 5;
                case "junho": return 6;
                case "julho": return 7;
                case "agosto": return 8;
                case "setembro": return 9;
                case "outubro": return 10;
                case "novembro": return 11;
                case "dezembro": return 12;
                default: throw new ArgumentException("Mês inválido", nameof(mes));
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                currentPageIndex = 0;  // Reinicia o índice da página ao iniciar uma nova impressão
                printDocument.Print();
            }
        }


        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            bool hasMorePages = DataGridViewPrinter.PrintDataGridView(dtgHolerite, e, currentPageIndex);

            if (hasMorePages)
            {
                currentPageIndex++;
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                currentPageIndex = 0;  // Reinicia o índice da página ao concluir a impressão
            }
        }


    }

    public static class DataGridViewPrinter
    {


        public static bool PrintDataGridView(DataGridView dataGridView, PrintPageEventArgs e, int pageIndex)
        {
            float yPos = 0;
            int count = 0;

            // Ajuste a fonte conforme necessário
            Font font = new Font("Arial", 10);

            int rowsPerPage = (int)(e.MarginBounds.Height / font.GetHeight());

            for (int i = pageIndex * rowsPerPage; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];

                if (count == 0)
                {
                    // Desenha os cabeçalhos das colunas
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        e.Graphics.DrawString(column.HeaderText, font, Brushes.Black, new PointF(column.Displayed ? column.DisplayIndex * 100 : 0, yPos));
                    }
                    yPos += font.GetHeight();
                }

                // Desenha o conteúdo da célula
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)
                    {
                        e.Graphics.DrawString(cell.FormattedValue.ToString(), font, Brushes.Black, new PointF(cell.ColumnIndex * 100, yPos));
                    }
                }

                yPos += font.GetHeight();
                count++;

                if (yPos + font.GetHeight() > e.MarginBounds.Height)
                {
                    return true;  // Há mais páginas a serem impressas
                }
            }

            return false;  // Não há mais páginas a serem impressas
        }
    }

}
