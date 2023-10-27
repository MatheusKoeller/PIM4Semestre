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

public class Holerite
{
    public int FuncionarioID { get; set; }
    public string NomeFuncionario { get; set; }
    public string NomeCargo { get; set; }
    public decimal ValorHolerite { get; set; }

    public Holerite() // Construtor padrão sem argumentos
    {
    }

    public Holerite(int funcionarioID, string nomeFuncionario, string nomeCargo, decimal valorHolerite)
    {
        FuncionarioID = funcionarioID;
        NomeFuncionario = nomeFuncionario;
        NomeCargo = nomeCargo;
        ValorHolerite = valorHolerite;
    }
    private decimal CalcularHolerite(Cargo cargo)
    {
        // Implemente o cálculo do holerite com base nas informações do cargo.
        // Adicione suas regras de cálculo aqui, como descontos, adicionais, etc.
        // Exemplo de cálculo simples (salário bruto do cargo):
        return cargo.Salario;
    }
}

