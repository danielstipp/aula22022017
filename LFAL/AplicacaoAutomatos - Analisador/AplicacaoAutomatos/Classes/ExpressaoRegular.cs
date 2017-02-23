using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoAutomatos.Classes
{
    /// <summary>
    /// Classe que cria e avalia expressões regulares.
    /// </summary>
    public class ExpressaoRegular
    {
        
        /// <summary>
        /// Instância do autômato que fará a validação da expressão regular.
        /// </summary>
        private Automato automato;

        /// <summary>
        /// Instância do autômato que fará a validação da expressão regular.
        /// </summary>
        public Automato Automato
        {
            get { return automato; }
        }

        /// <summary>
        /// Cria nova expressão regular.
        /// </summary>
        /// <param name="padrao">Padrão a ser analisado.</param>
        public ExpressaoRegular(string padrao)
        {
            automato = new Automato("0", false);
            CriaAutomato(padrao);
        }

        /// <summary>
        /// Valida o texto.
        /// </summary>
        /// <param name="texto">O texto a ser validado.</param>
        /// <returns>Valor indicando se é válido ou não.</returns>
        public bool Validar(string texto)
        {
            return automato.Validar(texto);
        }

        /// <summary>
        /// Cria o autômato a partir da string.
        /// </summary>
        /// <param name="padrao">O padrão a ser avaliado.</param>
        private void CriaAutomato(string padrao)
        {
            int estado = 0;
            int indice = 0;
            int[] ultimosEstados = new int[] { 0 };
            // Faz replace dos operadores * e + pelos operadores de tamanho para facilitar a implementação..
            string expressao = padrao.Replace("*", "{0,}").Replace("+", "{1,}").Replace("?", "{0,1}").Replace(" ", String.Empty);
            for (indice = 0; indice < expressao.Length - 1; indice++)
            {
                char simbolo = Char.ToLower(expressao[indice]);
                char proximoSimbolo = Char.ToLower(expressao[indice + 1]);
                // Verifica o símbolo..
                if (proximoSimbolo == '{')
                {
                    int indiceFechamento = expressao.IndexOf("}", indice + 1);
                    string repeticao = expressao.Substring(indice + 2, indiceFechamento - indice - 2);
                    ultimosEstados = AnalisaRepeticao(repeticao, estado, simbolo, ultimosEstados);
                    estado = ultimosEstados.Last();
                    // Determina que o índice caminhe até o final da operação..
                    indice = indiceFechamento;
                }
                else
                {
                    automato.AdicionarEstado((estado + 1).ToString(), false);
                    // Adiciona transição dos últimos estados..
                    foreach (int estadoAnterior in ultimosEstados)
                    {
                        automato.AdicionarTransicao(estadoAnterior.ToString(), (estado + 1).ToString(), simbolo);
                    }
                    estado++;
                    // Zera a lista de estados..
                    ultimosEstados = new int[] { estado };
                }
            }
            if (indice < expressao.Length)
            {
                estado++;
                // Adiciona transição para o estado final..
                automato.AdicionarEstado(estado.ToString(), true);
                // Adiciona transição dos últimos estados..
                foreach (int estadoAnterior in ultimosEstados)
                {
                    automato.AdicionarTransicao(estadoAnterior.ToString(), estado.ToString(), expressao[indice]);
                }
            }
            else
            {
                foreach (int estadoAnterior in ultimosEstados)
                {
                    automato.DefinirEstadoFinal(estadoAnterior.ToString(), true);
                }
            }
        }

        /// <summary>
        /// Análisa a operação de repetição.
        /// </summary>
        /// <param name="expressao">A expressão de repetição a ser avaliada.</param>
        /// <param name="estado">O último estado criado.</param>
        /// <param name="repeticao">O símbolo consumido na repetição.</param>
        /// <param name="simbolo">Os últimos estados finais.ç</param>
        private int[] AnalisaRepeticao(string repeticao, int estado, char simbolo, int[] ultimosEstados)
        {
            bool operadorFixo = repeticao.IndexOf(",") < 0;
            string[] partes = repeticao.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> estadosFinais = new List<int>();
            // Verifica quantas partes existem..
            int min = Int32.Parse(partes[0]);
            int max = Int32.MaxValue;
            if (partes.Length > 1)
            {
                max = Int32.Parse(partes[1]);
            }
            // Cria estados para definir o número minimo de símbolos..
            for (int i = 0; i < min; i++)
            {
                automato.AdicionarEstado((estado + 1).ToString(), false);
                // Adiciona transição dos últimos estados..
                foreach (int estadoAnterior in ultimosEstados)
                {
                    automato.AdicionarTransicao(estadoAnterior.ToString(), (estado + 1).ToString(), simbolo);
                }
                estado++;
                ultimosEstados = new int[] { estado };
            }
            // Caso não exista limite, adiciona auto repetição..
            if (!operadorFixo && max == Int32.MaxValue)
            {
                automato.AdicionarTransicao(estado.ToString(), estado.ToString(), simbolo);
            }
            estadosFinais.Add(estado);
            // Caso exista limite, garantir acesso ao máximo e gravar estados finais..
            if (!operadorFixo && max != Int32.MaxValue)
            {
                for (int i = 0; i < (max - min); i++)
                {
                    automato.AdicionarEstado((estado + 1).ToString(), false);
                    automato.AdicionarTransicao(estado.ToString(), (estado + 1).ToString(), simbolo);
                    estado++;
                    ultimosEstados = new int[] { estado };
                    estadosFinais.Add(estado);
                }
            }
            return estadosFinais.ToArray();
        }

    }
}
