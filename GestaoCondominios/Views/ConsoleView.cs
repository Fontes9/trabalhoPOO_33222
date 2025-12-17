/*
* <copyright file="ConsoleView.cs" company="IPCA">
* <description>Implementação da View em Consola.</description>
*/
using System;
using GestaoCondominios.Interfaces;
using GestaoCondominios.Models;

namespace GestaoCondominios.Views
{
    public class ConsoleView : ICondominioView
    {
        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine($"\n[INFO]: {mensagem}");
            Console.WriteLine("Prima Enter para continuar...");
            Console.ReadLine();
        }

        public string LerTexto(string label)
        {
            Console.Write($"{label}: ");
            return Console.ReadLine();
        }

        public decimal LerDecimal(string label)
        {
            Console.Write($"{label}: ");
            decimal.TryParse(Console.ReadLine(), out decimal val);
            return val;
        }

        public int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== GESTÃO DE CONDOMÍNIOS ===");
            Console.WriteLine("1. Lançar Despesa");
            Console.WriteLine("2. Relatório Financeiro");
            Console.WriteLine("3. Pagar Quota");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");

            int.TryParse(Console.ReadLine(), out int op);
            return op;
        }

        public void MostrarRelatorio(object dados)
        {
            if (dados is Condominio c)
            {
                Console.WriteLine($"\n--- Relatório: {c.Morada} ---");
                foreach (var f in c.Fracoes)
                {
                    Console.WriteLine($"Fração {f.Identificador} - {f.Proprietario.Nome}");
                    foreach (var q in f.Quotas)
                    {
                        Console.WriteLine($"\t{q}");
                    }
                }
            }
        }
    }
}