using Dijkstra.Core.Model;

namespace Dijkstra.Core.Services
{
    public interface IAlgorithmService
    {
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Nodes> graphNode);
    }
}
