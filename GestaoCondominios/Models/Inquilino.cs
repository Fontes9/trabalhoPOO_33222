/*
* <copyright file="Inquilino.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Classe Inquilino derivada de Pessoa.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa um Inquilino (arrendatário) de uma fração.
    /// Herda de <see cref="Pessoa"/>.
    /// </summary>
    [Serializable]
    public class Inquilino : Pessoa
    {
        string contacto;

        /// <summary>
        /// Inicializa um novo Inquilino.
        /// </summary>
        /// <param name="nome">Nome do inquilino.</param>
        /// <param name="nif">NIF do inquilino.</param>
        /// <param name="contacto">Contacto direto.</param>
        public Inquilino(string nome, string nif, string contacto) : base(nome, nif)
        {
            this.contacto = contacto;
        }
    }
}