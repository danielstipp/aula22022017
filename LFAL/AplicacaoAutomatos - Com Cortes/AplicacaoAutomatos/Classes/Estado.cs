using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoAutomatos.Classes
{

    /// <summary>
    /// Classe que representa um estado do Autômato.
    /// </summary>
    public class Estado
    {

        #region Atributos

        /// <summary>
        /// Indica se o estado é final ou não.
        /// </summary>
        public bool Final { get; set; }
        /// <summary>
        /// O nome do estado.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// A lista de transiçõoes que partem deste estado.
        /// </summary>
        public List<Transicao> Transicoes { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância da classe estado.
        /// </summary>
        public Estado()
            : this("q0", false)
        {
        }

        /// <summary>
        /// Cria nova estado.
        /// </summary>
        /// <param name="nome">O nome do estado.</param>
        public Estado(string nome, bool final)
        {
            Transicoes = new List<Transicao>();
            Nome = nome;
            Final = final;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona transição para o estado destino com consumo de símbolo.
        /// </summary>
        /// <param name="destino">O estado destino da transição.</param>
        /// <param name="simbolos">Símbolo a ser consumido.</param>
        public void AdicionarTransicao(Estado destino, params char[] simbolos)
        {

            AdicionarTransicao(destino, String.Join(String.Empty, simbolos));
        }

        /// <summary>
        /// Adiciona transição para o estado destino com consumo de símbolo.
        /// </summary>
        /// <param name="destino">O estado destino da transição.</param>
        /// <param name="simbolos">Símbolo a ser consumido.</param>
        public void AdicionarTransicao(Estado destino, string simbolos)
        {
            
        }

        /// <summary>
        /// Busca por uma transição válida.
        /// </summary>
        /// <param name="estado">O estado origem.</param>
        /// <param name="simbolo">O símbolo a ser consumido.</param>
        /// <returns>A transição encontrada. Caso não encontre retorna null.</returns>
        public Transicao BuscaTransicao(char simbolo)
        {
            return null;
        }

        #endregion

    }
}
