internal class Program
{
    private static void Main(string[] args)
    {
       Solution solution = new Solution();
        int ans=solution.LengthOfLongestSubstring("tmmzuxt");
    }
}
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int max = 0;
        int startIndx = 0;
        int endIndx = 0;
        var map=new Dictionary<char, int>();
        while(endIndx<s.Length )
        {
            int currentLength = endIndx - startIndx + 1;
            if (!map.ContainsKey(s[endIndx]))
            {
                map.Add(s[endIndx], endIndx);
                max=Math.Max(max, currentLength);
                endIndx++;

            }
            else
            {
                
                while (map.ContainsKey(s[endIndx]) && startIndx <= map[s[endIndx]])
                {
                    map.Remove(s[startIndx]);
                    startIndx++;
                }
                //startIndx;= map[s[endIndx]]+1;
                //for(int i=)
                map[s[endIndx]] = endIndx;
                endIndx++;

            }

        }
        return max;


    }
}