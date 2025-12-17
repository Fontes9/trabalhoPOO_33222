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

            // 1. Tentar Carregar dados
            Condominio predio = FicheiroService.CarregarDados();

            // 2. Se não existir ficheiro, cria dados de teste
            if (predio == null)
            {
                Console.WriteLine("-> Nenhum ficheiro encontrado. A criar dados novos...");
                predio = new Condominio("Edifício Panorâmico");

                Proprietario p1 = new Proprietario("Ana", "123456789", "910000000");
                Proprietario p2 = new Proprietario("Bruno", "987654321", "920000000");

                predio.AdicionarFracao(new Fracao("A", 500, p1));
                predio.AdicionarFracao(new Fracao("B", 500, p2));
            }

            // 3. Iniciar MVC
            ICondominioView view = new ConsoleView();
            CondominioController app = new CondominioController(predio, view);

            Console.WriteLine("\n[SISTEMA] Pressiona qualquer tecla para abrir o menu...");
            Console.ReadKey();

            // 4. Executar Aplicação
            app.Iniciar();

            // 5. Guardar ao Sair (Backup de segurança)
            Console.WriteLine("\n=== A SAIR ===");
            FicheiroService.GuardarDados(predio);

            Console.WriteLine("Pressiona Enter para fechar.");
            Console.ReadLine();
        }
    }
}