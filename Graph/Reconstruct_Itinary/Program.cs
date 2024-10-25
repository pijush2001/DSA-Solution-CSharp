internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        IList<string> res = solution.FindItinerary([["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]);
    }
}
public class Solution
{
    List<string> result = new List<string>();
    public IList<string> FindItinerary(IList<IList<string>> tickets)
    {
        int n= tickets.Count;
        Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();

        for(int i = 0; i < tickets.Count; i++)
        {
            if (!adj.ContainsKey(tickets[i][0]))
            {
                adj.Add(tickets[i][0],new List<string>(new string[] { tickets[i][1] }));
            }
            else
            {
                adj[tickets[i][0]].Add(tickets[i][1]);
                //adj[tickets[i][0]].Sort();
            }
        }
        foreach(var keyVal in adj)
        {
            keyVal.Value.Sort();
        }

        //DFS
        //List<string> result = new List<string>();
        List<string> path = new List<string>();


        DFS("JFK", path, adj, n);
        
        return result;
        



    }
    public bool DFS(string from_city, List<string> path, Dictionary<string, List<string>> adj,int n)
     {
        path.Add(from_city);
        if(path.Count == n + 1)
        {
            result = path;
            return true;
        }
        if (adj.ContainsKey(from_city))
        {
            List<string> neighbors = adj[from_city];

            for (int i = 0; i < neighbors.Count; i++)
            {
                string to_city = neighbors[i];
                neighbors.RemoveAt(i);
                if (DFS(to_city, path, adj, n))
                {
                    return true;
                }
                neighbors.Insert(i, to_city);

            }
        }
            path.Remove(from_city);
            return false;
        
    }
}