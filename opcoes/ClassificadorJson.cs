using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toolkit.AV1
{
    public sealed class QuestaoTIN
    {
        [JsonPropertyName("pergunta")]
        public string Pergunta { get; set; } = string.Empty;

        [JsonPropertyName("resposta")]
        public string RespostaCorreta { get; set; } = string.Empty;
    }

    public static class ClassificadorJson
    {
        public static void Executar()
        {
            Console.Clear();
            Console.WriteLine("=== Item 2 — Classificador T/I/N por JSON ===");
            string caminho = System.IO.Path.Combine(AppContext.BaseDirectory, "dados", "problemas_tin.json");

            List<QuestaoTIN> lista = Util.LerArquivoJson<List<QuestaoTIN>>(caminho);

            int acertos = 0;
            int erros = 0;

            foreach (QuestaoTIN q in lista)
            {
                Console.WriteLine();
                Console.WriteLine($"Item: {q.Pergunta}");
                string respostaUsuario = LerRespostaTIN("Classifique (T/I/N): ");

                if (string.Equals(respostaUsuario, q.RespostaCorreta, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correto.");
                    acertos++;
                }
                else
                {
                    Console.WriteLine($"Errado. Correto: {q.RespostaCorreta.ToUpperInvariant()}.");
                    erros++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Resumo: Acertos={acertos} | Erros={erros} | Total={lista.Count}\n"+
                              "\nTecle Enter para voltar...");
            Console.ReadLine();
        }

        private static string LerRespostaTIN(string rotulo)
        {
            while (true)
            {
                Console.Write(rotulo);
                string? s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) { Console.WriteLine("Entrada vazia."); continue; }
                s = s.Trim().ToUpperInvariant();
                if (s is "T" or "I" or "N") return s;
                Console.WriteLine("Use T, I ou N.");
            }
        }
    }
}
