internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        solution.islandsAndTreasure([
  [2147483647, -1, 0, 2147483647],
            [2147483647, 2147483647, 2147483647, -1],
            [2147483647, -1, 2147483647, -1],
            [0, -1, 2147483647, 2147483647]
]);
    }
}
public class Solution
{
    public void islandsAndTreasure(int[][] grid)
    {
        int n = grid.Length;
        int m = grid[0].Length;
        var dp = new int[n][];

        Queue<(int,int)> q= new Queue<(int,int)> ();
        for(int i = 0; i < n; i++)
        {
            dp[i] = new int[m];
            for(int j = 0; j < m; j++)
            {
                if (grid[i][j] == 0)
                {
                    //start from every water and update every time
                    dp[i][j] = 0;
                    q.Enqueue((i, j));
                }

                else
                {
                    dp[i][j] = Int32.MaxValue ;
                }
            }
        }

        while (q.Count > 0)
        {
            var (row, col) = q.Dequeue();
            int[] delRow = { -1, 0, 1, 0 };
            int[] delCol = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {

                int newRow = row + delRow[i];
                int newCol = col + delCol[i];
                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < m)
                {
                    
                    if (grid[newRow][newCol] != -1 && dp[newRow][newCol] > dp[row][col] + 1)
                    {
                        dp[newRow][newCol] = dp[row][col] + 1;
                        q.Enqueue((newRow, newCol));
                    }
                }

            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (dp[i][j] == Int32.MaxValue)
                {
                    grid[i][j] = -1;
                }
                else
                grid[i][j] = dp[i][j];
            }
        }
    }
    public int DFS(int row, int col, int[][] grid, int[][] dp, int n, int m)
    {
        //if (grid[row][col] == 0) { return dp[row][col]; }
        if (dp[row][col] != Int32.MaxValue) return dp[row][col];
        int[] delRow = {-1, 0, 1, 0 };
        int[] delCol = {0, 1, 0, -1 };
       
        for(int i = 0; i<4; i++)
        {
            
                int newRow = row + delRow[i];
                int newCol = col + delCol[i];
                if(newRow>=0 && newRow< n && newCol>=0 && newCol < m)
                {
                    dp[row][col] = Math.Min(dp[row][col], DFS(newRow, newCol, grid, dp, n, m)+1);
                }
        }
        
        return dp[row][col];

    }
}