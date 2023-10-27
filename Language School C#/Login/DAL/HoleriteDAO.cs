using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Login.DAL;
using Login.Modelo; // Certifique-se de importar as classes corretas

public class HoleriteDAO
{
    private conexao conexao;

    public HoleriteDAO(conexao conexao)
    {
        this.conexao = conexao;
    }

    public List<Holerite> ListarTodosHolerites()
    {
        using (SqlConnection connection = conexao.conectar())
        {
            string query = "SELECT F.ID, F.nome, C.nome_cargo AS NomeCargo, C.salario " +
                            "FROM funcionarios AS F " +
                            "INNER JOIN cargos AS C ON F.cargo = C.ID";
            string nomesCargos = "";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Holerite> holerites = new List<Holerite>();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Cargo cargo = new Cargo
                        {
                      
                            Salario = reader.GetDecimal(3)
                        };


                        Holerite holerite = new Holerite
                        {
                            FuncionarioID = reader.GetInt32(0),
                            NomeFuncionario = reader.GetString(1),
                            NomeCargo = reader.GetString(2), // Nome do cargo
                            ValorHolerite = CalcularHolerite(cargo)
                        };

                        holerites.Add(holerite);
                    }
                }

                return holerites;
            }
        }
    }




    public Holerite GerarHolerite(int funcionarioID)
    {
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO(conexao);
        CargoDAO cargoDAO = new CargoDAO(conexao);

        Funcionario funcionario = funcionarioDAO.PesquisarFuncionarioPorId(funcionarioID);

        if (funcionario != null)
        {
            Cargo cargo = cargoDAO.ObterCargoPorFuncionarioID(funcionarioID);

            if (cargo != null)
            {
                decimal valorHolerite = CalcularHolerite(cargo);

                Holerite holerite = new Holerite(funcionario.ID, funcionario.nome, cargo.NomeCargo, valorHolerite);

                return holerite;
            }
        }

        return null;
    }

    private decimal CalcularHolerite(Cargo cargo)
    {
        // Implemente o cálculo do holerite com base nas informações do cargo.
        // Adicione suas regras de cálculo aqui, como descontos, adicionais, etc.
        // Exemplo de cálculo simples (salário bruto do cargo):
        return cargo.Salario;
    }
    private string RetornaNomeCargo(Cargo cargo)
    {
        // Implemente o cálculo do holerite com base nas informações do cargo.
        // Adicione suas regras de cálculo aqui, como descontos, adicionais, etc.
        // Exemplo de cálculo simples (salário bruto do cargo):
        return cargo.NomeCargo;
    }


}
