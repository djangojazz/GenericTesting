using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    public static class RecursiveTesting
    {
        public class Node
        {
            public Node() {}
            public Node(string group) : this(group, null, null) { }
            public Node(string group, string name, string url) => (Group, Name, Url) = (group, name, url);

            public string Group { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }

            public List<Node> SubNodes { get; set; } = new List<Node>();
        }

        public static void UpdateNodeStructure(Node node, string Name, string Url, string Sub)
        {
            var firstSlash = Sub.IndexOf('/');
            if (!(firstSlash > 0))
                (node.Name, node.Url) = (Name, Url);
            else
            {
                var groupOnNode = Sub.Substring(0, firstSlash);
                var nameAfterGroup = Sub.Substring(firstSlash, Sub.Length - firstSlash);
                var groupIfExists = node.SubNodes.SingleOrDefault(x => String.Compare(x.Group, groupOnNode, false) == 0);

                if (groupIfExists != null)
                {
                    UpdateNodeStructure(groupIfExists, Name, Url, nameAfterGroup);
                }   
                else
                {
                    var newNode = new Node(groupOnNode, null, null);
                    node.SubNodes.Add(newNode);
                    UpdateNodeStructure(newNode, Name, Url, nameAfterGroup);
                }
            }
        }

        public static Node GetNodesFromDictionary(this Dictionary<string, string> dictionary, string startPoint)
        {
            var startLen = startPoint.Length;
            var main = new Node(null, null, null);
            dictionary.Select(x => (Name: x.Key, Url: x.Value, Sub: x.Value.Substring(startLen, x.Value.Length - startLen)))
            .ToList()
            .ForEach(x => UpdateNodeStructure(main, x.Name, x.Url, x.Sub));

            return main;
        }
    }
}
