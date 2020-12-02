namespace Core.Models.Calculo
{
    public partial class Calculo
    {
        public static Calculo Criar(decimal taxaJuros, decimal valorInicial, int tempo) => new Calculo() { 
           TaxaJuros = taxaJuros,
           Tempo = tempo,
           ValorInicial = valorInicial
        };
    }
}
