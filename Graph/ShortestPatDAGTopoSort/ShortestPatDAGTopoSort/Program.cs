
using System;
using System.Collections.Generic;

public class MainClass
{
    public static void Main(string[] args)
    {
        int n = 6, m = 7;
        int[,] edge = { { 0, 1, 2 }, { 0, 4, 1 }, { 4, 5, 4 }, { 4, 2, 2 }, { 1, 2, 3 }, { 2, 3, 6 }, { 5, 3, 1 } };
        Solution obj = new Solution();
        int[] res = obj.ShortestPath(n, m, edge);
        foreach (int item in res)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

public class Pair
{
    public int First { get; set; }
    public int Second { get; set; }

    public Pair(int first, int second)
    {
        this.First = first;
        this.Second = second;
    }
}

public class Solution
{
    private void TopoSort(int node, List<List<Pair>> adj, int[] vis, Stack<int> st)
    {
        vis[node] = 1;
        foreach (var item in adj[node])
        {
            int v = item.First;
            if (vis[v] == 0)
            {
                TopoSort(v, adj, vis, st);
            }
        }
        st.Push(node);
    }

    public int[] ShortestPath(int N, int M, int[,] edges)
    {
        List<List<Pair>> adj = new List<List<Pair>>();
        for (int i = 0; i < N; i++)
        {
            List<Pair> temp = new List<Pair>();
            adj.Add(temp);
        }

        for (int i = 0; i < M; i++)
        {
            int u = edges[i, 0];
            int v = edges[i, 1];
            int wt = edges[i, 2];
            adj[u].Add(new Pair(v, wt));
        }

        int[] vis = new int[N];
        Stack<int> st = new Stack<int>();
        for (int i = 0; i < N; i++)
        {
            if (vis[i] == 0)
            {
                TopoSort(i, adj, vis, st);
            }
        }

        int[] dist = new int[N];
        for (int i = 0; i < N; i++)
        {
            dist[i] = int.MaxValue;
        }

        dist[0] = 0;
        while (st.Count > 0)
        {
            int node = st.Pop();

            foreach (var item in adj[node])
            {
                int v = item.First;
                int wt = item.Second;

                if (dist[node] + wt < dist[v])
                {
                    dist[v] = wt + dist[node];
                }
            }
        }

        for (int i = 0; i < N; i++)
        {
            if (dist[i] == int.MaxValue) dist[i] = -1;
        }
        return dist;
    }
}
