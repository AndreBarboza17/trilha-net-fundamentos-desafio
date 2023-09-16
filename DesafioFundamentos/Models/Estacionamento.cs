namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private bool VeiculoExiste(string placaVeiculo) => veiculos.Any(x => x.Equals(placaVeiculo.ToUpper()));

        private decimal CalcularValorEstacionamento(int horas) => precoInicial + (precoPorHora * horas);

        private void ExibirDetalhes(string veiculo, int horas)
        {
            // calcula o valor total                                
            var valorTotal = CalcularValorEstacionamento(horas);

            Console.WriteLine($"Preço Inicial: {precoInicial}");
            Console.WriteLine($"Preço p/ Hora: {precoPorHora}");
            Console.WriteLine($"Qtde. Horas Estacionado: {horas}");

            Console.WriteLine($"O veículo {veiculo.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void AdicionarVeiculo()
        {            
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            var placaVeiculo = Console.ReadLine();

            if (!string.IsNullOrEmpty(placaVeiculo))
            {
                if (VeiculoExiste(placaVeiculo))
                {
                    Console.WriteLine("O veículo já está estacionado!");
                    return;
                }

                veiculos.Add(placaVeiculo.ToUpper());
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa            
            string placaVeiculo = Console.ReadLine();

            if (string.IsNullOrEmpty(placaVeiculo)) return;

            // Verifica se o veículo existe
            if (VeiculoExiste(placaVeiculo))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // obtem as horas
                int horas;
                int.TryParse(Console.ReadLine(), out horas);                   

                // remove o veiculo
                veiculos.Remove(placaVeiculo.ToUpper());
                
                ExibirDetalhes(placaVeiculo, horas);                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var item in veiculos)
                {
                    Console.WriteLine($"{veiculos.IndexOf(item) + 1} - Veiculo com placa: {item}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
