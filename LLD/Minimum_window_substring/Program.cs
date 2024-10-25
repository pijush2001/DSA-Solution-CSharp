internal class Program
{
    private static void Main(string[] args)
    {
        Solution solution = new Solution();
        string str= solution.MinWindow("ADOBECODEBANC", "ABC");
    }
}
public class Solution
{
    public string MinWindow(string s, string t)
    {
        int minLength = (int)10e7;
        int[] hash =new int[256];
        int start = 0, end = 0, count = 0, startIndex = -1;

        for(int i=0;i<t.Length;i++)
        {
            hash[t[i]]++;
        }
        while(end< s.Length)
        {
            if (hash[s[end]] > 0)
            {
                count ++;
                hash[s[end]]--;
            }
            while(count == t.Length)
            {
                if(end-start +1 < minLength)
                {
                    minLength = end - start + 1;
                    startIndex = start;
                }
                hash[s[start]]++;
                if (hash[s[start]] > 0)
                {
                    count--;
                }
                start++;
            }
            end++;
        }

        return minLength == -1 ? "" : s.Substring(startIndex, minLength);

    }
}