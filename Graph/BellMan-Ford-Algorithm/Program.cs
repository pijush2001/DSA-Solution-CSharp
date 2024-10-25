internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        List<int> ans = solution.BellmanFord(6, [[3, 2, 6], [5, 3, 1], [1, 5, -3], [1, 2, -2], [2, 4, 3], [3, 4, -2], [0,1,5]], 0);
    }
}

public class Solution
{
    public List<int> BellmanFord(int V, List<List<int>> edges, int S)
    {
        // Code here

        int[] dist = new int[V];

        for(int i=0;i<V; i++)
        {
            dist[i] = (int)1e8;
        }
        dist[S] = 0;

        for (int it = 0; it < V-1 ; it++)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                int weight = edges[i][2];
                int sources = edges[i][0];
                int destination = edges[i][1];

                if (dist[sources] != (int)1e8 && dist[sources] + weight < dist[destination])
                {
                    dist[destination] = dist[sources] + weight;
                    
                    
                }

            }
        }

        //checking for negative cycle
        for (int i = 0; i < edges.Count; i++)
        {
            int weight = edges[i][2];
            int sources = edges[i][0];
            int destination = edges[i][1];

            if (dist[sources] != (int)1e8 && dist[sources] + weight < dist[destination])
            {
                // If we can still relax an edge, there is a negative cycle
                return new List<int> { -1 };
            }
        }

        return dist.ToList();
    }
}