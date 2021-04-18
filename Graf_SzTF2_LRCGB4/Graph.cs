using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf_SzTF2_LRCGB4
{
    class Graph<T>
    {
        public delegate void GraphEventHandler(T item, int? distance = null);
        public delegate void GraphEventHandler<T>(object source, GraphEventArgs<T> geargs);
        List<T> Node;
        List<List<T>> NeighborList;
        public event GraphEventHandler<T> graphEventHandler;

        public Graph()
        {
            Node = new List<T>();
            NeighborList = new List<List<T>>();
        }

        public void AddNode(T node)
        {
            Node.Add(node);
            NeighborList.Add(new List<T>());
        }
        public void AddEdge(T from, T to)
        {
            int index = Node.IndexOf(from);
            NeighborList[index].Add(to);
            index = Node.IndexOf(to);
            NeighborList[index].Add(from);
            graphEventHandler?.Invoke(this, new GraphEventArgs<T>(from, to));
        }
        public bool HasEdge(T from, T to)
        {
            int index = Node.IndexOf(from);
            return NeighborList[index].Contains(to);
        }
        public List<T> Neighbors(T node)
        {
            int index = Node.IndexOf(node);
            return NeighborList[index];
        }

        public void BFS(T from, GraphEventHandler _method)
        {
            GraphEventHandler GraphHandler = _method;
            Queue<T> S = new Queue<T>();
            List<T> F = new List<T>();
            S.Enqueue(from);
            F.Add(from);
            List<int> distance = new List<int>();
            distance.Add(0);
            int index = 0;
            while (S.Count != 0)
            {
                T k = S.Dequeue();
                GraphHandler?.Invoke(k, distance[index]);
                foreach (T item in Neighbors(k))
                {
                    if (!F.Contains(item))
                    {
                        S.Enqueue(item);
                        F.Add(item);
                        distance.Add(distance[index] + 1);
                    }
                }
                index++;
            }
        }

        public void DFS(T from, GraphEventHandler _method)
        {
            GraphEventHandler GraphHandler = _method;
            List<T> F = new List<T>();
            DFPrec(from, GraphHandler, ref F);
        }

        private void DFPrec(T node, GraphEventHandler GraphHandler, ref List<T> F)
        {
            F.Add(node);
            GraphHandler?.Invoke(node);
            foreach (T item in Neighbors(node))
            {
                if (!F.Contains(item))
                {
                    DFPrec(item, GraphHandler, ref F);
                }
            }
        }
    }
}
