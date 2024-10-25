internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Solution solution = new Solution();
        Console.WriteLine(solution.LongestCommonSubsequence("abcde", "ace"));
    }





}

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n = text1.Length;
        int m = text2.Length;
        /*var dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1];
            for (int j = 0; j <= m; j++)
            {
                dp[i][j] = -1;
            }
        }

        return LCS(n-1, m-1, text1, text2, dp);*/
        var dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1];
            for (int j = 0; j <= m; j++)
            {
                if (i == 0)
                {
                    dp[i][j] = 0;
                }
                if (j == 0)
                {
                    dp[i][j] = 0;
                }
            }

        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (text1[i-1] == text2[j-1])
                {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                }
                else
                {
                    dp[i][j] = 0 + Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }
        return dp[n][m];
    }
    public int LCS(int idx1, int idx2, string text1, string text2, int[][] dp)
    {
        if (idx1 < 0 || idx2 < 0)
        {
            return 0;
        }
        if (dp[idx1][idx2] != -1) return dp[idx1][idx2];

        if (text1[idx1] == text2[idx2])
        {
            return dp[idx1][idx2] = 1 + LCS(idx1 - 1, idx2 - 1, text1, text2, dp);
        }
        return dp[idx1][idx2] = 0 + Math.Max(LCS(idx1 - 1, idx2, text1, text2, dp), LCS(idx1, idx2 - 1, text1, text2, dp));
    }
}