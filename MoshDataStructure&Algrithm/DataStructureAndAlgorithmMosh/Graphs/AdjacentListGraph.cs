using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithmMosh.Graphs
{
    public class AdjacentListGraph
    {
        private class Node
        {
            private string _label;

            public Node(string label)
            {
                _label = label;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node, List<Node>> adjacentList = new Dictionary<Node, List<Node>>();
        public void AddNode(string label)
        {
            var node = new Node(label);
            if (_nodes.ContainsKey(label)) return;
            _nodes.Add(label, node);
            adjacentList.Add(node, new List<Node>());

        }

        public void AddEdge(string from, string to)
        {
            if (!_nodes.ContainsKey(from) || !_nodes.ContainsKey(to)) return;
            

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            adjacentList[fromNode].Add(toNode);


        }
        public void RemoveEdge(string from, string to)
        {
            if (!_nodes.ContainsKey(from) || !_nodes.ContainsKey(to)) return;
            

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            adjacentList[fromNode].Remove(toNode);


        }


    }
}
