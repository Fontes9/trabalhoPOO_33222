/*
* <copyright file="Proprietario.cs" company="IPCA">
* Copyright (c) 2025 All Rights Reserved
* </copyright>
* <author>Tiago Barroso Fontes (33222)</author>
* <description>Classe Proprietário derivada de Pessoa.</description>
*/
using System;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa um Proprietário de uma fração.
    /// Herda de <see cref="Pessoa"/> e adiciona informações de contacto.
    /// </summary>
    [Serializable]
    public class Proprietario : Pessoa
    {
        string contacto;

        /// <summary>
        /// Inicializa um novo Proprietário.
        /// </summary>
        /// <param name="nome">Nome do proprietário.</param>
        /// <param name="nif">NIF do proprietário.</param>
        /// <param name="contacto">Contacto telefónico ou email.</param>
        public Proprietario(string nome, string nif, string contacto) : base(nome, nif)
        {
            this.contacto = contacto;
        }

        /// <summary>
        /// Obtém o contacto do proprietário.
        /// </summary>
        public string Contacto { get { return contacto; } }
    }
}