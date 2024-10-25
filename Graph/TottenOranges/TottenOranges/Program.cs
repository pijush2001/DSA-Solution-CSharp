internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.OrangesRotting([[0, 2]]));
    }
}
public class Solution
{
    public int OrangesRotting(int[][] grid)
    {

        Queue<Pair > bfsQ = new Queue<Pair>();
        int n=grid.Length;
        int m = grid[0].Length;
        int rottenRow = 0;
        int rottenCol = 0;
        int ans = 0;
        var isAnythingRotten = false;
        var isGood = false;

        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if (grid[i][j] == 2)
                {
                    rottenRow = i;
                    rottenCol = j;
                    isAnythingRotten = true;
                   

                }
                if (grid[i][j] == 1)
                {
                    isGood = true;
                }
            }
        }
        if (!isGood) { return 0; }
        if (!isAnythingRotten) { return -1; }
       
        int[] delRow = { -1, 0, 1, 0 };
        int[] delCol = { 0, 1, 0, -1 };
        bfsQ.Enqueue(new Pair(rottenRow,rottenCol));
        var height = new int[n][];
        for(int i = 0; i < n; i++)
        {
            height[i]= new int[m];
            for(int j = 0;j< m; j++)
            {
                height[i][j] = 0;
            }
        }
        int maxHeight = 0;

        var rottentOrange=grid.Select(a => a.ToArray()).ToArray();

        while (bfsQ.Count > 0)
        {
            int row = bfsQ.Peek().row;
            int col = bfsQ.Peek().col;
            bfsQ.Dequeue();
            for(int i = 0; i < 4; i++)
            {
                int newRow=row + delRow[i];
                int newCol=col + delCol[i];
                if (newRow>=0 && newRow<n && newCol>=0 && newCol<m && grid[newRow][newCol]==1 && rottentOrange[newRow][newCol] != 2)
                {
                    height[newRow][newCol] = height[row][col]+1;
                    maxHeight = Math.Max(height[newRow][newCol], maxHeight);
                    rottentOrange[newRow][newCol] = 2;
                    bfsQ.Enqueue(new Pair(newRow, newCol));
                }

            }

        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (rottentOrange[i][j] == 1)
                {
                    return -1;

                }
            }
        }


        return maxHeight;

    }
}
public class Pair
{
    public int row;
    public int col;
    public Pair(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}