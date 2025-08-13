using DesafioProjetoHospedagem.Models;

class Program
{
    static void Main(string[] args)
    {
        const string mensagemBoasVindas = "Bem-vindo ao sistema de reservas de hospedagem!";

        Console.WriteLine(mensagemBoasVindas);

        List<Reserva> reservas = new List<Reserva>();

        Console.WriteLine("Você já tem uma reserva? (S/N)");
        string respostaReserva = Console.ReadLine()?.Trim().ToUpper();
        if (respostaReserva == "S")
        {
            Console.WriteLine("Reservas existentes:");
            for (int i = 0; i < reservas.Count; i++)
            {
                var r = reservas[i];
                Console.WriteLine($"{i + 1} - Suíte: {r.Suite.TipoSuite}, Dias: {r.DiasReservados}, Hóspedes: {r.ObterQuantidadeHospedes()}, Valor: R$ {r.CalcularValorDiaria()}");
            }

            Console.Write("Digite o número da reserva que deseja cancelar: ");

            int indiceCancelar;

            if (int.TryParse(Console.ReadLine(), out indiceCancelar) && indiceCancelar > 0 && indiceCancelar <= reservas.Count)
            {
                reservas.RemoveAt(indiceCancelar - 1);
                Console.WriteLine("Reserva cancelada com sucesso!");
            }
            else
            {
                Console.WriteLine("Número de reserva inválido.");
            }
        }

        var suites = new List<Suite>
        {
            new Suite(TipoSuite.Padrao, capacidade: 2, valorDiaria: 20),
            new Suite(TipoSuite.Luxo, capacidade: 4, valorDiaria: 40),
            new Suite(TipoSuite.Premium, capacidade: 6, valorDiaria: 60)
        };

        Console.WriteLine("Suítes disponíveis:");
        foreach (var s in suites)
        {
            Console.WriteLine($"Tipo: {s.TipoSuite}, Capacidade: {s.Capacidade}, Valor Diária: {s.ValorDiaria:C}");
        }

        Console.WriteLine("Escolha o tipo de suíte para a reserva:");
        for (int i = 0; i < suites.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {suites[i].TipoSuite} | Capacidade: {suites[i].Capacidade} | Valor diária: R$ {suites[i].ValorDiaria}");
        }

        int escolha;
        do
        {
            Console.Write("Digite o número da suíte desejada: ");
        } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > suites.Count);

        Suite suiteEscolhida = suites[escolha - 1];

        Console.WriteLine($"Você escolheu a suíte: {suiteEscolhida.TipoSuite} com valor de R$ {suiteEscolhida.ValorDiaria} por diária.");

        int diasReservados;
        do
        {
            Console.Write("Quantos dias deseja reservar? ");
        } while (!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados < 1);

        List<Pessoa> hospedes = new List<Pessoa>();

        Pessoa p1 = new Pessoa(nome: "Hóspede 1");
        Pessoa p2 = new Pessoa(nome: "Hóspede 2");

        hospedes.Add(p1);
        hospedes.Add(p2);

        Reserva reserva = new Reserva(diasReservados);
        reserva.CadastrarSuite(suiteEscolhida);
        reserva.CadastrarHospedes(hospedes);

        decimal valorTotal = reserva.CalcularValorDiaria();
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total da reserva para {diasReservados} dias: R$ {valorTotal}");

        Console.Write("Deseja confirmar a reserva? (S/N): ");
        string resposta = Console.ReadLine()?.Trim().ToUpper();
        if (resposta == "S")
        {
            reservas.Add(reserva);
            Console.WriteLine("Reserva confirmada!");
        }
        else
        {
            Console.WriteLine("Reserva cancelada.");
        }
    }
}