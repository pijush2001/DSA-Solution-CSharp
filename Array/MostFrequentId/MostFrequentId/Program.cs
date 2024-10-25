internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        var ans = solution.MostFrequentIDs([2, 3, 2, 1], [3, 2, -3, 1]);
        for(int i = 0; i < ans.Length; i++)
        {
            Console.Write(ans[i] +" ");
        }
        Console.WriteLine();
    }
}
public class Solution
{
    public long[] MostFrequentIDs(int[] nums, int[] freq)
    {
        long maxCount = 0;
        var newFreq = new long[100000+1];
        var ans = new long[nums.Length];
        for (int i = 0; i < freq.Length; i++)
        {
            newFreq[nums[i]] += freq[i];
            maxCount = newFreq.Max();
            ans[i] = maxCount;
        }
        return ans;


    }
}