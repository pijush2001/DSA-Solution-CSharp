internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();

        Console.WriteLine(solution.UpdateMatrix([[0, 0, 0], [0, 1, 0], [1, 1, 1]]));
    }
}
public class Solution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        int n=mat.Length;
        int m = mat[0].Length;  
        var ans=new int[n][];
        for(int i=0; i<n; i++)
        {
            ans[i]=new int[m];
        }

        for(int i=0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if (mat[i][j] == 1)
                {
                    ans[i][j]=Update(i, j, mat, ref ans,n,m);
                }
                else
                {
                    ans[i][j] = 0;
                }
                
            }
            
        }
        string s = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                s+=ans[i][j] +" ";
            }
            s += "\n";
        }
        Console.WriteLine(s);

                return ans;

    }
    public int Update(int i,int j, int[][] mat,ref int[][] ans,int n,int m)
    {

        /*var distance=new Queue<Pair>();

        distance.Enqueue(new Pair(i, j));
        while(distance.Count > 0)
        {
            //

        }*/
        if (mat[i][j]==0 || i<0 ||j<0 ||i>=n ||j>=m)
        {
            return 0;
        }

        var delRow =new int[] { 0, 0, -1, 1 };
        var delCol = new int[] { -1, 1, 0, 0 };
        int minDistance = Int32.MaxValue;
        for(int k = 0; k < 4; k++)
        {
            int newRow = i + delRow[k];
            int newCol = j + delCol[k];
            if(newRow>=0 && newCol>=0 && newRow<n && newCol < m)
            {
                return minDistance = Math.Min(minDistance, 1+Update(newRow, newCol, mat, ref ans, n, m));
            }
            /*else
            {
                return 0;
            }*/
        }
        return minDistance;



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