using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Grafo
    {
        public List<int> vertices;
        public List<int[]> arestas;
        /// <summary>
        /// Inicia um grafo
        /// </summary>
        public Grafo()
        {
            vertices = new List<int>();
            arestas = new List<int[]>();            
        }
        /// <summary>
        /// Adiciona uma vertice (nó)
        /// </summary>
        /// <param name="addaresta">Valor do vertice, ou algo do tipo</param>
        public void addVertice(int vertice) {
            vertices.Add(vertice);
        }
        /// <summary>
        /// Deleta um vertice
        /// </summary>
        /// <param name="delaresta">Vertice a ser deletado</param>
        public void deleteVertice(int vertice) {
            vertices.Remove(vertice);
        }
        /// <summary>
        /// Adiciona uma aresta (linha)
        /// </summary>
        /// <param name="aresta1"></param>
        /// <param name="aresta2"></param>
        public void addAresta(int vertice1, int vertice2) {
            if (!vertices.Contains(vertice1) || !vertices.Contains(vertice2)) return;
            int[] newaresta = new int[2];
            newaresta[0] = vertice1;
            newaresta[1] = vertice2;
            arestas.Add(newaresta);
        }
        /// <summary>
        /// Deleta uma aresta
        /// </summary>
        /// <param name="aresta1"></param>
        /// <param name="aresta2"></param>
        public void deleteAresta(int vertice1, int vertice2)
        {
            foreach (var vert in arestas.Where(vert => vert[0] == vertice1 && vert[1] == vertice2 || vert[0] == vertice2 && vert[1] == vertice1))
            {
                arestas.Remove(vert);
            }
        }

        public List<int> widthSearch(Grafo grafo, int raiz) {
            List<int> fila = new List<int>();
            List<int> markedVertices = new List<int>();
            int index = 0;
            if (!grafo.vertices.Contains(raiz))
            {
                fila.Add(0);                
                return fila;
            }
            fila.Add(raiz);
            markedVertices.Add(raiz);
            while (fila.Count != 0)
            {
                foreach (int indv in fila)
                {                
                    var tempAL = new List<int[]>();
                    foreach (var vert in grafo.arestas)
                    {
                        if (vert[0] == indv)
                        {
                            tempAL.Add(vert);
                        }
                        else if (vert[1] == indv)
                        {
                            var tempvert = new int[2];
                            tempvert[0] = vert[1];
                            tempvert[1] = vert[0];
                            tempAL.Add(tempvert);
                        }
                    }
                    foreach (var conec in tempAL)
                    {
                        if (!markedVertices.Contains(conec[1]))
                        {
                            markedVertices.Add(conec[1]);
                            fila.Add(conec[1]);
                        }
                        else if (fila.Contains(conec[1]))
                        {
                            continue;
                        }
                    }
                    fila.Remove(indv);
                }                
            }
            return markedVertices;
        }
    }
}
