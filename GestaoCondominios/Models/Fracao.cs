/*
* <copyright file="Fracao.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Representa uma fração do condomínio.</description>
*/
using System;
using System.Collections.Generic;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa uma unidade habitacional (Fração) do condomínio.
    /// </summary>
    [Serializable]
    public class Fracao
    {
        #region Attributes
        string identificador;
        double permilagem;
        Proprietario proprietario;
        List<Quota> quotas;
        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa uma nova fração.
        /// </summary>
        /// <param name="id">Identificador único (ex: "A", "B").</param>
        /// <param name="permilagem">Valor da permilagem (0 a 1000).</param>
        /// <param name="prop">Proprietário associado.</param>
        public Fracao(string id, double permilagem, Proprietario prop)
        {
            this.identificador = id;
            this.permilagem = permilagem;
            this.proprietario = prop;
            this.quotas = new List<Quota>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Identificador da fração (ex: Letra ou Número da porta).
        /// </summary>
        public string Identificador => identificador;

        /// <summary>
        /// Valor da permilagem usado para cálculo de despesas.
        /// </summary>
        public double Permilagem => permilagem;

        /// <summary>
        /// Proprietário atual da fração.
        /// </summary>
        public Proprietario Proprietario => proprietario;

        /// <summary>
        /// Lista de quotas (dívidas) atribuídas a esta fração.
        /// </summary>
        public List<Quota> Quotas => quotas;
        #endregion

        #region Methods
        /// <summary>
        /// Calcula e atribui uma quota a esta fração com base numa despesa global.
        /// </summary>
        /// <param name="valorTotal">Valor total da despesa do condomínio.</param>
        /// <param name="desc">Descrição da despesa para referência.</param>
        /// <remarks>
        /// Fórmula: (ValorTotal * Permilagem) / 1000.
        /// Adiciona um novo objeto <see cref="Quota"/> à lista interna.
        /// </remarks>
        public void GerarQuota(decimal valorTotal, string desc)
        {
            decimal valorPagar = (valorTotal * (decimal)permilagem) / 1000;
            quotas.Add(new Quota(valorPagar, desc));
        }
        #endregion
    }
}