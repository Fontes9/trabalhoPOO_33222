using GestaoCondominios.Models;
using GestaoCondominios.Views;
using GestaoCondominios.Controllers;
using GestaoCondominios.Interfaces;

namespace GestaoCondominios
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Criar Proprietários (Agora a classe existe em Models)
            Proprietario p1 = new Proprietario("Ana", "123456789", "910000000");
            Proprietario p2 = new Proprietario("Bruno", "987654321", "920000000");

            // 2. Criar Condomínio e Frações
            Condominio predio = new Condominio("Edifício Panorâmico");
            predio.AdicionarFracao(new Fracao("A", 500, p1));
            predio.AdicionarFracao(new Fracao("B", 500, p2));

            // 3. Setup do MVC
            ICondominioView view = new ConsoleView();
            CondominioController app = new CondominioController(predio, view);

            // 4. Iniciar
            app.Iniciar();
        }
    }
}