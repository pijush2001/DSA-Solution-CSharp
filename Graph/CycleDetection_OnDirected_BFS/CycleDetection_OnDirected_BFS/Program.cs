internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
class Solution
{
    //Complete this function
    //Function to detect cycle in a directed graph.
    public bool isCyclic(int V, List<int>[] adj)
    {
        var indegree = new int[V];
        for (int i = 0; i < V; i++)
        {
            foreach (var it in adj[i])
            {
                indegree[it]++;
            }
        }
        var qBFS = new Queue<int>();

        int toposortCnt = 0;

        for (int i = 0; i < V; i++)
        {
            if (indegree[i] == 0)
            {
                qBFS.Enqueue(i);
            }
        }

        while (qBFS.Count > 0)
        {
            int node=qBFS.Peek();
            qBFS.Dequeue();
            toposortCnt++;
            foreach (var it in adj[node])
            {
                indegree[it]--;
                if (indegree[it] == 0)
                {
                    qBFS.Enqueue(it);
                }
            }
            
        }
        return toposortCnt == V ? false : true;


        //Your code here
    }
}