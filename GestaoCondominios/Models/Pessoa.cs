/*
* <copyright file="Pessoa.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Classe base para pessoas.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Classe base abstrata que representa um indivíduo no sistema.
    /// Define atributos comuns como Nome e NIF.
    /// </summary>
    [Serializable]
    public abstract class Pessoa
    {
        #region Attributes
        string nome;
        string nif;
        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Pessoa"/>.
        /// </summary>
        /// <param name="nome">Nome completo da pessoa.</param>
        /// <param name="nif">Número de Identificação Fiscal.</param>
        public Pessoa(string nome, string nif)
        {
            this.nome = nome;
            this.nif = nif;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Obtém ou define o nome da pessoa.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Obtém ou define o NIF da pessoa.
        /// </summary>
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Retorna uma representação textual da pessoa.
        /// </summary>
        /// <returns>String formatada com Nome e NIF.</returns>
        public override string ToString()
        {
            return String.Format("{0} (NIF: {1})", nome, nif);
        }
        #endregion
    }
}