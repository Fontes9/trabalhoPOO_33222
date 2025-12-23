/*
* <copyright file="DadosInvalidosException.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
*/
using System;

namespace GestaoCondominios.Exceptions
{
    /// <summary>
    /// Exceção personalizada para validação de dados.
    /// Segue o padrão da aula: Herda de ApplicationException.
    /// </summary>
    [Serializable]
    public class DadosInvalidosException : ApplicationException
    {
        #region CONSTRUTORES

        /// <summary>
        /// Construtor padrão com mensagem predefinida.
        /// </summary>
        public DadosInvalidosException() : base("Dados Inválidos detectados.")
        {
        }

        /// <summary>
        /// Construtor que recebe uma mensagem de erro específica.
        /// </summary>
        /// <param name="message">A mensagem de erro.</param>
        public DadosInvalidosException(string message) : base(message)
        {
        }

        /// <summary>
        /// Construtor que recebe mensagem e a exceção original (Inner Exception).
        /// </summary>
        /// <param name="message">Mensagem de erro.</param>
        /// <param name="e">Exceção original.</param>
        public DadosInvalidosException(string message, Exception e) : base(message, e)
        {
        }

        #endregion
    }
}