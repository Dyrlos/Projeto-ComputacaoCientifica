using System;

namespace Toolkit.AV1
{
    public static class TerminaComB
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Item 3 — Programa de decisão: termina com 'b'? ===\n");

            string cadeia = Util.LerCadeiaSigmaAB("Cadeia (Σ={a,b}): ");

            if (cadeia.Length == 0)
            {
                Console.WriteLine("NAO");
                Console.WriteLine("\nTecle Enter para voltar...");
                Console.ReadLine();
                return;
            }

            char ultimo = cadeia[cadeia.Length - 1];
            Console.WriteLine(ultimo == 'b' ? "SIM" : "NAO");
            Console.WriteLine("\nTecle Enter para voltar...");
            Console.ReadLine();
        }
    }
}
