using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class Funcional
    {

        public static bool Continuar = true;
        public static string GuardaOpcao;
        public static void EnunciadoMenu()
        {
            Console.Write(@"Bem-vindo ao BNE Bank. Veja abaixo as opções de simulação que você tem por aqui:

[1] Simulação Básica
[2] Simulação Com Período Fixo de 8 Meses e 10 dias e Taxas Específicas.
[3] Simulação Resgate 

Escolha uma das opções digitando um número: ");
        }

        public static void SetOpcao()
        {
            GuardaOpcao = Console.ReadLine();
        }

        public static void SetContinuaDoMenu()
        {
            Console.WriteLine("Deseja fazer outra simulação? Digite 's' para sim ou 'n' para não.");
            SetOpcao();
            Console.WriteLine();
            if (GuardaOpcao == "n")
            {
                Continuar = false;
            }
        }

    }
}
