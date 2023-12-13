using System.ComponentModel.DataAnnotations;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        [Required]
        private string Placa { get; set; }
        private decimal PrecoInicial = 0;
        private decimal PrecoPorHora = 0;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            try
            {
                Console.Write("Digite a placa do veículo para estacionar: ");
                Placa = Console.ReadLine();
                ValidationException.When(string.IsNullOrEmpty(Placa), "Valor da placa não pode ser nulo ou vazio.");

                if (veiculos.Any(v => v.ToUpper() == Placa.ToUpper()))
                {
                    Console.WriteLine("Já existe um veículo com essa placa no estacionamento.");
                }
                else
                {
                    veiculos.Add(Placa);
                    Console.WriteLine($"Veículo com a placa {Placa} foi adicionado com sucesso.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        public void RemoverVeiculo()
        {
            try
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                Placa = Console.ReadLine();

                if (veiculos.Any(x => x.ToUpper() == Placa.ToUpper()))
                {
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                    if (!int.TryParse(Console.ReadLine(), out int horas))
                    {
                        throw new ArgumentException("Valor inválido para horas.");
                    }

                    decimal valorTotal = (PrecoInicial + PrecoPorHora) * horas;

                    veiculos.Remove(Placa);
                    Console.WriteLine($"O veículo {Placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var placa in veiculos)
                {
                    Console.WriteLine($"Placa: {placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}