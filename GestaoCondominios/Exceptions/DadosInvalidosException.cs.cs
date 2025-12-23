/*
* <copyright file="DadosInvalidosException.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
*/
using System;

namespace GestaoCondominios.Exceptions
{
    [Serializable]
    public class DadosInvalidosException : ApplicationException
    {
        public DadosInvalidosException() : base("Dados Inválidos detectados.") { }

        public DadosInvalidosException(string message) : base(message) { }

        public DadosInvalidosException(string message, Exception inner) : base(message, inner) { }
    }
}