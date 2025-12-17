/*
* <copyright file="ConsoleView.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Implementação da View em Consola.</description>
*/
using System;
using GestaoCondominios.Interfaces;
using GestaoCondominios.Models;

namespace GestaoCondominios.Views
{
    /// <summary>
    /// Implementação da Interface de Utilizador baseada na Consola do Windows.
    /// </summary>
    public class ConsoleView : ICondominioView
    {
        /// <summary>
        /// Escreve uma mensagem na consola e aguarda confirmação.
        /// </summary>
        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine($"\n[INFO]: {mensagem}");
            Console.WriteLine("Prima Enter para continuar...");
            Console.ReadLine();
        }

        /// <summary>
        /// Lê uma string da consola.
        /// </summary>
        public string LerTexto(string label)
        {
            Console.Write($"{label}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Lê um valor decimal da consola, tratando erros básicos de conversão.
        /// </summary>
        public decimal LerDecimal(string label)
        {
            Console.Write($"{label}: ");
            // Tenta converter; se falhar devolve 0 (pode ser melhorado com validação num loop)
            decimal.TryParse(Console.ReadLine(), out decimal val);
            return val;
        }

        /// <summary>
        /// Limpa o ecrã e desenha o menu principal com as opções disponíveis.
        /// </summary>
        public int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== GESTÃO DE CONDOMÍNIOS ===");
            Console.WriteLine("1. Lançar Despesa");
            Console.WriteLine("2. Relatório Financeiro");
            Console.WriteLine("3. Pagar Quota");
            Console.WriteLine("4. Guardar Dados");
            Console.WriteLine("0. Sair");
            Console.Write("Opção: ");

            int.TryParse(Console.ReadLine(), out int op);
            return op;
        }

        /// <summary>
        /// Itera sobre as frações e quotas do condomínio para imprimir um relatório hierárquico.
        /// </summary>
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
                        // Usa o ToString() da classe Quota para formatação
                        Console.WriteLine($"\t{q}");
                    }
                }
            }
        }
    }
}