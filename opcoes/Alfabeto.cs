using System;

namespace Toolkit.AV1
{
    public static class Alfabeto
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=~=~= Item 1 — Verificador de alfabeto Σ={a,b} =~=~=\n");
            Console.Write("Digite um símbolo: ");
            char simbolo = Console.ReadKey(intercept: false).KeyChar;
            if (Util.SigmaAB.Contains(simbolo))
                Console.WriteLine("\nSímbolo válido.");
            else
                Console.WriteLine("\nSímbolo inválido.");

            string cadeia = Util.LerNaoNulo("Digite uma cadeia: ");
            bool valida = Util.CadeiaEmSigmaAB(cadeia);
            Console.WriteLine(valida ? "Cadeia válida." : "Cadeia inválida.");
            Util.Pausar();
        }
    }
}
