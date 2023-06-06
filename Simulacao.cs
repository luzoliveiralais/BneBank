using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Simulacao
    {
        public double ValorInvestido { get; set; }
        public double TaxaDeJuros;
        public double Periodo = 8.33333;
        public double Rendimento;
        public static double Contador;

        public Simulacao()
        {
            this.ValorInvestido = PedeValor();
            this.TaxaDeJuros = PedeTaxa() / 100;


        }
        public double PedeValor()
        {
            Console.WriteLine();
            Console.Write("[33m  Qual o valor do investimento inicial? R$ \u001b[0m");
            double valorInvestido = Convert.ToDouble(Console.ReadLine());
            return valorInvestido;
        }
        public virtual double PedeTaxa()
        {
            Console.Write("[33m  Escolha uma das opções de taxa de juros [3%] [2.48%] [2%]: [0m");
            string taxaEscolhida = Console.ReadLine();
            double taxa = 0;

            if (taxaEscolhida.EndsWith("%") || taxaEscolhida.EndsWith(" "))
            {
                taxa = Convert.ToDouble(taxaEscolhida.Trim().Remove(taxaEscolhida.Length - 1));
            }
            else
            {
                taxa = Convert.ToDouble(taxaEscolhida);
            }
            return taxa;
        }
        public double PedeTaxaEspecifica()
        {
            Console.Write("[33m  Escolha uma das opções de taxa de juros [3%] [2.48%] [2%]: [0m");
            string taxaEscolhida = Console.ReadLine();
            double taxa = 0;
            return taxa;
        }
        public double CalculoRendimento(double contador)
        {
            return this.Rendimento = this.ValorInvestido * Math.Pow(this.TaxaDeJuros + 1, contador);
        }
        public static void IncrementaContador()
        {
            Contador++;
            if (Contador > 8)
            {
                Contador = 8.33333;
            }
        }
        public static void ZeraContador()
        {
            Contador = 0;
        }
        public void TabelaDeValores()
        {
            Console.WriteLine();
            Console.WriteLine($"  \u001b[36mValor Presente (valor do investimento) = R${this.ValorInvestido}  \u001b[0m");
            Console.WriteLine($"  \u001b[36mTaxa de Juros escolhida = {this.TaxaDeJuros * 100}%  \u001b[0m");
            Console.WriteLine($"  \u001b[36mTempo do investimento = 8 Meses e 10 dias  \u001b[0m");
            Console.WriteLine();
            Console.WriteLine($"\u001b[36m  | Período          | Taxa de Juros | Rendimentos | Juros Acumulados | Rend. Acumulado |\u001b[0m");

            while (Contador <= Periodo)
            {
                IncrementaContador();
                double rendimento = CalculoRendimento(Contador);
                double rendimentoAcumulado = rendimento;
                double jurosAcumulado = rendimento - this.ValorInvestido;

                if (Contador == Periodo)
                {
                    Console.WriteLine($"\u001b[36m  | 8º Mês e 10 dias | {this.TaxaDeJuros * 100 + " %",-14}" +
                    $"| R$ {rendimento,-8:F2} | R$ {jurosAcumulado,-13:F2} | R$ {rendimentoAcumulado,-12:F2} |\u001b[0m");
                    break;
                }

                Console.WriteLine($"\u001b[36m  | {Contador + "º mês",-16} | {this.TaxaDeJuros * 100 + " %",-14}" +
                $"| R$ {rendimento,-8:F2} | R$ {jurosAcumulado,-13:F2} | R$ {rendimentoAcumulado,-12:F2} |\u001b[0m");
            }
            ZeraContador();
            Console.WriteLine();
        }
    }
}