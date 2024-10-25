internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.NumIslands([
  ["1", "1", "0", "0", "0"],
            ["1", "1", "0", "0", "0"],
            ["0", "0", "1", "0", "0"],
            ["0", "0", "0", "1", "1"]
]));
    }
}
public class Solution
{
    public int NumIslands(string[][] grid)
    {
        int n = grid.Length ;
        int m = grid[0].Length;

        var visited = new int[n][];
        for(int i=0; i<n; i++)
        {
            visited[i]=new int[m];
            for(int j=0; j < m; j++)
            {
                visited[i][j] = 0;
            }
        }
        
        int count = 0;

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if (visited[i][j]==0 && grid[i][j]=="1")
                {
                    count++;
                    visited[i][j] = 1;
                    BFS(i, j, grid,ref visited);


                }
            }
        }
        return count;


    }

    public void BFS(int row,int col, string[][] grid,ref int[][] visited)
    {
        Queue<Pair> bfsQueue = new Queue<Pair>();
        int n = grid.Length;
        int m = grid[0].Length;

        bfsQueue.Enqueue(new Pair(row,col));
        //traverse through all the four side
        while(bfsQueue.Count   > 0)
        {
             row=bfsQueue.Peek().row; col=bfsQueue.Peek().col;
            bfsQueue.Dequeue();

            if (row - 1 >= 0)
            {
                var up = grid[row - 1][col];
                if(up=="1" && visited[row - 1][col] == 0)
                {
                    bfsQueue.Enqueue(new Pair(row - 1, col));
                    visited[row - 1][col] = 1;
                }
                


            }
            if (row + 1 < n)
            {
                var down = grid[row + 1][col];
                if (down == "1" && visited[row + 1][col] == 0)
                {
                    visited[row + 1][col] = 1;
                    bfsQueue.Enqueue(new Pair(row + 1, col));
                }
                

            }
            if(col-1 >= 0)
            {
                var left = grid[row][col - 1];
                if (left == "1" && visited[row ][col - 1] == 0)
                {
                    bfsQueue.Enqueue(new Pair(row, col - 1));
                    visited[row ][col - 1] = 1;
                }
                
            }
            if(col+1 < m)
            {
                var right = grid[row][col + 1];
                if (right == "1" && visited[row ][col+1] == 0)
                {
                    bfsQueue.Enqueue(new Pair(row, col + 1));
                    visited[row ][col+1] = 1;
                }
                

            }

           
            
            
            


        }
        


    }
    
}
public class Pair{
    public int row;
    public int col;
    public Pair(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
}