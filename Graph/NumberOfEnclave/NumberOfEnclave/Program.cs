internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        int[][] grid = [[0, 0, 0, 0], [1, 0, 1, 0], [0, 1, 1, 0], [0, 0, 0, 0]];
        Console.WriteLine(solution.NumEnclaves(grid));
    }
}
public class Solution
{
    public int NumEnclaves(int[][] board)
    {
        int n = board.Length;
        int m = board[0].Length;
        //i=0,j=0 to m
        var visited = new int[n][];
        for (int i = 0; i < n; i++)
        {
            visited[i] = new int[m];

        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if ((i == 0 || j == 0 || i == n - 1 || j == m - 1))
                {
                    if(board[i][j] == 1)
                    {
                        DFS(i, j, board, ref visited, n, m);

                    }
                    
                }     
            }
            
        }
        for(int  i = 0; i < n; i++)
        {
            for(int j=0;j< m; j++)
            {
                if (board[i][j]==1 && visited[i][j] ==0)
                {
                    ans++;
                }
            }
        }
        return ans;

    }
    public void DFS(int row, int col, int[][] grid, ref int[][] visited, int n, int m)
    {
        //visited[row][col] = 1;
        visited[row][col] = 1;

        var delRow = new int[] { -1, 1, 0, 0 };
        var delCol = new int[] { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int newRow = row + delRow[i];
            int newCol = col + delCol[i];
            

            if(newRow>=0 && newCol>=0 && newRow<n && newCol < m && visited[newRow][newCol]==0 && grid[newRow][newCol]==1)
            {
                DFS(newRow,newCol,grid, ref visited, n, m);
                
                
            }
         
        }
        


    }
}