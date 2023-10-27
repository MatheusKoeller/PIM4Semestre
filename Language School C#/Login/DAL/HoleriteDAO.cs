using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Login.DAL;
using Login.Modelo; // Certifique-se de importar as classes corretas
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                List<Holerite> holerites = new List<Holerite>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cargo cargo = new Cargo
                        {
                            Salario = reader.GetDecimal(3),
                            NomeCargo = reader.GetString(2)
                        };

                        decimal valorHolerite = CalcularHolerite(cargo);

                        Holerite holerite = new Holerite
                        {
                            FuncionarioID = reader.GetInt32(0),
                            NomeFuncionario = reader.GetString(1),
                            NomeCargo = cargo.NomeCargo,
                            ValorHolerite = valorHolerite
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
        decimal salario = cargo.Salario;
        decimal salario2 = cargo.Salario;
        decimal salario3 = cargo.Salario;
        string nomeCargo = cargo.NomeCargo;
        decimal valorHolerite = salario;
       
           if (salario <= 1320.00m)
        {
            valorHolerite -= Math.Round(salario * 0.075m, 2); // Desconto de 7.5%
        }
        else if (salario <= 2571.29m)
        {
            valorHolerite -= Math.Round(salario * 0.09m, 2); // Desconto de 9.0%
        }
        else if (salario <= 3856.94m)
        {
            valorHolerite -= Math.Round(salario * 0.12m, 2); // Desconto de 12.0%
        }
        else if (salario <= 7507.49m)
        {
            valorHolerite -= Math.Round(salario * 0.14m, 2); // Desconto de 14.0%
        }

        // Adicionar descontos para VR (10%) e VA (6%)
        decimal descontoVR = Math.Round(salario2 * 0.10m, 2); // Desconto de 10% do VR
        decimal descontoVA = Math.Round(salario3 * 0.06m, 2); // Desconto de 6% do VA
        

        valorHolerite -= descontoVR;
        valorHolerite -= descontoVA;

        return Math.Round(valorHolerite, 2);
        
    }
    private string RetornaNomeCargo(Cargo cargo)
    {
        // Implemente o cálculo do holerite com base nas informações do cargo.
        // Adicione suas regras de cálculo aqui, como descontos, adicionais, etc.
        // Exemplo de cálculo simples (salário bruto do cargo):
        return cargo.NomeCargo;
    }


}
