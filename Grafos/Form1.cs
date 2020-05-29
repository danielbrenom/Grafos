using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Grafos
{
    public partial class Form1 : Form
    {
        public Grafo mygrafo;
        public Form1()
        {
            InitializeComponent();
            //toolStrip = toolStrip1;
            mygrafo = new Grafo();
            mygrafo.addVertice(6);
            mygrafo.addVertice(4);
            mygrafo.addVertice(5);
            mygrafo.addVertice(3);
            mygrafo.addVertice(2);
            mygrafo.addVertice(1);
            mygrafo.addVertice(8);
            mygrafo.addVertice(10);
            mygrafo.addAresta(6, 4);
            mygrafo.addAresta(4, 5);
            mygrafo.addAresta(4, 3);
            mygrafo.addAresta(5, 2);
            mygrafo.addAresta(5, 1);
            mygrafo.addAresta(2, 1);
            mygrafo.addAresta(2, 10);
            mygrafo.addAresta(1, 8);
            toolStripLabel1.Text = "Pronto para execução";
            //mygrafo.addAresta(4, 3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 busca = new Form4();
            foreach (int item in mygrafo.vertices)
            {
                busca.cm.Items.Add(item);
            }
            busca.ShowDialog();
            if (busca.DialogResult == DialogResult.OK)
            {
                List<int> caminho = widthSearch(mygrafo, busca.raiz);
                toolStripLabel1.Text = "Pesquisa encerrada";
                richTextBox2.AppendText("Caminho percorrido: ");
                foreach (int item in caminho)
                {
                    richTextBox2.AppendText(item.ToString() + " ");
                    //toolStripLabel1.Text += item.ToString() + " ";
                }
            }
            
        }

        public List<int> widthSearch(Grafo grafo, int raiz)
        {
            List<int> fila = new List<int>();
            List<int> markedVertices = new List<int>();
            //int index = 0;
            if (!grafo.vertices.Contains(raiz))
            {
                fila.Add(0);
                return fila;
            }
            fila.Add(raiz);
            markedVertices.Add(raiz);
            richTextBox1.AppendText("Raiz:" + raiz.ToString() + Environment.NewLine);
            richTextBox1.AppendText("Iniciando busca");
            //toolStripLabel1.Text = "Iniciando busca, atualmente no nó:";
            while (fila.Count != 0)
            {
                int atno = 0;
                foreach (int indv in fila.ToList())
                {
                    atno = indv;
                    richTextBox1.AppendText(Environment.NewLine + "Nó atual:" + indv.ToString() + Environment.NewLine);
                    List<int[]> tempAL = new List<int[]>();
                    foreach (int[] vert in grafo.arestas)
                    {
                        if (vert[0] == indv)
                        {
                            tempAL.Add(vert);
                        }
                        else if (vert[1] == indv)
                        {
                            int[] tempvert = new int[2];
                            tempvert[0] = vert[1];
                            tempvert[1] = vert[0];
                            tempAL.Add(tempvert);
                        }
                    }
                    foreach (int[] conec in tempAL)
                    {
                        if (!markedVertices.Contains(conec[1]))
                        {
                            markedVertices.Add(conec[1]);
                            fila.Add(conec[1]);
                            //break;
                        }
                        else if (fila.Contains(conec[1]))
                        {
                            continue;
                        }
                        richTextBox1.AppendText("Fila atual:");
                        foreach (int f in fila)
                        {
                            richTextBox1.AppendText(f.ToString() + " ");
                        }
                        richTextBox1.AppendText(Environment.NewLine);
                        //richTextBox1.Text += ",fila atual:" + indv.ToString() + "/n";
                    }
                    fila.Remove(atno);
                }
                
            }
            return markedVertices;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 select = new Form2();
            foreach (int item in mygrafo.vertices)
            {
                select.cm.Items.Add(item);
                select.cm2.Items.Add(item);
            }            
            select.ShowDialog();
            if (select.DialogResult == DialogResult.OK)
            {
                mygrafo.addAresta(select.a1,select.a2);
                toolStripLabel1.Text = "Adicionada uma aresta de:" + select.a1.ToString() + ",para:" + select.a2.ToString();
            }
            else
            {
                toolStripLabel1.Text = "Adição de aresta cancelada";
            }
            
            select.Dispose();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 vert = new Form3();
            vert.ShowDialog();
            if (vert.DialogResult == DialogResult.OK)
            {
                mygrafo.addVertice(vert.vertice);
                toolStripLabel1.Text = "Adicionado um vertice:" + vert.vertice.ToString();
            }
            else
            {
                toolStripLabel1.Text = "Adição de vertice cancelado";
            }
            
            vert.Dispose();
        }
    }
}
