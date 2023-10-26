using Login.Apresentacao;
using Login.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
           Controle controle = new Controle();
            controle.acessar(txbLogin.Text, txbSenha.Text);
           

            if(controle.msg.Equals("")) 
            {
                if (controle.dados)
                {
                    MessageBox.Show("Logado com sucesso!", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BemVindo bv = new BemVindo();
                    bv.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login não encontrado, verificar login e senha", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(controle.msg);
            }

        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbLogin_TextChanged(object sender, EventArgs e)
        {

        }

        public class Language_SchoolDataSet_funcionarios
        {
            internal object funcionarios;

            public string DataSetName { get; internal set; }
            public SchemaSerializationMode SchemaSerializationMode { get; internal set; }
        }

        internal class Language_SchoolDataSet_funcionariosTableAdapters
        {
            internal class funcionariosTableAdapter
            {
                public bool ClearBeforeFill { get; internal set; }

                internal void Fill(object funcionarios)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
