internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int ans = solution.MinFlips([[0, 1], [0, 1], [0, 0]]);
    }
}

public class Solution
{
    private int Solve(int idx, int rem, int nx, List<List<int>> p, int[,] dp)
    {
        if (idx >= nx)
        {
            //if not possible to get 1s which are divisible by 4
            if (rem != 0) return (int)1e9;
            return 0;
        }
        if (dp[idx, rem] != -1) return dp[idx, rem];

        int option1 = (p[idx][0] - p[idx][1]) + Solve(idx + 1, (rem + p[idx][0]) % 4, nx, p, dp);
        int option2 = p[idx][1] + Solve(idx + 1, rem, nx, p, dp);

        dp[idx, rem] = Math.Min(option1, option2);
        return dp[idx, rem];
    }
    public int MinFlips(int[][] grid)
    {

        int n = grid.Length;
        int m = grid[0].Length;
        bool[,] vis = new bool[n, m]; // Visited cells tracker
        List<List<int>> p = new List<List<int>>();
        int count = 0;
        for (int i = 0; i <( n+1) / 2; i++)
        {
            for (int j = 0; j <( m +2)/ 2; j++)
            {
                if (vis[i, j]) continue; // Skip if already visited
                /*int a = grid[i][j];
                int b = grid[i][m - j - 1];
                int c = grid[n - i - 1][j];
                int d = grid[n - i - 1][m - j - 1];*/

                HashSet<Tuple<int, int>> s = new HashSet<Tuple<int, int>>();

                s.Add(Tuple.Create(i, j));
                s.Add(Tuple.Create(i, m - j - 1));
                s.Add(Tuple.Create(n - i - 1, j));
                s.Add(Tuple.Create(n - i - 1, m - j - 1));

                int cnt = 0;
                foreach (var item in s)
                {
                    cnt += grid[item.Item1][item.Item2];
                }
                int total = s.Count;
                //total= in which subset it is: 4 or 2 or 1
                //because only 3 set can be formed
                //4-> when all the row and column exists separately
                p.Add(new List<int> { total, cnt });


            }
        }
        int nx = p.Count;
        int[,] dp = new int[nx, 4];
        for (int i = 0; i < nx; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                dp[i, j] = -1;
            }
        }

        return Solve(0, 0, nx, p, dp);
        //return count;

    }
} 