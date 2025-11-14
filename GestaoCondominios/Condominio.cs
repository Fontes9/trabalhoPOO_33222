/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Classe que representa um Condomínio.</description>
**/

using System;
using System.Collections.Generic;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Representa um Condomínio, que gere múltiplas frações.
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Utiliza um array de tamanho fixo para gerir as frações.</remarks>
    public class Condominio
    {
        #region Attributes
        const int MAX_FRACOES = 100;
        int idCondominio;
        string morada;
        Fracao[] fracoes;
        int totalFracoes;


        static int idGlobalCondominio = 0;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor por omissão. Inicializa arrays e atribui um ID único.
        /// </summary>
        public Condominio()
        {
            this.idCondominio = ++idGlobalCondominio;
            this.morada = String.Empty;
            this.fracoes = new Fracao[MAX_FRACOES];
            this.totalFracoes = 0;
        }

        /// <summary>
        /// Construtor com parâmetros. Inicializa arrays e atribui um ID único.
        /// </summary>
        /// <param name="morada">Morada do condomínio.</param>
        public Condominio(string morada)
        {
            this.idCondominio = ++idGlobalCondominio;
            this.morada = morada;
            this.fracoes = new Fracao[MAX_FRACOES];
            this.totalFracoes = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Obtém o ID único do Condomínio.
        /// </summary>
        public int IdCondominio
        {
            get { return idCondominio; }
        }

        /// <summary>
        /// Propriedade para a Morada do Condomínio.
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        /// <summary>
        /// Obtém o número total de frações inseridas.
        /// </summary>
        public int TotalFracoes
        {
            get { return totalFracoes; }
        }
        #endregion

        #region OtherMethods
        /// <summary>
        /// Adiciona uma nova fração ao condomínio.
        /// </summary>
        /// <param name="f">Objeto Fracao a adicionar.</param>
        /// <returns>True se inserido com sucesso, False se o array estiver cheio.</returns>
        public bool AdicionarFracao(Fracao f)
        {

            if (totalFracoes < MAX_FRACOES)
            {
                fracoes[totalFracoes++] = f;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra na consola os detalhes das frações deste condomínio.
        /// </summary>
        public void MostrarFracoes()
        {
            for (int i = 0; i < totalFracoes; i++)
            {
                Console.WriteLine(fracoes[i].Identificador);
                Console.WriteLine(fracoes[i].Proprietario.Nome);
            }
        }
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Condominio()
        {
        }
        #endregion

        #endregion
    }
}