/*
* <copyright file="CondominioController.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
*/
using System;
using GestaoCondominios.Interfaces;
using GestaoCondominios.Models;
using GestaoCondominios.Services;
using GestaoCondominios.Exceptions; // Verifica se esta linha não tem erro sublinhado

namespace GestaoCondominios.Controllers
{
    public class CondominioController
    {
        #region ESTADO

        private Condominio model;
        private ICondominioView view;

        #endregion

        #region CONSTRUTORES

        public CondominioController(Condominio model, ICondominioView view)
        {
            this.model = model;
            this.view = view;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Inicia o ciclo principal da aplicação com tratamento de erros global.
        /// </summary>
        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                #region SUPORTAR_ERROS
                try
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
                        case 4:
                            FicheiroService.GuardarDados(model);
                            view.MostrarMensagem("Dados guardados com sucesso!");
                            break;
                        case 0:
                            sair = true;
                            break;
                        default:
                            // Exemplo de lançamento da nossa exceção
                            throw new DadosInvalidosException("Opção inexistente no menu.");
                    }
                }
                catch (DadosInvalidosException ex)
                {
                    // Captura as nossas exceções de negócio (validações)
                    view.MostrarMensagem($"ERRO DE VALIDAÇÃO: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Captura erros genéricos de sistema (crashes)
                    view.MostrarMensagem($"ERRO DO SISTEMA: {ex.Message}");
                }
                #endregion
            }
        }

        /// <summary>
        /// Lança uma despesa e valida os inputs.
        /// </summary>
        private void ProcessarDespesa()
        {
            try
            {
                decimal valor = view.LerDecimal("Valor da Despesa");

                // Validação de Negócio
                if (valor <= 0)
                    throw new DadosInvalidosException("O valor da despesa tem de ser positivo.");

                string desc = view.LerTexto("Descrição");
                if (string.IsNullOrWhiteSpace(desc))
                    throw new DadosInvalidosException("A descrição é obrigatória.");

                string tipo = view.LerTexto("Tipo");

                model.InserirDespesa(valor, desc, tipo);
                view.MostrarMensagem("Despesa registada!");
            }
            catch (FormatException)
            {
                // Traduz um erro técnico para a nossa exceção
                throw new DadosInvalidosException("O formato do número introduzido não é válido.");
            }
            // Outras exceções sobem para o Iniciar()
        }

        private void ProcessarPagamento()
        {
            try
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
                    throw new DadosInvalidosException("Fração não encontrada ou sem dívidas.");
                }
            }
            catch (Exception ex)
            {
                // Encapsula o erro original (Inner Exception)
                throw new DadosInvalidosException("Erro ao processar pagamento.", ex);
            }
        }

        #endregion
    }
}