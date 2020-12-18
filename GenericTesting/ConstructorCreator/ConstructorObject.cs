using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorCreator
{
    public class ConstructorObject
    {
        public string Name { get; set; }
        public List<Line> Lines { get; set; }

        public ConstructorObject(string name, List<Line> lines) => (Name, Lines) = (name, lines);
    }

    public class Line
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Line(int id, string name, string type) => (Id, Name, Type) = (id, name, type);
    }
}
