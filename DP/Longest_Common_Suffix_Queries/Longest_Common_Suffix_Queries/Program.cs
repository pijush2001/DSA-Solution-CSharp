internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] ans = solution.StringIndices(["abcd", "bcd", "xbcd"], ["cd", "bcd", "xyz"]);
        foreach (int i in ans)
        {
            Console.WriteLine(i +" ");
        }
    }
}
public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        int containerLength=wordsContainer.Length;
        int queryLength=wordsQuery.Length;
        var maxCommonSubstringIndex = new int[queryLength];
        //int maxCommonSubstring = 0;
        for (int i=0;i<queryLength;i++)
        {
            int m = wordsQuery[i].Length;
            var prevCommonSubstring = Int32.MinValue; 
            int prevContainerLength = Int32.MaxValue;
            

            //int maxLength = 0;
            for (int j=0;j<containerLength;j++)
            {
               
                int n = wordsContainer[j].Length;

                int maxLength= LongestCommonSuffix(wordsContainer[j], wordsQuery[i],n,m);
                if (maxLength > prevCommonSubstring || (maxLength == prevCommonSubstring && prevContainerLength > n))
                {
                    prevCommonSubstring = maxLength;
                    prevContainerLength = n;
                    maxCommonSubstringIndex[i] = j;

                }
                
            }
            
        }
        return maxCommonSubstringIndex;

    }

    public int LongestCommonSuffix(string text1, string text2,int n,int m)
    {
        int i=n-1, j=m-1;
        int maxSuffix = 0;
        while(i>=0 && j >= 0)
        {
            if (text1[i] == text2[j])
            {
                maxSuffix++;
                i--; j--;
            }
            else break;
        }
        return maxSuffix;
    }


    //it is the code for longest common substring
    public int longestCommonSubstr(string text1, string text2, int n, int m)
    {

        var dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1];
            for (int j = 0; j <= m; j++)
            {

                dp[i][j] = 0;

            }

        }
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                    ans = Math.Max(ans, dp[i][j]);
                }
                else
                {
                    dp[i][j] = 0;

                }
            }
        }
        return ans;
        //Your code here
    }


}
class Pair
{
    public int value;
    public int length;
    public Pair(int value, int length)
    {
        this.value = value;
        this.length = length;
    }
}

