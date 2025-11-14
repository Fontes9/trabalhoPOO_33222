using System;

namespace GestaoCondominios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A iniciar Sistema de Gestão de Condomínios...");

            // 1. Criar Pessoas (Proprietários e Inquilinos)
            Proprietario p1 = new Proprietario("Ana Silva", "123456789", "911222333");
            Proprietario p2 = new Proprietario("Bruno Paiva", "987654321", "922333444");
            Inquilino i1 = new Inquilino("Carla Dias", "111222333", "933444555");

            // 2. Criar Frações e associar pessoas
            Fracao f1_A = new Fracao("1º Andar A", 150.0, p1);
            f1_A.Inquilino = i1; // A Ana (p1) é dona, mas a Carla (i1) é inquilina

            Fracao f1_B = new Fracao("1º Andar B", 120.0, p2);

            Fracao f2_A = new Fracao("2º Andar A", 150.0, p1); // A Ana (p1) também é dona desta fração

            // 3. Criar um Condomínio
            Condominio c1 = new Condominio("Rua da Liberdade, nº 10, Braga");

            // 4. Adicionar as Frações ao Condomínio
            c1.AdicionarFracao(f1_A);
            c1.AdicionarFracao(f1_B);
            c1.AdicionarFracao(f2_A);

            // 5. Adicionar o Condomínio ao sistema de Gestão
            bool sucesso = GestaoCondominios.InserirCondominio(c1);
            if (sucesso)
            {
                Console.WriteLine("Condomínio 'Rua da Liberdade' inserido com sucesso.");
            }

            // 6. Criar e adicionar outro condomínio
            Condominio c2 = new Condominio("Av. Central, nº 50, Porto");
            GestaoCondominios.InserirCondominio(c2);


            // 7. Mostrar dados
            Console.WriteLine("\n--- DADOS DO SISTEMA ---");
            GestaoCondominios.MostrarTodosCondominios();

            c1.MostrarFracoes();

            Console.WriteLine("\nTotal de Condomínios no sistema: " + GestaoCondominios.TotalCondominios);

            Console.WriteLine("\nPrima qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}