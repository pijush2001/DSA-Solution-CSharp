internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution(); 

        Console.WriteLine(solution.CanFinish(2, [[1, 0]]));
    }
}

public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        int count = 0;
        int n=prerequisites.Length;
        

        var indegree=new int[numCourses];
        var adj = new List<List<int>>(numCourses);
        for (int i = 0; i < numCourses; i++)
        {
            adj.Add(new List<int>()); // Initialize each sublist with an empty list
        }
        for (int i = 0; i < n; i++)
        {
            indegree[prerequisites[i][0]]++;
            //inserting into adj list
            adj[prerequisites[i][1]].Add(prerequisites[i][0]);
        }
        var bfsQ=new Queue<int>();
        for(int i = 0;i<numCourses;i++)
        {
            if (indegree[i] == 0)
            {
                bfsQ.Enqueue(i);
            }
        }
        //lets make adj list for better traversal
        
       

        while(bfsQ.Count > 0)
        {
            int node=bfsQ.Peek();
            bfsQ.Dequeue();
            count++;
            foreach(int i in adj[node])
            {
                indegree[i]--;
                if (indegree[i] == 0)
                {
                    bfsQ.Enqueue(i);
                }
            }
        }


        return count==numCourses? true: false;

    }
}