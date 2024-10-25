internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        var floodColor = solution.FloodFill([[1, 1, 1], [1, 1, 0], [1, 0, 1]],1,1,2);
        Console.WriteLine();
    }
}
public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var ans= image.Select(a => a.ToArray()).ToArray();
        int iniColor = image[sr][sc];
        int n=image.Length;
        int m = image[0].Length;
        int[] delRow = { -1, 0, 1, 0 };
        int[] delCol = { 0, 1, 0, -1 };

        DFS(sr,sc,image, ref ans, iniColor, color, delRow, delCol);



        return ans;

    }

    public void DFS(int row,int col,int[][] image,ref int[][] ans,int iniColor,int color, int[] delRow, int[] delCol)
    {
        ans[row][col] = color;
        int n = image.Length;
        int m= image[0].Length; 

        for(int i = 0; i < 4; i++)
        {
            int newRow = row + delRow[i];
            int newCol = col + delCol[i];
            if(newRow>=0 && newRow<n && newCol>=0 && newCol<m &&  image[newRow][newCol]==iniColor && ans[newRow][newCol] != color)
            {
                DFS(newRow,newCol,image,ref ans, iniColor, color,delRow,delCol);
            }
        }

    }
}