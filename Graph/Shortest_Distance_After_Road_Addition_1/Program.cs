using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        solution.ShortestDistanceAfterQueries(5, [[2, 4], [0, 2], [0, 4]]);
    }
}

public class Solution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        List<List<int>> adj = new List<List<int>>();
        int[] ans = new int[queries.Length];

        // Creating normal path i to i+1 (adjacent path)
        for (int i = 0; i < n; i++)
        {
            var list = new List<int>();
            if (i != 0)
            {
                list.Add(i - 1);
            }
            adj.Add(list);
        }

        // Initial Dijkstra run to find shortest paths from the last node (n-1)
        var dist = FindMinimumDistance(n, adj, n - 1);

        for (int i = 0; i < queries.Length; i++)
        {
            // Adding the additional path (reverse connection)
            adj[queries[i][1]].Add(queries[i][0]);

            // Update the shortest paths from the last node
            UpdateShortestPaths(n, adj, dist, queries[i][0], queries[i][1]);

            // Record the shortest distance to node 0 after this query
            ans[i] = dist[0];
        }

        return ans;
    }

    // Initial Dijkstra to find minimum distance from the source node S
    public int[] FindMinimumDistance(int V, List<List<int>> adj, int S)
    {
        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[S] = 0;

        SortedSet<Pair> pq = new SortedSet<Pair> { new Pair(0, S) };

        while (pq.Count > 0)
        {
            Pair currPair = pq.Min;
            pq.Remove(currPair);
            int currDist = currPair.Distance;
            int currNode = currPair.Node;

            foreach (var adjNode in adj[currNode])
            {
                if (currDist + 1 < dist[adjNode])
                {
                    dist[adjNode] = currDist + 1;
                    pq.Add(new Pair(dist[adjNode], adjNode));
                }
            }
        }

        return dist;
    }

    // Update shortest paths after adding a new edge from `newNode` to `endNode`
    public void UpdateShortestPaths(int V, List<List<int>> adj, int[] dist, int newNode, int endNode)
    {
        SortedSet<Pair> pq = new SortedSet<Pair> { new Pair(dist[endNode], endNode) };

        while (pq.Count > 0)
        {
            Pair currPair = pq.Min;
            pq.Remove(currPair);
            int currDist = currPair.Distance;
            int currNode = currPair.Node;

            foreach (var adjNode in adj[currNode])
            {
                if (currDist + 1 < dist[adjNode])
                {
                    dist[adjNode] = currDist + 1;
                    pq.Add(new Pair(dist[adjNode], adjNode));
                }
            }
        }
    }
}

public class Pair : IComparable<Pair>
{
    public int Node { get; set; }
    public int Distance { get; set; }
    public Pair(int distance, int node) { Node = node; Distance = distance; }
    public int CompareTo(Pair other)
    {
        if (this.Distance == other.Distance)
        {
            return this.Node.CompareTo(other.Node);
        }
        return this.Distance.CompareTo(other.Distance);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Pair other = (Pair)obj;
        return Node == other.Node && Distance == other.Distance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Node, Distance);
    }
}
