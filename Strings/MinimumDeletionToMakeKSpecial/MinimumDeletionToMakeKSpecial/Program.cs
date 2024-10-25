internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MinimumDeletions("dabdcbdcdcd", 2));
        
    }
}

public class Solution
{
    public int MinimumDeletions(string word, int k)
    {
        var freq=new int[26];
        for(int i = 0; i < word.Length; i++)
        {
            freq[word[i]- 'a']++;
        }
        
        //int diff=maxFreq-minFreq;
        var currentFreq =(freq.Where((x) => x != 0).ToArray());
        Array.Sort(currentFreq);
        /*int minDiff = Int32.MaxValue;
        int maxFreq = currentFreq[currentFreq.Length-1];
        
        for (int i = 0; i < currentFreq.Length; i++)
        {
            int diffByDeletingMax = currentFreq[currentFreq.Length-1] - currentFreq[i];
            int ansByDeletingMax = Int32.MaxValue;
            int ansByDeletingMin = Int32.MaxValue;
            if (i!=currentFreq.Length-1 && maxFreq - currentFreq[i + 1] <= k)
            {
                ansByDeletingMin = currentFreq[i];
            }

            if (diffByDeletingMax - k > 0)
            {
                ansByDeletingMax = diffByDeletingMax - k;

            }
            minDiff=Math.Min(minDiff,Math.Min(ansByDeletingMin,ansByDeletingMax));


        }*/
        int n = currentFreq.Length;
        var dp=new int[n][];
        for(int i = 0; i < n; i++)
        {
            dp[i]=new int[n];
            for(int j = 0; j < n; j++)
            {
                dp[i][j] = -1;
            }
        }

        return Solve(0, currentFreq.Length - 1, currentFreq,ref dp,k);
        
        
       


    }
    public int Solve(int i, int j,int[] freq, ref int[][] dp,int k)
    {
        if (i == j || freq[j] - freq[i] <= k) return 0;

        if (dp[i][j]!=-1) return dp[i][j];

        return dp[i][j] = Math.Min(freq[i] + Solve(i + 1, j , freq, ref dp, k),
            freq[j] - freq[i] - k + Solve(i , j - 1, freq, ref dp, k)
            );
    }
}