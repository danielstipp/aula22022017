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
        private ExpressaoRegular expressao;

        public Principal()
        {
            InitializeComponent();
            CriaAutomato();
            Valida();
        }

        /// <summary>
        /// Cria autômato para exibir.
        /// </summary>
        private void CriaAutomato()
        {
            expressao = new ExpressaoRegular(txtExpressaoRegular.Text);
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
            foreach (KeyValuePair<string, Estado> estado in expressao.Automato.Estados)
            {
                Node no = grafoAutomato.AddNode(estado.Key);
                no.Attr.Shape = Shape.Circle;
                // Faz marcações no grafo..
                if (estado.Value.Final)
                {
                    no.Attr.Shape = Shape.DoubleCircle;
                }
                if (estado.Value == expressao.Automato.EstadoInicial)
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
            pnlAutomato.Controls.Clear();
            pnlAutomato.Controls.Add(viewer);
        }

        /// <summary>
        /// Valida palavra.
        /// </summary>
        private void Valida()
        {
            if (expressao.Validar(txtValidar.Text))
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

        private void txtExpressaoRegular_TextChanged(object sender, EventArgs e)
        {
            CriaAutomato();
            Valida();
        }



    }
}
