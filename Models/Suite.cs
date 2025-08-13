namespace DesafioProjetoHospedagem.Models
{
    public enum TipoSuite
    {
        Padrao = 1,
        Luxo = 2,
        Premium = 3
    }

    public class Suite
    {

        public TipoSuite TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public Suite() { }


        public Suite(TipoSuite tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }
    }
}