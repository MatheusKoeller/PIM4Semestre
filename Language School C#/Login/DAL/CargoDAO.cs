using Login.DAL;
using System;
using System.Data.SqlClient;
using Login.Modelo;

public class CargoDAO
{
    private conexao conexao;

    public CargoDAO(conexao conexao)
    {
        this.conexao = conexao;
    }

    public Cargo ObterCargoPorFuncionarioID(int funcionarioID)
    {
        try
        {
            using (SqlConnection con = conexao.conectar())
            {
                string query = "SELECT C.ID, C.nome_cargo, C.salario, C.carga_horaria " +
                               "FROM funcionarios AS F " +
                               "INNER JOIN cargos AS C ON F.cargo = C.ID " +
                               "WHERE F.ID = @FuncionarioID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FuncionarioID", funcionarioID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cargo cargo = new Cargo
                            {
                                ID = reader.GetInt32(0),
                                NomeCargo = reader.GetString(1),
                                Salario = reader.GetDecimal(2),
                                CargaHoraria = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3)
                            };
                            return cargo;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Trate exceções apropriadamente ou registre-as.
        }

        return null; // Retorna null se não encontrar nenhum cargo associado ao funcionário.
    }
}
