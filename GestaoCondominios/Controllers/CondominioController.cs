using GestaoCondominios.Interfaces;
using GestaoCondominios.Models;

namespace GestaoCondominios.Controllers
{
    /// <summary>
    /// Controlador responsável por coordenar a interação entre a View e o Model (Padrão MVC).
    /// </summary>
    public class CondominioController
    {
        Condominio model;
        ICondominioView view;

        /// <summary>
        /// Construtor do Controlador.
        /// </summary>
        /// <param name="model">Instância do Condomínio (dados).</param>
        /// <param name="view">Instância da Interface de Utilizador (consola/form).</param>
        public CondominioController(Condominio model, ICondominioView view)
        {
            this.model = model;
            this.view = view;
        }

        /// <summary>
        /// Inicia o ciclo principal da aplicação (Main Loop).
        /// Mantém o menu ativo até o utilizador decidir sair.
        /// </summary>
        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                int op = view.MenuPrincipal();
                switch (op)
                {
                    case 1: ProcessarDespesa(); break;
                    case 2:
                        view.MostrarRelatorio(model);
                        view.LerTexto("Prima Enter");
                        break;
                    case 3: ProcessarPagamento(); break;
                    case 0: sair = true; break;
                    default: view.MostrarMensagem("Opção Inválida"); break;
                }
            }
        }

        /// <summary>
        /// Gere o fluxo de criação de uma nova despesa: pede dados à View e atualiza o Model.
        /// </summary>
        private void ProcessarDespesa()
        {
            decimal valor = view.LerDecimal("Valor da Despesa");
            string desc = view.LerTexto("Descrição");
            string tipo = view.LerTexto("Tipo");

            model.InserirDespesa(valor, desc, tipo);
            view.MostrarMensagem("Despesa registada com sucesso!");
        }

        /// <summary>
        /// Gere o fluxo de pagamento de quotas.
        /// </summary>
        private void ProcessarPagamento()
        {
            string id = view.LerTexto("Qual a Fração (ex: A, B)?");

            // Procura a fração usando uma expressão Lambda/LINQ simples
            Fracao f = model.Fracoes.Find(x => x.Identificador == id);

            if (f != null && f.Quotas.Count > 0)
            {
                // Simplificação: Paga sempre a primeira quota da lista (FIFO)
                f.Quotas[0].Pagar();
                view.MostrarMensagem("Pagamento efetuado!");
            }
            else
            {
                view.MostrarMensagem("Fração não encontrada ou sem dívidas pendentes.");
            }
        }
    }
}