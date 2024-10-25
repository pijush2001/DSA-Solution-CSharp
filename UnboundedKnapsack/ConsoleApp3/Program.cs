internal class Program
{
    private static void Main(string[] args)
    {
        //string[] strs = { "10", "0001", "111001", "1", "0" };
        //int m = 5, n = 3;
        //Console.WriteLine(FindMaxForm(strs,m,n));
        //var nums = new int[] { 3, 2, 3 };
        //Console.WriteLine(MajorityElement(nums));
        int[] profit = new int[] { 5, 4, 8 ,9, 1 ,6, 3, 2, 7, 10 }; // Profits of items
        int[] weight = new int[] { 5, 6, 3 ,4, 1, 2, 10 ,7, 8 ,9 }; // Weights of items
        int n = 10, w = 4;
        int maxProfit = UnboundedKnapsack(n, w, profit, weight);
        Console.WriteLine("Maximum profit that can be obtained: " + maxProfit);

    }
    public static int UnboundedKnapsack(int n, int w, int[] profit, int[] weight)
    {
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[w + 1];
            for (int j = 0; j < w + 1; j++)
            {
                dp[i][j] = -1;
            }
        }
        return Knapsack(n - 1, w, profit, weight, dp);
    }

    public static int Knapsack(int idx, int w, int[] profit, int[] weight, int[][] dp)
    {
        if (idx == 0)
        {
            return (int)(w / weight[0]) * profit[0];
        }
        if (dp[idx][w] != -1) return dp[idx][w];

        int notTake = 0 + Knapsack(idx - 1, w, profit, weight, dp);
        int take = int.MinValue;
        if (weight[idx] <= w)
            take = profit[idx] + Knapsack(idx, w - weight[idx], profit, weight, dp);

        return dp[idx][w] = Math.Max(take, notTake);
    }
    public static int MajorityElement(int[] nums)
    {
        int n = nums.Length;
        int max = nums.Max();
        Console.WriteLine(max);
        var count = new int[max + 1];

        for (int i = 0; i < n; i++)
        {
            count[nums[i]]++;
        }
        return count[max];

    }
    public static int FindMaxForm(string[] strs, int m, int n)
    {
        int len = strs.Length;

        var dp = new int[len][][];
        for (int i = 0; i < len; i++)
        {
            dp[i] = new int[m + 1][];
            for (int j = 0; j <= m; j++)
            {
                dp[i][j] = new int[n+1];
                for (int k = 0; k <= n; k++)
                {
                    dp[i][j][k] = -1;
                }

            }
        }

        return FindMax(len - 1, m, n, strs, ref dp);

    }
    public static int FindMax(int idx, int m, int n, string[] strs, ref int[][][] dp)
    {
       // if (m == 0 && n == 0) return 1;
        if (idx == 0)
        {
            int mCount = strs[0].Where(s => s=='0').Count();
            int nCount = strs[0].Where(s => s=='1').Count();
            if (mCount<=m && nCount <= n)
            {
                return 1;
            }
            return 0;
        }

        if (dp[idx][m][n] != -1) return dp[idx][m][n];

        int notTake = 0 + FindMax(idx - 1, m, n, strs, ref dp);
        int take = Int32.MinValue;
        int mCnt = strs[idx].Where(s => s == '0').Count();
        int nCnt = strs[idx].Where(s => s == '1').Count();
        if(mCnt<=m && nCnt <= n)
        {
            take=1+FindMax(idx-1,m-mCnt,n-nCnt, strs, ref dp);
        }

       return  dp[idx][m][n] = Math.Max(take, notTake);





    }
}