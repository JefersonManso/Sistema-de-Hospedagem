namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        // Lista de hóspedes da reserva
        public List<Pessoa> Hospedes { get; set; }

        // Suíte associada à reserva
        public Suite Suite { get; set; }

        // Quantidade de dias reservados
        public int DiasReservados { get; set; } 

        // Contrutor padrão
        public Reserva() { }

        // Construtor com número de dias
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Método para cadastrar os hóspedes na reserva
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a quantidade de hóspedes é menor ou igual à capacidade da suíte
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exceção se exceder a capacidade
                int quantidadeHospedes = hospedes.Count;
                int capacidadeSuite = Suite?.Capacidade ?? 0;

                throw new ArgumentException(
                    $"Erro ao cadastrar hóspedes: foram informados {quantidadeHospedes} hóspede(s), " +
                    $"mas a suíte '{Suite?.TipoSuite ?? "indefinida"}' comporta no máximo {capacidadeSuite}.");
            }
        }

        // Método para cadastrar a suíte na reserva
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        // Retorna a quantidade de hóspedes cadastrados
        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0; // operador null-safe para evitar exceção
        }
        
        // Calcula o valor total da diária
        public decimal CalcularValorDiaria()
        {
            // Verifica se a suíte está definida
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte cadastrada para a reserva.");
            }

            // Cálculo de dias x valor da diária da suíte
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            if (DiasReservados >= 10)
            {
                valor *= 0.90M; // Aplica 10% de desconto
            }

            return valor;
        }
    }
}