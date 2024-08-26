using Dijkstra.Core.Model;
using Dijkstra.Core.Services;
using Dijkstra.Infrastructure.Services;

Console.WriteLine("============ Dijkstra Algorithm ============");

Console.WriteLine("Enter to Node: ");
string startNode = Console.ReadLine();

Console.WriteLine("Enter from Node: ");
string endNode = Console.ReadLine();

IAlgorithmService service = new AlgorithmService();

var response = service.ShortestPath(startNode.ToUpper(), endNode.ToUpper(), new Nodes().InitializeData());

Console.WriteLine($"Shortest path from {startNode} to {endNode}: {string.Join(", ", response.NodeNames)}");
Console.WriteLine($"Distance: {response.Distance}");
