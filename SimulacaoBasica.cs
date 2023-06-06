using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SimulacaoBasica : Simulacao
    {

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        static public double Periodo;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        static public double Taxa;
        static public int Contador = 0;


        public SimulacaoBasica()
        {
            Periodo = this.PedePeriodo();
        }

        public double PedePeriodo()
        {
            Console.Write("[33m  Tempo do investimento (em meses): \u001b[0m");
            string tempo = Console.ReadLine();
            double tempoEscolhido = 0;
            if (tempo.EndsWith("meses"))
            {
                tempoEscolhido = Convert.ToDouble(tempo.Trim().Remove(tempo.Length - 1));
            }
            else
            {
                tempoEscolhido = Convert.ToDouble(tempo);
            }
            return tempoEscolhido;
        }

        public override double PedeTaxa()
        {
            Console.Write("[33m  Escolha a taxa de juros desejada: [0m");
            string taxaEscolhida = Console.ReadLine();
            double taxa = 0;

            if (taxaEscolhida.EndsWith("%"))
            {
                TaxaDeJuros = Convert.ToDouble(taxaEscolhida.Trim().Remove(taxaEscolhida.Length - 1));
            }
            else
            {
                TaxaDeJuros = Convert.ToDouble(taxaEscolhida);
            }
            return TaxaDeJuros;
        }

        public static void IncrementaContador()
        {
            Contador++;
        }

        public static void ZeraContador()
        {
            Contador = 0;
        }
        public static void ZeraPeriodo()
        {
            Periodo = 0;
        }

        public void TabelaCompleta()
        {
            Console.WriteLine();
            Console.WriteLine($"  \u001b[36mValor Presente (valor do investimento) = R${ValorInvestido}  \u001b[0m");
            Console.WriteLine($"  \u001b[36mTaxa de Juros escolhida = {TaxaDeJuros * 100}%  \u001b[0m");
            Console.WriteLine($"  \u001b[36mTempo do investimento (meses) = {Periodo} meses \u001b[0m");
            Console.WriteLine();
            Console.WriteLine($"\u001b[36m  | Período          | Taxa de Juros | Rendimentos | Juros Acumulados | Rend. Acumulado |\u001b[0m");

            while (Contador < Periodo)
            {
                IncrementaContador();
                double rendimento = CalculoRendimento(Contador);
                double rendimentoAcumulado = rendimento;
                double jurosAcumulado = rendimento - ValorInvestido;

                Console.WriteLine($"\u001b[36m  | {Contador + "º mês",-16} | {TaxaDeJuros * 100 + " %",-14}" +
                $"| R$ {rendimento,-8:F2} | R$ {jurosAcumulado,-13:F2} | R$ {rendimentoAcumulado,-12:F2} |\u001b[0m");
            }

            ZeraContador();
            ZeraPeriodo();
            Console.WriteLine();
        }
    }
}
