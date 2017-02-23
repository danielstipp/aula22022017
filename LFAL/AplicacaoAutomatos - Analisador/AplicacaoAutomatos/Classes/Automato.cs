using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoAutomatos.Classes
{
    /// <summary>
    /// Classe que representa um autômato.
    /// </summary>
    public class Automato
    {

        #region Atributos

        /// <summary>
        /// 
        /// O estado inicial do autômato.
        /// </summary>
        private Estado estadoInicial;

        #endregion

        #region Propriedades

        /// <summary>
        /// O estado inicial do autômato.
        /// </summary>
        public Estado EstadoInicial
        {
            get { return estadoInicial; }
        }
        /// <summary>
        /// Lista de estados.
        /// </summary>
        public Dictionary<string, Estado> Estados { get; private set; }
        
        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do automato.
        /// </summary>
        /// <param name="estadoInicial">O nome do estado inicial.</param>
        /// <param name="alfabeto">O alfabeto do autômato.</param>
        /// <param name="final">Indica se estado inicial é final.</param>
        public Automato(string estadoInicial, bool final)
        {
            this.Estados = new Dictionary<string, Estado>();
            // Cria estado e adiciona..
            this.estadoInicial = new Estado(estadoInicial, final);
            this.Estados.Add(estadoInicial, this.estadoInicial);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona novo estado.
        /// </summary>
        /// <param name="nomeEstado">O nome do estado.</param>
        /// <param name="final">Indica se o estado é final.</param>
        public void AdicionarEstado(string nomeEstado, bool final)
        {
            if (!Estados.ContainsKey(nomeEstado))
            {
                Estados.Add(nomeEstado, new Estado(nomeEstado, final));
            }
        }

        /// <summary>
        /// Definir se o estado é final ou não.
        /// </summary>
        /// <param name="nomeEstado">O nome do estado.</param>
        /// <param name="final">Indicação se é final ou inicial.</param>
        public void DefinirEstadoFinal(string nomeEstado, bool final)
        {
            if (Estados.ContainsKey(nomeEstado))
            {
                Estados[nomeEstado].Final = final;
            }
        }

        /// <summary>
        /// Adiciona transição entre 2 estados.
        /// </summary>
        /// <param name="estadoOrigem">O estado origem do autômato.</param>
        /// <param name="simbolos">O símbolo a ser avaliado.</param>
        /// <param name="estadoDestino">O estado destino.</param>
        public void AdicionarTransicao(string estadoOrigem, string estadoDestino, params char[] simbolos)
        {
            // Adiciona transições..
            if (Estados.ContainsKey(estadoOrigem) && Estados.ContainsKey(estadoDestino))
            {
                Estados[estadoOrigem].AdicionarTransicao(Estados[estadoDestino], simbolos);
            }
        }

        /// <summary>
        /// Adiciona transição entre 2 estados.
        /// </summary>
        /// <param name="estadoOrigem">O estado origem do autômato.</param>
        /// <param name="simbolos">O símbolo a ser avaliado.</param>
        /// <param name="estadoDestino">O estado destino.</param>
        public void AdicionarTransicao(string estadoOrigem, string estadoDestino, string simbolos)
        {
            // Adiciona transições..
            if (Estados.ContainsKey(estadoOrigem) && Estados.ContainsKey(estadoDestino))
            {
                Estados[estadoOrigem].AdicionarTransicao(Estados[estadoDestino], simbolos);
            }
        }

        /// <summary>
        /// Busca por uma transição válida.
        /// </summary>
        /// <param name="estado">O estado origem.</param>
        /// <param name="simbolo">O símbolo a ser consumido.</param>
        /// <returns>A transição encontrada. Caso não encontre retorna null.</returns>
        private Transicao BuscaTransicao(Estado estado, char simbolo)
        {
            return estado.BuscaTransicao(simbolo);
        }

        /// <summary>
        /// Valida o texto através da estrutura do autômato.
        /// </summary>
        /// <param name="texto">O texto a ser validado.</param>
        /// <returns>Um valor indicando se o texto é válido ou não.</returns>
        public bool Validar(string texto)
        {
            Estado estado = estadoInicial;
            int posicao = 0;
            int tamanho = texto.Length;
            // Percorre a cadeia de caracteres..
            while (posicao < tamanho)
            {
                Transicao transicao = BuscaTransicao(estado, texto[posicao]);
                if (transicao != null)
                {
                    estado = transicao.Destino;
                    posicao++;
                }
                else
                {
                    return false;
                }
            }
            return estado.Final;
        }

        #endregion

    }
}
