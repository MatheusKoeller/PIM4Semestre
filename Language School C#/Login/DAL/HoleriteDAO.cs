using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

    public Holerite GerarHolerite(int funcionarioID, int mesRef, int anoRef)
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
                decimal beneficios = CalcularBeneficios(cargo);
                decimal inss = CalcularInss(cargo.Salario);
                decimal descontos = beneficios + inss;

                // O ID do holerite será obtido automaticamente
                int proximoIdHolerite = ObterProximoIdHolerite();

                Holerite holerite = new Holerite(
                    funcionarioID: funcionario.ID,
                    nomeFuncionario: funcionario.nome,
                    nomeCargo: cargo.NomeCargo,
                    valorHolerite: valorHolerite,
                    beneficios: beneficios,
                    descontos: descontos,
                    salarioBruto: cargo.Salario,
                    inss: inss,
                    idCargo: cargo.ID,
                    mesRef: mesRef,
                    anoRef: anoRef
                );

                // Atribuir o objeto Cargo ao Holerite
                holerite.Cargo = cargo;

                return holerite;
            }
        }

        return null;
    }


    private decimal CalcularHolerite(Cargo cargo)
    {
        decimal salario = cargo.Salario;
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
        decimal descontoVR = Math.Round(salario * 0.10m, 2); // Desconto de 10% do VR
        decimal descontoVA = Math.Round(salario * 0.06m, 2); // Desconto de 6% do VA

        return Math.Round(valorHolerite, 2);
    }

    private decimal CalcularBeneficios(Cargo cargo)
    {
        decimal salario = cargo.Salario;

        // Adicionar descontos para VR (10%) e VA (6%)
        decimal descontoVR = Math.Round(salario * 0.10m, 2); // Desconto de 10% do VR
        decimal descontoVA = Math.Round(salario * 0.06m, 2); // Desconto de 6% do VA

        return descontoVR + descontoVA;
    }

    public void InserirHolerite(Holerite holerite, int mesRef, int anoRef, int idFuncionario)
    {
        try
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO(conexao);
            CargoDAO cargoDAO = new CargoDAO(conexao);

            // Obtém o cargo do funcionário
            Cargo cargo = cargoDAO.ObterCargoPorFuncionarioID(idFuncionario);

            // Verifica se o cargo foi encontrado
            if (cargo != null)
            {
                // Calcular descontos do INSS
                decimal inss = CalcularInss(cargo.Salario);

                // Calcular descontos dos benefícios
                decimal descontosBeneficios = CalcularBeneficios(cargo);

                // Calcular o total de descontos
                decimal descontosTotais = inss + descontosBeneficios;

                // Calcular o total líquido
                decimal totalLiquido = cargo.Salario - descontosTotais;

                string insertQuery = $@"
                INSERT INTO [dbo].[holerites] (
                    [id_funcionario], [total_liquido],
                    [beneficios], [descontos], [salario_bruto],
                    [mes_ref], [ano_ref], [inss], [id_cargo]
                ) VALUES (
                    {idFuncionario},
                    {totalLiquido.ToString("F2", CultureInfo.InvariantCulture)},
                    {holerite.Beneficios.ToString("F2", CultureInfo.InvariantCulture)},
                    {descontosTotais.ToString("F2", CultureInfo.InvariantCulture)},
                    {cargo.Salario.ToString("F2", CultureInfo.InvariantCulture)},
                    {mesRef},
                    {anoRef},
                    {inss.ToString("F2", CultureInfo.InvariantCulture)},
                    {cargo.ID}
                );
            ";



                try
                {
                    using (SqlConnection con = new conexao().conectar())
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        // Execute a query de inserção
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocorreu um erro ao inserir o holerite: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Tratar o caso em que o cargo não foi encontrado
                MessageBox.Show("Cargo não encontrado para o funcionário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocorreu um erro ao inserir o holerite: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }



    public int ObterProximoIdHolerite()
    {
        try
        {
            using (SqlConnection con = new conexao().conectar())
            {
                string query = "SELECT MAX([id_holerite]) FROM [dbo].[holerites]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Se houver um ID máximo, retorne o próximo ID incrementado
                        return Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        // Se não houver IDs existentes, retorna 1 como o próximo ID
                        return 1;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Trate exceções conforme necessário
            MessageBox.Show($"Erro ao obter próximo ID de holerite: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1; // Ou outro valor que indique um erro
        }
    }




    private List<int> ObterIdsHoleritesDoBancoDeDados()
    {
        List<int> idsExistente = new List<int>();

        try
        {
            using (SqlConnection con = new conexao().conectar())
            {
                string query = "SELECT [id_holerite] FROM [dbo].[holerites]";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idHolerite = reader.GetInt32(reader.GetOrdinal("id_holerite"));
                            idsExistente.Add(idHolerite);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Trate exceções conforme necessário
            MessageBox.Show($"Erro ao obter IDs de holerites: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return idsExistente;
    }





    private decimal CalcularInss(decimal salario)
    {
        if (salario <= 1659.38m)
        {
            return Math.Round(salario * 0.08m, 2); // Alíquota de 8% para salários até R$ 1.659,38
        }
        else if (salario <= 2765.66m)
        {
            return Math.Round(salario * 0.09m, 2); // Alíquota de 9% para salários até R$ 2.765,66
        }
        else if (salario <= 5531.31m)
        {
            return Math.Round(salario * 0.11m, 2); // Alíquota de 11% para salários até R$ 5.531,31
        }
        else
        {
            return Math.Round(5531.31m * 0.11m, 2); // Para salários acima de R$ 5.531,31, aplica-se a alíquota máxima
        }
    }
}
