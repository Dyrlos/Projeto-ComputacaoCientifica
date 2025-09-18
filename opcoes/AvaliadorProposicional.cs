using System;
using System.Collections.Generic;

namespace Toolkit.AV1
{
    public static class AvaliadorProposicional
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=~=~= Item 4 — Avaliador proposicional (P, Q, R) =~=~=\n");

            bool opcaoP = Util.LerBool("Valor de P (s/n): ");
            bool opcaoQ = Util.LerBool("Valor de Q (s/n): ");
            bool opcaoR = Util.LerBool("Valor de R (s/n): ");

            while (true)
            {
                Console.WriteLine("\nFórmulas:\n\n" +
                                  "(1) Verificar (P ∧ Q) ∨ R\n" +
                                  "(2) Verificar (P → Q) ∧ (Q → R)\n" +
                                  "(3) Gerar Tabela-verdade da 1\n" +
                                  "(4) Gerar Tabela-verdade da 2\n" +
                                  "(5) Voltar\n");
                Console.Write("Escolha uma opção: ");
                string? op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        bool formula1 = ((opcaoP && opcaoQ) || opcaoR);
                        Console.WriteLine($"Resultado: {(formula1 ? "VERDADEIRO" : "FALSO")}");
                        break;
                    case "2":
                        bool implementacao1 = (!opcaoP || opcaoQ);
                        bool implementacao2 = (!opcaoQ || opcaoR);
                        bool formula2 = (implementacao1 && implementacao2);
                        Console.WriteLine($"Resultado: {(formula2 ? "VERDADEIRO" : "FALSO")}");
                        break;
                    case "3":
                        ImprimirTabelaVerdade(Formula1, "Fórmula 1: (P ∧ Q) ∨ R");
                        break;
                    case "4":
                        ImprimirTabelaVerdade(Formula2, "Fórmula 2: (P → Q) ∧ (Q → R)");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Inválido.");
                        break;
                }
                Console.WriteLine("\n(1) Escolher outra opção" +
                                  "\n(2) Escolher outros valores para P, Q, R" +
                                  "\n(3) Sair");
                Console.Write("Escolha: ");
                string? escolha = Console.ReadLine();
                switch (escolha)
                {
                    case "1":
                        Console.Clear();
                        continue;
                    case "2":
                        Console.Clear();
                        opcaoP = Util.LerBool("Valor de P (s/n): ");
                        opcaoQ = Util.LerBool("Valor de Q (s/n): ");
                        opcaoR = Util.LerBool("Valor de R (s/n): ");
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Inválido.");
                        break;
                }
            }
        }

        private static bool Formula1(bool p, bool q, bool r) => (p && q) || r;

        private static bool Formula2(bool p, bool q, bool r)
        {
            bool imp1 = (!p || q);
            bool imp2 = (!q || r);
            return imp1 && imp2;
        }

        private static void ImprimirTabelaVerdade(Func<bool, bool, bool, bool> f, string titulo)
        {
            Console.WriteLine();
            Console.WriteLine($"\n{titulo}\n"+
                              "(P Q R | F)");
            foreach (bool p in new[] { false, true })
            foreach (bool q in new[] { false, true })
            foreach (bool r in new[] { false, true })
            {
                bool res = f(p, q, r);
                Console.WriteLine($"{Bt(p)} {Bt(q)} {Bt(r)} | {Bt(res)}");
            }
        }

        private static char Bt(bool v) => v ? '1' : '0';
    }
}
