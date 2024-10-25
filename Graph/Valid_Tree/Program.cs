using System.ComponentModel;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
public class Solution
{
    public bool ValidTree(int n, int[][] edges)
    {
        HashSet<int> visited = new HashSet<int>();
        int len = edges.Length;
        var adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>()); // Initialize each sublist with an empty list
        }
        for (int i = 0; i < len; i++)
        {
            adj[edges[i][0]].Add(edges[i][1]);
            adj[edges[i][1]].Add(edges[i][0]);
        }

        //check if any cycle detected or not
        var isConnected = DFSConnected(adj, visited,  0,-1); 
        if(!isConnected)
        {
            return false;
        }
        //check all node is visited
        if(visited.Count != n)
        {
            return false;
        }
        return true;



    }
    public bool DFSConnected(List<List<int>> adj,HashSet<int> visited,int start,int prev)
    {
        
            visited.Add(start);
            //count++;

            foreach (var node in adj[start])
            {
            if (node == prev) continue; // Skip the edge leading back to the parent
            if (visited.Contains(node)) return false; // Found a cycle
            if (!DFSConnected(adj, visited, node, start)) return false; // Recurse on neighbors

           }
        return true;
        
        

    }

    public int CountComponents(int n, int[][] edges)
    {
        HashSet<int> visited = new HashSet<int>();
        int len = edges.Length;
        var adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>()); // Initialize each sublist with an empty list
        }
        for (int i = 0; i < len; i++)
        {
            adj[edges[i][0]].Add(edges[i][1]);
            adj[edges[i][1]].Add(edges[i][0]);
        }
        int ans = 0;
        for(int i = 0;i < n; i++)
        {
            if (!visited.Contains(i))
            {
                DFSConnected(adj, visited, i);
                ans++;
            }
        }
        return ans;


    }
    public void DFSConnected(List<List<int>> adj, HashSet<int> visited, int start)
    {

        visited.Add(start);
        //count++;
       
        foreach (var node in adj[start])
        {
            if (!visited.Contains(node))
            {
                DFSConnected(adj, visited, node, start);
            }

        }
        return ;



    }
}