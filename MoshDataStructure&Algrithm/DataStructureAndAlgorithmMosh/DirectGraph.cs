/**
 * Author: yf.eva.yifan@gmail.com
 * Date: 10-06-2021 09:37:13
 * LastEditTime: 10-06-2021 13:11:34
 * FilePath: \DataStructureAndAlgorithmMosh\DirectGraph.cs
 * Description: 
 */
   
using System.Collections.Generic;

namespace DataStructureAndAlgorithmMosh
{
    public class DirectGraph
    {
        private class Node
        {
            private string _label;

            public Node(string label)
            {
                _label = label;
            }
        }

        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> adjacentList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            var node = new Node(label);
            if (nodes.ContainsKey(label)) return;

            nodes.Add(label, node);
            adjacentList.Add(node, new List<Node>());

        }

        public void AddEdge(string from, string to)
        {
            try
            {
                var fromNode = nodes[from];
                var toNode = nodes[to];

                adjacentList[fromNode].Add(toNode);
                // If this is undirected graph then we need 
                // to Add edges from both end
                // adjacentList[toNode].Add(fromNode);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void RemoveNode(string label)
        {
            if (!nodes.ContainsKey(label)) return;
            var node = nodes[label];

            foreach (var item in adjacentList.Keys)
            {
                adjacentList[item].Remove(node);
            }

            adjacentList.Remove(node);

            nodes.Remove(label);

        }

        public void RemoveEdge(string from, string to)
        {
            if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to)) return;

            var fromNode = nodes[from];
            var toNode = nodes[to];

            adjacentList[fromNode].Remove(toNode);
        }
    }
}
