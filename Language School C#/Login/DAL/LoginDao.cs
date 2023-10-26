using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Login.DAL
{
    class LoginDao
    {
        public bool dados = false;
        public String msg = ""; // tudo OK
        SqlCommand cmd = new SqlCommand();
        conexao con = new conexao();
        SqlDataReader dr;
        
        public bool verificarLogin(String usuario,String senha) //Verificação no BD de Login e senha
        {

            //if (usuario == "ADM" && senha == "123")
            //{
            //    dados = true;
            //}
            //else
            //{
            //    this.msg = "Login invalido";
            //}

            //Colocar comandos SQL de verificação
            cmd.CommandText = "select * from logins_Adm where usuario = @usuario and senha = @senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);


             try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dados = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException ex)
            {
                this.msg = "Erro no banco de Dados! " + ex;
            }


            return dados;
        }

        public string Cadastro(string nome, string cpf, string rg, string tel, string gen, string dt_ad, string nacio, string end, string usuario, string senha, string email, int cargo, string nasc, string status)
        {
             dados = false;

            // Comandos SQL para cadastrar
            cmd.CommandText = "INSERT INTO funcionarios (nome, cpf, rg, tel, gen, dt_ad, nacio, [end], usuario, senha, email, cargo, nasc, status) VALUES (@nome, @cpf, @rg, @tel, @gen, @dt_ad, @nacio, @end, @usuario, @senha, @email, @cargo, @nasc, @status)";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@rg", rg);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@gen", gen);
            cmd.Parameters.AddWithValue("@dt_ad", dt_ad);
            cmd.Parameters.AddWithValue("@nacio", nacio);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@nasc", nasc);
            cmd.Parameters.AddWithValue("@status", status);

            try
            {
                cmd.Connection = con.conectar();
                cmd.ExecuteNonQuery();
                con.desconectar();
                this.msg = "Cadastrado com sucesso!";
                dados = true;
            }
            catch (SqlException ex)
            {
                this.msg = "Erro com o banco de dados " + ex;
            }

            return msg;
        }

        
    }
}
