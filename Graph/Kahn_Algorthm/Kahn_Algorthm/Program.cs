internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
class Solution
{
    //Function to return list containing vertices in Topological order. 
    public List<int> topoSort(int V, List<List<int>> adj)
    {
        //code here
        var indegree = new int[V];
        for (int i = 0; i < V; i++)
        {
            foreach (var it in adj[i])
            {
                indegree[it]++;
            }
        }
        var bfsQ = new Queue<int>();
        //insert all the node which don't
        //have any dependency or simply indegree 0

        for (int i = 0; i < V; i++)
        {
            if (indegree[i] == 0)
            {
                bfsQ.Enqueue(i);
            }
        }

        List<int> topo = new List<int>();
        while (bfsQ.Count > 0)
        {
            //take the first element and
            //find how many dependency it creats
            int node = bfsQ.Peek();
            bfsQ.Dequeue();
            topo.Add(node);
            //the node is in your toposort
            //so please remove the indegree for this node
            foreach(var it in adj[node])
            {
                indegree[it]--;
                if (indegree[it] == 0) bfsQ.Enqueue(it);

            }
        }
        return topo;
    }
}