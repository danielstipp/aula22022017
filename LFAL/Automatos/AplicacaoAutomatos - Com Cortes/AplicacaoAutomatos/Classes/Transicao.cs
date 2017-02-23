using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoAutomatos.Classes
{
    /// <summary>
    /// Classe que representa uma transição entre dois estados.
    /// </summary>
    public class Transicao
    {

        #region Atributos

        /// <summary>
        /// O estado origem da transição.
        /// </summary>
        public Estado Origem { get; set; }
        /// <summary>
        /// O estado destino da transição.
        /// </summary>
        public Estado Destino { get; set; }

        /// <summary>
        /// Os símbolos que podem ser consumidos por esta transição.
        /// </summary>
        public string Simbolo { get; set; }



        /// <summary>
        /// Retorna simbolos separados por vírgula.
        /// </summary>
        public string SimbolosSeparados
        {
            get
            {
                string dadosFormatados = String.Empty;
                if (Simbolo.Length > 0)
                {
                    dadosFormatados = Simbolo[0].ToString();
                    for (int i = 1; i < Simbolo.Length; i++)
                    {
                        dadosFormatados += Simbolo[i].ToString();
                    }
                }
                return dadosFormatados;
            }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova transição.
        /// </summary>
        /// <param name="origem">Estado origem da transição.</param>
        /// <param name="simbolo">Símbolos que podem ser consumidos nesta transição.</param>
        /// <param name="destino">Estado destino da transição.</param>
        public Transicao(Estado origem, string simbolo, Estado destino)
        {
            Origem = origem;
            Simbolo = simbolo;
            Destino = destino;



        }

        #endregion

    }
}
