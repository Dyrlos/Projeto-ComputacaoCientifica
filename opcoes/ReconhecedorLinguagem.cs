using System;

namespace Toolkit.AV1
{
    public static class ReconhecedorLinguagem
    {
        public static void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Item 5 — Reconhecedor Σ={a,b} ===\n\n"+
                                  "(1) L_par_a  (quantidade de 'a' par)\n" +
                                  "(2) L = { w | w = a b* }\n" +
                                  "(0) Voltar\n");
                Console.Write("Escolha: ");
                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ReconhecerParA();
                        break;
                    case "2":
                        ReconhecerAbEstrela();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Inválido.");
                        break;
                }

                Console.WriteLine("\n(1) Escolher outra opção" +
                                  "\n(2) Sair");
                Console.Write("Escolha: ");
                string? escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        continue;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Inválido.");
                        break;
                }
            }
        }

        private static void ReconhecerParA()
        {
            string cadeiaEntrada = Util.LerCadeiaSigmaAB("Cadeia (Σ={a,b}): ");
            int quantidadeDeA = 0;
            foreach (char simbolo in cadeiaEntrada) if (simbolo == 'a') quantidadeDeA++;
            Console.WriteLine(quantidadeDeA % 2 == 0 ? "ACEITA" : "REJEITA");
        }

        private static void ReconhecerAbEstrela()
        {
            string cadeiaEntrada = Util.LerCadeiaSigmaAB("Cadeia (Σ={a,b}): ");
            bool aceita = cadeiaEntrada.Length >= 1 && cadeiaEntrada[0] == 'a';
            if (aceita)
            {
                for (int i = 1; i < cadeiaEntrada.Length; i++)
                {
                    if (cadeiaEntrada[i] != 'b') { aceita = false; break; }
                }
            }
            Console.WriteLine(aceita ? "ACEITA" : "REJEITA");
        }
    }
}
