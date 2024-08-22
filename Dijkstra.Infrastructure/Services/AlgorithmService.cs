using Dijkstra.Core.Model;
using Dijkstra.Core.Services;

namespace Dijkstra.Infrastructure.Services
{
    public class AlgorithmService : IAlgorithmService
    {
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Nodes> graphNode)
        {
            Dictionary<string, int> distances;
            List<string> path;
            CalculatePath(fromNodeName, toNodeName, graphNode, out distances, out path);

            return new ShortestPathData().Create(path, distances[toNodeName]);
        }

        #region Logic Implementation 

        private static void CalculatePath(string fromNodeName, string toNodeName, List<Nodes> graphNode, out Dictionary<string, int> distances, out List<string> path)
        {
            var graph = new Dictionary<string, Dictionary<string, int>>();
            foreach (var node in graphNode)
            {
                graph[node.Name] = node.Neighbors;
            }

            distances = new Dictionary<string, int>();
            var previousNodes = new Dictionary<string, string>();
            var priorityQueue = new SortedSet<(int distance, string node)>();
            var visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                distances[node] = int.MaxValue;
            }
            distances[fromNodeName] = 0;

            priorityQueue.Add((0, fromNodeName));

            while (priorityQueue.Count > 0)
            {
                var (currentDistance, currentNode) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (visited.Contains(currentNode))
                {
                    continue;
                }
                visited.Add(currentNode);

                if (currentNode == toNodeName)
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    var newDist = currentDistance + neighbor.Value;

                    if (newDist < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = newDist;
                        previousNodes[neighbor.Key] = currentNode;
                        priorityQueue.Add((newDist, neighbor.Key));
                    }
                }
            }

            path = new List<string>();
            string? currentNodeInPath = toNodeName;

            while (currentNodeInPath != null && previousNodes.ContainsKey(currentNodeInPath))
            {
                path.Add(currentNodeInPath);
                currentNodeInPath = previousNodes[currentNodeInPath];
            }

            path.Add(fromNodeName);
            path.Reverse();
        }

        #endregion
    }
}
