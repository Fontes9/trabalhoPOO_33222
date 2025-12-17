/*
* <copyright file="ICondominioView.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Interface que define o contrato de interação com o utilizador.</description>
*/

namespace GestaoCondominios.Interfaces
{
    /// <summary>
    /// Interface que define o contrato de interação com o utilizador.
    /// Permite desacoplar a lógica (Controller) da apresentação (Console, Forms, etc.).
    /// </summary>
    public interface ICondominioView
    {
        /// <summary>
        /// Exibe uma mensagem informativa ao utilizador.
        /// </summary>
        void MostrarMensagem(string mensagem);

        /// <summary>
        /// Solicita a introdução de texto (string) ao utilizador.
        /// </summary>
        /// <param name="label">Texto da pergunta.</param>
        /// <returns>Texto introduzido.</returns>
        string LerTexto(string label);

        /// <summary>
        /// Solicita a introdução de um valor numérico decimal.
        /// </summary>
        /// <param name="label">Texto da pergunta.</param>
        /// <returns>Valor decimal válido.</returns>
        decimal LerDecimal(string label);

        /// <summary>
        /// Apresenta o menu principal e recolhe a opção escolhida.
        /// </summary>
        /// <returns>Número da opção escolhida.</returns>
        int MenuPrincipal();

        /// <summary>
        /// Apresenta o relatório financeiro completo com base nos dados fornecidos.
        /// </summary>
        /// <param name="dados">Objeto contendo os dados a exibir (espera-se do tipo Condominio).</param>
        void MostrarRelatorio(object dados);
    }
}