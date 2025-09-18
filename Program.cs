using System;

namespace Toolkit
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=~=~=~=~=~=~=~= AV1 =~=~=~=~=~=~=~=\n\n" +
                                  "(1) Verificador alfabeto Σ={a,b}\n" +
                                  "(2) Classificador T/I/N por JSON\n" +
                                  "(3) Programa de decisão termina com 'b'\n" +
                                  "(4) Avaliador proposicional\n" +
                                  "(5) Reconhecedor linguagens simples\n" +
                                  "(0) Voltar\n");
                Console.Write("Escolha uma opção: ");

                switch (Console.ReadLine())
                {
                    case "1": AV1.Alfabeto.Executar(); break;
                    case "2": AV1.ClassificadorJson.Executar(); break;
                    case "3": AV1.TerminaComB.Executar(); break;
                    case "4": AV1.AvaliadorProposicional.Executar(); break;
                    case "5": AV1.ReconhecedorLinguagem.Executar(); break;
                    case "0": return;
                    default: Console.WriteLine("Inválido."); Console.ReadKey(); break;
                }
            }
        }
    }
}
