using GestaoCondominios.Interfaces;
using GestaoCondominios.Models;
using GestaoCondominios.Services; // <--- NECESSÁRIO para o FicheiroService

namespace GestaoCondominios.Controllers
{
    public class CondominioController
    {
        Condominio model;
        ICondominioView view;

        public CondominioController(Condominio model, ICondominioView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                int op = view.MenuPrincipal();
                switch (op)
                {
                    case 1:
                        ProcessarDespesa();
                        break;
                    case 2:
                        view.MostrarRelatorio(model);
                        view.LerTexto("Prima Enter");
                        break;
                    case 3:
                        ProcessarPagamento();
                        break;

                    // === NOVA OPÇÃO ===
                    case 4:
                        FicheiroService.GuardarDados(model);
                        view.MostrarMensagem("Dados guardados no disco com sucesso!");
                        break;
                    // ==================

                    case 0:
                        sair = true;
                        break;
                    default:
                        view.MostrarMensagem("Opção Inválida");
                        break;
                }
            }
        }

        private void ProcessarDespesa()
        {
            decimal valor = view.LerDecimal("Valor da Despesa");
            string desc = view.LerTexto("Descrição");
            string tipo = view.LerTexto("Tipo");

            model.InserirDespesa(valor, desc, tipo);
            view.MostrarMensagem("Despesa registada!");
        }

        private void ProcessarPagamento()
        {
            string id = view.LerTexto("Qual a Fração (ex: A, B)?");

            Fracao f = model.Fracoes.Find(x => x.Identificador == id);

            if (f != null && f.Quotas.Count > 0)
            {
                f.Quotas[0].Pagar();
                view.MostrarMensagem("Pagamento efetuado!");
            }
            else
            {
                view.MostrarMensagem("Fração não encontrada ou sem dívidas.");
            }
        }
    }
}