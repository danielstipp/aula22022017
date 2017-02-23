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
            List<int> loopestados = new List<int> { };
            List<char> loopsimbolos = new List<char> { };
            int[] ultimosEstados = new int[] { 0 };
            // Faz replace dos operadores * e + pelos operadores de tamanho para facilitar a implementação..
            //padrao = "busca&abc&123";
            string expressao = verificaEcomercial(padrao);
            expressao = expressao.Replace("*", "{0,}").Replace("+", "{1,}").Replace("?", "{0,1}").Replace(" ", String.Empty);
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
                    if (simbolo == '(')
                    {
                        //Pega os dados para o loop
                        int estadoloop = estado + 1;
                        char simbololoop = Char.ToLower(expressao[indice + 1]);

                        loopestados.Add(estadoloop);
                        loopsimbolos.Add(simbololoop);

                        //automato.AdicionarEstado((estado + 1).ToString(), false);
                        //automato.AdicionarTransicao((estado).ToString(), (estado + 1).ToString(), simbolo);
                        // Adiciona transição dos últimos estados..

                        //int j = 1;
                        for (int i = indice + 1; i < expressao.Length; i++)
                        {
                            if (expressao[i] != ')')
                            {
                                if (expressao.Length - 2 == i)
                                {
                                    if (Char.ToLower(expressao[i + 1]) == '(')
                                        automato.AdicionarEstado((estado + 1).ToString(), true);
                                    else
                                        automato.AdicionarEstado((estado + 1).ToString(), false);
                                }
                                else
                                {
                                    if (Char.ToLower(expressao[i + 2]) == '(')
                                        automato.AdicionarEstado((estado + 1).ToString(), true);
                                    else
                                        automato.AdicionarEstado((estado + 1).ToString(), false);
                                }
                                automato.AdicionarTransicao((estado).ToString(), (estado + 1).ToString(), expressao[i]);
                                estado++;
                            }
                            else
                                break;

                            if (indice == expressao.Length - 1)
                                indice = i;
                            if (Char.ToLower(expressao[i + 1]) == ')')
                                indice = i + 1;
                        }

                        automato.AdicionarTransicao((estado).ToString(), (estadoloop).ToString(), simbololoop);
                        //estado++;
                        // Zera a lista de estados..
                        ultimosEstados = new int[] { estado };
                        //indice = indice + 1;
                    }
                    else
                    {
                        //Se houver um inicio de loop, considerar o estado antes como final
                        if (Char.ToLower(expressao[indice + 1]) == '(')
                            automato.AdicionarEstado((estado + 1).ToString(), true);
                        else
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

            if (loopestados.Count > 1)
            {
                for (int i = 0; i < loopestados.Count; i++)
                {
                    for (int j = 1; j < loopestados.Count; j++)
                    {
                        automato.AdicionarTransicao((loopestados[i] - 1).ToString(), (loopestados[j]).ToString(), loopsimbolos[j]);
                    }
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

        private string verificaEcomercial(string expressao)
        {
            bool existe = true;
            int inicio, fim;

            while (existe)
            {
                bool check = expressao.Contains("&");
                if (check)
                {
                    inicio = expressao.IndexOf("&");
                    fim = -1;

                    for (int i = inicio + 1; i < expressao.Length - 1; i++)
                    {
                        if (expressao[i] == '*' || expressao[i] == '+' || expressao[i] == '?')
                            fim = i - 2;
                        else if (expressao[i] == '&')
                            fim = i - 1;

                        if (fim != -1)
                            i = expressao.Length - 1;
                    }

                    if (fim == -1)
                        fim = expressao.Length - 1;

                    if (inicio == 0)
                    {
                        expressao = "(" + expressao.Substring(inicio + 1, fim - inicio) +
                                    ")" + expressao.Substring(fim + 1, expressao.Length - 1);
                    }
                    else
                    {
                        if (fim != expressao.Length - 1)
                            expressao = expressao.Substring(0, inicio) + "(" + expressao.Substring(inicio + 1, fim - inicio) +
                                    ")" + expressao.Substring(fim + 1, expressao.Length - 1 - fim);
                        else
                            expressao = expressao.Substring(0, inicio) + "(" + expressao.Substring(inicio + 1, fim - inicio) +
                                    ")";
                        fim++;
                    }

                }
                else
                {
                    existe = false;
                }
            }

            return expressao;

        }
    }
}
