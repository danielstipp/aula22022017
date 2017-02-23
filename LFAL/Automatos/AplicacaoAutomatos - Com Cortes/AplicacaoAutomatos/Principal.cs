using AplicacaoAutomatos.Classes;
using Microsoft.Glee.Drawing;
using Microsoft.Glee.GraphViewerGdi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacaoAutomatos
{
    public partial class Principal : Form
    {
        private Automato automato;
        private Automato automatoMini;
     
        public Principal()
        {
            InitializeComponent();
            CriaAutomato(0);
            Valida();
            lblgrafo.Text = "AFN";
        }

        public Principal(Automato aut)
        {
            InitializeComponent();
            automato = aut;
            Desenha();
            Valida();
            lblgrafo.Text = "AFD";
        }
        /// <summary>
        /// Cria autômato para exibir.
        /// </summary>
        private void CriaAutomato(int cod)
        {
            if (cod == 0)
                for (int i = 1; i <= 7; i++)
                    cmbPronto.Items.Add(i);

            if (cod == 1)
            {
                automato = new Automato("q0", false);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", true);
                automato.AdicionarTransicao("q0", "q1", 'a');
                automato.AdicionarTransicao("q1", "q2", 'b');
                automato.AdicionarTransicao("q2", "q2", 'b');
            }

            if (cod == 2)
            {
                automato = new Automato("q0", false);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", true);
                automato.AdicionarTransicao("q0", "q1", 'a');
                automato.AdicionarTransicao("q0", "q2", 'a');
                automato.AdicionarTransicao("q1", "q2", 'a');
                automato.AdicionarTransicao("q1", "q0", 'b');
                automato.AdicionarTransicao("q1", "q2", 'b');
                automato.AdicionarTransicao("q2", "q0", 'b');
                automato.AdicionarTransicao("q2", "q2", 'a');
            }

            if (cod == 3)
            {
                automato = new Automato("q0", false);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", false);
                automato.AdicionarEstado("q3", true);

                automato.AdicionarTransicao("q0", "q0", 'a');
                automato.AdicionarTransicao("q0", "q0", 'b');

                automato.AdicionarTransicao("q0", "q1", 'a');
                automato.AdicionarTransicao("q1", "q2", 'a');
                automato.AdicionarTransicao("q2", "q3", 'a');
            }

            if (cod == 4)
            {
                automato = new Automato("q0", false);
                automato.AdicionarEstado("q1", true);
                automato.AdicionarTransicao("q0", "q0", 'a');
                automato.AdicionarTransicao("q0", "q1", 'a');

                automato.AdicionarTransicao("q1", "q1", 'b');
                automato.AdicionarTransicao("q1", "q0", 'b');
            }

            if (cod == 5)
            {
                automato = new Automato("q0", false);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", true);
                automato.AdicionarEstado("q3", false);
                automato.AdicionarEstado("q4", false);
                automato.AdicionarEstado("q5", true);

                automato.AdicionarTransicao("q0", "q1", 'a');
                automato.AdicionarTransicao("q1", "q2", 'a');
                automato.AdicionarTransicao("q2", "q3", 'a');
                automato.AdicionarTransicao("q3", "q4", 'a');
                automato.AdicionarTransicao("q4", "q5", 'a');
                automato.AdicionarTransicao("q5", "q0", 'a');
                automato.AdicionarTransicao("q0", "q0", 'b');
                automato.AdicionarTransicao("q1", "q1", 'b');
                automato.AdicionarTransicao("q2", "q2", 'b');
                automato.AdicionarTransicao("q3", "q3", 'b');
                automato.AdicionarTransicao("q4", "q4", 'b');
                automato.AdicionarTransicao("q5", "q5", 'b');

                lblEstados.Text = "6";
                lblTrans.Text = "12";
            }

            if (cod == 6)
            {
                automato = new Automato("q0", true);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", true);
                automato.AdicionarEstado("q3", false);
                automato.AdicionarEstado("q4", false);
                automato.AdicionarEstado("q5", false);
                automato.AdicionarEstado("q6", true);
                automato.AdicionarEstado("q7", false);

                automato.AdicionarTransicao("q0", "q1", 'a');
                automato.AdicionarTransicao("q1", "q4", 'a');
                automato.AdicionarTransicao("q2", "q1", 'a');
                automato.AdicionarTransicao("q3", "q0", 'a');
                automato.AdicionarTransicao("q5", "q2", 'a');
                automato.AdicionarTransicao("q6", "q5", 'a');
                automato.AdicionarTransicao("q7", "q6", 'a');
                automato.AdicionarTransicao("q0", "q3", 'b');
                automato.AdicionarTransicao("q1", "q2", 'b');
                automato.AdicionarTransicao("q2", "q5", 'b');
                automato.AdicionarTransicao("q3", "q4", 'b');
                automato.AdicionarTransicao("q5", "q4", 'b');
                automato.AdicionarTransicao("q6", "q7", 'b');
                automato.AdicionarTransicao("q7", "q2", 'b');

                lblEstados.Text = "8";
                lblTrans.Text = "14";
            }

            if (cod == 7)
            {
                automato = new Automato("q0", true);
                automato.AdicionarEstado("q1", false);
                automato.AdicionarEstado("q2", false);
                automato.AdicionarEstado("q3", false);
                automato.AdicionarEstado("q4", true);
                automato.AdicionarEstado("q5", true);

                automato.AdicionarTransicao("q0", "q2", 'a');
                automato.AdicionarTransicao("q1", "q1", 'a');
                automato.AdicionarTransicao("q2", "q4", 'a');
                automato.AdicionarTransicao("q3", "q5", 'a');
                automato.AdicionarTransicao("q4", "q3", 'a');
                automato.AdicionarTransicao("q5", "q2", 'a');
                automato.AdicionarTransicao("q0", "q1", 'b');
                automato.AdicionarTransicao("q1", "q0", 'b');
                automato.AdicionarTransicao("q2", "q5", 'b');
                automato.AdicionarTransicao("q3", "q4", 'b');
                automato.AdicionarTransicao("q4", "q2", 'b');
                automato.AdicionarTransicao("q5", "q3", 'b');

                lblEstados.Text = "6";
                lblTrans.Text = "12";
            }

            if (cod != 0)
                Desenha();

        }

        /// <summary>
        /// Desenha o autômato.
        /// </summary>
        private void Desenha()
        {
            Graph grafoAutomato = new Graph("Autômato");
            List<Transicao> transicoes = new List<Transicao>();
            // Adiciona elementos com base nas transições
            foreach (KeyValuePair<string, Estado> estado in automato.Estados)
            {
                Node no = grafoAutomato.AddNode(estado.Key);
                no.Attr.Shape = Shape.Circle;
                // Faz marcações no grafo..
                if (estado.Value.Final)
                {
                    no.Attr.Shape = Shape.DoubleCircle;
                }
                if (estado.Value == automato.EstadoInicial)
                {
                    no.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.LightGray;
                }
                transicoes.AddRange(estado.Value.Transicoes);
            }
            foreach (Transicao transicao in transicoes)
            {
                Edge arco = grafoAutomato.AddEdge(transicao.Origem.Nome, transicao.Destino.Nome);
                arco.Attr.Label = transicao.Simbolo;
            }
            GViewer viewer = new GViewer();
            viewer.NavigationVisible = false;
            viewer.OutsideAreaBrush = Brushes.White;
            viewer.RemoveToolbar();
            viewer.Graph = grafoAutomato;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlAutomato.Controls.Add(viewer);
        }

        /// <summary>
        /// Valida palavra.
        /// </summary>
        private void Valida()
        {
            if (automato != null)
                if (automato.Validar(txtValidar.Text))
                {
                    txtValidar.BackColor = System.Drawing.Color.Green;
                    txtValidar.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    txtValidar.BackColor = System.Drawing.Color.Red;
                    txtValidar.ForeColor = System.Drawing.Color.White;
                }
        }

        private void txtValidar_TextChanged(object sender, EventArgs e)
        {
            // Valida e coloca a cor de fundo de acordo com a necessidade..
            Valida();
          
        }

        private void btnAfd_Click(object sender, EventArgs e)
        {


            Principal prin = new Principal(automato.ConverterAFD());
            prin.Show();
        }

        private void addEstado_Click(object sender, EventArgs e)
        {
            int est = Convert.ToInt16(lblEstados.Text);

            if (est == 0)
                automato = new Automato("q" + est, false);
            else
                automato.AdicionarEstado("q" + est, false);

            cboxDestino.Items.Add("q" + est);
            cboxOrigem.Items.Add("q" + est);

            est++;

            lblEstados.Text = est.ToString();

            pnlAutomato.Controls.Clear();

            Desenha();
        }

        private void btnAddEstadoF_Click(object sender, EventArgs e)
        {
            int est = Convert.ToInt16(lblEstados.Text);

            if (est == 0)
                automato = new Automato("q" + est, true);
            else
                automato.AdicionarEstado("q" + est, true);

            cboxDestino.Items.Add("q" + est);
            cboxOrigem.Items.Add("q" + est);

            est++;

            lblEstados.Text = est.ToString();

            pnlAutomato.Controls.Clear();

            Desenha();
        }

        private void addTrans_Click(object sender, EventArgs e)
        {
            int tra = Convert.ToInt16(lblTrans.Text);

            string o = cboxOrigem.SelectedItem.ToString();
            string d = cboxDestino.SelectedItem.ToString();
            char v = txtValor.Text[0];

            automato.AdicionarTransicao(o, d, v);

            tra++;

            lblTrans.Text = tra.ToString();

            pnlAutomato.Controls.Clear();

            Desenha();
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            automato = new Automato();

            lblTrans.Text = "0";
            lblEstados.Text = "0";

            pnlAutomato.Controls.Clear();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            btnLimpa_Click(sender, e);

            string cod = cmbPronto.SelectedItem.ToString();

            CriaAutomato(Convert.ToInt16(cod));
        }

        private void btn_closing_Click(object sender, EventArgs e)
        {
            //Principal prin = new Principal(automato.ConverterAFD_Closure());
            //prin.Show();
        }

        private void btnCriaAutom_Click(object sender, EventArgs e)
        {
            btnLimpa_Click(sender, e);

            automato = new Automato("q0", false);

            int estado = 0;
            int indice = 0;
            int[] ultimosEstados = new int[] { 0 };

            // Faz replace dos operadores * e + pelos operadores de tamanho para facilitar a implementação..
            string expressao = txtExpress.Text.Replace("*", "{0,}").Replace("+", "{1,}").Replace(" ", String.Empty);
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

        private void btnFillTable_Click(object sender, EventArgs e)
        {
            //int numEstados = Convert.ToInt16(lblEstados.Text);
            int numEstados = automato.Estados.Count;
            DataTable dt = new DataTable();
            List<string> lista = new List<string>();
            List<string> transacoes = new List<string>(); 
            List<string> dependencias = new List<string>();
            int numSimbolos = 0;
            char[] simbolos = {};

            //RemoveInacessibilidade(numEstados);
            //VerificaSimbolos(numEstados, numSimbolos, simbolos);
            //VerificaDeterminicidade(numEstados, numSimbolos, simbolos);
            MontaTabela(numEstados, dt);
            PreencheTabelaComEstados(numEstados, dt);
            PreencheTabelaComFinaiseNaoFinais(numEstados, dt, lista, dependencias);
            GeraNovoAutomato(numEstados, dt);
            DesenhaMini();

        }

        private void RemoveInacessibilidade(int numEstados)
        {
            List<int> Votacao = new List<int>();

            for (int i = 0; i < numEstados; i++)
                Votacao.Add(0);

            for (int i = 0; i < numEstados; i++)
            {
                List<string> estados = new List<string>();

                for (int j = 0; j < numEstados; j++)
                    estados.Add("q" + j);

                Estado e = automato.RetornaEstado("q" + i, automato);
                string ea = e.Nome;
                string eb = e.Nome;

                for (int j = 0; j < numEstados; j++)
                {
                    if (ea != null)
                    {
                        ea = automato.Transicoes(automato.RetornaEstado(ea, automato), "a").Trim();
                        estados.Remove(ea);
                    }

                    if (eb != null)
                    {
                        eb = automato.Transicoes(automato.RetornaEstado(eb, automato), "b").Trim();
                        estados.Remove(eb);
                    }
                }

                foreach (string s in estados)
                    Votacao[Convert.ToInt16(s.Substring(1, 2))] ++;

            }

            for (int i = 0; i < Votacao.Count; i++)
            {
                if (Votacao[i] == numEstados)
                    automato.Estados.Remove("q" + i);
            }

            
        }

        private void VerificaSimbolos(int numEstados, int numSimbolos, char[] simbolos)
        {
            for (int i = 0; i < numEstados; i++)
            {
                return;
            }


        }

        private void VerificaDeterminicidade(int numEstados, int numSimbolos, char[] simbolos)
        {
            for (int i = 0; i < numEstados; i++)
            {
                return;
            }

           
        }

        private void MontaTabela(int numEstados, DataTable dt)
        {
            for (int i = 0; i < numEstados; i++)
            {
                dt.Columns.Add("" + i);
                dt.Rows.Add();
            }

            gridTable.DataSource = dt;
        }

        private void PreencheTabelaComEstados(int numEstados, DataTable dt)
        {
            for (int i = 0; i < numEstados-1; i++)
            {
                if (i <= numEstados-1)
                    dt.Rows[i][0] = "q" + (i + 1);

                if (i <= numEstados-2)
                    dt.Rows[dt.Rows.Count - 1][i + 1] = "q" + i;
                
                dt.Rows[dt.Rows.Count - 1][i + 1] = "q" + i;
                dt.Rows[dt.Rows.Count - 1][i + 1] = "q" + i;
            }

            gridTable.DataSource = dt;
        }

        private void PreencheTabelaComFinaiseNaoFinais(int numEstados, DataTable dt, List<string> lista, List<string> dependencias)
        {

            List<string> temp = new List<string>();

            for (int i = 0; i < numEstados - 1; i++)
            {
                Estado e = automato.RetornaEstado("q" + i, automato);

                for (int j = i + 1; j < numEstados; j++)
                {
                    Estado v = automato.RetornaEstado("q" + j, automato);

                    if (e.Final == true && v.Final == false)
                    {
                        dt.Rows[j-1][i+1] = "X";
                        dependencias.Add("q" + i + ", q" + j);
                    }   
                    else if (e.Final == false && v.Final == true)
                    {
                        dt.Rows[j - 1][i + 1] = "X";
                        dependencias.Add("q" + i + ", q" + j);
                    }
                    else
                    {
                        lista.Add("q" + i + ", q" + j);

                        string nome1 = automato.Transicoes(automato.RetornaEstado("q" + i, automato), "a");
                        lista.Add("(q" + i + ",a) = " + nome1);

                        string nome2 = automato.Transicoes(automato.RetornaEstado("q" + j, automato), "a");
                        lista.Add("(q" + j + ",a) = " + nome2);

                        string nome3 = automato.Transicoes(automato.RetornaEstado("q" + i, automato), "b");
                        lista.Add("(q" + i + ",b) = " + nome3);

                        string nome4 = automato.Transicoes(automato.RetornaEstado("q" + j, automato), "b");
                        lista.Add("(q" + j + ",b) = " + nome4);

                        lista.Add(" ");

                        temp.Add(nome1 + ", " + nome2);
                        temp.Add(nome3 + ", " + nome4);

                    }     
                }
            }

            bool cont = true;

            while (cont)
            {
                cont = false;

                for (int i = 0; i < numEstados - 1; i++)
                {
                    Estado e = automato.RetornaEstado("q" + i, automato);

                    for (int j = i + 1; j < numEstados; j++)
                    {
                        Estado v = automato.RetornaEstado("q" + j, automato);

                        if (e.Final == true && v.Final == false)
                        {
                            continue;
                        }
                        else if (e.Final == false && v.Final == true)
                        {
                            continue;
                        }
                        else
                        {
                            string nome1 = automato.Transicoes(automato.RetornaEstado("q" + i, automato), "a").Trim();
                            string nome2 = automato.Transicoes(automato.RetornaEstado("q" + j, automato), "a").Trim();
                            string nome3 = automato.Transicoes(automato.RetornaEstado("q" + i, automato), "b").Trim();
                            string nome4 = automato.Transicoes(automato.RetornaEstado("q" + j, automato), "b").Trim();

                            List<string> dep = new List<string>(dependencias);

                            //dep.CopyTo(dependencias.ToArray());


                            foreach (string s in dependencias)
                            {
                                if (s.Equals(nome1 + ", " + nome2) && (dt.Rows[j - 1][i + 1] != "X") && (dt.Rows[j - 1][i + 1] != "⦾"))
                                {
                                    dt.Rows[j - 1][i + 1] = "⦾";
                                    dep.Add("q" + i + ", " + "q" + j);
                                    cont = true;
                                }
                                if (s.Equals(nome3 + ", " + nome4) && (dt.Rows[j - 1][i + 1] != "X") && (dt.Rows[j - 1][i + 1] != "⦾"))
                                {
                                    dt.Rows[j - 1][i + 1] = "⦾";
                                    dep.Add("q" + i + ", " + "q" + j);
                                    cont = true;
                                }
                            }

                            //dependencias.CopyTo(dep.ToArray());
                            dependencias = dep;
                        }
                    }
                }
            }

            for (int i = 2; i < numEstados; i++)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    dt.Rows[j][i] = "|||||||||||||";
                }
            }

            gridTable.DataSource = dt;
            txtdfaedge.Text = String.Join(Environment.NewLine, lista);
            txtdependencia.Text = String.Join(Environment.NewLine, dependencias);
        }

        private void GeraNovoAutomato(int numEstados, DataTable dt)
        {
            automatoMini = new Automato();
            pnlMini.Controls.Clear();

            bool primeiro = true;

            for (int i = 0; i < numEstados - 1; i++)
            {
                for (int j = i + 1; j < numEstados; j++)
                {
                    string t = dt.Rows[j - 1][i + 1].ToString();
                    if (t == "")
                    {
                        string nome1 = "q" + i;
                        string nome2 = "q" + j;

                        Estado e1 = automato.RetornaEstado(nome1, automato);
                        Estado e2 = automato.RetornaEstado(nome2, automato);

                        bool final = false;

                        if (e1.Final == true || e2.Final == true)
                            final = true;

                        if (primeiro)
                        {
                            automatoMini = new Automato(nome1 + nome2, final);
                            primeiro = false;
                        }
                        else
                            automatoMini.AdicionarEstado(nome1 + nome2, final);
                    }
                }
            }

            List<string> estadosToAdd = new List<string>();

            for (int i = 0; i < numEstados - 1; i++)
            {
                int totalestados = automatoMini.Estados.Count;
                string estado = "q" + i;
                int existe = 0;

                foreach (var e in automatoMini.Estados)
                    if (e.Value.Nome.Contains(estado))
                        existe++;
                
                if (existe == 0)
                    estadosToAdd.Add(estado);
            }

            foreach (string s in estadosToAdd)
            {
                Estado e1 = automato.RetornaEstado(s, automato);

                bool final = false;

                if (e1.Final == true)
                    final = true;

                automatoMini.AdicionarEstado(s, final);
            }

            for (int i = 0; i < numEstados - 1; i++)
            {
                for (int j = i + 1; j < numEstados; j++)
                {
                    string t = dt.Rows[j - 1][i + 1].ToString();
                    if (t == "")
                    {
                        string nome1 = "q" + i;
                        string nome2 = "q" + j;

                        Estado e1 = automato.RetornaEstado(nome1, automato);
                        Estado e2 = automato.RetornaEstado(nome2, automato);

                        foreach (Transicao tr in e1.Transicoes)
                        {
                            string destino = automato.Transicoes(automato.RetornaEstado(nome1, automato), tr.Simbolo).Trim();
                            string destinoMini = "";

                            foreach (var e in automatoMini.Estados)
                            {
                                if (e.Value.Nome.Contains(destino))
                                    destinoMini = e.Value.Nome;
                            }

                            if (automatoMini.Transicoes(automatoMini.RetornaEstado(nome1+nome2, automatoMini), tr.Simbolo).Trim() == "")
                                automatoMini.AdicionarTransicao(nome1+nome2, destinoMini, tr.Simbolo.ToCharArray());
                        }

                        foreach (Transicao tr in e2.Transicoes)
                        {
                            string destino = automato.Transicoes(automato.RetornaEstado(nome1, automato), tr.Simbolo).Trim();
                            string destinoMini = "";

                            foreach (var e in automatoMini.Estados)
                            {
                                if (e.Value.Nome.Contains(destino))
                                    destinoMini = e.Value.Nome;
                            }

                            if (automatoMini.Transicoes(automatoMini.RetornaEstado(nome1 + nome2, automatoMini), tr.Simbolo).Trim() == "")
                                automatoMini.AdicionarTransicao(nome1 + nome2, destinoMini, tr.Simbolo.ToCharArray());
                        }
                    }
                }
            }

            foreach (string s in estadosToAdd)
            {
                Estado e1 = automato.RetornaEstado(s, automato);

                foreach (Transicao tr in e1.Transicoes)
                {
                    string destino = automato.Transicoes(automato.RetornaEstado(s, automato), tr.Simbolo).Trim();
                    string destinoMini = "";

                    foreach (var e in automatoMini.Estados)
                    {
                        if (e.Value.Nome.Contains(destino))
                            destinoMini = e.Value.Nome;
                    }

                    if (automatoMini.Transicoes(automatoMini.RetornaEstado(s, automatoMini), tr.Simbolo).Trim() == "")
                        automatoMini.AdicionarTransicao(s, destinoMini, tr.Simbolo.ToCharArray());
                }

            }
        }

        private void DesenhaMini()
        {
            Graph grafoAutomato = new Graph("Autômato");
            List<Transicao> transicoes = new List<Transicao>();
            // Adiciona elementos com base nas transições
            foreach (KeyValuePair<string, Estado> estado in automatoMini.Estados)
            {
                Node no = grafoAutomato.AddNode(estado.Key);
                no.Attr.Shape = Shape.Circle;
                // Faz marcações no grafo..
                if (estado.Value.Final)
                {
                    no.Attr.Shape = Shape.DoubleCircle;
                }
                if (estado.Value == automato.EstadoInicial)
                {
                    no.Attr.Fillcolor = Microsoft.Glee.Drawing.Color.LightGray;
                }
                transicoes.AddRange(estado.Value.Transicoes);
            }
            foreach (Transicao transicao in transicoes)
            {
                Edge arco = grafoAutomato.AddEdge(transicao.Origem.Nome, transicao.Destino.Nome);
                arco.Attr.Label = transicao.Simbolo;
            }
            GViewer viewer = new GViewer();
            viewer.NavigationVisible = false;
            viewer.OutsideAreaBrush = Brushes.White;
            viewer.RemoveToolbar();
            viewer.Graph = grafoAutomato;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMini.Controls.Add(viewer);
        }
    }
}
