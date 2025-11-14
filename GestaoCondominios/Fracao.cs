/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Representa uma fração de um condomínio.</description>
**/

using System;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Representa uma fração (unidade) de um Condomínio.
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Agrega o Proprietário e (opcionalmente) o Inquilino.</remarks>
    public class Fracao
    {
        #region Attributes
        string identificador;
        double permilagem;
        Proprietario proprietario;
        Inquilino inquilino;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// Construtor por omissão.
        /// </summary>
        public Fracao()
        {
            identificador = String.Empty;
            permilagem = 0;
            proprietario = null;
            inquilino = null;
        }

        /// <summary>
        /// Construtor com parâmetros.
        /// </summary>
        /// <param name="id">Identificador da fração (ex: 1ºA).</param>
        /// <param name="permilagem">Permilagem da fração.</param>
        /// <param name="p">Proprietário da fração.</param>
        public Fracao(string id, double permilagem, Proprietario p)
        {
            this.identificador = id;
            this.permilagem = permilagem;
            this.proprietario = p;
            this.inquilino = null;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Identificador da fração (ex: '1º A').
        /// </summary>
        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        /// <summary>
        /// Permilagem da fração (para cálculo de quotas).
        /// </summary>
        public double Permilagem
        {
            get { return permilagem; }
            set { permilagem = value; }
        }

        /// <summary>
        /// O Proprietário associado a esta fração.
        /// </summary>
        public Proprietario Proprietario
        {
            get { return proprietario; }
            set { proprietario = value; }
        }

        /// <summary>
        /// O Inquilino opcional associado a esta fração.
        /// </summary>
        public Inquilino Inquilino
        {
            get { return inquilino; }
            set { inquilino = value; }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Fracao()
        {
        }
        #endregion

        #endregion
    }
}