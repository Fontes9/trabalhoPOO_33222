using System;
using System.Collections.Generic;

namespace GestaoCondominios.Models
{
    /// <summary>
    /// Representa o Condomínio e atua como a classe principal (Aggregate Root) do sistema.
    /// Gere a lista de frações e o histórico de despesas.
    /// </summary>
    [Serializable]
    public class Condominio
    {
        #region Attributes
        private string morada;
        private List<Fracao> fracoes;
        private List<Despesa> despesas;
        #endregion

        #region Constructors
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Condominio"/>.
        /// </summary>
        /// <param name="morada">A morada ou nome do edifício.</param>
        public Condominio(string morada)
        {
            this.morada = morada;
            this.fracoes = new List<Fracao>();
            this.despesas = new List<Despesa>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Obtém a morada do condomínio.
        /// </summary>
        public string Morada { get { return morada; } }

        /// <summary>
        /// Obtém a lista de frações pertencentes ao condomínio.
        /// </summary>
        public List<Fracao> Fracoes { get { return fracoes; } }

        /// <summary>
        /// Obtém o histórico de despesas lançadas.
        /// </summary>
        public List<Despesa> Despesas { get { return despesas; } }
        #endregion

        #region Methods
        /// <summary>
        /// Adiciona uma nova fração à lista do condomínio.
        /// </summary>
        /// <param name="f">Objeto fração a adicionar.</param>
        public void AdicionarFracao(Fracao f)
        {
            fracoes.Add(f);
        }

        /// <summary>
        /// Regista uma nova despesa global e distribui o valor pelas frações (Gera Quotas).
        /// </summary>
        /// <param name="valor">O valor total da despesa.</param>
        /// <param name="desc">Descrição da despesa (ex: "Limpeza").</param>
        /// <param name="tipo">Categoria da despesa (ex: "Manutenção").</param>
        /// <remarks>
        /// Este método executa dois passos:
        /// 1. Cria e guarda o registo da <see cref="Despesa"/>.
        /// 2. Itera sobre todas as frações e invoca o método <see cref="Fracao.GerarQuota"/> para calcular a parte de cada uma.
        /// </remarks>
        public void InserirDespesa(decimal valor, string desc, string tipo)
        {
            // 1. Guarda a despesa no histórico
            despesas.Add(new Despesa(valor, desc, tipo));

            // 2. Manda cada fração calcular a sua parte
            foreach (Fracao f in fracoes)
            {
                f.GerarQuota(valor, desc);
            }
        }
        #endregion
    }
}