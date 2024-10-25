internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.MaximumLengthSubstring("bcbbbcba"));
    }
}
public class Solution
{
    public int MaximumLengthSubstring(string s)
    {
        int n = s.Length;
        int i = 0, j = 1;
        if (n <= 2) return n;
        int ans = 0;
        while (i < n - 1 && j < n)
        {
            string subs = s.Substring(i, j - i+1);
            if (isValid(subs))
            {
                ans = Math.Max(ans, j - i+1);
                j++;
            }
            else
            {
                j++;
                i++;
            }

        }
        return ans;


    }
    public bool isValid(string sub)
    {
        var freq = new int[26];
        for (int i = 0; i < sub.Length; i++)
        {
            freq[sub[i] - 'a']++;
        }
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] > 2) return false;
        }
        return true;
    }
}