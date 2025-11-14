/*
* <author>Tiago Barroso Fontes (33222)</author>
* <date>11/14/2025</date>
*	<description>Classe de gestão de todos os Condomínios da empresa.</description>
**/

using System;

namespace GestaoCondominios
{
    /// <summary>
    /// Purpose: Classe estática para gerir a coleção de Condomínios da empresa.
    /// Created by: Tiago Barroso Fontes (33222)
    /// </summary>
    /// <remarks>Controla todos os condomínios num array estático.</remarks>
    public static class GestaoCondominios
    {
        #region Attributes
        const int MAX_CONDOMINIOS = 50;
        static string nomeEmpresa;
        static int totalCondominios;
        static Condominio[] listaCondominios;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Construtor Estático. Inicializa os arrays e dados da empresa.
        /// </summary>
        static GestaoCondominios()
        {
            nomeEmpresa = "Empresa de Gestão de Condomínios, SA";
            totalCondominios = 0;
            listaCondominios = new Condominio[MAX_CONDOMINIOS];
        }
        #endregion

        #region Properties
        /// <summary>
        /// Propriedade para o Nome da Empresa gestora.
        /// </summary>
        public static string NomeEmpresa
        {
            get { return nomeEmpresa; }
            set { nomeEmpresa = value; }
        }

        /// <summary>
        /// Obtém o número total de condomínios geridos.
        /// </summary>
        public static int TotalCondominios
        {
            get { return totalCondominios; }
        }
        #endregion

        #region OtherMethods

        /// <summary>
        /// Insere um novo condomínio no sistema.
        /// </summary>
        /// <param name="c">Objeto Condominio a inserir.</param>
        /// <returns>True se inserido, False se já existir ou o array estiver cheio.</returns>
        public static bool InserirCondominio(Condominio c)
        {
            if (ExisteCondominio(c.IdCondominio)) return false;

            if (totalCondominios < MAX_CONDOMINIOS)
            {
                listaCondominios[totalCondominios++] = c;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica se um condomínio existe pelo seu ID.
        /// </summary>
        /// <param name="id">ID do condomínio a procurar.</param>
        /// <returns>True se existe, False caso contrário.</returns>
        public static bool ExisteCondominio(int id)
        {
            for (int i = 0; i < totalCondominios; i++)
            {
                if (listaCondominios[i].IdCondominio == id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Mostra na consola todos os condomínios geridos.
        /// </summary>
        public static void MostrarTodosCondominios()
        {
            Console.WriteLine(NomeEmpresa);
            for (int i = 0; i < totalCondominios; i++)
            {
                Console.WriteLine(listaCondominios[i].IdCondominio + listaCondominios[i].Morada);
            }
            Console.WriteLine(" ");
        }
        #endregion

        #endregion
    }
}