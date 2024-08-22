namespace Dijkstra.Core.Model
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        public int Distance { get; set; }

        public ShortestPathData Create(List<string> NodeNames, int Distance) {
            this.NodeNames = NodeNames;
            this.Distance = Distance;
            return this;
        }
    }
}
