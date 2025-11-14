/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Classe base para Pessoas</description>
**/

using System;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Classe base abstrata para representar uma Pessoa.
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Define os atributos comuns a todos os intervenientes.</remarks>
    public abstract class Pessoa
    {
        #region Attributes
        string nome;
        string nif;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor por omissão.
        /// </summary>
        public Pessoa()
        {
            nome = String.Empty;
            nif = String.Empty;
        }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="nome">Nome da Pessoa.</param>
        /// <param name="nif">NIF da Pessoa.</param>
        public Pessoa(string nome, string nif)
        {
            this.nome = nome;
            this.nif = nif;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o Nome da Pessoa.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade para o NIF da Pessoa.
        /// </summary>
        public string Nif
        {
            get { return nif; }
            set { nif = value; }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Formata a Pessoa como string.
        /// </summary>
        /// <returns>String formatada (Nome, NIF).</returns>
        public override string ToString()
        {
            return String.Format("Nome: {0} - NIF: {1}", nome, nif);
        }

        /// <summary>
        /// Verifica se dois objetos Pessoa são iguais (baseado no NIF).
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True se forem iguais, False caso contrário.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Pessoa)
            {
                Pessoa p = obj as Pessoa;
                return (this.nif == p.Nif);
            }
            return false;
        }

        /// <summary>
        /// Gera um hash code baseado no NIF (para cumprir a regra CS0659).
        /// </summary>
        /// <returns>O hash code do NIF.</returns>
        public override int GetHashCode()
        {
            return (nif != null ? nif.GetHashCode() : 0);
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Pessoa()
        {
        }
        #endregion

        #endregion
    }
}