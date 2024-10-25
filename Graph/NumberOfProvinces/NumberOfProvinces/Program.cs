internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Solution.FindCircleNum([[1, 0, 0], [0, 1, 0], [0, 0, 1]]));
    }
}

public  class Solution
{
    public static int FindCircleNum(int[][] isConnected)
    {
        int n=isConnected.Length;
        int circle = 0;
        var visited=new int[n];
        for (int i = 0; i < n; i++)
        {
            
            if (!isConnected[i].Where(x => x!=i && x == 1).Any())
            {
                circle++;
            }
            else
            {

                if (visited[i] == 0)
                {

                    Circle(i, isConnected, ref visited);
                    
                }
                circle++;

            }

        }




        return circle;
    }
    public static void Circle(int node, int[][] isConnected,ref int[] visited)
    {
        if (visited[node] == 0)
        {
            visited[node] = 1;
            foreach(int i in isConnected[node])
            {
                Circle(i, isConnected, ref visited);

            }
            
        }
        return ;

        
    }
}