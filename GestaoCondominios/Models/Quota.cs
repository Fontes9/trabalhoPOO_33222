/*
* <copyright file="Quota.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Representa uma dívida de uma fração.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa uma dívida (obrigação de pagamento) atribuída a uma fração específica.
    /// </summary>
    [Serializable]
    public class Quota
    {
        decimal valor;
        bool estaPaga;
        string referencia;

        /// <summary>
        /// Inicializa uma nova quota.
        /// </summary>
        /// <param name="valor">Valor a pagar.</param>
        /// <param name="referencia">Descrição ou referência da despesa original.</param>
        public Quota(decimal valor, string referencia)
        {
            this.valor = valor;
            this.referencia = referencia;
            this.estaPaga = false; // Por omissão, a quota inicia como não paga
        }

        /// <summary>
        /// Valor monetário da quota.
        /// </summary>
        public decimal Valor { get { return valor; } }

        /// <summary>
        /// Indica se a quota já foi liquidada.
        /// </summary>
        public bool EstaPaga { get { return estaPaga; } }

        /// <summary>
        /// Marca a quota como paga.
        /// </summary>
        public void Pagar()
        {
            this.estaPaga = true;
        }

        /// <summary>
        /// Formata a quota para exibição (mostra estado PAGA/EM DÍVIDA).
        /// </summary>
        public override string ToString()
        {
            return $"Ref: {referencia} | {valor:F2}€ | {(estaPaga ? "PAGA" : "EM DÍVIDA")}";
        }
    }
}