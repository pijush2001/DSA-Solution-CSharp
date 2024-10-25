internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var ans = solution.EventualSafeNodes([[1, 2], [2, 3], [5], [0], [5], [], []]);
        Console.WriteLine("Hello, World!");
    }
}
public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n= graph.Length;  
        var ans=new List<int>();
        var indegree = new int[n];
        var bfsQ=new Queue<int>();
        var adj = new List<List<int>>(n);
        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>()); // Initialize each sublist with an empty list
        }
        for (int i = 0; i < n; i++)
        {

            indegree[i] = graph[i].Length;
            if (indegree[i]==0) bfsQ.Enqueue(i);

            //inserting into adj list
            for(int j=0; j < graph[i].Length; j++)
            {
                adj[graph[i][j]].Add(i);
            }
        }
        while (bfsQ.Count > 0)
        {
            int safeNode = bfsQ.Peek(); 
            ans.Add(safeNode);
            bfsQ.Dequeue();
            foreach(int node in adj[safeNode])
            {
                indegree[node]--;
                if (indegree[node]==0) bfsQ.Enqueue(node);
            }
        }
        ans.Sort();
        return ans;

    }
}