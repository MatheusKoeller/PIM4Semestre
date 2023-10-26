using Login.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Modelo
{
    public class Controle
    {
        public bool dados;
        public String msg = "";
        public bool acessar(String usuario, String senha)
        {
            LoginDao LoginD = new LoginDao();//Informações inseridas no forms
            dados = LoginD.verificarLogin(usuario, senha);//Envia parametro e retorna o metodo de LoginDao
            if (!LoginD.msg.Equals(""))//Verifica se a mensagem
            {
                this.msg = LoginD.msg;
            }
            return dados;
        }
        public string Cadastro(string nome, string cpf, string rg, string tel, string gen, string dt_ad, string nacio, string end, string usuario, string senha, string email, int cargo, string nasc, string status)
        {
            LoginDao LoginD = new LoginDao();
            this.msg = LoginD.Cadastro(nome, cpf, rg, tel, gen, dt_ad, nacio, end, usuario, senha, email, cargo, nasc, status);

            if (LoginD.dados) // a mensagem que vai vir é de sucesso
            {
                this.dados = true;
            }

            return msg;
        }
    }
}
