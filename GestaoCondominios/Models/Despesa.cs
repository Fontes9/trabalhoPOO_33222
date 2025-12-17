/*
* <copyright file="Despesa.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Representa uma despesa financeira.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa uma despesa financeira registada no condomínio.
    /// Contém o valor, descrição, tipo e a data em que foi criada.
    /// </summary>
    [Serializable]
    public class Despesa
    {
        #region Attributes
        decimal valor;
        string descricao;
        string tipo;
        DateTime data;
        #endregion

        /// <summary>
        /// Cria uma nova despesa e atribui a data atual automaticamente.
        /// </summary>
        /// <param name="valor">Valor monetário da despesa.</param>
        /// <param name="descricao">Descrição detalhada.</param>
        /// <param name="tipo">Categoria da despesa (ex: Água, Luz, Elevador).</param>
        public Despesa(decimal valor, string descricao, string tipo)
        {
            this.valor = valor;
            this.descricao = descricao;
            this.tipo = tipo;
            this.data = DateTime.Now;
        }

        /// <summary>
        /// Obtém o valor da despesa.
        /// </summary>
        public decimal Valor => valor;

        /// <summary>
        /// Retorna a descrição formatada da despesa com data e valor.
        /// </summary>
        public override string ToString() => $"{data.ToShortDateString()} - {descricao}: {valor:C}";
    }
}