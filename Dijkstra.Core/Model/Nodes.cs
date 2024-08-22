namespace Dijkstra.Core.Model
{
    public class Nodes
    {
        public string Name { get; set; }
        public Dictionary<string, int> Neighbors { get; set; } = new Dictionary<string, int>();

        public List<Nodes> InitializeData()
        {
            var nodes = new List<Nodes>
            {
                new Nodes { Name = "A", Neighbors = new Dictionary<string, int> { { "B", 4 }, { "C", 6 } } },
                new Nodes { Name = "B", Neighbors = new Dictionary<string, int> { { "A", 4 }, { "E", 2 }, { "F", 2 } } },
                new Nodes { Name = "C", Neighbors = new Dictionary<string, int> { { "A", 6 }, { "D", 8 } } },
                new Nodes { Name = "D", Neighbors = new Dictionary<string, int> { { "C", 8 }, { "E", 4 }, { "G", 1 } } },
                new Nodes { Name = "E", Neighbors = new Dictionary<string, int> { { "B", 2 }, { "D", 4 }, { "F", 3 } } },
                new Nodes { Name = "F", Neighbors = new Dictionary<string, int> { { "B", 2 }, { "E", 3 }, { "H", 6 } } },
                new Nodes { Name = "G", Neighbors = new Dictionary<string, int> { { "D", 1 }, { "E", 4 }, { "I", 5 } } },
                new Nodes { Name = "H", Neighbors = new Dictionary<string, int> { { "F", 6 }, { "I", 5 } } },
                new Nodes { Name = "I", Neighbors = new Dictionary<string, int> { { "G", 5 }, { "H", 5 } } }
            };
            return nodes;
        }
    }
}
