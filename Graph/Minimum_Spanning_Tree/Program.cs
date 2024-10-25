internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var adj = new List<List<List<int>>>
        {
            new List<List<int>> { new List<int> { 1, 2 }, new List<int> { 3, 6 } }, // Edges from node 0
            new List<List<int>> { new List<int> { 0, 2 }, new List<int> { 2, 3 }, new List<int> { 3, 8 }, new List<int> { 4, 5 } }, // Edges from node 1
            new List<List<int>> { new List<int> { 1, 3 }, new List<int> { 4, 7 } }, // Edges from node 2
            new List<List<int>> { new List<int> { 0, 6 }, new List<int> { 1, 8 } }, // Edges from node 3
            new List<List<int>> { new List<int> { 1, 5 }, new List<int> { 2, 7 } }  // Edges from node 4
        };
        var ans = solution.spanningTree(5, ref adj);
    }
}
public class Solution
{
    // Function to find the sum of weights of edges of the Minimum Spanning Tree.
    public int spanningTree(int V, ref List<List<List<int>>> adj)
    {
        // Convert the input to a proper adjacency list.
        //var adjList = ConvertToAdjacencyList(V, adj);
        var adjList = adj;

        var pq = new PriorityQueue<(int, int), int>();
        // (node, parentNode), weight

        pq.Enqueue((0, -1), 0); // Start from node 0 with no parent and weight 0

        List<(int, int)> mst = new List<(int, int)>();
        bool[] visited = new bool[V];
        int Sum = 0;

        while (pq.Count > 0)
        {
            pq.TryDequeue(out var item, out var priority);
            int node = item.Item1;
            int parentNode = item.Item2;
            int weight = priority;

            if (!visited[node])
            {
                visited[node] = true;
                Sum += weight;

                foreach (var adjNodeInfo in adjList[node])
                {
                    int adjNode = adjNodeInfo[0];
                    int adjWeight = adjNodeInfo[1];
                    if (!visited[adjNode])
                    {
                        pq.Enqueue((adjNode, node), adjWeight);
                    }
                }
            }
        }
        return Sum;
    }

    // Corrected method to convert input to an adjacency list.
    public List<List<List<int>>> ConvertToAdjacencyList(int V, List<List<List<int>>> adj)
    {
        var adjList = new List<List<List<int>>>(V);

        for (int i = 0; i < V; i++)
        {
            adjList.Add(new List<List<int>>());
        }

        // Iterate over the adjacency list input
        for (int i = 0; i < V; i++)
        {
            foreach (var edge in adj[i])
            {
                int u = i; // Current node
                int v = edge[0]; // Adjacent node
                int weight = edge[1]; // Weight of the edge

                adjList[u].Add(new List<int> { v, weight });
            }
        }

        return adjList;
    }
}
