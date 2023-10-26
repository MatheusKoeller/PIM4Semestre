using Login.DAL;
using Login.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public class FuncionarioDAO
{
    private conexao conexao;

    public FuncionarioDAO(conexao conexao)
    {
        this.conexao = conexao;
    }



    public Funcionario PesquisarFuncionarioPorId(int id)
    {
        try
        {
            conexao minhaConexao = new conexao();

            using (SqlConnection con = minhaConexao.conectar())
            {
                string query = "SELECT * FROM funcionarios WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            Funcionario funcionario = new Funcionario
                            {


                                ID = Convert.ToInt32(reader["ID"]),
                                nome = reader["nome"].ToString(),
                                cpf = RemoverMascaraCPF(reader["cpf"].ToString()), // Remove a máscara
                                rg = reader["rg"].ToString(),
                                tel = reader["tel"].ToString(),
                                gen = reader["gen"].ToString(),
                                dtAd = reader["dt_ad"].ToString(),
                                nacio = reader["nacio"].ToString(),
                                end = reader["end"].ToString(),
                                usuario = reader["usuario"].ToString(),
                                senha = reader["senha"].ToString(),
                                email = reader["email"].ToString(),
                                cargo = Convert.ToInt32(reader["cargo"]),
                                nasc = reader["nasc"].ToString(),
                                status = reader["status"].ToString()
                            };

                            return funcionario;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Trate exceções apropriadamente ou registre-as.
        }

        return null; // Retorna null se não encontrar nenhum funcionário com o ID especificado.
    }

    // Função para remover a máscara de CPF (caso haja)
    private string RemoverMascaraCPF(string cpf)
    {
        return cpf.Replace(".", "").Replace("-", "");
    }

    public List<Funcionario> ListarTodosFuncionarios(int? idFiltragem = null)
    {
        List<Funcionario> funcionarios = new List<Funcionario>();

        try
        {
            conexao minhaConexao = new conexao();

            using (SqlConnection con = minhaConexao.conectar())
            {
                string query = "SELECT * FROM funcionarios";
                if (idFiltragem.HasValue)
                {
                    query += " WHERE ID = @ID";
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (idFiltragem.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ID", idFiltragem.Value);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionario funcionario = new Funcionario
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                nome = reader["nome"].ToString(),
                                cpf = RemoverMascaraCPF(reader["cpf"].ToString()), // Remove a máscara
                                rg = reader["rg"].ToString(),
                                tel = reader["tel"].ToString(),
                                gen = reader["gen"].ToString(),
                                dtAd = reader["dt_ad"].ToString(),
                                nacio = reader["nacio"].ToString(),
                                end = reader["end"].ToString(),
                                usuario = reader["usuario"].ToString(),
                                senha = reader["senha"].ToString(),
                                email = reader["email"].ToString(),
                                cargo = Convert.ToInt32(reader["cargo"]),
                                nasc = reader["nasc"].ToString(),
                                status = reader["status"].ToString()
                            };
                            funcionarios.Add(funcionario);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Trate exceções apropriadamente ou registre-as.
        }

        return funcionarios;
    }

    public bool AlterarFuncionario(Funcionario funcionario)
    {
        try
        {
   
            conexao minhaConexao = new conexao();

            using (SqlConnection con = minhaConexao.conectar())
            {
                string query = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, rg = @rg, tel = @tel, " +
                    "gen = @gen, dt_ad = @dt_ad, nacio = @nacio, [end] = @end, " +
                    "usuario = @usuario, senha = @senha, email = @email, cargo = @cargo, " +
                    "nasc = @nasc, status = @status " +
                    "WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
                    cmd.Parameters.AddWithValue("@rg", funcionario.rg);
                    cmd.Parameters.AddWithValue("@tel", funcionario.tel);
                    cmd.Parameters.AddWithValue("@gen", funcionario.gen);
                    cmd.Parameters.AddWithValue("@dt_ad", funcionario.dtAd);
                    cmd.Parameters.AddWithValue("@nacio", funcionario.nacio);
                    cmd.Parameters.AddWithValue("@end", funcionario.end);
                    cmd.Parameters.AddWithValue("@usuario", funcionario.usuario);
                    cmd.Parameters.AddWithValue("@senha", funcionario.senha);
                    cmd.Parameters.AddWithValue("@email", funcionario.email);
                    cmd.Parameters.AddWithValue("@cargo", funcionario.cargo);
                    cmd.Parameters.AddWithValue("@nasc", funcionario.nasc);
                    cmd.Parameters.AddWithValue("@status", funcionario.status);
                    cmd.Parameters.AddWithValue("@ID", funcionario.ID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }


}
