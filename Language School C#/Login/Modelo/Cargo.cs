public class Cargo
{
    public int ID { get; set; }
    public string NomeCargo { get; set; }
    public decimal Salario { get; set; }
    public int? CargaHoraria { get; set; }

    public Cargo() // Construtor padrão sem argumentos
    {
    }

    public Cargo(int id, string nomeCargo, decimal salario, int? cargaHoraria)
    {
        ID = id;
        NomeCargo = nomeCargo;
        Salario = salario;
        CargaHoraria = cargaHoraria;
    }
}
