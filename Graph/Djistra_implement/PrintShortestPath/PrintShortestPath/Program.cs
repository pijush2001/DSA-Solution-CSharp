using System;
using System.Collections.Generic;

/*public class Task : IComparable<Task>
{
    public string Name { get; set; }
    public int Priority { get; set; }

    public int CompareTo(Task other)
    {
        return Priority.CompareTo(other.Priority);
    }
}*/
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
class Solution
{
    //Complete this function
    //Function to find the shortest distance of all the vertices
    //from the source vertex S.
    public List<int> dijkstra(int V, List<List<int>>[] adj, int S)
    {

        // Code here
        SortedSet<Pair> pq = new SortedSet<Pair>();
        int[] dist = new int[V+1];
        int[] parent = new int[V+1];
        for(int i = 1; i <=V; i++)
        {
            parent[i] = i;
        }
        for (int i = 1; i <= V; i++)
        {
            dist[i] = (int)1e9;
        }
        dist[S] = 0;
        pq.Add(new Pair(0, S));

        while (pq.Count > 0)
        {
            Pair currPair = pq.Min();
            pq.Remove(currPair);
            int currDist = currPair.Distance;
            int currNode = currPair.Node;
            //for zero based index but node starts from 1
            foreach (var adjNode in adj[currNode-1])
            {
                int adjDist = adjNode[1];
                int adjND = adjNode[0];
                if (currDist + adjDist < dist[adjND])
                {
                    //adding the previous node from where it is comming from 
                    parent[adjND] = currNode;
                    dist[adjND] = currDist + adjDist;
                    pq.Add(new Pair(dist[adjND], adjND));
                }
            }
            
        }

        List<int> ans = new List<int>();
        ans.Add(V);
        for (int i = V ; i >= 1;)
        {
            var prevNode = parent[i];
            i = prevNode;
            ans.Add(prevNode);
            if (prevNode == 1) break;
        }
        ans.Reverse();
        return dist.ToList();
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        //SortedSet<Pair> pq = new SortedSet<Pair>();
        /*priorityQueue.Enqueue(new Task { Name = "Task A", Priority = 3 },1);
    priorityQueue.Enqueue(new Task { Name = "Task B", Priority = 2 },5);
    priorityQueue.Enqueue(new Task { Name = "Task C", Priority = 1 },3);

    while (priorityQueue.Count > 0)
    {
        var task = priorityQueue.Dequeue();
        Console.WriteLine("Executing task: {0}", task.Name);
    }*/
        Solution solution = new Solution();
        var ans = solution.dijkstra(5,
            [
                [[2,2], [4, 1]],
                [[1,2], [3, 4],[5,5]],
                [[2,4], [5,1],[4,3]],
                [[1,1], [3, 3]],
                [[3,1],[2,5]]
            ]
, 1);

    }
}
