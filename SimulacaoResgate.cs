using Bank;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SimulacaoResgate : Simulacao
    {
        public int MesRetirada;
        public double Resgate;
        public int MesDoResgate;
        public static int ContadorDeControle  = 0;
        public double Saldo;
        public double RendaAcumulada;
        public double Redimento;
        public double RendimentoLiquido;
#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        public double Periodo;
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        public SimulacaoResgate()
        {
            Periodo = this.PedePeriodo();
            this.Resgate = PedeValorResgate();
            this.MesDoResgate = PedeMesDoResgate();
            
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

        public double PedeValorResgate()
        {
            Console.Write("\u001b[33m  Que valor deseja resgatar? R$ \u001b[0m");

            double valorResgate = Convert.ToDouble(Console.ReadLine());
            return valorResgate;
        }

        public int PedeMesDoResgate()
        {
            Console.Write("\u001b[33m  Em que mês deseja fazer o resgate?  \u001b[0m");
            int mes = Convert.ToInt32(Console.ReadLine());
            return mes;
        }

#pragma warning disable CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        public static void IncrementaContador()
#pragma warning restore CS0108 // O membro oculta o membro herdado; nova palavra-chave ausente
        {
            Contador++;
        }

        public static void IncrementaContadorDeControle()
        {
            ContadorDeControle++;
        }

        public static void ZeraContadorDeControle()
        {
            ContadorDeControle = 0;
        }
        public double CalculoRendimentoLiquido()
        {
            return Rendimento - ValorInvestido;
        }

        public double CalculoRendaAcumulada()
        {
            if (ContadorDeControle == this.MesDoResgate)
            {
                return ValorInvestido + CalculoRendimentoLiquido() - Resgate;
            }
            else
            {
                return ValorInvestido + CalculoRendimentoLiquido();
            }
        }

        public bool AnalisaValorResgate()
        {
            if (Resgate > Rendimento)
            {
                ValorInvestido = 0;
                Console.WriteLine($"\u001b[31m  Não é possível fazer o resgate de R$ {Resgate:F2} pois o valor excede o rendimento acumulado até o mês {MesDoResgate}.\u001b[0m");
                return true;
            }
            else
            {
                return false;
            }

        }


        public void TabelaDeValoresComResgate()
        {
            Console.WriteLine();
            Console.WriteLine($"\u001b[36m  |  Valor Presente  | Período    | Juros | Rendimentos    | Renda Liquida   | " +
                $"Rend. Acumulado  | Resgate      | Saldo      |\u001b[0m");

            while (Contador < Periodo)
            {

                IncrementaContador();
                IncrementaContadorDeControle();
                Redimento = CalculoRendimento(Contador);
                RendaAcumulada = CalculoRendaAcumulada();
                RendimentoLiquido = CalculoRendimentoLiquido();
                Saldo = CalculoRendaAcumulada();


                if (Contador == MesDoResgate && ContadorDeControle == MesDoResgate)
                {
                    Saldo = Rendimento - RendimentoLiquido;
                    RendaAcumulada = CalculoRendaAcumulada();
                    Saldo = CalculoRendaAcumulada();
                    Console.WriteLine($"\u001b[36m  |  R$ {ValorInvestido,-11:F2}  | {Contador + "º mês",-9}  |  {TaxaDeJuros * 100 + "%",-5}" +
                        $"| R$ {Rendimento,-11:F2} |  R$ {RendimentoLiquido,-11:F2} |  R$ {RendaAcumulada,-12:F2} | R$ {Resgate,-8:F2}  | {this.Saldo,-10:F2} |\u001b[0m");
                    Console.WriteLine("  ----------------------------------------------------------------------------------------------------------------------------");

                    if (AnalisaValorResgate() == true)
                    {
                        break;
                    }

                    ValorInvestido = RendaAcumulada;
                    Contador = 0;
                    Resgate = 0;
                    continue;
                }

                Console.WriteLine($"\u001b[36m  |  R$ {ValorInvestido,-11:F2}  | {Contador + "º mês",-9}  |  {TaxaDeJuros * 100 + "%",-5}" +
                $"| R$ {Rendimento,-11:F2} |  R$ {RendimentoLiquido,-11:F2} |  R$ {RendaAcumulada,-12:F2} |              | {this.Saldo,-10:F2} |\u001b[0m");

            }
            ZeraContador();
            ZeraContadorDeControle();
            Console.WriteLine();
        }
    }
}

