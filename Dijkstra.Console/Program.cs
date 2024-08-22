﻿using Dijkstra.Core.Model;
using Dijkstra.Core.Services;
using Dijkstra.Infrastructure.Services;

Console.WriteLine("============ Dijkstra Algorithm ============");

Console.WriteLine("Enter to Node: ");
string startNode = Console.ReadLine();

Console.WriteLine("Enter from Node: ");
string endNode = Console.ReadLine();

IAlgorithmService service = new AlgorithmService();

var response = service.ShortestPath(startNode, endNode, new Nodes().InitializeData());

Console.WriteLine($"Shortest path from {startNode} to {endNode}: {string.Join(" -> ", response.NodeNames)}");
Console.WriteLine($"Total distance: {response.Distance}");