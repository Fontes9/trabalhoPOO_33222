/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Classe para o Inquilino (Arrendatário) de uma Fração.</description>
**/

using System;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Representa o Inquilino (arrendatário) de uma fração.
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Classe concreta que herda de Condomino.</remarks>
    public class Inquilino : Condomino
    {
        #region Methods
        #region Constructors

        /// <summary>
        /// Construtor com parâmetros. Chama o construtor base (Condomino).
        /// </summary>
        /// <param name="nome">Nome (herdado de Pessoa).</param>
        /// <param name="nif">NIF (herdado de Pessoa).</param>
        /// <param name="contacto">Contacto (herdado de Condomino).</param>
        public Inquilino(string nome, string nif, string contacto) : base(nome, nif, contacto)
        {
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Inquilino()
        {
        }
        #endregion
        #endregion
    }
}