using Bank;

internal class Program
{
    public static void Main(string[] args)
    {

        string opcao1;

        Console.WriteLine("");
        do
        {
            Funcional.EnunciadoMenu();
            opcao1 = Console.ReadLine();
            double valor;

            switch (opcao1)
            {
                case "1":
                    SimulacaoBasica simula1 = new SimulacaoBasica();
                    simula1.TabelaCompleta();

                    Funcional.SetContinuaDoMenu();
                    break;
                case "2":
                    Console.WriteLine();
                    var simula2 = new Simulacao();
                    simula2.TabelaDeValores();
                    Funcional.SetContinuaDoMenu();
                    break;
                case "3":
                    Console.WriteLine();
                    SimulacaoResgate simula3 = new SimulacaoResgate();
                    simula3.TabelaDeValoresComResgate();
                    Funcional.SetContinuaDoMenu();
                    break;
            }
        } while (Funcional.Continuar == true);


        Console.WriteLine("");

        Console.ReadLine();
    }


}
