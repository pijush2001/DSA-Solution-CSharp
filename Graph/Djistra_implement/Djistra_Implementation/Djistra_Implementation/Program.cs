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
public class Pair:IComparable<Pair>
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
    public List<int> dijkstraUsingSortedSet(int V, List<List<int>>[] adj, int S)
    {
        
        // Code here
        SortedSet<Pair> pq = new SortedSet<Pair>();
        int[] dist = new int[V];
        for(int i=0;i< V; i++)
        {
            dist[i] = (int)1e9;
        }
        dist[S]= 0;
        pq.Add(new Pair(0, S));

        while(pq.Count>0)
        {
            Pair currPair = pq.Min();
            pq.Remove(currPair);
            int currDist = currPair.Distance;
            int currNode=currPair.Node;
            foreach(var adjNode in adj[currNode])
            {
                int adjDist = adjNode[1];
                int adjND = adjNode[0];
                if (currDist + adjDist < dist[adjND])
                {
                    dist[adjND] = currDist + adjDist;
                    pq.Add(new Pair(dist[adjND], adjND));
                }
            }
        }
        return dist.ToList();
    }

    public List<int> dijkstraUsingPriorityQueue(int V, List<List<int>>[] adj, int S)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        int[] dist = new int[V];
        for (int i = 0; i < V; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[S] = 0;

        pq.Enqueue(S, 0);
        while(pq.Count>0)
        {
            int currentNode = pq.Dequeue();

            int currentDistance = dist[currentNode];

            foreach(var adjNode in adj[currentNode])
            {
                int adjDist = adjNode[1];
                int adjND = adjNode[0];

                if(currentNode + adjDist < dist[adjND])
                {
                    dist[adjND] = currentDistance + adjDist;
                    pq.Enqueue(adjND, dist[adjND]);
                }
            }

        }
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
        var ans=solution.dijkstraUsingPriorityQueue(4, 
            [
            [[1, 9], [2, 1], [3, 1]],
            [[0, 9], [3, 3]],
            [[0, 1], [3, 2]],
            [[0, 1], [1, 3], [2, 2]]
            ]
, 0);
        var ans1 = solution.dijkstraUsingSortedSet(4,
            [
            [[1, 9], [2, 1], [3, 1]],
                [[0, 9], [3, 3]],
                [[0, 1], [3, 2]],
                [[0, 1], [1, 3], [2, 2]]
            ]
, 0);


    }
}
