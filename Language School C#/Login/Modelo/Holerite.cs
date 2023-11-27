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
    public decimal Beneficios { get; set; }
    public decimal Descontos { get; set; }
    public decimal SalarioBruto { get; set; }
    public decimal Inss { get; set; }
    public int IDCargo { get; set; }
    public Cargo Cargo { get; set; }

    public int MesRef { get; set; }
    public int AnoRef { get; set; }
    public Holerite() { }

    public Holerite( int funcionarioID, string nomeFuncionario, string nomeCargo, decimal valorHolerite, decimal beneficios, decimal descontos, decimal salarioBruto, decimal inss, int idCargo, int mesRef, int anoRef)
    {

        FuncionarioID = funcionarioID;
        NomeFuncionario = nomeFuncionario;
        NomeCargo = nomeCargo;
        ValorHolerite = valorHolerite;
        Beneficios = beneficios;
        Descontos = descontos;
        SalarioBruto = salarioBruto;
        Inss = inss;
        IDCargo = idCargo;
        MesRef = mesRef;
        AnoRef = anoRef;
    }
}

