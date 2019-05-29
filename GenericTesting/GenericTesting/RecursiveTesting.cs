using Newtonsoft.Json.Linq;
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
            public string Value { get; set; }

            public List<Node> SubNodes { get; set; } = new List<Node>();
        }


        public static string CreateRecursiveJsonFromNode(this Node node, StringBuilder sb = null)
        {
            if (sb == null)
                sb = new StringBuilder($"{{{Environment.NewLine}");

            var nodeToWorkOn = node.SubNodes.FirstOrDefault();

            if (nodeToWorkOn != null)
            {
                var itemsToWorkOn = nodeToWorkOn.SubNodes.Where(x => x.Name != null);
                if (itemsToWorkOn.Any())
                {
                    sb.Append($"\"{nodeToWorkOn.Group}\": [{Environment.NewLine}");
                    sb.Append(String.Join($",{Environment.NewLine}", itemsToWorkOn.Select(x => $"{{\"{x.Name}\": \"{x.Value}\"}}")));
                    sb.Append($"{Environment.NewLine}],{Environment.NewLine}");
                    node.SubNodes.Remove(nodeToWorkOn);
                    CreateRecursiveJsonFromNode(node, sb);
                }
                else
                    CreateRecursiveJsonFromNode(nodeToWorkOn, sb);
            }

            return $"{sb.ToString().Substring(0, sb.Length - 3)}{Environment.NewLine}}}";
        }

        /// <summary>
        /// DTO object for options for Node heirarchy settings
        /// StartPoint: This is the section of code BEFORE a heirarchy, EG: https://localhost/admin/settings/mysetting.  I would want to start AFTER admin to have settings/mysetting to discern
        /// Remove Excess: Say you have a node after start like /university/reporting/report1 and then /university/reporting/report2.  And 'university' never has any other nodes beyond reporting.  This would get rid of that and use the bottom group.
        /// ReseatRootToName: If you only ever have start/badge you may if you have collections of groups a named group to hold objects that were at the root.  If it is 'string.empty' or null it assumes you want them at the root.
        /// HeirarchSeparator: You usually will have a/b/c/point.  But you may have a|b|c or a-b-c.  separator is flexibility to inject this.
        /// AlphaOrderNodes: true will order alphabetically, false will leave it the way it came in.
        /// </summary>
        public class OptionsForHeirarchy
        {
            public OptionsForHeirarchy(string startPoint = "localhost/", bool removeExcess = true, bool alphaOrderNodes = true, string reseatRootToName = "Main", char heirarchySeparator = '/')
            {
                StartPoint = startPoint;
                RemoveExcess = removeExcess;
                AlphaOrderNodes = alphaOrderNodes;
                ReseatRootToName = reseatRootToName;
                HeirarchySeparator = heirarchySeparator;
            }

            public string StartPoint { get; set; }
            public bool RemoveExcess { get; set; }
            public string ReseatRootToName { get; set; }
            public char HeirarchySeparator { get; set; }
            public bool AlphaOrderNodes { get; set; }
        }


        /// <summary>
        /// You create an empty 'node' object then iterate recursively through it to update it as needed from a dictionary and choose options from DTO OptionsForHeirarchy
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Node GetNodesFromDictionary(this Dictionary<string, string> dictionary, OptionsForHeirarchy options = null)
        {
            if (options == null)
                options = new OptionsForHeirarchy();

            var startLen = options.StartPoint.Length;
            var mainNode = new Node();

            dictionary.Select(x => new { Name = x.Key, Url = x.Value, Sub = x.Value.Substring(x.Value.IndexOf(options.StartPoint, StringComparison.InvariantCultureIgnoreCase) + startLen, x.Value.Length - (x.Value.IndexOf(options.StartPoint, StringComparison.InvariantCultureIgnoreCase) + startLen)) })
            .Select(x => new { x.Name, x.Url, Sub = x.Sub.ToCharArray().Last() == '/' ? x.Sub.Substring(0, x.Sub.Length - 1) : x.Sub })
            .ToList()
            .ForEach(x => UpdateNodeStructure(mainNode, x.Name, x.Url, x.Sub, options.HeirarchySeparator));

            if (options.RemoveExcess)
                RemoveExcessFromNode(mainNode);

            if (!string.IsNullOrEmpty(options.ReseatRootToName))
            {
                var nodesMinusAGroup = mainNode.SubNodes.Where(x => x.Group == null).ToList();
                nodesMinusAGroup.ForEach(x => mainNode.SubNodes.Remove(x));
                mainNode.SubNodes.Add(new Node { Group = options.ReseatRootToName, SubNodes = nodesMinusAGroup });
            }

            if (options.AlphaOrderNodes)
                mainNode.SubNodes = mainNode.SubNodes.OrderBy(x => x.Group).ToList();

            return mainNode;
        }

        private static void UpdateNodeStructure(Node node, string name, string url, string sub, char hierarchySeparator)
        {
            var firstSlash = sub.IndexOf(hierarchySeparator);

            if (firstSlash == -1)
                node.SubNodes.Add(new Node { Name = name, Value = url });
            else
            {
                var groupOnNode = $"{sub.Substring(0, 1).ToUpper()}{sub.Substring(1, firstSlash - 1).ToLower()}";
                var nameAfterGroup = sub.Substring(firstSlash + 1, sub.Length - firstSlash - 1);
                var groupIfExists = node.SubNodes.FirstOrDefault(x => String.Compare(x.Group, groupOnNode, false) == 0);

                if (groupIfExists != null)
                    UpdateNodeStructure(groupIfExists, name, url, nameAfterGroup, hierarchySeparator);
                else
                {
                    var newNode = new Node { Group = groupOnNode };
                    node.SubNodes.Add(newNode);
                    UpdateNodeStructure(newNode, name, url, nameAfterGroup, hierarchySeparator);
                }
            }
        }

        private static void RemoveExcessFromNode(Node node)
        {
            var excessNodes = node.SubNodes.Where(x => x.Group != null && x.SubNodes.FirstOrDefault()?.Group != null).ToList();
            excessNodes.ForEach(x =>
            {
                node.SubNodes.Remove(x);
                node.SubNodes.AddRange(x.SubNodes);
                RemoveExcessFromNode(x);
            });
        }
    }
}
