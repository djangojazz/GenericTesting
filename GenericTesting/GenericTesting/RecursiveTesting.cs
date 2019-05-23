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
            public string Group { get; set; }
            public string Name { get; set; }
            public string Url { get; set; }

            public List<Node> SubNodes { get; set; } = new List<Node>();
        }

        public static void UpdateNodeStructure(Node node, string name, string url, string sub)
        {
            var firstSlash = sub.IndexOf('/');

            if (firstSlash == -1)
                node.SubNodes.Add(new Node { Name = name, Url = url});
            else
            {
                var slashCount = sub.ToCharArray().Where(x => x == '/').Count();
                var groupOnNode = sub.Substring(0, firstSlash);
                var nameAfterGroup = sub.Substring(firstSlash + 1, sub.Length - firstSlash - 1);
                var groupIfExists = node.SubNodes.FirstOrDefault(x => String.Compare(x.Group, groupOnNode, false) == 0);

                if (groupIfExists != null)
                {
                    //if (slashCount == 1)
                    //    node.SubNodes.Add(new Node(groupOnNode, Name, Url));
                    //else
                        UpdateNodeStructure(groupIfExists, name, url, nameAfterGroup);
                }
                else
                {
                    var newNode = new Node { Group = groupOnNode };
                node.SubNodes.Add(newNode);
                UpdateNodeStructure(newNode, name, url, nameAfterGroup);
                }
            }
        }

        public static Node GetNodesFromDictionary(this Dictionary<string, string> dictionary, string startPoint)
        {
            var startLen = startPoint.Length;
            var main = new Node();
            dictionary.Select(x => (Name: x.Key, Url: x.Value, Sub: x.Value.Substring(startLen, x.Value.Length - startLen)))
            .ToList()
            .ForEach(x => UpdateNodeStructure(main, x.Name, x.Url, x.Sub));

            return main;
        }
    }
}
