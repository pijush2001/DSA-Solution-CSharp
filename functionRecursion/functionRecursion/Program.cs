using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution solution = new Solution();
       //var grid =new int[{ 1, 1, 1}, { 1, 0, 1}, { 1, 1, 1}]
        Console.WriteLine(solution.Largest1BorderedSquare([[1, 1, 1], [1, 0, 1], [1, 1, 1]]));
    }
}
public class Solution
{
    public int Largest1BorderedSquare(int[][] grid)
    {

        int n = grid.Length;
        int m = grid[0].Length;

        var pairs = new Cell[n][];
        for(int i = 0; i < n; i++)
        {
            pairs[i] = new Cell[m];
            for(int j = 0; j < m; j++)
            {
                pairs[i][j] = new Cell();
            }

        }
        bool isAllZero = true;
        for (int i = 0; i < pairs.Length; i++)
        {
            for (int j = 0; j < pairs[0].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    isAllZero= false;
                    if (i == 0 && j == 0)
                    {
                        pairs[i][j].hori = 1;
                        pairs[i][j].ver = 1;
                    }
                    else if (i == 0)
                    {
                        pairs[i][j].hori = pairs[i][j - 1].hori + 1;
                        pairs[i][j].ver = 1;
                    }
                    else if (j == 0)
                    {
                        pairs[i][j].ver = pairs[i - 1][j].ver + 1;
                        pairs[i][j].hori = 1;
                    }
                    else
                    {
                        pairs[i][j].hori = pairs[i][j - 1].hori + 1;
                        pairs[i][j].ver = pairs[i - 1][j].ver + 1;
                    }
                }
            }
        }
        if (isAllZero) return 0;

        //start iterating from bottom right corner and find min of hori or ver at every cell.
        //If this is greater than 1 then see if you can find a number between this min and 1
        //such that on left's ver and top's hori is greater greater than or equal to k.
        int max = 1;
        for (int i = pairs.Length - 1; i >= 0; i--)
        {
            for (int j = pairs[0].Length - 1; j >= 0; j--)
            {
                if (pairs[i][j].ver == 0 || pairs[i][j].ver == 1 || pairs[i][j].hori == 1)
                {
                    continue;
                }
                int min = Math.Min(pairs[i][j].ver, pairs[i][j].hori);
                int k = 0;
                for (k = min; k > 1; k--)
                {
                    if (pairs[i][j - k + 1].ver >= k && pairs[i - k + 1][j].hori >= k)
                    {
                        break;
                    }
                }
                if (max < k)
                {
                    max = k;
                }
            }
        }
        return max * max;



    }

}
public class Cell
{
   public int ver;
   public int hori;
}