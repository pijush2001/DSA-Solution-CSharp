internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
       var ans= solution.CountPaths(7, [[0, 6, 7], [0, 1, 2], [1, 2, 3], [1, 3, 3], [6, 3, 3], [3, 5, 1], [6, 5, 1], [2, 5, 1], [0, 4, 5], [4, 6, 2]]);
        Console.WriteLine(ans);
    }
}

public class Pair : IComparable<Pair>
{
    public int Node { get; set; }
    public long Distance { get; set; }
    public Pair(long distance, int node) { Node = node; Distance = distance; }
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

public class Solution
{
    public int CountPaths(int n, int[][] roads)
    {
        var ways=new int[n];

        ways[0] = 1;
        var dist=new long[n];
        SortedSet<Pair> pq = new SortedSet<Pair>();
        for (int i = 0; i <n; i++)
        {
            dist[i] = Int64.MaxValue ;
        }
        dist[0] = 1;

        var adjRoads = new List<List<Tuple<int, long>>>();
        for (int i = 0; i < n; i++)
        {
            adjRoads.Add(new List<Tuple<int, long>>());
        }
        for (int i = 0; i < roads.Length; i++)
        {
            adjRoads[roads[i][0]].Add(Tuple.Create(roads[i][1], Convert.ToInt64(roads[i][2])));
            adjRoads[roads[i][1]].Add(Tuple.Create(roads[i][0], Convert.ToInt64(roads[i][2])));
        }
        pq.Add(new Pair(0, 0));
        var mod = (int)(1e9 + 7);
        while (pq.Count > 0)
        {
            var pairInfo = pq.Min();
            pq.Remove(pairInfo);
            var node = pairInfo.Node;
            var distance = pairInfo.Distance;
            foreach(var nodeInfo in adjRoads[node])
            {
                var currentNode = nodeInfo.Item1;
                var currentDistance = nodeInfo.Item2;
                if(distance+currentDistance < dist[currentNode])
                {
                    if(pq.Contains(new Pair(dist[currentNode], currentNode)))
                    {
                        pq.Remove(new Pair(dist[currentNode], currentNode));
                    }
                    ways[currentNode] = ways[node];
                    dist[currentNode] = distance+currentDistance;
                    pq.Add(new Pair(dist[currentNode], currentNode));
                }
                else if(distance+currentDistance == dist[currentNode])
                {
                    ways[currentNode] = (ways[currentNode] + ways[node])%mod;
                }
            }

        }



        return ways[ways.Length-1]%mod;

    }
}