internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var ans=solution.FindCheapestPrice(5, [[1, 2, 10], [2, 0, 7], [1, 3, 8], [4, 0, 10], [3, 4, 2], [4, 2, 10], [0, 3, 3], [3, 1, 6], [2, 4, 5]], 0, 4, 1);
        Console.WriteLine(ans);
        
    }
}
public class Solution
{
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        var adjFlights=new List<List<Tuple<int, int>>>();
        for(int i=0;i<n;i++)
        {
            adjFlights.Add(new List<Tuple<int, int>>());
        }
        for(int i=0;i<flights.Length; i++)
        {
            adjFlights[flights[i][0]].Add(Tuple.Create(flights[i][1], flights[i][2]));   
        }
        var normalQue=new Queue<Tuple<int, int,int>>();
        var cost=new int[n];
        for(int i = 0; i < n; i++)
        {
            cost[i] = (int)(1e9);
        }
        cost[src] = 0;
        normalQue.Enqueue(Tuple.Create(0,src,0));//(stoppage,node,cost)
        while(normalQue.Count > 0)
        {
            var tupleValue=normalQue.Dequeue();
            var stop = tupleValue.Item1;
            var node=tupleValue.Item2;
            var cst=tupleValue.Item3;
            if (stop > k) continue;
            foreach(var nodeInfo in adjFlights[node])
            {
                var currentNode = nodeInfo.Item1;
                var currentCost=nodeInfo.Item2;
                if (currentNode == dst && stop + 1 <= k + 1 && currentCost + cst < cost[dst])
                {
                    cost[dst] = currentCost + cst;
                    normalQue.Enqueue(Tuple.Create(stop + 1, dst, cost[dst]));
                }
                else if (currentNode != dst && stop + 1 == k + 1)
                {
                    continue;
                }
                else if (currentNode != dst && currentCost + cst < cost[currentNode])
                {
                    cost[currentNode] = currentCost + cst;
                    normalQue.Enqueue(Tuple.Create(stop + 1, currentNode, cost[currentNode]));
                }
                else { continue; }
            }

        }
        if (cost[dst] == (int)(1e9)) return -1;
        return cost[dst];

    }
}