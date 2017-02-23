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





        public List<string> simbolosAutomato;

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

        public Automato()
        {
            
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
            foreach (KeyValuePair<string, Estado> k in Estados)
            {

                if (k.Key.ToString().Equals(nomeEstado))
                {
                    k.Value.Final = final;
                }
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
            Estado origem = null;
            Estado final = null;

            foreach (KeyValuePair<string,Estado> k in Estados)
            {

                if (k.Key.ToString().Equals(estadoOrigem))
                {
                    origem = k.Value;
                }

                if (k.Key.ToString().Equals(estadoDestino))
                {
                    final = k.Value;
                }
            }


            origem.AdicionarTransicao(final, simbolos);





            try { 
            if (simbolosAutomato.Count != 0)
            {
                foreach (string item in simbolosAutomato)
                {
                    if (item.Equals(simbolos[0].ToString()))
                    {
                        return;
                    }
                }
                simbolosAutomato.Add(simbolos[0].ToString());
            }
            }
            catch(Exception ex){

           
           
                simbolosAutomato = new List<string>();
                simbolosAutomato.Add(simbolos[0].ToString());
            
            }
        }

        public void ListaSimbolosTransicao()
        {

            

            
        }

        /// <summary>
        /// Adiciona transição entre 2 estados.
        /// </summary>
        /// <param name="estadoOrigem">O estado origem do autômato.</param>
        /// <param name="simbolos">O símbolo a ser avaliado.</param>
        /// <param name="estadoDestino">O estado destino.</param>
        public void AdicionarTransicao(string estadoOrigem, string estadoDestino, string simbolos)
        {

            AdicionarTransicao(estadoOrigem, estadoDestino, simbolos);
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
            Transicao transicao;

            int indice = default(int);

            while (indice < texto.Length)
            {
                transicao = BuscaTransicao(estado, texto[indice]);
                
                if (transicao != null)
                {
                    estado = transicao.Destino;
                    indice++;
                }
                else
                {
                    return false;
                }

            }

            return estado.Final;
        }


        public Automato ConverterAFD()
        {
            //
            int mascara = (1 << Estados.Count);
            int atual = 1;

            //Pesquisa nomes de todos os estados
            List<string> nomeEstados = ObterEstados();
            List<string> nomesEstadosAFD = new List<string>();

            //Novos estados
            List<string> novosEstados = new List<string>();


            while (atual < mascara)
            {
                string nomeEstado = string.Empty;

                for (int i = 0; i < nomeEstados.Count; i++)
                {
                    int pos = (1 << i);

                    //faz o e binario entre os numeros
                    if ((atual & pos) == pos)
                    {
                        nomeEstado += nomeEstados[i] + " ";
                    }
                }
                nomesEstadosAFD.Add(nomeEstado.Trim());

                novosEstados.Add("S"+(atual-1));
                atual++;    
                
            }
            //Ordena os nomes por tamanho e depois por valor
            nomesEstadosAFD = (from e in nomesEstadosAFD orderby e.Length, e select e).ToList();

            return MontarTabela(nomesEstadosAFD, novosEstados);


            
        }

        private Automato MontarTabela(List<string> nomesEstadosAFD, List<string> novosEstados)
        {
            string aux = string.Empty;
            string aux2 = string.Empty;
            List<string> transicoes = new List<string>();

            foreach (string nomes in nomesEstadosAFD)
            {
                foreach (string simbo in simbolosAutomato)
                {
                    var non = nomes.Split(' ');

                    foreach (var item in non)
                    {
                        Estado es = RetornaEstado(item.ToString(),this);
                        aux += Transicoes(es,simbo);

                    }

                    string newEst = MontaNovoEstado(aux);
                    aux = string.Empty;

                    //Verifica se é S0 ou S5 ou S2
                   aux2+= Verifica(nomesEstadosAFD, novosEstados, newEst) +" ";

                }
                transicoes.Add(aux2.Trim());
                aux2 = string.Empty;
            }

            RemoverEstados(transicoes, novosEstados,nomesEstadosAFD);

            return Automato2(transicoes, novosEstados, nomesEstadosAFD);

          //  return MontarAutomato(nomesEstadosAFD, possibilidades, novosEstados);
        }

        private Automato Automato2(List<string> transicoes, List<string> novosEstados, List<string> nomesEstadosAFD)
        {

            //AdcionarNovosEstados

            Automato aut = null;
           
            bool cond = false;
            bool firstTime = true;

            //Adciona Estados
            for (int i = 0; i < nomesEstadosAFD.Count; i++)
			{
                if (!nomesEstadosAFD[i].Equals(string.Empty))
                {
                    var non = nomesEstadosAFD[i].Split(' ');

                    foreach (var item in non)
                    {
                        Estado es = RetornaEstado(item.ToString(), this);
                        if (es.Final)
                        {
                            cond = true;
                        }
                    }

                    if (firstTime)
                    {
                        aut = new Automato(novosEstados[i], cond);
                        firstTime = false;
                    }
                    else
                    {
                        aut.AdicionarEstado(novosEstados[i], cond);
                    }
                    cond = false;
                }
             }


            //AdcionaTrnasicoes
           int cont = 0;
           int indice = 0;

                for (int i = 0; i < transicoes.Count; i++)
			    {
                    if (!transicoes[i].Equals(""))
                    {
                        var sep = transicoes[i].Split(' ');
                        foreach (var se in sep)
                        {
                            //Adcionar
                         //   Estado es = RetornaEstado(se.ToString(), aut);
                          //  item.Value.AdicionarTransicao(es, simbolosAutomato[i]);
                            aut.AdicionarTransicao(aut.Estados[("S"+cont)].Nome, se.ToString(), (simbolosAutomato[indice]).ToCharArray());
                            indice++;
                        }
                        indice = 0;
                    }
			         
                    cont++;
			    }
                  
            


            return aut;

         }

        private void RemoverEstados(List<string> transicoes, List<string> novosEstados, List<string> nomesEstadosAFD)
        {
            List<int> indicesRemove = new List<int>();
            bool cond = false;
            bool cond2 = true;
            while (cond2)
            {
                cond2 = false;
                for (int i = 0; i < novosEstados.Count; i++)
                {
                    foreach (string trans in transicoes)
                    {
                        var sep = trans.Split(' ');

                        foreach (var item in sep)
                        {
                            if (item.ToString().Equals(novosEstados[i]))
                            {
                                cond = true;
                            }
                        }

                    }

                    if (!cond)
                    {
                        indicesRemove.Add(i);
                        cond2 = true;
                    }
                    cond = false;
                    
                }
                foreach (int item in indicesRemove)
                {
                    novosEstados[item] = "";
                    nomesEstadosAFD[item] = "";
                    transicoes[item] = "";
                }
                indicesRemove.Clear();
            }



            





        }

        private string Verifica(List<string> nomesEstadosAFD, List<string> novosEstados,string est)
        {
            for (int i = 0; i < nomesEstadosAFD.Count; i++)
            {
                if (nomesEstadosAFD[i].Equals(est))
                {
                    return novosEstados[i];
                }
            }

            return null;

        }
        private string MontaNovoEstado(string esta)
        {

            esta = esta.Trim();
            List<string> estados = new List<string>();
            string ret = string.Empty;

            var sep = esta.Split(' ');

            foreach (var item in sep)
            {
                if (!estados.Contains(item.ToString()))
                {
                    estados.Add(item);
                }        
            }

            foreach (string item in estados)
            {
                ret += item + " ";
            }

            return ret.Trim();
        }

        public string Transicoes(Estado es, string simbolo)
        {
            string aux = string.Empty;

            foreach (Transicao tran in es.Transicoes)
            {
                if (simbolo.Equals(tran.Simbolo.ToString()))
                {
                    aux += tran.Destino.Nome + " ";     
                }  
            }

            return aux;


        
        }


           






    

        private List<string> ObterEstados()
        {
            List<string> nomes = new List<string>();

            foreach (KeyValuePair<string, Estado> k in Estados)
            {
                nomes.Add(k.Key);
            }

            return nomes;
        }

      

        public Estado RetornaEstado(string nomeFind,Automato aut)
        {
            foreach (KeyValuePair<string,Estado> est in aut.Estados)
            {
                if (nomeFind.Equals(est.Key))
                {
                    return est.Value;
                }
            }

            return null;
        }


        /*public Automato ConverterAFD_Closure()
        {

            List<string> closure = ObterClosure();

            //
            int mascara = (1 << Estados.Count);
            int atual = 1;

            //Pesquisa nomes de todos os estados
            List<string> nomeEstados = ObterEstados();
            List<string> nomesEstadosAFD = new List<string>();

            //Novos estados
            List<string> novosEstados = new List<string>();


            while (atual < mascara)
            {
                string nomeEstado = string.Empty;

                for (int i = 0; i < nomeEstados.Count; i++)
                {
                    int pos = (1 << i);

                    //faz o e binario entre os numeros
                    if ((atual & pos) == pos)
                    {
                        nomeEstado += nomeEstados[i] + " ";
                    }
                }
                nomesEstadosAFD.Add(nomeEstado.Trim());

                novosEstados.Add("S" + (atual - 1));
                atual++;

            }
            //Ordena os nomes por tamanho e depois por valor
            nomesEstadosAFD = (from e in nomesEstadosAFD orderby e.Length, e select e).ToList();

            return MontarTabela(nomesEstadosAFD, novosEstados);



        }

        private List<string> ObterClosure()
        {
            List<string> nomes = new List<string>();

            //Estado inicial = (from e in Estados where e.Value.Nome select "q0" ) ;

            Estados.Where(Estados => Estados.Value.Nome == "q0");

            foreach (KeyValuePair<string, Estado> k in Estados)
            {
                if (k.Key == "q0")
                {
                    
                }
                nomes.Add(k.Key;
            }

            return nomes;
        }*/

         
        #endregion

    }
}
