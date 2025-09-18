using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Toolkit
{
    public static class Util
    {
        public static readonly HashSet<char> SigmaAB = new HashSet<char> { 'a', 'b' };

        public static void Pausar()
        {
            Console.WriteLine("\nTecle Enter para voltar...");
            Console.ReadLine();
        }

        public static string LerNaoNulo(string rotulo)
        {
            while (true)
            {
                Console.Write(rotulo);
                string? s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s))
                    return s.Trim();
                Console.WriteLine("Entrada vazia.");
            }
        }

        public static bool CadeiaEmSigmaAB(string cadeia)
        {
            foreach (char c in cadeia)
            {
                if (!SigmaAB.Contains(c)) return false;
            }
            return true;
        }

        public static string LerCadeiaSigmaAB(string rotulo)
        {
            while (true)
            {
                string cadeia = LerNaoNulo(rotulo);
                if (CadeiaEmSigmaAB(cadeia)) return cadeia;
                Console.WriteLine("Alfabeto inválido. Use apenas 'a' e 'b'.");
            }
        }

        public static bool LerBool(string rotulo)
        {
            while (true)
            {
                Console.Write(rotulo);
                string? s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) { Console.WriteLine("Entrada vazia."); continue; }
                s = s.Trim().ToLowerInvariant();
                if (s is "s" or "sim" or "true" or "1") return true;
                if (s is "n" or "nao" or "não" or "false" or "0") return false;
                Console.WriteLine("Responda com S/N.");
            }
        }

        public static T LerArquivoJson<T>(string caminho) where T : class
        {
            if (!File.Exists(caminho))
                throw new FileNotFoundException($"Arquivo não encontrado: {caminho}");
            string json = File.ReadAllText(caminho);
            T? obj = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            if (obj is null)
                throw new InvalidOperationException("Falha ao ler JSON.");
            return obj;
        }

        public static int LerInteiroPositivo(string rotulo, int minimoInclusivo = 0, int maximoInclusivo = int.MaxValue)
        {
            while (true)
            {
                Console.Write(rotulo);
                string? s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v >= minimoInclusivo && v <= maximoInclusivo)
                    return v;
                Console.WriteLine("Valor inválido.");
            }
        }
    }
}