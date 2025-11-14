/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Classe abstrata para Condóminos.</description>
**/

using System;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Representa um Condómino (Proprietário ou Inquilino).
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Herda de Pessoa e adiciona Contacto.</remarks>
    public abstract class Condomino : Pessoa
    {
        #region Attributes
        string contacto;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor por omissão. Chama o construtor base.
        /// </summary>
        public Condomino() : base()
        {
            this.contacto = String.Empty;
        }

        /// <summary>
        /// Construtor com parâmetros. Chama o construtor base.
        /// </summary>
        /// <param name="nome">Nome (herdado de Pessoa).</param>
        /// <param name="nif">NIF (herdado de Pessoa).</param>
        /// <param name="contacto">Contacto do Condómino.</param>
        public Condomino(string nome, string nif, string contacto) : base(nome, nif)
        {
            this.contacto = contacto;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o Contacto do Condómino.
        /// </summary>
        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Condomino()
        {
        }
        #endregion

        #endregion
    }
}