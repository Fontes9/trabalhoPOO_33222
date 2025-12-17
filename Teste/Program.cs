using System;
using GestaoCondominios.Models;
using GestaoCondominios.Views;
using GestaoCondominios.Controllers;
using GestaoCondominios.Interfaces;
using GestaoCondominios.Services;

namespace GestaoCondominios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("=== A INICIAR SISTEMA ===");

            // 1. Tentar Carregar dados existentes
            Condominio predio = FicheiroService.CarregarDados();

            // 2. Se não existirem dados (primeira vez), cria dados de teste
            if (predio == null)
            {
                Console.WriteLine("-> A criar dados de demonstração...");
                predio = new Condominio("Edifício Panorâmico");

                Proprietario p1 = new Proprietario("Ana", "123456789", "910000000");
                Proprietario p2 = new Proprietario("Bruno", "987654321", "920000000");

                predio.AdicionarFracao(new Fracao("A", 500, p1));
                predio.AdicionarFracao(new Fracao("B", 500, p2));
            }

            // 3. Setup do MVC
            ICondominioView view = new ConsoleView();
            CondominioController app = new CondominioController(predio, view);

            // === PAUSA PARA LER AS MENSAGENS INICIAIS ===
            Console.WriteLine("\n[DEBUG] Dados prontos. Pressiona qualquer tecla para abrir o menu...");
            Console.ReadKey();
            // ============================================

            // 4. Iniciar a aplicação (Loop do Menu)
            app.Iniciar();

            // 5. Guardar automaticamente ao sair
            Console.WriteLine("\n=== A ENCERRAR SISTEMA ===");
            Console.WriteLine("A guardar dados...");
            FicheiroService.GuardarDados(predio);

            // === PAUSA FINAL ===
            Console.WriteLine("\nPressiona Enter para fechar a janela.");
            Console.ReadLine();
        }
    }
}