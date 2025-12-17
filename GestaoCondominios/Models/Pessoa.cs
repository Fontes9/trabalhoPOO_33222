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
    [Serializable]
    public abstract class Pessoa
    {
        #region Attributes
        string nome;
        string nif;
        #endregion

        #region Methods
        public Pessoa(string nome, string nif)
        {
            this.nome = nome;
            this.nif = nif;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} (NIF: {1})", nome, nif);
        }
        #endregion
    }
}