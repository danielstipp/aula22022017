using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoAutomatos.Classes
{
    /// <summary>
    /// Classe que converte um AFE para AFD.
    /// </summary>
    public class ConverteAutomato
    {

        #region Atributos

        /// <summary>
        /// Autômato a ser convertido.
        /// </summary>
        private Automato afe;
        /// <summary>
        /// Autômato gerado.
        /// </summary>
        private Automato afd;

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância da classe que converte um AFE para AFD.
        /// </summary>
        /// <param name="afe"></param>
        public ConverteAutomato(Automato afe)
        {
            this.afe = afe;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Cria AFD.
        /// </summary>
        private void CriarAFD()
        {
            Estado[] estados = afe.Closure(afe.EstadoInicial.Nome);
            string estado = ObterNomeEstado(estados);
            this.afd = new Automato(estado, Final(estados));
        }

        /// <summary>
        /// Obtem o nome de um estado a partir de uma lista de estados.
        /// </summary>
        /// <param name="estados"></param>
        /// <returns></returns>
        private string ObterNomeEstado(Estado[] estados)
        {
            estados = estados.OrderBy(e => e.Nome).ToArray();
            string nomeEstado = estados[0].Nome;
            for (int i = 1; i < estados.Length; i++)
            {
                nomeEstado = nomeEstado + " " + estados[i].Nome;
            }
            return nomeEstado;
        }

        /// <summary>
        /// Determina se conjunto possui estado final.
        /// </summary>
        /// <param name="estados"></param>
        /// <returns></returns>
        private bool Final(Estado[] estados)
        {
            foreach (Estado e in estados)
            {
                if (e.Final)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Obtem o autômato finito deterministico.
        /// </summary>
        /// <returns></returns>
        public Automato ObterAFD()
        {
            this.CriarAFD();
            this.GerarTransicoes();
            return this.afd;
        }

        /// <summary>
        /// Gera a lista de estados.
        /// </summary>
        private void GerarEstados()
        {
            int mascara = (1 << afe.Estados.Count);
            int atual = 1;
            // Pesquisa todos os estados..
            string[] nomeEstados = afe.ObterEstados();
            List<string> nomeEstadosAFD = new List<string>();
            while (atual < mascara)
            {
                string nomeEstado = String.Empty;
                for (int i = 0; i < nomeEstados.Length; i++)
                {
                    int pos = (1 << i);
                    if ((atual & pos) == pos)
                    {
                        nomeEstado += nomeEstados[i] + " ";
                    }
                }
                nomeEstadosAFD.Add(nomeEstado.Trim());
                atual++;
            }
            // Ordena os nomes por tamanho e depois por valor..
            nomeEstadosAFD = (from e in nomeEstadosAFD
                              orderby e.Length, e
                              select e).ToList();
            // Adiciono ao autômato..
            foreach (string nomeEstadoAFD in nomeEstadosAFD)
            {
                if (!afd.Estados.ContainsKey(nomeEstadoAFD))
                {
                    afd.AdicionarEstado(nomeEstadoAFD, false);
                }
            }
        }

        /// <summary>
        /// Gerar transições do AFD.
        /// </summary>
        private void GerarTransicoes()
        { 
            char[] alfabeto = afe.Alfabeto.ToCharArray();            
            // Executa o processo para todo estado que tenha sido adicionado..
            for (int i = 0; i < afd.Estados.Count; i++)
            {
                // Obtem nome do estado inicial e quebra..
                string estadoOrigem = afd.Estados.ElementAt(i).Key;
                string[] composicaoOrigem = estadoOrigem.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                // Verifica transição para cada símbolo do alfabeto..
                foreach (char simbolo in alfabeto)
                {
                    if (simbolo != afe.SimboloVazio)
                    {
                        Estado[] destinos = afe.DFAEdge(composicaoOrigem, simbolo);
                        if (destinos != null && destinos.Length > 0)
                        {
                            // Gera novo estado: Autômato já controla duplicações..
                            string estadoDestino = ObterNomeEstado(destinos);
                            bool final = Final(destinos);
                            afd.AdicionarEstado(estadoDestino, final);
                            // Adiciona transição..
                            afd.AdicionarTransicao(estadoOrigem, estadoDestino, simbolo);
                        }
                    }
                }
            }
        }

        #endregion

    }
}
